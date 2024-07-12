using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerce.Service;
using ECommerceWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(
            IUnitOfWork unitOfWork,
            UserManager<IdentityUser> userManager
            )
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public IActionResult Index(PaginatedRequest request)
        {
            PaginatedResult<Product> result = _unitOfWork.Product.GetPaginated(
                request.PageNumber,
                PaginatedRequest.ITEMS_PER_PAGE,
                product => 
                    product.Name.Contains(request.SearchKeyword ?? string.Empty) || 
                    (   
                        product.Category != null && 
                        product.Category.Any(c => c.Category.Name.ToLower().Contains(request.SearchKeyword ?? string.Empty))
                    )
                );
            
            result.SearchKeyword = request.SearchKeyword;

            return View(result);
        }

        public IActionResult Details(int prodId)
        {
            Cart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.Id == prodId, nameof(Category)),
                Quantity = 1,
                ProductId = prodId
            };

            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(Cart cart)
        {
            string? userId = _userManager.GetUserId(User);

            if(!string.IsNullOrEmpty(userId))
            {
                cart.OwnerId = userId;

                Cart cartFromDb = _unitOfWork.Cart.Get(u => u.OwnerId == userId && u.ProductId == cart.ProductId);

                if (cartFromDb != null)
                {
                    cartFromDb.Quantity += cart.Quantity;
                    _unitOfWork.Cart.Update(cartFromDb);
                }
                else
                {
                    _unitOfWork.Cart.Add(cart);
                }

                _unitOfWork.Save();
                var result = _unitOfWork.Cart.GetAll().Where(c => c.OwnerId == userId).Count();
                HttpContext.Session.SetInt32(SD.SessionCart, result);
                TempData["success"] = "Item added to cart.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

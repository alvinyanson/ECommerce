using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerce.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.Areas.Customer.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public CartController(
            UserManager<IdentityUser> userManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string? userId = _userManager.GetUserId(User);

            IEnumerable<Cart> result = _unitOfWork.Cart.GetAll(nameof(Product)).Where(u => u.OwnerId == userId);

            CartVM cartVM = new CartVM()
            {
                Cart = result
            };

            foreach (var cart in cartVM.Cart)
            {
                cartVM.OrderTotal += (cart.Product.Price * cart.Quantity);
            }

            return View(cartVM);
        }

        public IActionResult Plus(int cartId)
        {
            var cartFromDb = _unitOfWork.Cart.Get(u => u.Id == cartId);
            cartFromDb.Quantity += 1;

            _unitOfWork.Cart.Update(cartFromDb);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int cartId)
        {
            var cartFromDb = _unitOfWork.Cart.Get(u => u.Id == cartId);
            if(cartFromDb.Quantity <= 1)
            {
                _unitOfWork.Cart.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Quantity -= 1;
                _unitOfWork.Cart.Update(cartFromDb);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId) 
        {
            var cartFromDb = _unitOfWork.Cart.Get(u => u.Id == cartId);

            if (cartFromDb != null)
            {
                _unitOfWork.Cart.Remove(cartFromDb);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        public IActionResult Checkout()
        {
            string? userId = _userManager.GetUserId(User);

            var cartFromDb = _unitOfWork.Cart.GetAll().Where(u => u.OwnerId == userId);

            _unitOfWork.Cart.RemoveRange(cartFromDb);
            _unitOfWork.Save();

            TempData["success"] = "Checkout success";

            return RedirectToAction("Index", "Home");
        }

    }
}

using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerceWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public IActionResult Index(string? query)
        {
            if(query != null)
            {
                IEnumerable<Product> products = _unitOfWork.Product.Search(query);
                return View(products);
            }
            else
            {
                //IEnumerable<Product> products = _unitOfWork.Product.GetAll("Category");
                IEnumerable<Product> products = _unitOfWork.Product.GetAll();

                return View(products);
            }
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Search(String? query)
        {
            return RedirectToAction("Index", new {query = "Air"});
        }


        [HttpPost]
        [Authorize]
        public IActionResult Details(Cart cart)
        {
            string? userId = _userManager.GetUserId(User);
            cart.OwnerId = userId;

            Cart cartFromDb = _unitOfWork.Cart.Get(u => u.OwnerId == userId && u.ProductId == cart.ProductId);

            if(cartFromDb != null)
            {
                // shopping cart exist
                cartFromDb.Quantity += cart.Quantity;
                _unitOfWork.Cart.Update(cart);
            }
            else
            {
                // shopping cart does not exist
                _unitOfWork.Cart.Add(cart);
            }

            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}

using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.Areas.Customer.Controllers
{
    public class ShopController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ShopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Cart> CartItems = _unitOfWork.Cart.GetAll("CartItems");

            return View(CartItems);
        }


    }
}

using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.Areas.Customer.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}

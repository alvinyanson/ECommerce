using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerceWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerceWeb.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public IActionResult Details(int? id)
        {
            //Product product = _unitOfWork.Product.Get(u => u.Id == id, "Category");
            Product product = _unitOfWork.Product.Get(u => u.Id == id);

            return View(product);
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
    }
}

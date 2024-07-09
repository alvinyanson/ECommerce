using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerce.Models.ViewModel;
using ECommerce.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceWeb.Areas.Admin.Controllers
{
    [Authorize(Policy = nameof(Policy.AdminRights))]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll("Categories");

            return View(products);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            if(id == null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Product product, IFormFile? file)
        {
            if (ModelState.IsValid)
            {


                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    // file upload detected and there is a previous image for this product
                    // old image must be deleted
                    if (!string.IsNullOrEmpty(product.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(productPath))
                        {
                            System.IO.File.Delete(productPath);
                        }
                    }


                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    product.ImageUrl = @"images\product\" + fileName;
                }

                if (product.Id == 0)
                {
                    product.Categories = _unitOfWork.Category.GetAll().Where(u => u.Id == product.CategoryId).ToList();
                    _unitOfWork.Product.Add(product);
                    TempData["success"] = "Product created successfully.";
                }
                else
                {
                    _unitOfWork.Product.Update(product);
                    TempData["success"] = "Product updated successfully.";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToDelete = _unitOfWork.Product.Get(u => u.Id == id);

            if (productToDelete == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Product.Remove(productToDelete);
            _unitOfWork.Save();

            String successMessage = "Product deleted successfully";
            TempData["success"] = successMessage;

            return Json(new { success = true, message = successMessage });
        }
    }
}

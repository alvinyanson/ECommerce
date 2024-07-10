using AutoMapper;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerce.Models.ViewModel;
using ECommerce.Service;
using ECommerce.Service.DTO;
using ECommerce.Service.Services;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerceWeb.Areas.Admin.Controllers
{
    [Authorize(Policy = nameof(Policy.AdminRights))]
    public class ProductController : Controller
    {
        private static CategoryStateManager _categoryStateManager;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public ProductController(
            IUnitOfWork unitOfWork, 
            IWebHostEnvironment webHostEnvironment,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll("Category");

            return View(products);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll()
            };

            if (id == null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id, "Category");

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
                    // save product to database
                    _unitOfWork.Product.Add(product);
                    _unitOfWork.Save();

                    // save product categories to database
                    if (_categoryStateManager.Any())
                    {
                        IEnumerable<ProductCategoryDto> newCategoryDtos = _categoryStateManager.ToProductCategoryDtos(product.Id);

                        foreach (var dto in newCategoryDtos)
                        {
                            _unitOfWork.ProductCategory.Add(_mapper.Map<ProductCategory>(dto));
                        }
                    }

                    _categoryStateManager.Clear();
                    _unitOfWork.Save();


                    TempData["success"] = "Product created successfully.";
                }
                else
                {
                    _unitOfWork.Product.Update(product);
                    _unitOfWork.Save();


                    IEnumerable<ProductCategory> toDelete = _unitOfWork.ProductCategory.GetAll().Where(u => u.ProductId == product.Id);

                    // delete the old categories of the product
                    foreach (var delete in toDelete)
                    {
                        _unitOfWork.ProductCategory.Remove(delete);
                    }


                    IEnumerable<ProductCategoryDto> toAdd = _categoryStateManager.ToProductCategoryDtos(product.Id);

                    // replace with the new categories
                    foreach (var add in toAdd)
                    {
                        _unitOfWork.ProductCategory.Add(_mapper.Map<ProductCategory>(add));
                    }

                    _unitOfWork.Save();


                    TempData["success"] = "Product updated successfully.";
                }

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

        [HttpGet, HttpPost]
        public IActionResult GetCategories(int id)
        {
            IEnumerable<Category> categories = _unitOfWork.Category.GetAll();

            var builder = new CategoryStateManagerBuilder();

            builder = builder
                .SetItems(_mapper.Map<IEnumerable<CategoryReadDto>>(categories));

            // obtain the categories of the product with the specified id
            if (id > 0)
            {
                IEnumerable<ProductCategory> productCategories = _unitOfWork.ProductCategory.GetAll().Where(u => u.ProductId == id);

                builder = builder.SetSelectedItems(productCategories.Select(c => c.CategoryId));

            }
            _categoryStateManager = builder.Build();

            return PartialView("CategoryTogglePartialView", _categoryStateManager);
        }

        [HttpGet]
        public IActionResult ToggleCategory(int id)
        {
            _categoryStateManager.Toggle(id);

            return PartialView("CategoryTogglePartialView", _categoryStateManager);
        }

    }
}

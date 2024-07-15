using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerce.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.Areas.Admin.Controllers
{
    [Authorize(Policy = nameof(Policy.AdminRights))]
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _unitOfWork.Category.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            if(id == null || id == 0)
            {
                return View(new Category());
            }
            else
            {
                Category category = _unitOfWork.Category.Get(u => u.Id == id);
                return View(category);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Category category) {
            if(ModelState.IsValid)
            {
                if(category.Id == 0)
                {
                    _unitOfWork.Category.Add(category);
                    TempData["success"] = "Category added successfully";
                } 
                else
                {
                    _unitOfWork.Category.Update(category);
                    TempData["success"] = "Category updated successfully";
                }

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpDelete]
        public IActionResult Delete(int id) 
        { 
            var categoryToDelete = _unitOfWork.Category.Get(u => u.Id == id);

            if(categoryToDelete == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Category.Remove(categoryToDelete);
            _unitOfWork.Save();

            String successMessage = "Category deleted successfully";
            TempData["success"] = successMessage;

            return Json(new { success = true, message = successMessage });
        }
    }
}

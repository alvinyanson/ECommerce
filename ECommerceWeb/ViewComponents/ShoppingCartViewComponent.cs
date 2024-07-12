using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.ViewComponents {
    public class ShoppingCartViewComponent : ViewComponent {

        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);


            if (claim != null) {
                var result = _unitOfWork.Cart.GetAll().Where(c => c.OwnerId == claim.Value).Count();

                if (HttpContext.Session.GetInt32(SD.SessionCart) == null) {
                    HttpContext.Session.SetInt32(SD.SessionCart,
                    result);
                }
                
                return View(HttpContext.Session.GetInt32(SD.SessionCart));
            }
            else {
                HttpContext.Session.Clear();
                return View(0);
            }
        }

    }
}

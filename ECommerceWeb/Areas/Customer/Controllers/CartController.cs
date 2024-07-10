﻿using ECommerce.DataAccess.Repository.IRepository;
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

            IEnumerable<Cart> result = _unitOfWork.Cart.GetAll("Product").Where(u => u.OwnerId == userId);

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

    }
}

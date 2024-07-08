using ECommerce.Models;
using ECommerce.Service.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace ECommerceWeb.Areas.Account.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogIn()
        {

            //if (await _accountService.IsSignedIn(User))
            //{
            //    return RedirectToAction("index", "home");
            //}

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> SignUp(SignUp credentials)
        {
            bool succeeded = await _accountService.CreateAccountAsync(credentials);

            if (!succeeded)
            {
                return BadRequest();
            }


            return Json (new {success = "register successful"});
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogIn credentials)
        {
            var result = await _accountService.SignInAsync(credentials);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            return result.Succeeded ? RedirectToAction("index", "home") : View();
        }

    }
}

using AutoMapper;
using ECommerce.Models;
using ECommerce.Service.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using NuGet.Protocol.Plugins;

namespace ECommerceWeb.Areas.Account.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService,
            IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
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

            LogIn login = _mapper.Map<LogIn>(credentials);

            var result = await _accountService.SignInAsync(login);

            return result.Succeeded ? LocalRedirect(Url.Content("~/")) : throw new InvalidOperationException();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogIn credentials)
        {


            var result = await _accountService.SignInAsync(credentials);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            return result.Succeeded ? LocalRedirect(Url.Content("~/")) : View();
        }

    }
}

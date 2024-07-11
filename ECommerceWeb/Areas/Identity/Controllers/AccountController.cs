using AutoMapper;
using ECommerce.Models;
using ECommerce.Models.ViewModel;
using ECommerce.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.Areas.Account.Controllers
{
    [AllowAnonymous]
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
        public async Task<IActionResult> LogIn(string returnUrl = null)
        {
            if (await _accountService.IsSignedIn(User))
            {
                return LocalRedirect(Url.Content("~/"));
            }

            LoginVM loginVM = new LoginVM()
            {
                ReturnUrl = returnUrl,
            };

            return View(loginVM);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginVM loginVM)
        {
            var result = await _accountService.SignInAsync(loginVM.Credential);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            loginVM.ReturnUrl ??= Url.Content("~/");

            return result.Succeeded ? LocalRedirect(loginVM.ReturnUrl) : View();
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

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOutAsync();

            return RedirectToAction("LogIn");
        }

    }
}

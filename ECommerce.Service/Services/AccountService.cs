using ECommerce.Models;
using ECommerce.Service.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services
{
    public class AccountService: IAccountService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AccountService(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<bool> CreateAccountAsync(SignUp credentials)
        {
            ArgumentNullException.ThrowIfNull(credentials);

            var identityUser = new IdentityUser
            {
                UserName = credentials.Email,
                Email = credentials.Email,
            };

            var identityRole = new IdentityRole
            {
                Name = ((Role)credentials.Role).ToString()
            };

            IdentityResult identityResult = await _userManager.CreateAsync(identityUser, credentials.Password);
            await _roleManager.CreateAsync(identityRole);

            await _userManager.AddToRoleAsync(identityUser, identityRole.Name);

            return identityResult.Succeeded;
        }

        public async Task<bool> IsSignedIn(ClaimsPrincipal user)
        {
            IdentityUser? identityUser = await _userManager.GetUserAsync(user);

            if (identityUser is null)
            {
                return false;
            }

            return _signInManager.IsSignedIn(user);
        }

        public async Task<SignInResult> SignInAsync(LogIn credentials)
        {
            return await _signInManager.PasswordSignInAsync(
                credentials.Email,
                credentials.Password,
                isPersistent: false,
                lockoutOnFailure: false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

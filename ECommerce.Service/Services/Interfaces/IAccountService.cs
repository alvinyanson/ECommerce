using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CreateAccountAsync(SignUp credentials);

        Task<SignInResult> SignInAsync(LogIn credentials);

        Task SignOutAsync();

        Task<bool> IsSignedIn(ClaimsPrincipal user);
    }
}

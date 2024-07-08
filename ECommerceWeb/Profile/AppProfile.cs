using AutoMapper;
using ECommerce.Models;

namespace BrowseBay.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            // Login
            CreateMap<SignUp, LogIn>();
        }
    }
}

﻿using AutoMapper;
using ECommerce.Models;
using ECommerce.Service.DTO;

namespace BrowseBay.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            // Login
            CreateMap<SignUp, LogIn>();

            // Products
            CreateMap<Product, ProductReadDto>();


            // Categories
            CreateMap<Category, CategoryReadDto>();


            // Product Categories
            CreateMap<ProductCategoryDto, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryDto>();
        }
    }
}

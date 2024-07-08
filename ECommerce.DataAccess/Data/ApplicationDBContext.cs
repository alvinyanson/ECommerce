using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Home and Kitchen" },
                new Category { Id = 3, Name = "Fashion" }
                );


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Stainless steel blender",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    BriefDescription = "Praesent vitae sodales libero. ",
                    ImageUrl = "",
                    Price = 1000,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 2,
                    Name = "Espresso machine",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    BriefDescription = "Praesent vitae sodales libero. ",
                    ImageUrl = "",
                    Price = 500,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 3,
                    Name = "Toaster oven",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    BriefDescription = "Praesent vitae sodales libero. ",
                    ImageUrl = "",
                    Price = 800,
                    CategoryId = 2,
                }
                );

            modelBuilder.Entity<Cart>().HasData(
                    new Cart
                    {
                        Id = 1,
                        TotalPrice = 500,
                    }
                );

            modelBuilder.Entity<CartItem>().HasData(
            new CartItem { Id = 1, ProductId = 25, Quantity = 2, CartId = 1 }
        );
        }
    }
}

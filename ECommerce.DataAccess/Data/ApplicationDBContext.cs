using ECommerce.Models;
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
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            Category[] seedCategories =
            [
                new() { Id = 1, Name = "Clothing & Apparel" },
                new() { Id = 2, Name = "Electronics" },
                new() { Id = 3, Name = "Home & Kitchen" },
                new() { Id = 4, Name = "Health & Beauty" },
                new() { Id = 5, Name = "Sports & Outdoors" },
                new() { Id = 6, Name = "Books & Media" },
                new() { Id = 7, Name = "Toys & Games" },
                new() { Id = 8, Name = "Automotive" },
                new() { Id = 9, Name = "Pets" },
                new() { Id = 10, Name = "Jewelry & Accessories" }
            ];

            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasIndex(pc => new { pc.ProductId, pc.CategoryId })
                .IsUnique();


            modelBuilder.Entity<Cart>()
                .HasIndex(cart => new { cart.ProductId, cart.OwnerId })
                .IsUnique();


            modelBuilder.Entity<Category>().HasData(seedCategories);

        }
    }
}

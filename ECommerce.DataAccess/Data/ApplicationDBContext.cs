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
            Product[] seedProducts =
 [
     new() {Id = 1, Name = "Twin Lens Camera", Description = "Twin Lens Camera", BriefDescription = "Twin Lens Camera", ImageUrl = "images\\product\\e30fdaf9-489c-4a4c-b933-ef698f1d28e0.jpg", Price = 1000},
                 new() {Id = 2, Name = "Compact SLR Camera", Description = "Compact SLR Camera", BriefDescription = "Compact SLR Camera", ImageUrl = "images\\product\\cedff5d3-ed2a-4b6b-8157-3e0293eb61bd.jpg", Price = 1000},
                 new() {Id = 3, Name = "Nikkormat SLR Camera", Description = "Nikkormat SLR Camera", BriefDescription = "Nikkormat SLR Camera", ImageUrl = "images\\product\\092b7d67-1010-43b9-8c4f-f8f674947edf.jpg", Price = 1900},
                 new() {Id = 4, Name = "Compact Digital Camera", Description = "Compact Digital Camera", BriefDescription = "Compact Digital Camera", ImageUrl = "images\\product\\b7f4cb2c-42c5-43c8-b41d-61d63a7d95f2.jpg", Price = 1900},
                 new() {Id = 5, Name = "Instamatic Camera", Description = "Instamatic Camera", BriefDescription = "Instamatic Camera", ImageUrl = "images\\product\\43d302da-06bb-4b78-a55b-822ecb114257.jpg", Price = 1900},
                 new() {Id = 6, Name = "Tripod", Description = "Tripod", BriefDescription = "Tripod", ImageUrl = "images\\product\\5ad3224c-b2ba-425c-8973-6ea79a8bd940.jpg", Price = 1000},
                 new() {Id = 7, Name = "Vintage Folding Camera", Description = "Vintage Folding Camera", BriefDescription = "Vintage Folding Camera", ImageUrl = "images\\product\\cb38d263-938a-48dd-87b9-05b458ca3032.jpg", Price = 1000},
                 new() {Id = 8, Name = "Camera Lens", Description = "Camera Lens", BriefDescription = "Camera Lens", ImageUrl = "images\\product\\9aa2a2b5-ded2-4bbe-b97d-a09095fa02d5.jpg", Price = 1000},
                 new() {Id = 9, Name = "Instant Camera", Description = "Instant Camera", BriefDescription = "Instant Camera", ImageUrl = "images\\product\\2ceab055-200f-4817-bd5f-52d12ce09921.jpg", Price = 1000},
                 new() {Id = 10, Name = "USB Cable", Description = "USB Cable", BriefDescription = "USB Cable", ImageUrl = "images\\product\\48ff9ac1-006f-4a81-8847-2357cd648ed4.jpg", Price = 1600},
                 new() {Id = 11, Name = "Ethernet Cable", Description = "Ethernet Cable", BriefDescription = "Ethernet Cable", ImageUrl = "images\\product\\f88f2194-1e60-411a-b268-2eae125705d5.jpg", Price = 100},
                 new() {Id = 12, Name = "Clacky Keyboard", Description = "Clacky Keyboard", BriefDescription = "Clacky Keyboard", ImageUrl = "images\\product\\daf3a747-30fb-4841-96e0-9f64084307ef.jpg", Price = 1000},
                 new() {Id = 13, Name = "Hard Drive", Description = "Hard Drive", BriefDescription = "Hard Drive", ImageUrl = "images\\product\\6e13c1da-a19b-4827-88ba-91498e3f2241.jpg", Price = 1000},
                 new() {Id = 14, Name = "Gaming PC", Description = "Gaming PC", BriefDescription = "Gaming PC", ImageUrl = "images\\product\\4ac6662f-639d-480b-b318-8875943321e5.jpg", Price = 1000},
                 new() {Id = 15, Name = "High Performance RAM", Description = "High Performance RAM", BriefDescription = "High Performance RAM", ImageUrl = "images\\product\\accc318f-38df-4c5f-a0f5-91c98948a2ea.jpg", Price = 1000},
                 new() {Id = 16, Name = "Curvy Monitor", Description = "Curvy Monitor", BriefDescription = "Curvy Monitor", ImageUrl = "images\\product\\1497ba90-2c8a-4a71-90f2-c970e1a0214f.jpg", Price = 1000},
                 new() {Id = 17, Name = "32-Inch Monitor", Description = "32-Inch Monitor", BriefDescription = "32-Inch Monitor", ImageUrl = "images\\product\\f990bf34-3cbf-47ac-a0d0-296d3f282474.jpg", Price = 1900},
                 new() {Id = 18, Name = "Wireless Optical Mouse", Description = "Wireless Optical Mouse", BriefDescription = "Wireless Optical Mouse", ImageUrl = "images\\product\\5aa66166-310c-435e-bafa-5f6d8f9ca384.jpg", Price = 1000},
                 new() {Id = 19, Name = "Tablet", Description = "Tablet", BriefDescription = "Tablet", ImageUrl = "images\\product\\25cf7661-618f-4281-bcd3-c3814e1e5aba.jpg", Price = 1000},
                 new() {Id = 20, Name = "Laptop", Description = "Laptop", BriefDescription = "Laptop", ImageUrl = "images\\product\\771af035-72f6-42c7-998b-b38f3775e99d.jpg", Price = 1000},
                 new() {Id = 21, Name = "Grey Fabric Sofa", Description = "Grey Fabric Sofa", BriefDescription = "Grey Fabric Sofa", ImageUrl = "images\\product\\66f06846-c2f6-45be-aa6e-6c428fcf3396.jpg", Price = 1000},
                 new() {Id = 22, Name = "Hi-Top Basketball Shoe", Description = "Hi-Top Basketball Shoe", BriefDescription = "Hi-Top Basketball Shoe", ImageUrl = "images\\product\\45bd9afc-91ad-45d2-ab0a-2fee340b7dc6.jpg", Price = 250},
             ];

            ProductCategory[] seedProductCategories =
            [
                new() { ProductId = 1, CategoryId = 2 },
                    new() { ProductId = 2, CategoryId = 2 },
                    new() { ProductId = 3, CategoryId = 2 },
                    new() { ProductId = 4, CategoryId = 2 },
                    new() { ProductId = 5, CategoryId = 2 },
                    new() { ProductId = 6, CategoryId = 2 },
                    new() { ProductId = 7, CategoryId = 2 },
                    new() { ProductId = 8, CategoryId = 2 },
                    new() { ProductId = 9, CategoryId = 2 },
                    new() { ProductId = 10, CategoryId = 2 },
                    new() { ProductId = 12, CategoryId = 2 },
                    new() { ProductId = 13, CategoryId = 2 },
                    new() { ProductId = 14, CategoryId = 2 },
                    new() { ProductId = 15, CategoryId = 2 },
                    new() { ProductId = 16, CategoryId = 2 },
                    new() { ProductId = 17, CategoryId = 2 },
                    new() { ProductId = 18, CategoryId = 2 },
                    new() { ProductId = 19, CategoryId = 2 },
                    new() { ProductId = 20, CategoryId = 2 },
                    new() { ProductId = 21, CategoryId = 3 },
                    new() { ProductId = 22, CategoryId = 5 },
                ];


            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasIndex(pc => new { pc.ProductId, pc.CategoryId })
                .IsUnique();

            modelBuilder.Entity<Category>().HasData(seedCategories);

            modelBuilder.Entity<ProductCategory>().HasData(seedProductCategories);

            modelBuilder.Entity<Product>().HasData(seedProducts);

        }
    }
}

using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Home and Kitchen", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Fashion", DisplayOrder = 3 }
                );
        }
    }
}

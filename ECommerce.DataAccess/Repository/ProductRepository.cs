using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerceWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDBContext _db;

        public ProductRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            _db.Products.Update(product);
        }

        public IEnumerable<Product> Search(String query)
        {
            return _db.Products.Where(p => p.Name.ToLower().Contains(query.ToLower()) ||
                    p.Category.Any(c => c.Category.Name.ToLower().Contains(query.ToLower())));
        }

        public PaginatedResult<Product> GetPaginated(int page, int pageSize)
        {
            var count = _db.Products.Count();
            var records = _db.Products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedResult<Product>
            {
                Result = records,
                Page = page,
                TotalCount = (int)Math.Ceiling(count / (double)pageSize)
            };
        }
    }
}

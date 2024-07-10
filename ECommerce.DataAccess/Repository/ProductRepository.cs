using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;
using ECommerceWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public PaginatedResult<Product> GetPaginated(int page, int pageSize, Expression<Func<Product, bool>> condition)
        {
            var count = _db.Products.Where(condition).Count();
            var records = _db.Products.Where(condition)
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

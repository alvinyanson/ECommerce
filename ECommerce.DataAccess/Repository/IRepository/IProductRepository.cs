using ECommerce.Models;
using ECommerceWeb.Models;
using System.Linq.Expressions;

namespace ECommerce.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);

        PaginatedResult<Product> GetPaginated(int page, int pageSize, Expression<Func<Product, bool>> condition);
    }
}

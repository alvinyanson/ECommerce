using ECommerce.Models;
using ECommerceWeb.Models;

namespace ECommerce.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);

        IEnumerable<Product> Search(String query);

        PaginatedResult<Product> GetPaginated(int page, int pageSize);
    }
}

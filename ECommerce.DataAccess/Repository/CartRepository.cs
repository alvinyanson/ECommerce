using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;


namespace ECommerce.DataAccess.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {

        private ApplicationDBContext _db;

        public CartRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
    }
}

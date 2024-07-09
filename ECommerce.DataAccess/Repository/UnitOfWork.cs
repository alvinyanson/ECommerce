using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using ECommerce.Models;


namespace ECommerce.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _db;
        public IProductRepository Product { get; private set; }

        public ICategoryRepository Category { get; private set; }

        public ICartRepository Cart { get; private set; }

        public IProductCategoryRepository ProductCategory { get; private set; }

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
            Product = new ProductRepository(_db);
            Category = new CategoryRepository(_db);
            Cart = new CartRepository(_db);
            ProductCategory = new ProductCategoryRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

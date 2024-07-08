namespace ECommerce.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }

        ICategoryRepository Category { get; }

        ICartRepository Cart { get; }

        void Save();
    }
}

namespace ECommerce.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }

        void Save();
    }
}

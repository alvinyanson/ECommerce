using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private ApplicationDBContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDBContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includedProperties)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            if (!string.IsNullOrEmpty(includedProperties))
            {
                foreach (var includeProp in includedProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includedProperties)
        {
            IQueryable<T> query = dbSet;

            if (!string.IsNullOrEmpty(includedProperties))
            {
                foreach (var includeProp in includedProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}

using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Linq.Expressions;


namespace Rectangles.DataAccess.IRepository
{
    public interface IRepository<T> where T : class
    {
        ValueTask<T> FindAsync(int id);

        Task<List<T>> GetAllAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = null,
        bool isTracking = true
        );

        Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null,
            bool isTracking = true
            );

        void Update(T entity);

        ValueTask<EntityEntry<T>> AddAsync(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        Task<int> SaveAsync();
    }
}

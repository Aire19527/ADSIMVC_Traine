using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace MVC.Data.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {

        Task<T> GetById(int id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);

        Task<int> Add(T entity);
        Task<int> AddRange(IEnumerable<T> entities);
        Task<int> Update(T entity);
        Task<int> Remove(T entity);

        Task<List<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FinAll(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetWhere(Expression<Func<T, bool>> predicate);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);


        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();

    }
}

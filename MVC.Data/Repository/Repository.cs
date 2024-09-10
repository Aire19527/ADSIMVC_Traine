using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MVC.Data.Context;
using MVC.Data.Repository.Interfaces;
using System.Linq.Expressions;

namespace MVC.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        #region Fields

        protected DataContext _context;

        #endregion

        public Repository(DataContext context)
        {
            _context = context;
        }


        #region Privates
        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable<T>();
        }

        private IQueryable<T> PerformInclusions(IEnumerable<Expression<Func<T, object>>> includeProperties,
                                              IQueryable<T> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }



        #endregion

        #region Public Methods



        public async Task<T> GetById(int id) => await _context.Set<T>().FindAsync(id);

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);

        public async Task<int> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddRange(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            // In case AsNoTracking is used
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            return await PerformInclusions(includeProperties, query).ToListAsync();
        }

        public IQueryable<T> FinAll(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);

            return  query.Where(where);
        }

        public async Task<List<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => _context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().CountAsync(predicate);


        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }


        #endregion

    }

}

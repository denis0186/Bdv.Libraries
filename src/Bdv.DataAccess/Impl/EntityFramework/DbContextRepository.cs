using Bdv.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace Bdv.DataAccess.Impl.EntityFramework
{
    public class DbContextRepository<TDbContext> : IRepository
        where TDbContext : DbContext
    {
        public DbContextRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected TDbContext DbContext { get; }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>>? predicate = null)
            where TEntity : class, IEntity
        {
            return await DbContext.Set<TEntity>().Where(predicate ?? (x => true)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sql, params object[] param)
            where T : class
        {
            return await DbContext.Set<T>().FromSqlRaw(sql, param).AsNoTracking().ToListAsync();
        }

        public Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity
        {
            return DbContext.Set<TEntity>().Where(predicate).AsNoTracking().SingleOrDefaultAsync();
        }

        public Task<TEntity?> GetAsync<TEntity, TKey>(TKey key)
            where TEntity : class, IEntity<TKey>
            where TKey : struct
        {
            return DbContext.Set<TEntity>().Where(x => x.Id.Equals(key)).AsNoTracking().SingleOrDefaultAsync();
        }

        public Task<T?> GetAsync<T>(string sql, params object[] param) where T : class
        {
            return DbContext.Set<T>().FromSqlRaw(sql, param).AsNoTracking().SingleOrDefaultAsync();
        }

        public IQueryable<TEntity> GetQuery<TEntity>()
            where TEntity : class, IEntity
        {
            return DbContext.Set<TEntity>().AsNoTracking();
        }
    }
}

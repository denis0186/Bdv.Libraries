using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace Bdv.DataAccess.Impl.EntityFramework
{
    public class EntityFrameworkRepository<TDbContext> : IRepository
        where TDbContext : DbContext
    {
        public EntityFrameworkRepository(TDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        protected TDbContext DbContext { get; }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>>? predicate = null, IDbConnection? connection = null, IDbTransaction? transaction = null)
            where TEntity : class
        {
            predicate ??= x => true;
            return await DbContext.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
        }
    }
}

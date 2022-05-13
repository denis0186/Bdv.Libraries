using Bdv.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Bdv.DataAccess.Impl.EntityFramework
{
    public class DbContextCrudService<TDbContext> : ICrudService
        where TDbContext : DbContext
    {
        public DbContextCrudService(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected TDbContext DbContext { get; }

        public async Task<IDbTransaction> BeginTransactionAsync()
        {
            var transaction = await DbContext.Database.GetDbConnection().BeginTransactionAsync();
            await DbContext.Database.UseTransactionAsync(transaction);
            return transaction;
        }

        public Task UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            DbContext.Update(entity);
            return DbContext.SaveChangesAsync();
        }

        public Task UpdateAsync<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            DbContext.UpdateRange(entities);
            return DbContext.SaveChangesAsync();
        }
    }
}

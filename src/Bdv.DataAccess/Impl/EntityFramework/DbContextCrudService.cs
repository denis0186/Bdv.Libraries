using Bdv.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Bdv.DataAccess.Impl.EntityFramework
{
    public class DbContextCrudService<TDbContext> : ICrudService
        where TDbContext : DbContext
    {
        private readonly IDbContextFactory<TDbContext> _dbContextFactory;

        public DbContextCrudService(IDbContextFactory<TDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IDbTransaction> BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            context.UpdateRange(entities);
            await context.SaveChangesAsync();
        }

        public async Task InsertAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task InsertAsync<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            context.RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        public async Task ExecuteAsync(string sql)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.Database.ExecuteSqlRawAsync(sql);
        }
    }
}

using Bdv.Domain.Abstractions;
using System.Data;

namespace Bdv.DataAccess
{
    public interface ICrudService
    {
        /// <summary>
        /// Begins transaction
        /// </summary>
        /// <returns></returns>
        Task<IDbTransaction> BeginTransactionAsync();

        /// <summary>
        /// Inserts entity 
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        Task InsertAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        /// <summary>
        /// Inserts entities
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entities">Entity</param>
        /// <returns></returns>
        Task InsertAsync<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity;

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        Task UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        /// <summary>
        /// Updates entities
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entities">Entities collection</param>
        /// <returns></returns>
        Task UpdateAsync<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity;

        /// <summary>
        /// Deletes entity
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        Task DeleteAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        /// <summary>
        /// Deletes entities
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entities">Entities collection</param>
        /// <returns></returns>
        Task DeleteAsync<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity;

        /// <summary>
        /// Executes sql instruction
        /// </summary>
        /// <param name="sql">Sql instruction</param>
        /// <returns></returns>
        Task ExecuteAsync(string sql);
    }
}

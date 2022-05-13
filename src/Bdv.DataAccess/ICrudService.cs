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
        /// Updates entity
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        Task UpdateAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        /// <summary>
        /// Update entities
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="entities">Entities collection</param>
        /// <returns></returns>
        Task UpdateAsync<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity;
    }
}

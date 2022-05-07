using Bdv.Domain.Abstractions;
using System.Data;
using System.Linq.Expressions;

namespace Bdv.DataAccess
{
    public interface IRepository
    {
        /// <summary>
        /// Get entities using predicate
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="predicate">Condition</param>
        /// <param name="connection">Connection</param>
        /// <param name="transaction">Transaction</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>>? predicate = null, IDbConnection? connection = null, IDbTransaction? transaction = null)
            where TEntity : class;

        /// <summary>
        /// Get entity using predicate
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="predicate">Condition</param>
        /// <param name="connection">Connection</param>
        /// <param name="transaction">Transaction</param>
        /// <returns></returns>
        Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, IDbConnection? connection = null, IDbTransaction? transaction = null)
            where TEntity : class;

        /// <summary>
        /// Get entity by key
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <param name="key">Key</param>
        /// <param name="connection">Connection</param>
        /// <param name="transaction">Transaction</param>
        /// <returns></returns>
        Task<TEntity?> GetAsync<TEntity, TKey>(TKey key, IDbConnection? connection = null, IDbTransaction? transaction = null)
            where TEntity : class, IEntity<TKey>
            where TKey : struct;
    }
}

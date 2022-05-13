using Bdv.Domain.Abstractions;
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
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>>? predicate = null)
            where TEntity : class, IEntity;

        /// <summary>
        /// Get list result by sql query
        /// </summary>
        /// <typeparam name="T">Result type</typeparam>
        /// <param name="sql">Sql query</param>
        /// <param name="param">Sql parameters</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync<T>(string sql, params object[] param)
            where T : class;

        /// <summary>
        /// Get entity using predicate
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <param name="predicate">Condition</param>
        /// <returns></returns>
        Task<TEntity?> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity;

        /// <summary>
        /// Get single result by sql
        /// </summary>
        /// <typeparam name="T">Result type</typeparam>
        /// <param name="sql">Sql query</param>
        /// <param name="param">Sql parameters</param>
        /// <returns></returns>
        Task<T?> GetAsync<T>(string sql, params object[] param)
            where T : class;

        /// <summary>
        /// Get entity by key
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <typeparam name="TKey">Type of key</typeparam>
        /// <param name="key">Key</param>
        /// <returns></returns>
        Task<TEntity?> GetAsync<TEntity, TKey>(TKey key)
            where TEntity : class, IEntity<TKey>
            where TKey : struct;

        /// <summary>
        /// Get query
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <returns></returns>
        IQueryable<TEntity> GetQuery<TEntity>()
            where TEntity : class, IEntity;
    }
}

namespace Bdv.Redis
{
    /// <summary>
    /// Redis cache
    /// </summary>
    public interface IRedisRepository
    {
        /// <summary>
        /// Set a value to redis cache
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <returns></returns>
        Task SetValueAsync<TValue>(string key, TValue value)
            where TValue : class;

        /// <summary>
        /// Get a value from redis cache by key
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        Task<TValue?> GetValueAsync<TValue>(string key)
            where TValue : class;
    }
}

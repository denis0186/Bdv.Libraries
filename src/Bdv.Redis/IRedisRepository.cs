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
        Task SetAsync<TValue>(string key, TValue value, TimeSpan? expiry = null);

        /// <summary>
        /// Get a value from redis cache by key
        /// </summary>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        Task<TValue?> GetAsync<TValue>(string key);

        /// <summary>
        /// Increment a value from redis cache by key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Increment value</param>
        /// <returns>Incremented value</returns>
        Task<double> Incerement(string key, double value = 1);

        /// <summary>
        /// Decrement a value from redis cache by key
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Deccrement value</param>
        /// <returns>Decremented value</returns>
        Task<double> Decrement(string key, double value = 1);
    }
}

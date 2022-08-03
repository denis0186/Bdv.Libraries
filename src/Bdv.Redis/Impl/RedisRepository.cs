using StackExchange.Redis;
using System.Text.Json;

namespace Bdv.Redis.Impl
{
    public class RedisRepository : IRedisRepository
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _db;
        private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            
        };

        public RedisRepository(IRedisSettings settings)
        {
            _redis = ConnectionMultiplexer.Connect(settings.Connection);
            _db = _redis.GetDatabase();
        }

        public async Task SetAsync<TValue>(string key, TValue value, TimeSpan? expiry = null)
        {
            if (value == null)
            {
                await _db.KeyDeleteAsync(key);
                return;
            }

            var redisValue = JsonSerializer.Serialize(value, _serializerOptions);
            if (!await _db.StringSetAsync(key, redisValue, expiry))
            {
                throw new RedisException($"Redis key = {key} wasn't set");
            }
        }

        public async Task<TValue?> GetAsync<TValue>(string key)
        {
            var redisValue = await _db.StringGetAsync(key);
            if (!redisValue.HasValue)
            {
                return default;
            }

            return JsonSerializer.Deserialize<TValue>(redisValue.ToString());
        }

        public Task<double> IncerementAsync(string key, double value = 1)
        {
            return _db.StringIncrementAsync(key, value);
        }

        public Task<double> DecrementAsync(string key, double value = 1)
        {
            return _db.StringDecrementAsync(key, value);
        }
    }
}

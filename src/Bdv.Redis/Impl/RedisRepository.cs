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

        public async Task SetValueAsync<TValue>(string key, TValue value)
            where TValue : class
        {
            if (value == null)
            {
                await _db.KeyDeleteAsync(key);
                return;
            }
            
            var redisValue = JsonSerializer.Serialize(value, _serializerOptions);
            if (!await _db.StringSetAsync(key, redisValue))
            {
                throw new RedisException($"Redis key = {key} wasn't set");
            }
        }

        public async Task<TValue?> GetValueAsync<TValue>(string key)
            where TValue : class
        {
            var redisValue = await _db.StringGetAsync(key);
            if (!redisValue.HasValue)
            {
                return default;
            }

            return JsonSerializer.Deserialize<TValue>(redisValue.ToString());
        }
    }
}

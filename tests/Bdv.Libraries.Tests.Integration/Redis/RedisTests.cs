using Bdv.Redis;
using Bdv.Redis.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bdv.Libraries.Tests.Integration.Redis
{
    public class RedisTests : TestsBase
    {
        private IRedisRepository _redisRepository;

        public RedisTests(IRedisRepository redisRepository)
        {
            _redisRepository = redisRepository;
        }
        
        protected override void SetUp()
        {
        }

        protected override void TearDown()
        {
        }

        [Fact]
        public async Task SetIntValue()
        {
            
        }
    }
}

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
        public async Task SetIntValue_GetIntValue()
        {
            var key = Guid.NewGuid().ToString();
            await _redisRepository.SetAsync(key, 10, TimeSpan.FromMinutes(1));
            var value = await _redisRepository.GetAsync<int>(key);

            Assert.Equal(10, value);
        }

        [Fact]
        public async Task SetStringValue_GetStringValue()
        {
            var key = Guid.NewGuid().ToString();
            await _redisRepository.SetAsync(key, "temp string", TimeSpan.FromMinutes(1));
            var value = await _redisRepository.GetAsync<string>(key);

            Assert.Equal("temp string", value);
        }

        [Fact]
        public async Task SetDateTimeValue_GetDateTimeValue()
        {
            var key = Guid.NewGuid().ToString();
            var dateTime = DateTime.UtcNow;
            await _redisRepository.SetAsync(key, dateTime, TimeSpan.FromMinutes(1));
            var value = await _redisRepository.GetAsync<DateTime>(key);

            Assert.Equal(dateTime, value);
        }

        [Fact]
        public async Task SetStructValue_GetStructValue()
        {
            var key = Guid.NewGuid().ToString();
            var testStruct = new TestStruct { Id = Guid.NewGuid(), Value = 5, Nested = new NestedClass { Name = "name" } };
            await _redisRepository.SetAsync(key, testStruct, TimeSpan.FromMinutes(1));
            var value = await _redisRepository.GetAsync<TestStruct>(key);

            Assert.Equal(testStruct.Id, value.Id);
            Assert.Equal(testStruct.Value, value.Value);
            Assert.Equal(testStruct.Nested.Name, value.Nested.Name);
        }

        [Fact]
        public async Task SetClassValue_GetClassValue()
        {
            var key = Guid.NewGuid().ToString();
            var testClass = new TestClass { Id = 10, Name = "name", Nested = new NestedStruct { Date = DateTime.UtcNow } };
            await _redisRepository.SetAsync(key, testClass, TimeSpan.FromMinutes(1));
            var value = await _redisRepository.GetAsync<TestClass>(key);

            Assert.Equal(testClass.Id, value?.Id);
            Assert.Equal(testClass.Name, value?.Name);
            Assert.Equal(testClass.Nested.Date, value?.Nested.Date);
        }

        [Fact]
        public async Task SetNullableStructValue_GetNullableStructValue()
        {
            var key = Guid.NewGuid().ToString();
            await _redisRepository.SetAsync<TestStruct?>(key, null, TimeSpan.FromMinutes(1));
            var value = await _redisRepository.GetAsync<TestStruct?>(key);

            Assert.Null(value);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public async Task MultiplyIncrements(int count)
        {
            await _redisRepository.SetAsync("inc", 0d, TimeSpan.FromMinutes(1));
            var tasks = Enumerable.Range(0, count).Select(i => _redisRepository.Incerement("inc")).ToArray();
            await Task.WhenAll(tasks);
            var result = await _redisRepository.GetAsync<double>("inc");

            Assert.Equal(count, result);
            Assert.Equal(count * (1 + count) / 2, tasks.Sum(x => x.Result));
            
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public async Task MultiplyDecrements(int count)
        {
            await _redisRepository.SetAsync("inc", count, TimeSpan.FromMinutes(1));
            var tasks = Enumerable.Range(0, count).Select(i => _redisRepository.Decrement("inc")).ToArray();
            await Task.WhenAll(tasks);
            var result = await _redisRepository.GetAsync<double>("inc");

            Assert.Equal(0, result);
            Assert.Equal(count * (count - 1) / 2, tasks.Sum(x => x.Result));
        }

        struct TestStruct
        {
            public Guid Id { get; set; }
            public int Value { get; set; }
            public NestedClass Nested { get; set; }
        }

        struct NestedStruct
        {
            public DateTime Date { get; set; }
        }

        class TestClass
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public NestedStruct Nested { get; set; }
        }

        class NestedClass
        {
            public string? Name { get; set; }
        }
    }
}

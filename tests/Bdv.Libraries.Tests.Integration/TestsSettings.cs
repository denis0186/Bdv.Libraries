using Bdv.Redis;
using Microsoft.Extensions.Configuration;

namespace Bdv.Libraries.Tests.Integration
{
    public class TestsSettings : IRedisSettings
    {
        private readonly IConfiguration _configuration;

        public TestsSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        string IRedisSettings.Connection => _configuration["Redis:Connection"];
    }
}

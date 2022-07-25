using Bdv.Redis;
using Bdv.Redis.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdv.Libraries.Tests.Integration
{
    public class Startup
    {
        //public void ConfigureHost(IHostBuilder hostBuilder)
        //{
        //    hostBuilder
        //        .ConfigureHostConfiguration(
        //        builder => builder.AddConfiguration(new ConfigurationBuilder().AddJsonFile());
        //}

        public void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
        {
            var testsSettings = new TestsSettings(hostBuilderContext.Configuration);
            services.AddSingleton<IRedisSettings>(testsSettings);
            
            services.AddSingleton<IRedisRepository, RedisRepository>();
        }
    }
}

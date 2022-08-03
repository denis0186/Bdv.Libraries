using Bdv.DataAccess.DependencyInjection;
using Bdv.Libraries.Tests.Integration.DataAccess.Entities;
using Bdv.Libraries.Tests.Integration.DataAccess.EntityFramework;
using Bdv.Redis;
using Bdv.Redis.Impl;
using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bdv.Libraries.Tests.Integration
{
    public class Startup
    {
        public void ConfigureHost(IHostBuilder hostBuilder)
        {
            hostBuilder
                .ConfigureHostConfiguration(builder => builder.AddJsonFile("testssettings.json"));
        }

        public void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilderContext)
        {
            var testsSettings = new TestsSettings(hostBuilderContext.Configuration);
            services.AddSingleton<IRedisSettings>(testsSettings);
            
            services.AddSingleton<IRedisRepository, RedisRepository>();
            services.AddBdvDbContext<IntegrationTestsContext>(
                options => options.UseNpgsql(hostBuilderContext.Configuration.GetConnectionString("tests")));

            services.AddFluentMigratorCore()
                .ConfigureRunner(options => options.AddPostgres()
                .WithGlobalConnectionString(hostBuilderContext.Configuration.GetConnectionString("tests"))
                .ScanIn(typeof(User).Assembly).For.Migrations());
        }
    }
}

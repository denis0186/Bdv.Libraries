using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bdv.DataAccess.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBdvDbContext<TDbContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null)
            where TDbContext : DbContext
        {
            services.AddDbContext<TDbContext>(optionsAction, ServiceLifetime.Transient)
                .AddDbContextFactory<TDbContext>();
            return services;
        }
    }
}

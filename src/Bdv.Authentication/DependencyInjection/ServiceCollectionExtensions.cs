using Bdv.Authentication.AuthenticationHandlers;
using Bdv.Authentication.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace Bdv.Authentication.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBdvAuthentication(this IServiceCollection services, Action<BdvAuthenticationSchemeOptions>? configureOptions = null)
        {
            services.AddSingleton<IRsaKeyReader, RsaKeyReader>();
            services.AddAuthentication(options => options.DefaultScheme = BdvAuthenticationConstants.AuthenticationScheme)
                .AddScheme<BdvAuthenticationSchemeOptions, BdvAuthenticationHandler>(BdvAuthenticationConstants.AuthenticationScheme, configureOptions);

            return services;
        }
    }
}

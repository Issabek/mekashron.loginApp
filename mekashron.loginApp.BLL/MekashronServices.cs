using mekashron.loginApp.BLL.Interfaces;
using mekashron.loginApp.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.ServiceModel.Security;

namespace mekashron.loginApp.Client{
    public static class MekashronServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddConfigurations(configuration)
                .AddScopedServices()
                .AddSingletonServices()
                .AddTransientServices();
            return services;

        }
        private static IServiceCollection AddConfigurations(this IServiceCollection services,
    IConfiguration configuration)
        {
            return services;
        }
        private static IServiceCollection AddTransientServices(this IServiceCollection services)
        {
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IIcutechService, IcutechService>();
            return services;
        }
        private static IServiceCollection AddSingletonServices(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
        private static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IIcutechService, IcutechService>();
            return services;
        }
    }

}
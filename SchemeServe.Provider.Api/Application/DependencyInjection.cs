using SchemeServe.Provider.Api.Application.Interfaces;
using SchemeServe.Provider.Api.Application.Services;

namespace SchemeServe.Provider.Api.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProviderService, ProviderService>();

        return services;
    }
}
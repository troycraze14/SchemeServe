using SchemeServe.Provider.Api.Application;
using SchemeServe.Provider.Api.Infrastructure;

namespace SchemeServe.Provider.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddInfrastructureDependencyInjection(configuration)
            .AddApplicationDependencyInjection(configuration);

        return services;
    }
}
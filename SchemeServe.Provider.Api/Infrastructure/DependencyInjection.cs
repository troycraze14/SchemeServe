using Microsoft.EntityFrameworkCore;
using SchemeServe.Provider.Api.Application.Interfaces;
using SchemeServe.Provider.Api.Infrastructure.Data;
using SchemeServe.Provider.Api.Settings;
using SchemeServe.Provider.Api.Infrastructure.Services.Cqc;

namespace SchemeServe.Provider.Api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        AddProviderContext(services, configuration);
        RegisterCqcApiClient(services, configuration);

        return services;

        static IServiceCollection AddProviderContext(IServiceCollection services, IConfiguration configuration)
        {
            var dbOptions = configuration.GetSection(DatabaseSettings.SectionName);

            services
                .AddOptions<DatabaseSettings>()
                .Bind(dbOptions)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var databaseSettings = dbOptions.Get<DatabaseSettings>();

            services.AddDbContext<ProviderContext>((provider, options) =>
            {
                options.UseSqlServer($"{databaseSettings!.ProviderContextConnectionString}");
            });


            services.AddScoped<IProviderRepository, ProviderRepository>();

            return services;
        }

        static IServiceCollection RegisterCqcApiClient(IServiceCollection services, IConfiguration configuration)
        {
            var cqcOptions = configuration.GetSection(CqcApiClientSettings.SectionName);

            services
                .AddOptions<CqcApiClientSettings>()
                .Bind(cqcOptions)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            var cqcSettings = cqcOptions.Get<CqcApiClientSettings>();

            services.AddHttpClient(CqcApiClientSettings.HttpClientName, client =>
            {
                client.BaseAddress = new Uri(cqcSettings!.CqcApiBaseUrl);
                client.DefaultRequestHeaders.Add(cqcSettings.CqcApiAuthHeaderKey, cqcSettings.CqcApiAuthHeaderValue);
            });

            services.AddSingleton(TimeProvider.System);
            services.AddSingleton<IProviderExternalApi, CqcApiClient>();

            return services;
        }
    }
}
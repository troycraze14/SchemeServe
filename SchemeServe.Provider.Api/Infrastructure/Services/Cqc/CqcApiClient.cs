using SchemeServe.Provider.Api.Application.Interfaces;
using SchemeServe.Provider.Api.Application.Models;
using SchemeServe.Provider.Api.Domain.Models;
using SchemeServe.Provider.Api.Infrastructure.Services.Cqc.Models;
using SchemeServe.Provider.Api.Settings;

namespace SchemeServe.Provider.Api.Infrastructure.Services.Cqc;

public class CqcApiClient(IHttpClientFactory httpClientFactory) 
    : HttpApiClient.HttpApiClient(httpClientFactory), IProviderExternalApi
{
    public static readonly string ProvidersEndpoint = "/public/v1/providers";

    public async Task<Result<CqcProviderDto>> GetProvider(string identifier)
    {
        return await GetAsync<CqcProviderDto>(CqcApiClientSettings.HttpClientName, $"{ProvidersEndpoint}/{identifier}");
    }

    public async Task<Result<CqcProvidersDto>> GetProviders(GetProvidersQueryParameters query)
    {
        return await GetAsync<CqcProvidersDto>(CqcApiClientSettings.HttpClientName, ProvidersEndpoint, query);
    }
}
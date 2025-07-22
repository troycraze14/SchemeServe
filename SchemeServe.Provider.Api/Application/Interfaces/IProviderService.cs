using SchemeServe.Provider.Api.Application.Models;
using SchemeServe.Provider.Api.Domain.Models;

namespace SchemeServe.Provider.Api.Application.Interfaces;

public interface IProviderService
{
    Task<Result<ProviderDto>> GetProviderAsync(string providerId);
    Task<Result<ProvidersDto>> GetProvidersAsync(string requestRoute, GetProvidersQueryParameters query);
}
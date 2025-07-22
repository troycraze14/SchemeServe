using SchemeServe.Provider.Api.Infrastructure.Services.Cqc.Models;
using SchemeServe.Provider.Api.Domain.Models;
using SchemeServe.Provider.Api.Application.Models;

namespace SchemeServe.Provider.Api.Application.Interfaces;

public interface IProviderExternalApi
{
    Task<Result<CqcProviderDto>> GetProvider(string identifier);
    Task<Result<CqcProvidersDto>> GetProviders(GetProvidersQueryParameters query);
}
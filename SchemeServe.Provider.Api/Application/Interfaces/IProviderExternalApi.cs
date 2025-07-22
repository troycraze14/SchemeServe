using SchemeServe.Provider.Api.Infrastructure.Services.Cqc.Models;
using SchemeServe.Provider.Api.Application.Queries;
using SchemeServe.Provider.Api.Domain.Models;

namespace SchemeServe.Provider.Api.Application.Interfaces;

public interface IProviderExternalApi
{
    Task<Result<CqcProviderDto>> GetProvider(string identifier);
    Task<Result<CqcProvidersDto>> GetProviders(GetProvidersQueryParameters query);
}
using System.Data.Common;
using SchemeServe.Provider.Api.Application.Interfaces;
using SchemeServe.Provider.Api.Application.Mappers;
using SchemeServe.Provider.Api.Application.Models;
using SchemeServe.Provider.Api.Domain.Models;
using SchemeServe.Provider.Api.Infrastructure.Services.Cqc;

namespace SchemeServe.Provider.Api.Application.Services;

public class ProviderService(IProviderExternalApi cqcApi, IProviderRepository repository, ILogger<ProviderService> logger) : IProviderService
{
    private readonly IProviderExternalApi _cqcApi = cqcApi ?? throw new ArgumentNullException(nameof(cqcApi));
    private readonly IProviderRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<Result<ProviderDto>> GetProviderAsync(string providerId)
    {
        var provider = await GetProviderFromRepository(providerId);

        if (provider is not null) 
            return Result<ProviderDto>.Success(provider.ToProviderDto());

        provider = await GetProviderFromExternalApi(providerId);

        if (provider is null) 
            return Result<ProviderDto>.Failure(ProviderErrors.NotFound(providerId));

        // Saving is an optimization and should not prevent the response being returned should it fail.
        await TrySaveProviderToLocalData(provider);

        return Result<ProviderDto>.Success(provider.ToProviderDto());
    }

    private async Task<bool> TrySaveProviderToLocalData(Domain.Models.Provider providerToSave)
    {
        try
        {
            await _repository.Save(providerToSave);
            return true;
        }
        catch (DbException e)
        {
            _logger.LogError("Error saving provider {0}. {1}", providerToSave.ProviderId, e.Message);
            return false;
        }
    }

    private async Task<Domain.Models.Provider?> GetProviderFromRepository(string providerId)
    {
        var lastModifiedAfter = TimeProvider.System.GetUtcNow().AddMonths(-1).UtcDateTime;
        
        var provider = await _repository
            .FindWhere(providerId, p => p.LastModified > lastModifiedAfter);
        
        return provider;
    }

    private async Task<Domain.Models.Provider?> GetProviderFromExternalApi(string providerId)
    {
        var apiResult = await _cqcApi.GetProvider(providerId);
        if (apiResult.IsFailure)
        {
            _logger.LogError("Failed to retrieve provider {ProviderId} from external API: {ErrorMessage}", providerId, apiResult.Error.Message);
            return null;
        }
        return apiResult.Value.ToProvider();
    }

    public async Task<Result<ProvidersDto>> GetProvidersAsync(string requestRoute, GetProvidersQueryParameters query)
    {
        var result = await _cqcApi.GetProviders(query);
        if (result.IsFailure)
        {
            _logger.LogError("Failed to retrieve providers from external API: {ErrorMessage}", result.Error.Message);
            return Result<ProvidersDto>.Failure(result.Error);
        }
        return Result<ProvidersDto>.Success(result.Value.ToProvidersDto(requestRoute, CqcApiClient.ProvidersEndpoint));
    }

}
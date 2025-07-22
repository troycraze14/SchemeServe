using SchemeServe.Provider.Api.Application.Models;
using SchemeServe.Provider.Api.Infrastructure.Services.Cqc.Models;

namespace SchemeServe.Provider.Api.Application.Mappers;

public static class ProvidersMappings
{
    public static ProvidersDto ToProvidersDto(this CqcProvidersDto cqcProvidersDto, string requestRoute, string cqcRoute)
    {
        return new ProvidersDto
        {
            Total = cqcProvidersDto.Total,
            FirstPageUri = MapRoute(cqcProvidersDto.FirstPageUri),
            Page = cqcProvidersDto.Page,
            PreviousPageUri = MapOptionalRoute(cqcProvidersDto.PreviousPageUri),
            LastPageUri = MapRoute(cqcProvidersDto.LastPageUri),
            NextPageUri = MapOptionalRoute(cqcProvidersDto.NextPageUri),
            PerPage = cqcProvidersDto.PerPage,
            TotalPages = cqcProvidersDto.TotalPages,
            Providers = cqcProvidersDto.Providers.Select(p => new ProvidersDto.Provider
            {
                ProviderId = p.ProviderId,
                ProviderName = p.ProviderName
            }).ToList()
        };

        string? MapOptionalRoute(string? cqcFullPath) => string.IsNullOrEmpty(cqcFullPath) 
            ? null 
            :cqcFullPath.Replace(cqcRoute, requestRoute);
        string MapRoute(string cqcFullPath) => cqcFullPath.Replace(cqcRoute, requestRoute);
    }
}
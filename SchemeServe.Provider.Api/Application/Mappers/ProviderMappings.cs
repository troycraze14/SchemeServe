using SchemeServe.Provider.Api.Application.Models;
using SchemeServe.Provider.Api.Infrastructure.Services.Cqc.Models;

namespace SchemeServe.Provider.Api.Application.Mappers;

public static class ProviderMappings
{
    public static Domain.Models.Provider ToProvider(this CqcProviderDto cqcProviderDto)
    {
        return new Domain.Models.Provider
        {
            ProviderId = cqcProviderDto.ProviderId,
            OrganisationType = cqcProviderDto.OrganisationType,
            OwnershipType = cqcProviderDto.OwnershipType,
            Type = cqcProviderDto.Type,
            Name = cqcProviderDto.Name,
            BrandId = cqcProviderDto.BrandId,
            BrandName = cqcProviderDto.BrandName,
            RegistrationStatus = cqcProviderDto.RegistrationStatus,
            RegistrationDate = cqcProviderDto.RegistrationDate,
            CompaniesHouseNumber = cqcProviderDto.CompaniesHouseNumber,
            CharityNumber = cqcProviderDto.CharityNumber,
            Website = cqcProviderDto.Website,
            PostalAddressLine1 = cqcProviderDto.PostalAddressLine1,
            PostalAddressLine2 = cqcProviderDto.PostalAddressLine2,
            PostalAddressTownCity = cqcProviderDto.PostalAddressTownCity,
            PostalAddressCounty = cqcProviderDto.PostalAddressCounty,
            Region = cqcProviderDto.Region,
            PostalCode = cqcProviderDto.PostalCode,
            Uprn = cqcProviderDto.Uprn,
            OnSpdLatitude = cqcProviderDto.OnspdLatitude,
            OnSpdLongitude = cqcProviderDto.OnspdLongitude,
            MainPhoneNumber = cqcProviderDto.MainPhoneNumber,
            InspectionDirectorate = cqcProviderDto.InspectionDirectorate,
            Constituency = cqcProviderDto.Constituency,
            LocalAuthority = cqcProviderDto.LocalAuthority,
            LastInspection = cqcProviderDto.LastInspection?.Date,
            Locations = cqcProviderDto.LocationIds
                .Select(l => new Domain.Models.Provider.Location
                {
                    Id = l
                })
                .ToList()
        };
    }

    public static ProviderDto ToProviderDto(this Domain.Models.Provider provider)
    {
        return new ProviderDto
        {
            ProviderId = provider.ProviderId,
            OrganisationType = provider.OrganisationType,
            OwnershipType = provider.OwnershipType,
            Type = provider.Type,
            Name = provider.Name,
            BrandId = provider.BrandId,
            BrandName = provider.BrandName,
            RegistrationStatus = provider.RegistrationStatus,
            RegistrationDate = provider.RegistrationDate,
            CompaniesHouseNumber = provider.CompaniesHouseNumber,
            CharityNumber = provider.CharityNumber,
            Website = provider.Website,
            PostalAddressLine1 = provider.PostalAddressLine1,
            PostalAddressLine2 = provider.PostalAddressLine2,
            PostalAddressTownCity = provider.PostalAddressTownCity,
            PostalAddressCounty = provider.PostalAddressCounty,
            Region = provider.Region,
            PostalCode = provider.PostalCode,
            Uprn = provider.Uprn,
            OnspdLatitude = provider.OnSpdLatitude,
            OnspdLongitude = provider.OnSpdLongitude,
            MainPhoneNumber = provider.MainPhoneNumber,
            InspectionDirectorate = provider.InspectionDirectorate,
            Constituency = provider.Constituency,
            LocalAuthority = provider.LocalAuthority,
            LastInspection = provider.LastInspection is null
            ? null
            : new ProviderDto.InspectionDate
            {
                Date = provider.LastInspection.Value
            },
            LocationIds = provider.Locations
                .Select(l => l.Id)
                .ToList()
        };
    }

}
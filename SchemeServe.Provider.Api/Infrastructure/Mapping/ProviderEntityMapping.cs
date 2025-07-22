using SchemeServe.Provider.Api.Infrastructure.Data.Entities;

namespace SchemeServe.Provider.Api.Infrastructure.Mapping;

internal static class ProviderEntityMapping
{
    internal static Domain.Models.Provider ToProvider(this ProviderEntity entity)
    {
        return new Domain.Models.Provider
        {
            ProviderId = entity.ProviderId,
            OrganisationType = entity.OrganisationType,
            OwnershipType = entity.OwnershipType,
            Type = entity.Type,
            Name = entity.Name,
            BrandId = entity.BrandId,
            BrandName = entity.BrandName,
            RegistrationStatus = entity.RegistrationStatus,
            RegistrationDate = entity.RegistrationDate,
            CompaniesHouseNumber = entity.CompaniesHouseNumber,
            CharityNumber = entity.CharityNumber,
            Website = entity.Website,
            PostalAddressLine1 = entity.PostalAddressLine1,
            PostalAddressLine2 = entity.PostalAddressLine2,
            PostalAddressTownCity = entity.PostalAddressTownCity,
            PostalAddressCounty = entity.PostalAddressCounty,
            Region = entity.Region,
            PostalCode = entity.PostalCode,
            Uprn = entity.Uprn,
            OnSpdLatitude = entity.OnSpdLatitude,
            OnSpdLongitude = entity.OnSpdLongitude,
            MainPhoneNumber = entity.MainPhoneNumber,
            InspectionDirectorate = entity.InspectionDirectorate,
            Constituency = entity.Constituency,
            LocalAuthority = entity.LocalAuthority,
            LastInspection = entity.LastInspection,
            Locations = entity.Locations
                .Select(l => (Domain.Models.Provider.Location)l)
                .ToList() 
        };
    }

    internal static ProviderEntity ToProviderEntity(this Domain.Models.Provider provider)
    {
        return new ProviderEntity
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
            OnSpdLatitude = provider.OnSpdLatitude,
            OnSpdLongitude = provider.OnSpdLongitude,
            MainPhoneNumber = provider.MainPhoneNumber,
            InspectionDirectorate = provider.InspectionDirectorate,
            Constituency = provider.Constituency,
            LocalAuthority = provider.LocalAuthority,
            LastInspection = provider.LastInspection,
            Locations = provider.Locations
                .Select(l => new LocationEntity
                {
                    Id = l.Id
                }).ToList()
        };
    }

    internal static ProviderEntity UpdateFrom(this ProviderEntity entity, Domain.Models.Provider source)
    {
        entity.ProviderId = source.ProviderId;
        entity.OrganisationType = source.OrganisationType;
        entity.OwnershipType = source.OwnershipType;
        entity.Type = source.Type;
        entity.Name = source.Name;
        entity.BrandId = source.BrandId;
        entity.BrandName = source.BrandName;
        entity.RegistrationStatus = source.RegistrationStatus;
        entity.RegistrationDate = source.RegistrationDate;
        entity.CompaniesHouseNumber = source.CompaniesHouseNumber;
        entity.CharityNumber = source.CharityNumber;
        entity.Website = source.Website;
        entity.PostalAddressLine1 = source.PostalAddressLine1;
        entity.PostalAddressLine2 = source.PostalAddressLine2;
        entity.PostalAddressTownCity = source.PostalAddressTownCity;
        entity.PostalAddressCounty = source.PostalAddressCounty;
        entity.Region = source.Region;
        entity.PostalCode = source.PostalCode;
        entity.Uprn = source.Uprn;
        entity.OnSpdLatitude = source.OnSpdLatitude;
        entity.OnSpdLongitude = source.OnSpdLongitude;
        entity.MainPhoneNumber = source.MainPhoneNumber;
        entity.InspectionDirectorate = source.InspectionDirectorate;
        entity.Constituency = source.Constituency;
        entity.LocalAuthority = source.LocalAuthority;
        entity.LastInspection = source.LastInspection;

        entity.Locations = entity.Locations
            .Where(el => source.Locations.Any(sl => sl.Id == el.Id))
            .ToList();

        var toAdd = source.Locations
            .Where(sl => entity.Locations.All(el => el.Id != sl.Id))
            .Select(sl => new LocationEntity { Id = sl.Id });

        entity.Locations.AddRange(toAdd);

        return entity;
    }
}
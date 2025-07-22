using NUnit.Framework;
using SchemeServe.Provider.Api.Application.Mappers;
using SchemeServe.Provider.Api.Infrastructure.Services.Cqc.Models;

namespace SchemeServe.Provider.Api.Tests.Mappers;

[TestFixture]
public class ProviderMappingsTests
{
    [Test]
    public void ToProviderShouldMapsAllProperties()
    {
        var cqcDto = new CqcProviderDto
        {
            ProviderId = "P1",
            OrganisationType = "OrgType",
            OwnershipType = "OwnType",
            Type = "TypeA",
            Name = "ProviderName",
            BrandId = "B1",
            BrandName = "BrandName",
            RegistrationStatus = "Active",
            RegistrationDate = "2020-01-01",
            CompaniesHouseNumber = "CH123",
            CharityNumber = "CN456",
            Website = "http://test.com",
            PostalAddressLine1 = "Line1",
            PostalAddressLine2 = "Line2",
            PostalAddressTownCity = "Town",
            PostalAddressCounty = "County",
            Region = "Region1",
            PostalCode = "PC1",
            Uprn = "UPRN1",
            OnspdLatitude = 51.5,
            OnspdLongitude = -0.1,
            MainPhoneNumber = "0123456789",
            InspectionDirectorate = "Dir",
            Constituency = "Constituency1",
            LocalAuthority = "LA1",
            LastInspection = new CqcProviderDto.InspectionDate { Date = new DateTime(2023, 5, 1) },
            LocationIds = ["L1", "L2"]
        };

        var provider = cqcDto.ToProvider();

        Assert.Multiple(() =>
        {
            Assert.That(provider.ProviderId, Is.EqualTo(cqcDto.ProviderId));
            Assert.That(provider.OrganisationType, Is.EqualTo(cqcDto.OrganisationType));
            Assert.That(provider.OwnershipType, Is.EqualTo(cqcDto.OwnershipType));
            Assert.That(provider.Type, Is.EqualTo(cqcDto.Type));
            Assert.That(provider.Name, Is.EqualTo(cqcDto.Name));
            Assert.That(provider.BrandId, Is.EqualTo(cqcDto.BrandId));
            Assert.That(provider.BrandName, Is.EqualTo(cqcDto.BrandName));
            Assert.That(provider.RegistrationStatus, Is.EqualTo(cqcDto.RegistrationStatus));
            Assert.That(provider.RegistrationDate, Is.EqualTo(cqcDto.RegistrationDate));
            Assert.That(provider.CompaniesHouseNumber, Is.EqualTo(cqcDto.CompaniesHouseNumber));
            Assert.That(provider.CharityNumber, Is.EqualTo(cqcDto.CharityNumber));
            Assert.That(provider.Website, Is.EqualTo(cqcDto.Website));
            Assert.That(provider.PostalAddressLine1, Is.EqualTo(cqcDto.PostalAddressLine1));
            Assert.That(provider.PostalAddressLine2, Is.EqualTo(cqcDto.PostalAddressLine2));
            Assert.That(provider.PostalAddressTownCity, Is.EqualTo(cqcDto.PostalAddressTownCity));
            Assert.That(provider.PostalAddressCounty, Is.EqualTo(cqcDto.PostalAddressCounty));
            Assert.That(provider.Region, Is.EqualTo(cqcDto.Region));
            Assert.That(provider.PostalCode, Is.EqualTo(cqcDto.PostalCode));
            Assert.That(provider.Uprn, Is.EqualTo(cqcDto.Uprn));
            Assert.That(provider.OnSpdLatitude, Is.EqualTo(cqcDto.OnspdLatitude));
            Assert.That(provider.OnSpdLongitude, Is.EqualTo(cqcDto.OnspdLongitude));
            Assert.That(provider.MainPhoneNumber, Is.EqualTo(cqcDto.MainPhoneNumber));
            Assert.That(provider.InspectionDirectorate, Is.EqualTo(cqcDto.InspectionDirectorate));
            Assert.That(provider.Constituency, Is.EqualTo(cqcDto.Constituency));
            Assert.That(provider.LocalAuthority, Is.EqualTo(cqcDto.LocalAuthority));
            Assert.That(provider.LastInspection, Is.EqualTo(cqcDto.LastInspection.Date));
            Assert.That(provider.Locations.Count, Is.EqualTo(2));
            Assert.That(provider.Locations[0].Id, Is.EqualTo("L1"));
            Assert.That(provider.Locations[1].Id, Is.EqualTo("L2"));
        });
    }

    [Test]
    public void ToProviderShouldHandlesNullLastInspectionAndEmptyLocations()
    {
        var cqcDto = new CqcProviderDto
        {
            ProviderId = "P2",
            LastInspection = null,
            LocationIds = []
        };

        var provider = cqcDto.ToProvider();

        Assert.That(provider.LastInspection, Is.Null);
        Assert.That(provider.Locations, Is.Empty);
    }

    [Test]
    public void ToProviderDtoShouldMapsAllProperties()
    {
        var provider = new Domain.Models.Provider
        {
            ProviderId = "P3",
            OrganisationType = "OrgType",
            OwnershipType = "OwnType",
            Type = "TypeB",
            Name = "ProviderName2",
            BrandId = "B2",
            BrandName = "BrandName2",
            RegistrationStatus = "Inactive",
            RegistrationDate = "2021-02-02",
            CompaniesHouseNumber = "CH789",
            CharityNumber = "CN101",
            Website = "http://test2.com",
            PostalAddressLine1 = "LineA",
            PostalAddressLine2 = "LineB",
            PostalAddressTownCity = "City",
            PostalAddressCounty = "County2",
            Region = "Region2",
            PostalCode = "PC2",
            Uprn = "UPRN2",
            OnSpdLatitude = 52.5,
            OnSpdLongitude = -1.1,
            MainPhoneNumber = "0987654321",
            InspectionDirectorate = "Dir2",
            Constituency = "Constituency2",
            LocalAuthority = "LA2",
            LastInspection = new DateTime(2024, 6, 1),
            Locations =
            [
                new Domain.Models.Provider.Location { Id = "L3" },
                new Domain.Models.Provider.Location { Id = "L4" }
            ]
        };

        var dto = provider.ToProviderDto();

        Assert.Multiple(() =>
        {
            Assert.That(dto.ProviderId, Is.EqualTo(provider.ProviderId));
            Assert.That(dto.OrganisationType, Is.EqualTo(provider.OrganisationType));
            Assert.That(dto.OwnershipType, Is.EqualTo(provider.OwnershipType));
            Assert.That(dto.Type, Is.EqualTo(provider.Type));
            Assert.That(dto.Name, Is.EqualTo(provider.Name));
            Assert.That(dto.BrandId, Is.EqualTo(provider.BrandId));
            Assert.That(dto.BrandName, Is.EqualTo(provider.BrandName));
            Assert.That(dto.RegistrationStatus, Is.EqualTo(provider.RegistrationStatus));
            Assert.That(dto.RegistrationDate, Is.EqualTo(provider.RegistrationDate));
            Assert.That(dto.CompaniesHouseNumber, Is.EqualTo(provider.CompaniesHouseNumber));
            Assert.That(dto.CharityNumber, Is.EqualTo(provider.CharityNumber));
            Assert.That(dto.Website, Is.EqualTo(provider.Website));
            Assert.That(dto.PostalAddressLine1, Is.EqualTo(provider.PostalAddressLine1));
            Assert.That(dto.PostalAddressLine2, Is.EqualTo(provider.PostalAddressLine2));
            Assert.That(dto.PostalAddressTownCity, Is.EqualTo(provider.PostalAddressTownCity));
            Assert.That(dto.PostalAddressCounty, Is.EqualTo(provider.PostalAddressCounty));
            Assert.That(dto.Region, Is.EqualTo(provider.Region));
            Assert.That(dto.PostalCode, Is.EqualTo(provider.PostalCode));
            Assert.That(dto.Uprn, Is.EqualTo(provider.Uprn));
            Assert.That(dto.OnspdLatitude, Is.EqualTo(provider.OnSpdLatitude));
            Assert.That(dto.OnspdLongitude, Is.EqualTo(provider.OnSpdLongitude));
            Assert.That(dto.MainPhoneNumber, Is.EqualTo(provider.MainPhoneNumber));
            Assert.That(dto.InspectionDirectorate, Is.EqualTo(provider.InspectionDirectorate));
            Assert.That(dto.Constituency, Is.EqualTo(provider.Constituency));
            Assert.That(dto.LocalAuthority, Is.EqualTo(provider.LocalAuthority));
            Assert.That(dto.LastInspection, Is.Not.Null);
            Assert.That(dto.LastInspection.Date, Is.EqualTo(provider.LastInspection.Value));
            Assert.That(dto.LocationIds.Count, Is.EqualTo(2));
            Assert.That(dto.LocationIds[0], Is.EqualTo("L3"));
            Assert.That(dto.LocationIds[1], Is.EqualTo("L4"));
        });
    }

    [Test]
    public void ToProviderDtoShouldHandleNullLastInspectionAndEmptyLocations()
    {
        var provider = new Domain.Models.Provider
        {
            ProviderId = "P4",
            LastInspection = null,
            Locations = new List<Domain.Models.Provider.Location>()
        };

        var dto = provider.ToProviderDto();

        Assert.That(dto.LastInspection, Is.Null);
        Assert.That(dto.LocationIds, Is.Empty);
    }
}
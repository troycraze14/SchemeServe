using NUnit.Framework;
using SchemeServe.Provider.Api.Application.Mappers;
using SchemeServe.Provider.Api.Infrastructure.Services.Cqc.Models;

namespace SchemeServe.Provider.Api.Tests.Mappers;

[TestFixture]
public class ProvidersMappingsTests
{
    [Test]
    public void ToProvidersDtoShouldMapsAllProperties()
    {
        // Arrange
        var cqcRoute = "/cqc/providers";
        var requestRoute = "/api/providers";
        var cqcDto = new CqcProvidersDto
        {
            Total = 2,
            FirstPageUri = $"{cqcRoute}?page=1",
            Page = 1,
            PreviousPageUri = $"{cqcRoute}?page=0",
            LastPageUri = $"{cqcRoute}?page=10",
            NextPageUri = $"{cqcRoute}?page=2",
            PerPage = 20,
            TotalPages = 10,
            Providers =
            [
                new() { ProviderId = "1", ProviderName = "Alpha" },
                new CqcProvidersDto.CqcProvider { ProviderId = "2", ProviderName = "Beta" }
            ]
        };

        // Act
        var dto = cqcDto.ToProvidersDto(requestRoute, cqcRoute);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(dto.Total, Is.EqualTo(2));
            Assert.That(dto.FirstPageUri, Is.EqualTo($"{requestRoute}?page=1"));
            Assert.That(dto.Page, Is.EqualTo(1));
            Assert.That(dto.PreviousPageUri, Is.EqualTo($"{requestRoute}?page=0"));
            Assert.That(dto.LastPageUri, Is.EqualTo($"{requestRoute}?page=10"));
            Assert.That(dto.NextPageUri, Is.EqualTo($"{requestRoute}?page=2"));
            Assert.That(dto.PerPage, Is.EqualTo(20));
            Assert.That(dto.TotalPages, Is.EqualTo(10));
            Assert.That(dto.Providers.Count, Is.EqualTo(2));
            Assert.That(dto.Providers[0].ProviderId, Is.EqualTo("1"));
            Assert.That(dto.Providers[0].ProviderName, Is.EqualTo("Alpha"));
            Assert.That(dto.Providers[1].ProviderId, Is.EqualTo("2"));
            Assert.That(dto.Providers[1].ProviderName, Is.EqualTo("Beta"));
        });
    }

    [Test]
    public void ToProvidersDtoShouldHandlesNullAndEmptyOptionalUris()
    {
        // Arrange
        var cqcRoute = "/cqc/providers";
        var requestRoute = "/api/providers";
        var cqcDto = new CqcProvidersDto
        {
            Total = 1,
            FirstPageUri = $"{cqcRoute}?page=1",
            Page = 1,
            PreviousPageUri = null,
            LastPageUri = $"{cqcRoute}?page=1",
            NextPageUri = "",
            PerPage = 10,
            TotalPages = 1,
            Providers = [new CqcProvidersDto.CqcProvider { ProviderId = "1", ProviderName = "Alpha" }]
        };

        // Act
        var dto = cqcDto.ToProvidersDto(requestRoute, cqcRoute);

        // Assert
        Assert.That(dto.PreviousPageUri, Is.Null);
        Assert.That(dto.NextPageUri, Is.Null);
    }

    [Test]
    public void ToProvidersDtoShouldMapEmptyProvidersList()
    {
        // Arrange
        var cqcRoute = "/cqc/providers";
        var requestRoute = "/api/providers";
        var cqcDto = new CqcProvidersDto
        {
            Total = 0,
            FirstPageUri = $"{cqcRoute}?page=1",
            Page = 1,
            PreviousPageUri = null,
            LastPageUri = $"{cqcRoute}?page=1",
            NextPageUri = null,
            PerPage = 10,
            TotalPages = 1,
            Providers = []
        };

        // Act
        var dto = cqcDto.ToProvidersDto(requestRoute, cqcRoute);

        // Assert
        Assert.That(dto.Providers, Is.Empty);
    }
}
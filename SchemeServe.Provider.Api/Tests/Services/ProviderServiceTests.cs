using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SchemeServe.Provider.Api.Application.Interfaces;
using SchemeServe.Provider.Api.Application.Services;
using SchemeServe.Provider.Api.Domain.Models;
using SchemeServe.Provider.Api.Infrastructure.Data.Entities;
using SchemeServe.Provider.Api.Infrastructure.Services.Cqc.Models;

namespace SchemeServe.Provider.Api.Tests.Services;

[TestFixture]
public class ProviderServiceTests
{
    private Mock<IProviderExternalApi> _cqcApiMock;
    private Mock<IProviderRepository> _repositoryMock;
    private Mock<ILogger<ProviderService>> _loggerMock;
    private ProviderService _service;

    [SetUp]
    public void SetUp()
    {
        _cqcApiMock = new Mock<IProviderExternalApi>();
        _repositoryMock = new Mock<IProviderRepository>();
        _loggerMock = new Mock<ILogger<ProviderService>>();
        _service = new ProviderService(_cqcApiMock.Object, _repositoryMock.Object, _loggerMock.Object);
    }

    [Test]
    public async Task GetProviderAsyncShouldReturnProviderFromRepositoryWhenFound()
    {
        // Arrange
        const string providerId = "123";
        var provider = new Domain.Models.Provider { ProviderId = providerId };
        _repositoryMock
            .Setup(r => r.FindWhere(providerId, It.IsAny<Expression<Func<ProviderEntity, bool>>>()))
            .ReturnsAsync(provider);

        // Act
        var result = await _service.GetProviderAsync(providerId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.ProviderId.Should().Be(providerId);
        _cqcApiMock.Verify(api => api.GetProvider(It.IsAny<string>()), Times.Never);
    }

    [Test]
    public async Task GetProviderAsyncShouldFetchFromApiAndSaveWhenNotInRepository()
    {
        // Arrange
        const string providerId = "456";
        _repositoryMock
            .Setup(r => r.FindWhere(providerId, It.IsAny<Expression<Func<ProviderEntity, bool>>>()))
            .ReturnsAsync((Domain.Models.Provider?)null);

        var cqcProviderDto = new CqcProviderDto { ProviderId = providerId };
        var apiResult = Result<CqcProviderDto>.Success(cqcProviderDto);
        _cqcApiMock
            .Setup(api => api.GetProvider(providerId))
            .ReturnsAsync(apiResult);

        _repositoryMock
            .Setup(r => r.Save(It.IsAny<Domain.Models.Provider>()))
            .ReturnsAsync(new Domain.Models.Provider { ProviderId = providerId });

        // Act
        var result = await _service.GetProviderAsync(providerId);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.ProviderId.Should().Be(providerId);
        _repositoryMock.Verify(r => r.Save(It.IsAny<Domain.Models.Provider>()), Times.Once);
    }

    [Test]
    public async Task GetProviderAsyncShouldReturnFailureWhenNotFoundAnywhere()
    {
        // Arrange
        var providerId = "789";
        _repositoryMock
           .Setup(r => r.FindWhere(providerId, It.IsAny<Expression<Func<ProviderEntity, bool>>>()))
           .ReturnsAsync((Domain.Models.Provider?)null);

        var apiResult = Result<CqcProviderDto>.Failure(new Error("AnyErrorCode","Not found"));
        _cqcApiMock
            .Setup(api => api.GetProvider(providerId))
            .ReturnsAsync(apiResult);

        // Act
        var result = await _service.GetProviderAsync(providerId);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().NotBeNull();
    }

}
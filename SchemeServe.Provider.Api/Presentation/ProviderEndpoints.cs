using SchemeServe.Provider.Api.Application.Interfaces;
using SchemeServe.Provider.Api.Application.Models;

namespace SchemeServe.Provider.Api.Presentation;

public static class ProviderEndpoints
{
    public const string Group = "/api/providers";
    public const string GetListing = "/";
    public const string GetById = "/{id}";

    public static void MapProviderEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup(Group)
            .WithTags("Providers")
            .WithOpenApi();

        group.MapGet(GetListing, async ([AsParameters] GetProvidersQueryParameters query, IProviderService providerService) =>
        {
            var result = await providerService.GetProvidersAsync($"{Group}/{GetListing}", query);
            return result.Match(
                onSuccess: Results.Ok,
                onFailure: Results.BadRequest);
        }).WithName("GetProviderListing");


        group.MapGet(GetById, async (string providerId, IProviderService providerService) =>
        {
            var result = await providerService.GetProviderAsync(providerId);
            return result.Match(
                onSuccess: Results.Ok,
                onFailure: Results.NotFound);
        }).WithName("GetProviderById");
    }
}
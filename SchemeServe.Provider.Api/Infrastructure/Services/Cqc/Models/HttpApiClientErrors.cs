using System.Net;
using SchemeServe.Provider.Api.Domain.Models;

namespace SchemeServe.Provider.Api.Infrastructure.Services.Cqc.Models;

internal static class HttpApiClientErrors
{
    internal static Error HttpErrorStatus(string route, HttpStatusCode statusCode, string? reasonPhrase) 
        => new("HttpApiClient.ResponseError", $"Endpoint {route} returned {statusCode} : {reasonPhrase}.");
    
    internal static Error UnhandledApiResponse(string route, string message)
        => new("HttpApiClient.UnhandledApiResponse", $"Endpoint {route} returned an unhandled response: {message}.");
}
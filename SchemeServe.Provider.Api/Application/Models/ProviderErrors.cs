using SchemeServe.Provider.Api.Domain.Models;

namespace SchemeServe.Provider.Api.Application.Models;

public static class ProviderErrors
{
    public static Error NotFound(string id) => new("Provider.NotFound", $"Provider with identifier {id} not found.");
}
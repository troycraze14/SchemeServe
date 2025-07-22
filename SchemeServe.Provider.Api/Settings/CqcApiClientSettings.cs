using System.ComponentModel.DataAnnotations;

namespace SchemeServe.Provider.Api.Settings;

public sealed class CqcApiClientSettings
{
    internal const string SectionName = nameof(CqcApiClientSettings);
    public const string HttpClientName = "CqcApiClient";

    [Required]
    public required string CqcApiBaseUrl { get; set; }

    [Required]
    public required string CqcApiAuthHeaderKey { get; set; }

    [Required]
    public required string CqcApiAuthHeaderValue { get; set; }

   
    
}
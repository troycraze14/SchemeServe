using System.ComponentModel.DataAnnotations;

namespace SchemeServe.Provider.Api.Settings;

public class DatabaseSettings
{
    internal const string SectionName = nameof(DatabaseSettings);

    [Required]
    public required string ProviderContextConnectionString { get; set; }
}
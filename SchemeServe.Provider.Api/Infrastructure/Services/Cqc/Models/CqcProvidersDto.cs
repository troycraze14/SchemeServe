using System.Runtime.Serialization;

namespace SchemeServe.Provider.Api.Infrastructure.Services.Cqc.Models;

public class CqcProvidersDto
{
    private List<CqcProvider>? _providers = [];

    [DataMember]
    public int Total { get; set; }
    [DataMember]
    public required string FirstPageUri { get; set; }
    [DataMember]
    public int Page { get; set; }
    [DataMember]
    public string? PreviousPageUri { get; set; }
    [DataMember]
    public required string LastPageUri { get; set; }
    [DataMember]
    public string? NextPageUri { get; set; }
    [DataMember]
    public int PerPage { get; set; }
    [DataMember]
    public int TotalPages { get; set; }

    [DataMember]
    public List<CqcProvider> Providers
    {
        get => _providers ??= [];
        set => _providers = value;
    }
    public class CqcProvider
    {
        [DataMember]
        public required string ProviderId { get; set; }
        [DataMember]
        public required string ProviderName { get; set; }
    }
}
using System.Runtime.Serialization;

namespace SchemeServe.Provider.Api.Application.Models;

public class ProvidersDto
{
    private List<Provider>? _providers = [];

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
    public List<Provider> Providers
    {
        get => _providers ??= [];
        set => _providers = value;
    }
    public class Provider
    {
        [DataMember]
        public required string ProviderId { get; set; }
        [DataMember]
        public required string ProviderName { get; set; }
    }
}
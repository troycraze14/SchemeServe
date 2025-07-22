using System.Runtime.Serialization;

namespace SchemeServe.Provider.Api.Application.Models;

public class ProviderDto
{
    private List<string>? _locationIds;

    [DataMember]
    public required string ProviderId { get; set; }

    [DataMember]
    public List<string> LocationIds
    {
        get => _locationIds ??= [];
        set => _locationIds = value;
    }

    [DataMember]
    public string? OrganisationType { get; set; }
    [DataMember]
    public string? OwnershipType { get; set; }
    [DataMember]
    public string? Type { get; set; }
    [DataMember]
    public string? Name { get; set; }
    [DataMember]
    public string? BrandId { get; set; }
    [DataMember]
    public string? BrandName { get; set; }
    [DataMember]
    public string? RegistrationStatus { get; set; }
    [DataMember]
    public string? RegistrationDate { get; set; }
    [DataMember]
    public string? CompaniesHouseNumber { get; set; }
    [DataMember]
    public string? CharityNumber { get; set; }
    [DataMember]
    public string? Website { get; set; }
    [DataMember]
    public string? PostalAddressLine1 { get; set; }
    [DataMember]
    public string? PostalAddressLine2 { get; set; }
    [DataMember]
    public string? PostalAddressTownCity { get; set; }
    [DataMember]
    public string? PostalAddressCounty { get; set; }
    [DataMember]
    public string? Region { get; set; }
    [DataMember]
    public string? PostalCode { get; set; }
    [DataMember]
    public string? Uprn { get; set; }
    [DataMember]
    public double? OnspdLatitude { get; set; }
    [DataMember]
    public double? OnspdLongitude { get; set; }
    [DataMember]
    public string? MainPhoneNumber { get; set; }
    [DataMember]
    public string? InspectionDirectorate { get; set; }
    [DataMember]
    public string? Constituency { get; set; }
    [DataMember]
    public string? LocalAuthority { get; set; }
    [DataMember]
    public InspectionDate? LastInspection { get; set; }

    public record InspectionDate
    {
        [DataMember]
        public required DateTime Date { get; set; }
    }
}
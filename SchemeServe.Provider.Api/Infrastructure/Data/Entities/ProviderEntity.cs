using System.ComponentModel.DataAnnotations;

namespace SchemeServe.Provider.Api.Infrastructure.Data.Entities;

// Production code should define max string lengths where possible
// ILastModified was defined to automate timestamp management in context, but didn't get time
public class ProviderEntity : ILastModified
{
    [Key]
    public required string ProviderId { get; set; }
    public string? OrganisationType { get; set; }
    public string? OwnershipType { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }
    public string? BrandId { get; set; }
    public string? BrandName { get; set; }
    public string? RegistrationStatus { get; set; }
    public string? RegistrationDate { get; set; }
    public string? CompaniesHouseNumber { get; set; }
    public string? CharityNumber { get; set; }
    public string? Website { get; set; }
    public string? PostalAddressLine1 { get; set; }
    public string? PostalAddressLine2 { get; set; }
    public string? PostalAddressTownCity { get; set; }
    public string? PostalAddressCounty { get; set; }
    public string? Region { get; set; }
    public string? PostalCode { get; set; }
    public string? Uprn { get; set; }
    public double? OnSpdLatitude { get; set; }
    public double? OnSpdLongitude { get; set; }
    public string? MainPhoneNumber { get; set; }
    public string? InspectionDirectorate { get; set; }
    public string? Constituency { get; set; }
    public string? LocalAuthority { get; set; }
    public DateTime? LastInspection { get; set; }
    public required List<LocationEntity> Locations { get; set; } = [];
    public DateTime LastModified { get; set; }

}
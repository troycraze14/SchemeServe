﻿namespace SchemeServe.Provider.Api.Domain.Models;

public class Provider 
{
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
    public List<Location> Locations { get; set; } = [];
    public class Location
    {
        public required string Id { get; set; }
    }
}
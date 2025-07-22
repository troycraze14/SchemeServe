namespace SchemeServe.Provider.Api.Application.Models;

public record GetProvidersQueryParameters(
    string[]? Constituency,
    string[]? LocalAuthority,
    string[]? InspectionDirectorate,
    string[]? NonPrimaryInspectionCategoryCode,
    string[]? NonPrimaryInspectionCategoryName,
    string[]? PrimaryInspectionCategoryCode,
    string[]? PrimaryInspectionCategoryName,
    string[]? OverallRating,
    string[]? Region,
    string[]? RegulatedActivity,
    string[]? ReportType,
    int? PerPage = 10,
    int? Page = 1);
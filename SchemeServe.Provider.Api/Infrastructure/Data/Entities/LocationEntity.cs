using System.ComponentModel.DataAnnotations;

namespace SchemeServe.Provider.Api.Infrastructure.Data.Entities;

public class LocationEntity
{
    [Key] 
    public required string Id { get; set; }

    public static explicit operator Domain.Models.Provider.Location(LocationEntity entity) =>
        new() { Id = entity.Id };
}
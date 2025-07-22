using Microsoft.EntityFrameworkCore;
using SchemeServe.Provider.Api.Infrastructure.Data.Entities;
namespace SchemeServe.Provider.Api.Infrastructure.Data;

public class ProviderContext(DbContextOptions<ProviderContext> options) : DbContext(options)
{
    public DbSet<ProviderEntity> Providers { get; set; }
    public DbSet<LocationEntity> Locations { get; set; }
}
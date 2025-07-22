using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SchemeServe.Provider.Api.Application.Interfaces;
using SchemeServe.Provider.Api.Infrastructure.Data.Entities;
using SchemeServe.Provider.Api.Infrastructure.Mapping;

namespace SchemeServe.Provider.Api.Infrastructure.Data;

public class ProviderRepository(ProviderContext context) : IProviderRepository
{
    private readonly ProviderContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<Domain.Models.Provider?> Find(string providerId)
    {
        var found = await _context.Providers

            .FindAsync(providerId);
        return found?.ToProvider();
    }

    public async Task<Domain.Models.Provider?> FindWhere(string providerId, Expression<Func<ProviderEntity, bool>> condition)
    {
        var found = await _context.Providers
            .Include(p => p.Locations)
            .Where(p => p.ProviderId == providerId)
            .Where(condition)
            .AsNoTracking()
            .FirstOrDefaultAsync();
        return found?.ToProvider();
    }

    public async Task<Domain.Models.Provider> Save(Domain.Models.Provider provider)
    {
        // TODO - UDT and MERGE 
        var existing = await _context.Providers
            .Include(p => p.Locations)
            .FirstOrDefaultAsync(p => p.ProviderId == provider.ProviderId);

        if (existing is null)
        {
            AddProvider(provider.ToProviderEntity());
        }
        else
        {
            UpdateProvider(existing, provider);
        }

        await _context.SaveChangesAsync();

        return provider;

        void AddProvider(ProviderEntity providerEntity)
        {
            providerEntity.LastModified = TimeProvider.System.GetUtcNow().UtcDateTime;
            _context.Providers.Add(providerEntity);
        }

        void UpdateProvider(ProviderEntity providerEntity, Domain.Models.Provider source)
        {
            providerEntity.UpdateFrom(source);
            providerEntity.LastModified = TimeProvider.System.GetUtcNow().UtcDateTime;
        }
    }
}
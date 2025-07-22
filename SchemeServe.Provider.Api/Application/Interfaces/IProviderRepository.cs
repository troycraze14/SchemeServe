namespace SchemeServe.Provider.Api.Application.Interfaces;
using Infrastructure.Data.Entities;
using System.Linq.Expressions;
using Provider = Domain.Models.Provider;

public interface IProviderRepository
{
    Task<Provider?> Find(string providerId);

    Task<Provider?> FindWhere(string providerId, Expression<Func<ProviderEntity, bool>> condition);

    Task<Provider> Save(Provider provider);
}
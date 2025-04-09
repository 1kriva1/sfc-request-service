using SFC.Request.Domain.Entities.Identity;

namespace SFC.Request.Application.Interfaces.Persistence.Context;

/// <summary>
/// Identity service related entities.
/// </summary>
public interface IIdentityDbContext : IDbContext
{
    IQueryable<User> Users { get; }
}
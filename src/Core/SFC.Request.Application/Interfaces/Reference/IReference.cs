using SFC.Request.Domain.Common;

namespace SFC.Request.Application.Interfaces.Reference;

/// <summary>
/// Contract to get entities from other services.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
/// <typeparam name="TID">Entity identifier type.</typeparam>
/// <typeparam name="TDto">Entity related DTO type.</typeparam>
public interface IReference<TEntity, TID, TDto>
    where TEntity : BaseEntity<TID>
{
    Task<TEntity?> GetAsync(TID id, CancellationToken cancellationToken = default);
}
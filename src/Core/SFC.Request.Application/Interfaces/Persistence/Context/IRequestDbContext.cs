namespace SFC.Request.Application.Interfaces.Persistence.Context;

/// <summary>
/// Core DB context of the service.
/// </summary>
public interface IRequestDbContext : IDbContext
{
    #region General

    IQueryable<RequestEntity> Requests { get; }

    #endregion
}
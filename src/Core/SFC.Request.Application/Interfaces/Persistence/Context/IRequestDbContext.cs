using SFC.Request.Domain.Entities.Request.Data;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Interfaces.Persistence.Context;

/// <summary>
/// Core DB context of the service.
/// </summary>
public interface IRequestDbContext : IDbContext
{
    #region General

    IQueryable<TeamPlayerRequest> TeamPlayerRequests { get; }

    #endregion

    #region Data

    IQueryable<RequestStatus> RequestStatuses { get; }

    #endregion Data
}
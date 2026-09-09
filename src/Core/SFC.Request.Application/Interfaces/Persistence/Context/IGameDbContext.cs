using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Domain.Entities.Game.General;
using SFC.Request.Domain.Entities.Game.Player;
using SFC.Request.Domain.Entities.Game.Team;

namespace SFC.Request.Application.Interfaces.Persistence.Context;
public interface IGameDbContext : IDbContext
{
    #region General

    IQueryable<GameEntity> Games { get; }

    IQueryable<GameGeneralProfile> GeneralProfiles { get; }

    IQueryable<GameFinancialProfile> FinancialProfiles { get; }

    IQueryable<GameInventaryProfile> InventaryProfiles { get; }

    IQueryable<GameAvailability> Availabilities { get; }

    IQueryable<GameTag> Tags { get; }

    #endregion General

    #region Player

    IQueryable<GamePlayer> GamePlayers { get; }

    #endregion Player

    #region Team

    IQueryable<GameTeam> GameTeams { get; }

    #endregion Team

    #region Data

    IQueryable<GameStatus> GameStatuses { get; }

    IQueryable<GamePlayerStatus> GamePlayerStatuses { get; }

    IQueryable<GameTeamStatus> GameTeamStatuses { get; }

    IQueryable<GameTeamIndex> GameTeamIndexes { get; }

    #endregion Data
}
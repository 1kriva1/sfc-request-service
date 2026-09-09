using Microsoft.EntityFrameworkCore;

using SFC.Request.Domain.Entities.Game.Player;
using SFC.Request.Domain.Entities.Game.Team;
using SFC.Request.Domain.Entities.Request.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Team;
using SFC.Request.Domain.Entities.Request.Team.Player;
using SFC.Request.Domain.Entities.Team.Player;

namespace SFC.Request.Infrastructure.Persistence.Extensions;
public static class IncludeExtensions
{
    #region Player

    public static IQueryable<PlayerEntity> IncludePlayer(this IQueryable<PlayerEntity> players)
    {
        IQueryable<PlayerEntity> result = players
                    .Include(p => p.GeneralProfile)
                    .Include(p => p.FootballProfile)
                    .Include(p => p.Availability)
                    .Include(p => p.Availability.Days)
                    .Include(p => p.Points)
                    .Include(p => p.Tags)
                    .Include(p => p.Stats)
                    .Include(p => p.Photo);

        return result;
    }

    #endregion Player

    #region Team

    public static IQueryable<TeamEntity> IncludeTeam(this IQueryable<TeamEntity> teams)
    {
        IQueryable<TeamEntity> result = teams
                    .Include(p => p.GeneralProfile)
                    .Include(p => p.InventaryProfile)
                    .Include(p => p.FinancialProfile)
                    .Include(p => p.Shirts)
                    .Include(p => p.Availability)
                    .Include(p => p.Tags)
                    .Include(p => p.Logo)
                    .Include(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.GeneralProfile)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.FootballProfile)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability.Days)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Points)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Tags)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Stats)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Photo);

        return result;
    }

    public static IQueryable<TeamPlayer> ThanIncludePlayer(this IQueryable<TeamPlayer> teamPlayers)
    {
        IQueryable<TeamPlayer> result = teamPlayers
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    #endregion Team

    #region Game

    public static IQueryable<GameEntity> IncludeGame(this IQueryable<GameEntity> games)
    {
        IQueryable<GameEntity> result = games
                    .Include(p => p.GeneralProfile)
                    .Include(p => p.InventaryProfile)
                    .Include(p => p.FinancialProfile)
                    .Include(p => p.Availability)
                    .Include(p => p.Tags)
                    .Include(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.GeneralProfile)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.FootballProfile)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability.Days)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Points)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Tags)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Stats)
                    .Include(x => x.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Photo);

        return result;
    }

    public static IQueryable<GamePlayer> ThanIncludePlayer(this IQueryable<GamePlayer> gamePlayers)
    {
        IQueryable<GamePlayer> result = gamePlayers
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    public static IQueryable<GameTeam> ThanIncludeTeam(this IQueryable<GameTeam> gameTeams)
    {
        IQueryable<GameTeam> result = gameTeams
                      .Include(x => x.Team).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Team).ThenInclude(p => p.FinancialProfile)
                      .Include(x => x.Team).ThenInclude(p => p.InventaryProfile)
                      .Include(x => x.Team).ThenInclude(p => p.Shirts)
                      .Include(x => x.Team).ThenInclude(p => p.Availability)
                      .Include(x => x.Team).ThenInclude(p => p.Tags)
                      .Include(x => x.Team).ThenInclude(p => p.Logo)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    #endregion Game

    #region Request

    public static IQueryable<TeamPlayerRequest> ThanIncludePlayer(this IQueryable<TeamPlayerRequest> teamPlayerRequests)
    {
        IQueryable<TeamPlayerRequest> result = teamPlayerRequests
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    public static IQueryable<TeamPlayerRequest> ThanIncludeTeam(this IQueryable<TeamPlayerRequest> teamPlayerRequests)
    {
        IQueryable<TeamPlayerRequest> result = teamPlayerRequests
                      .Include(x => x.Team).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Team).ThenInclude(p => p.FinancialProfile)
                      .Include(x => x.Team).ThenInclude(p => p.InventaryProfile)
                      .Include(x => x.Team).ThenInclude(p => p.Shirts)
                      .Include(x => x.Team).ThenInclude(p => p.Availability)
                      .Include(x => x.Team).ThenInclude(p => p.Tags)
                      .Include(x => x.Team).ThenInclude(p => p.Logo)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    public static IQueryable<GamePlayerRequest> ThanIncludePlayer(this IQueryable<GamePlayerRequest> gamePlayerRequests)
    {
        IQueryable<GamePlayerRequest> result = gamePlayerRequests
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    public static IQueryable<GamePlayerRequest> ThanIncludeGame(this IQueryable<GamePlayerRequest> gamePlayerRequests)
    {
        IQueryable<GamePlayerRequest> result = gamePlayerRequests
                      .Include(x => x.Game).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Game).ThenInclude(p => p.FinancialProfile)
                      .Include(x => x.Game).ThenInclude(p => p.InventaryProfile)
                      .Include(x => x.Game).ThenInclude(p => p.Availability)
                      .Include(x => x.Game).ThenInclude(p => p.Tags)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    public static IQueryable<GameTeamRequest> ThanIncludeTeam(this IQueryable<GameTeamRequest> gameTeamRequests)
    {
        IQueryable<GameTeamRequest> result = gameTeamRequests
                      .Include(x => x.Team).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Team).ThenInclude(p => p.FinancialProfile)
                      .Include(x => x.Team).ThenInclude(p => p.InventaryProfile)
                      .Include(x => x.Team).ThenInclude(p => p.Shirts)
                      .Include(x => x.Team).ThenInclude(p => p.Availability)
                      .Include(x => x.Team).ThenInclude(p => p.Tags)
                      .Include(x => x.Team).ThenInclude(p => p.Logo)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Team).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    public static IQueryable<GameTeamRequest> ThanIncludeGame(this IQueryable<GameTeamRequest> gameTeamRequests)
    {
        IQueryable<GameTeamRequest> result = gameTeamRequests
                      .Include(x => x.Game).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Game).ThenInclude(p => p.FinancialProfile)
                      .Include(x => x.Game).ThenInclude(p => p.InventaryProfile)
                      .Include(x => x.Game).ThenInclude(p => p.Availability)
                      .Include(x => x.Game).ThenInclude(p => p.Tags)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Game).ThenInclude(p => p.Players).ThenInclude(x => x.Player).ThenInclude(p => p.Photo);

        return result;
    }

    #endregion Request
}
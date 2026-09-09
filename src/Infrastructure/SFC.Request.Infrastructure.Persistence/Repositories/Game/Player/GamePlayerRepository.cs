using Microsoft.EntityFrameworkCore;

using SFC.Request.Application.Features.Common.Models.Find;
using SFC.Request.Application.Features.Common.Models.Find.Paging;
using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Player;
using SFC.Request.Domain.Entities.Game.Player;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Extensions;
using SFC.Request.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Game.Player;
public class GamePlayerRepository(GameDbContext context)
    : Repository<GamePlayer, GameDbContext, long>(context), IGamePlayerRepository
{
    public override Task<PagedList<GamePlayer>> FindAsync(FindParameters<GamePlayer> parameters)
    {
        return Context.GamePlayers
                      .ThanIncludePlayer()
                      .AsQueryable()
                      .PaginateAsync(parameters);
    }

    public Task<GamePlayer?> GetByIdAsync(long gameId, long playerId)
    {
        return Context.GamePlayers.FirstOrDefaultAsync(item => item.GameId == gameId && item.Player.Id == playerId);
    }

    public Task<bool> AnyAsync(long id)
    {
        return Context.GamePlayers.AnyAsync(item => item.Id == id);
    }

    public Task<bool> AnyAsync(long gameId, long playerId)
    {
        return Context.GamePlayers.AnyAsync(item => item.GameId == gameId && item.Player.Id == playerId);
    }

    public Task<bool> AnyAsync(long gameId, long playerId, GamePlayerStatusEnum status)
    {
        return Context.GamePlayers.AnyAsync(GamePlayer =>
            GamePlayer.GameId == gameId &&
            GamePlayer.StatusId == status &&
            GamePlayer.Player.Id == playerId);
    }

    public async Task<GamePlayer[]> AddRangeIfNotExistsAsync(params GamePlayer[] entities)
    {
        await Context.Set<GamePlayer>().AddRangeIfNotExistsAsync<GamePlayer, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }
}
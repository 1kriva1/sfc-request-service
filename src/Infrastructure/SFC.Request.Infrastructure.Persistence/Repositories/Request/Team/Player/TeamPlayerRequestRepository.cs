using Microsoft.EntityFrameworkCore;

using SFC.Request.Application.Features.Common.Models.Find;
using SFC.Request.Application.Features.Common.Models.Find.Paging;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Team.Player;
using SFC.Request.Domain.Entities.Request.Team.Player;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Extensions;
using SFC.Request.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Request.Team.Player;
public class TeamPlayerRequestRepository(RequestDbContext context)
    : Repository<TeamPlayerRequest, RequestDbContext, long>(context), ITeamPlayerRequestRepository
{
    #region Public

    public Task<bool> AnyAsync(long id)
    {
        return Context.TeamPlayerRequests.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.TeamPlayerRequests.AnyAsync(u => u.Id == id && u.UserId == userId);
    }
    public Task<bool> AnyAsync(long teamId, long playerId, RequestStatusEnum status)
    {
        return Context.TeamPlayerRequests.AnyAsync(request =>
            request.TeamId == teamId &&
            request.StatusId == status &&
            request.Player.Id == playerId);
    }

    public Task<TeamPlayerRequest?> GetByIdAsync(long id, long teamId, long playerId)
    {
        return Context.TeamPlayerRequests
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo)
                      .FirstOrDefaultAsync(request => request.Id == id && request.TeamId == teamId && request.Player.Id == playerId);
    }

    public async Task<IEnumerable<TeamPlayerRequest>> GetByIdsAsync(IEnumerable<long> teamIds, IEnumerable<long> playerIds)
    {
        return await Context.TeamPlayerRequests
                            .Where(request => teamIds.Contains(request.TeamId) && playerIds.Contains(request.PlayerId))
                            .ToListAsync()
                            .ConfigureAwait(true);
    }


    public async Task<TeamPlayerRequest[]> AddRangeIfNotExistsAsync(params TeamPlayerRequest[] entities)
    {
        await Context.Set<TeamPlayerRequest>().AddRangeIfNotExistsAsync<TeamPlayerRequest, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }

    #endregion Public

    #region Ovveride

    public override Task<PagedList<TeamPlayerRequest>> FindAsync(FindParameters<TeamPlayerRequest> parameters)
    {
        return Context.TeamPlayerRequests
                      .Include(x => x.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(x => x.Player).ThenInclude(p => p.FootballProfile)
                      .Include(x => x.Player).ThenInclude(p => p.Availability)
                      .Include(x => x.Player).ThenInclude(p => p.Availability.Days)
                      .Include(x => x.Player).ThenInclude(p => p.Points)
                      .Include(x => x.Player).ThenInclude(p => p.Tags)
                      .Include(x => x.Player).ThenInclude(p => p.Stats)
                      .Include(x => x.Player).ThenInclude(p => p.Photo)
                      .AsQueryable<TeamPlayerRequest>()
                      .PaginateAsync(parameters);
    }

    #endregion Ovveride
}
using SFC.Request.Application.Common.Dto.Team.General;

namespace SFC.Request.Application.Interfaces.Team.General;
public interface ITeamService
{
    Task<TeamDto?> GetTeamAsync(long id, CancellationToken cancellationToken = default);
}
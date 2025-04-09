using SFC.Request.Domain.Entities.Team.Data;

namespace SFC.Request.Application.Interfaces.Persistence.Repository.Team.Data;
public interface ITeamPlayerStatusRepository : ITeamDataRepository<TeamPlayerStatus, TeamPlayerStatusEnum> { }
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Request.Domain.Common;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Team.Data;
public class TeamDataRepository<TEntity, TEnum>(TeamDbContext context)
    : DataRepository<TEntity, TeamDbContext, TEnum>(context), ITeamDataRepository<TEntity, TEnum>
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }
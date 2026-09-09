using SFC.Request.Application.Interfaces.Persistence.Repository.Game.Data;
using SFC.Request.Domain.Common;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Game.Data;
public class GameDataRepository<TEntity, TEnum>(GameDbContext context)
    : DataRepository<TEntity, GameDbContext, TEnum>(context), IGameDataRepository<TEntity, TEnum>
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }
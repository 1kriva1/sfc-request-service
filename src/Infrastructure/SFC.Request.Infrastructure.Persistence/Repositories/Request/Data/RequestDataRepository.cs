using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Data;
using SFC.Request.Domain.Common;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Request.Data;
public class RequestDataRepository<TEntity, TEnum>(RequestDbContext context)
     : DataRepository<TEntity, RequestDbContext, TEnum>(context), IRequestDataRepository<TEntity, TEnum>
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }
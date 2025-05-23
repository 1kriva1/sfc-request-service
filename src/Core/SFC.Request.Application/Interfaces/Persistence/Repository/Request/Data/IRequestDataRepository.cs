using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Application.Interfaces.Persistence.Repository.Common.Data;
using SFC.Request.Domain.Common;

namespace SFC.Request.Application.Interfaces.Persistence.Repository.Request.Data;
public interface IRequestDataRepository<T, TEnum> : IDataRepository<T, IRequestDbContext, TEnum>
    where T : EnumDataEntity<TEnum>
    where TEnum : struct
{
}
using SFC.Request.Domain.Entities.Data;

namespace SFC.Request.Application.Interfaces.Persistence.Repository.Data;
public interface IStatTypeRepository : IDataRepository<StatType, StatTypeEnum>
{
    Task<int> CountAsync();
}
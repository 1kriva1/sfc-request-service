using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Domain.Common;
public class DataEntity<TId> : BaseEntity<TId>, IDataEntity
{
    public DateTime CreatedDate { get; set; }
}
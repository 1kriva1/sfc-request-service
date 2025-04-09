using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Data;
public class WorkingFoot : EnumDataEntity<WorkingFootEnum>
{
    public WorkingFoot() : base() { }

    public WorkingFoot(WorkingFootEnum enumType) : base(enumType) { }
}
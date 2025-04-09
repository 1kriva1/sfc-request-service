using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Data;
public class StatType : EnumDataEntity<StatTypeEnum>
{
    public StatType() : base() { }

    public StatType(StatTypeEnum enumType) : base(enumType) { }

    public StatCategoryEnum CategoryId { get; set; }

    public StatSkillEnum SkillId { get; set; }
}
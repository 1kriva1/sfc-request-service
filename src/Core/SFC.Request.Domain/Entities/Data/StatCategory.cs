using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Data;
public class StatCategory : EnumDataEntity<StatCategoryEnum>
{
    public StatCategory() : base() { }

    public StatCategory(StatCategoryEnum enumType) : base(enumType) { }

    public ICollection<StatType> Types { get; init; } = [];
}
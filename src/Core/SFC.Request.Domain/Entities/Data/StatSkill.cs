﻿using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Data;
public class StatSkill : EnumDataEntity<StatSkillEnum>
{
    public StatSkill() : base() { }

    public StatSkill(StatSkillEnum enumType) : base(enumType) { }

    public ICollection<StatType> Types { get; init; } = [];
}
﻿using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Team.Data;
public class TeamPlayerStatus : EnumDataEntity<TeamPlayerStatusEnum>
{
    public TeamPlayerStatus() : base() { }

    public TeamPlayerStatus(TeamPlayerStatusEnum enumType) : base(enumType) { }
}
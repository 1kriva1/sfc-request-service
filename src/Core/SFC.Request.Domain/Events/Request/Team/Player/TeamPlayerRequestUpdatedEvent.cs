﻿using SFC.Request.Domain.Common;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Domain.Events.Request.Team.Player;
public class TeamPlayerRequestUpdatedEvent(TeamPlayerRequest entity) : BaseEvent
{
    public TeamPlayerRequest Request { get; } = entity;
}
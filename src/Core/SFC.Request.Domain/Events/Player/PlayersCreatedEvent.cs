﻿using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Events.Player;
public class PlayersCreatedEvent(IEnumerable<PlayerEntity> players) : BaseEvent
{
    public IEnumerable<PlayerEntity> Players { get; } = players;
}
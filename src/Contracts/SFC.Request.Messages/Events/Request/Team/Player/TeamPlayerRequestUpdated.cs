﻿using SFC.Request.Messages.Models.Request.Team.Player;

namespace SFC.Request.Messages.Events.Request.Team.Player;
public class TeamPlayerRequestUpdated
{
    public required TeamPlayerRequest Request { get; set; }
}
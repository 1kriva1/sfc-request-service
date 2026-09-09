using System.ComponentModel;

namespace SFC.Request.Domain.Enums.Game;

public enum GameTeamStatus
{
    [Description("In Game")]
    InGame = 0,
    [Description("Out Of Game")]
    OutOfGame = 1
}
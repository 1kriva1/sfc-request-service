using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Domain.Entities.Request.Game.Player;

public class GamePlayerRequest : RequestEntity, IPlayerEntity, IGameEntity
{
    public long GameId { get; set; }

    public GameEntity Game { get; set; } = default!;

    public string? GameComment { get; set; }

    public long PlayerId { get; set; }

    public PlayerEntity Player { get; set; } = default!;

    public required string PlayerComment { get; set; }
}
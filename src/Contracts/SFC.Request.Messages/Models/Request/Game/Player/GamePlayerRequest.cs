using SFC.Request.Messages.Models.Common;

namespace SFC.Request.Messages.Models.Request.Game.Player;

public class GamePlayerRequest : Auditable
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public string? GameComment { get; set; }

    public required string PlayerComment { get; set; }
}
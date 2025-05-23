using SFC.Request.Messages.Models.Common;

namespace SFC.Request.Messages.Models.Request.Team.Player;
public class TeamPlayerRequest : Auditable
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public required string PlayerComment { get; set; }

    public string? TeamComment { get; set; }
}
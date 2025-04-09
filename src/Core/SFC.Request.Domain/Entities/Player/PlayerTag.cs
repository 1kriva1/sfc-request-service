using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Player;
public class PlayerTag : BasePlayerEntity
{
    public string Value { get; set; } = null!;
}
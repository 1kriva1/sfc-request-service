namespace SFC.Request.Domain.Common.Interfaces;
public interface IPlayerEntity
{
    long PlayerId { get; set; }

    PlayerEntity Player { get; set; }
}
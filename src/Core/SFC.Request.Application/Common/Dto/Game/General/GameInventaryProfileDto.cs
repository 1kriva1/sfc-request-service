using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Game.General;

namespace SFC.Request.Application.Common.Dto.Game.General;
public class GameInventaryProfileDto : IMapFromReverse<GameInventaryProfile>
{
    public bool ShirtsRequired { get; set; }

    public int? ShirtsCount { get; set; }
}
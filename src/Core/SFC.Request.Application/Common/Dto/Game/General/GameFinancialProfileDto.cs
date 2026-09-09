using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Game.General;

namespace SFC.Request.Application.Common.Dto.Game.General;
public class GameFinancialProfileDto : IMapFromReverse<GameFinancialProfile>
{
    public bool FreeGame { get; set; }

    public decimal? PayAmount { get; set; }
}
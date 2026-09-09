using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Application.Common.Dto.Game.General;
public class GameProfileDto : IMapFrom<GameEntity>
{
    public required GameGeneralProfileDto General { get; set; }

    public required GameFinancialProfileDto Financial { get; set; }

    public required GameInventaryProfileDto Inventary { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<GameEntity, GameProfileDto>()
               .ForMember(p => p.General, d => d.MapFrom(z => z))
               .ForMember(p => p.Financial, d => d.MapFrom(z => z.FinancialProfile))
               .ForMember(p => p.Inventary, d => d.MapFrom(z => z.InventaryProfile));
    }
}
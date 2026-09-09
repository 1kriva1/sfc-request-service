using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Exist;
public class GamePlayerRequestExistViewModel : IMapFrom<bool>
{
    public bool Exist { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<bool, GamePlayerRequestExistViewModel>()
               .ConvertUsing(exist => new GamePlayerRequestExistViewModel { Exist = exist });
    }
}
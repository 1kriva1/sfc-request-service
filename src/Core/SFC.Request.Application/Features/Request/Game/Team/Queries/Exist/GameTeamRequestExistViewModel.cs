using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Exist;
public class GameTeamRequestExistViewModel : IMapFrom<bool>
{
    public bool Exist { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<bool, GameTeamRequestExistViewModel>()
               .ConvertUsing(exist => new GameTeamRequestExistViewModel { Exist = exist });
    }
}
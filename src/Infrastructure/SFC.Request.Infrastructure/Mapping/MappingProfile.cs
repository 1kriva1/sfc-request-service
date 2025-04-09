using System.Reflection;

using Google.Protobuf.WellKnownTypes;

using SFC.Request.Application.Common.Dto.Identity;
using SFC.Request.Application.Common.Dto.Player.General;
using SFC.Request.Application.Common.Dto.Team.General;
using SFC.Request.Application.Common.Dto.Team.Player;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Base;
using SFC.Request.Application.Features.Data.Commands.Reset;
using SFC.Request.Application.Features.Data.Common.Dto;
using SFC.Request.Application.Features.Identity.Commands.Create;
using SFC.Request.Application.Features.Identity.Commands.CreateRange;
using SFC.Request.Application.Features.Player.Commands.Create;
using SFC.Request.Application.Features.Player.Commands.CreateRange;
using SFC.Request.Application.Features.Player.Commands.Update;
using SFC.Request.Application.Features.Team.Data.Commands.Reset;
using SFC.Request.Application.Features.Team.Data.Common.Dto;
using SFC.Request.Application.Features.Team.General.Commands.Create;
using SFC.Request.Application.Features.Team.General.Commands.CreateRange;
using SFC.Request.Application.Features.Team.General.Commands.Update;
using SFC.Request.Application.Features.Team.Player.Commands.Create;
using SFC.Request.Application.Features.Team.Player.Commands.CreateRange;
using SFC.Request.Application.Features.Team.Player.Commands.Update;
using SFC.Request.Domain.Entities.Request.General;
using SFC.Request.Messages.Commands.Data;
using SFC.Request.Messages.Events.Request;
using SFC.Request.Messages.Models;

namespace SFC.Request.Infrastructure.Mapping;
public class MappingProfile : BaseMappingProfile
{
    protected override Assembly Assembly => Assembly.GetExecutingAssembly();

    public MappingProfile() : base()
    {
        ApplyCustomMappings();
    }

    private void ApplyCustomMappings()
    {
        #region Simple types       

        CreateMap<Timestamp, DateTime>()
           .ConvertUsing(value => value.ToDateTime());

        CreateMap<Duration, TimeSpan>()
            .ConvertUsing(value => value.ToTimeSpan());

        #endregion Simple types

        #region Data

        // messages        
        CreateMapDataMessages();

        #endregion Data

        #region Identity

        // messages        
        CreateMapIdentityMessages();

        // contracts        
        CreateMapIdentityContracts();

        #endregion Identity

        #region Player

        // messages
        CreateMapPlayerMessages();

        // contracts
        CreateMapPlayerContracts();

        #endregion Player

        #region Team
        CreateMapTeamMessages();
        #endregion Team

        #region Request

        // messages
        CreateMapRequestMessages();

        // contracts
        CreateMapRequestContracts();

        #endregion Request
    }

    #region Data

    private void CreateMapDataMessages()
    {
        CreateMap<SFC.Data.Messages.Events.DataInitialized, ResetDataCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, FootballPositionDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, GameStyleDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, StatCategoryDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, StatSkillDto>();
        CreateMap<SFC.Data.Messages.Models.Stats.StatTypeDataValue, StatTypeDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, WorkingFootDto>();
        CreateMap<SFC.Data.Messages.Models.Common.DataValue, ShirtDto>();
    }

    #endregion Data

    #region Identity

    private void CreateMapIdentityMessages()
    {
        CreateMap<SFC.Identity.Messages.Events.UserCreated, CreateUserCommand>().IgnoreAllNonExisting();

        CreateMap<IEnumerable<SFC.Identity.Messages.Models.User>, CreateUsersCommand>()
            .ForMember(p => p.Users, d => d.MapFrom(z => z));

        CreateMap<SFC.Identity.Messages.Models.User, UserDto>();
    }

    private void CreateMapIdentityContracts()
    {
        CreateMap<Guid, SFC.Identity.Contracts.Messages.Get.GetUserRequest>()
            .ConvertUsing(id => new SFC.Identity.Contracts.Messages.Get.GetUserRequest { Id = id.ToString() });
        CreateMap<SFC.Identity.Contracts.Models.Get.User, UserDto>();
    }

    #endregion Identity

    #region Player

    private void CreateMapPlayerMessages()
    {
        CreateMap<SFC.Player.Messages.Events.PlayerCreated, CreatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<SFC.Player.Messages.Events.PlayerUpdated, UpdatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<SFC.Player.Messages.Events.PlayerUpdated, CreatePlayerCommand>().IgnoreAllNonExisting();

        CreateMap<IEnumerable<SFC.Player.Messages.Models.Player.Player>, CreatePlayersCommand>()
            .ForMember(p => p.Players, d => d.MapFrom(z => z));

        CreateMap<SFC.Player.Messages.Commands.Player.SeedPlayers, CreatePlayersCommand>();

        CreateMap<SFC.Player.Messages.Models.Player.Player, PlayerDto>()
            .ForPath(p => p.Stats.Values, d => d.MapFrom(z => z.Stats))
            .ForPath(p => p.Stats.Points, d => d.MapFrom(z => z.Points))
            .ForPath(p => p.Profile.General, d => d.MapFrom(z => z.GeneralProfile))
            .ForPath(p => p.Profile.Football, d => d.MapFrom(z => z.FootballProfile))
            .ForPath(p => p.Profile.General.Photo, d => d.MapFrom(z => z.Photo))
            .ForPath(p => p.Profile.General.Availability, d => d.MapFrom(z => z.Availability))
            .ForPath(p => p.Profile.General.Tags, d => d.MapFrom(z => z.Tags));

        // stats
        CreateMap<SFC.Player.Messages.Models.Player.PlayerStat, PlayerStatValueDto>()
            .ForPath(p => p.Type, d => d.MapFrom(z => z.TypeId));
        CreateMap<SFC.Player.Messages.Models.Player.PlayerStatPoints, PlayerStatPointsDto>();

        // general profile
        CreateMap<SFC.Player.Messages.Models.Player.PlayerGeneralProfile, PlayerGeneralProfileDto>();
        CreateMap<SFC.Player.Messages.Models.Player.PlayerPhoto, PlayerPhotoDto>();
        CreateMap<SFC.Player.Messages.Models.Player.PlayerAvailability, PlayerAvailabilityDto>();
        CreateMap<SFC.Player.Messages.Models.Player.PlayerAvailableDay, DayOfWeek>().ConvertUsing(day => day.Day);
        CreateMap<SFC.Player.Messages.Models.Player.PlayerTag, string>().ConvertUsing(tag => tag.Value);

        // football profile
        CreateMap<SFC.Player.Messages.Models.Player.PlayerFootballProfile, PlayerFootballProfileDto>()
            .ForPath(p => p.AdditionalPosition, d => d.MapFrom(z => z.AdditionalPositionId))
            .ForPath(p => p.Position, d => d.MapFrom(z => z.PositionId))
            .ForPath(p => p.GameStyle, d => d.MapFrom(z => z.GameStyleId))
            .ForPath(p => p.WorkingFoot, d => d.MapFrom(z => z.WorkingFootId));
    }

    private void CreateMapPlayerContracts()
    {
        CreateMap<long, SFC.Player.Contracts.Messages.Get.GetPlayerRequest>()
            .ConvertUsing(id => new SFC.Player.Contracts.Messages.Get.GetPlayerRequest { Id = id });

        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayer, PlayerDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerProfile, PlayerProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerGeneralProfile, PlayerGeneralProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Common.Player.PlayerAvailability, PlayerAvailabilityDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerFootballProfile, PlayerFootballProfileDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerStats, PlayerStatsDto>();
        CreateMap<SFC.Player.Contracts.Models.Get.GetPlayerStatPoints, PlayerStatPointsDto>();
        CreateMap<SFC.Player.Contracts.Models.Common.Player.PlayerStatValue, PlayerStatValueDto>();
    }

    #endregion Player

    #region Team

    private void CreateMapTeamMessages()
    {
        // data
        // events
        CreateMap<SFC.Team.Messages.Events.Data.DataInitialized, ResetTeamDataCommand>().IgnoreAllNonExisting();
        // models
        CreateMap<SFC.Team.Messages.Models.Common.DataValue, TeamPlayerStatusDto>();

        // domain
        // team
        // events
        CreateMap<SFC.Team.Messages.Events.Team.General.TeamCreated, CreateTeamCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Team.Messages.Events.Team.General.TeamUpdated, UpdateTeamCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Team.Messages.Events.Team.General.TeamUpdated, CreateTeamCommand>().IgnoreAllNonExisting();
        // commands
        CreateMap<SFC.Team.Messages.Commands.Team.General.SeedTeams, CreateTeamsCommand>();
        // models
        CreateMap<IEnumerable<SFC.Team.Messages.Models.Team.General.Team>, CreateTeamsCommand>()
           .ForMember(p => p.Teams, d => d.MapFrom(z => z));
        CreateMap<SFC.Team.Messages.Models.Team.General.Team, TeamDto>()
           .ForPath(p => p.Profile.General, d => d.MapFrom(z => z.GeneralProfile))
           .ForPath(p => p.Profile.Financial, d => d.MapFrom(z => z.FinancialProfile))
           .ForPath(p => p.Profile.Inventary.Shirts, d => d.MapFrom(z => z.Shirts))
           .ForPath(p => p.Profile.General.Logo, d => d.MapFrom(z => z.Logo))
           .ForPath(p => p.Profile.General.Availability, d => d.MapFrom(z => z.Availability))
           .ForPath(p => p.Profile.General.Tags, d => d.MapFrom(z => z.Tags));
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamGeneralProfile, TeamGeneralProfileDto>();
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamFinancialProfile, TeamFinancialProfileDto>();
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamLogo, TeamLogoDto>();
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamAvailability, TeamAvailabilityDto>();
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamTag, string>().ConvertUsing(tag => tag.Value);
        CreateMap<SFC.Team.Messages.Models.Team.General.TeamShirt, int>().ConvertUsing(shirt => shirt.ShirtId);
        // team player
        // events
        CreateMap<SFC.Team.Messages.Events.Team.Player.TeamPlayerCreated, CreateTeamPlayerCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Team.Messages.Events.Team.Player.TeamPlayerUpdated, UpdateTeamPlayerCommand>().IgnoreAllNonExisting();
        // models
        CreateMap<IEnumerable<SFC.Team.Messages.Models.Team.Player.TeamPlayer>, CreateTeamPlayersCommand>()
           .ForMember(p => p.TeamPlayers, d => d.MapFrom(z => z));
        CreateMap<SFC.Team.Messages.Models.Team.Player.TeamPlayer, TeamPlayerDto>();
    }

    #endregion Team

    #region Request

    private void CreateMapRequestMessages()
    {
        // data
        //commands
        CreateMap<SFC.Request.Messages.Commands.Data.InitializeData, ResetDataCommand>().IgnoreAllNonExisting();
        CreateMap<SFC.Request.Messages.Models.Data.DataValue, FootballPositionDto>();
        CreateMap<SFC.Request.Messages.Models.Data.DataValue, GameStyleDto>();
        CreateMap<SFC.Request.Messages.Models.Data.DataValue, StatCategoryDto>();
        CreateMap<SFC.Request.Messages.Models.Data.DataValue, StatSkillDto>();
        CreateMap<SFC.Request.Messages.Models.Data.StatTypeDataValue, StatTypeDto>();
        CreateMap<SFC.Request.Messages.Models.Data.DataValue, WorkingFootDto>();
        CreateMap<SFC.Request.Messages.Models.Data.DataValue, ShirtDto>();

        // team
        // commands
        CreateMap<SFC.Request.Messages.Commands.Team.Data.InitializeData, ResetTeamDataCommand>().IgnoreAllNonExisting();
        //models
        CreateMap<SFC.Request.Messages.Models.Data.DataValue, TeamPlayerStatusDto>();

        // general template
        // events
        CreateMap<RequestEntity, SFC.Request.Messages.Events.Request.RequestCreated>()
            .ForMember(p => p.Request, d => d.MapFrom(z => z));
        CreateMap<RequestEntity, SFC.Request.Messages.Events.Request.RequestUpdated>()
            .ForMember(p => p.Request, d => d.MapFrom(z => z));
        CreateMap<IEnumerable<RequestEntity>, SFC.Request.Messages.Events.Request.RequestsSeeded>()
           .ForMember(p => p.Requests, d => d.MapFrom(z => z));
        //commands
        CreateMap<IEnumerable<RequestEntity>, SFC.Request.Messages.Commands.Request.SeedRequests>()
            .ForMember(p => p.Requests, d => d.MapFrom(z => z));
        // models
        CreateMap<RequestEntity, SFC.Request.Messages.Models.Request.Request>();
    }

    private static void CreateMapRequestContracts()
    {

    }

    #endregion Request
}
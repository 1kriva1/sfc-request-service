using AutoMapper;

using SFC.Request.Application.Common.Dto.Common;
using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Application.Common.Dto.Player.General;
public class PlayerDto : AuditableDto, IMapFromReverse<PlayerEntity>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public PlayerProfileDto Profile { get; set; } = null!;

    public PlayerStatsDto Stats { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerDto, PlayerEntity>()
                .ForMember(p => p.GeneralProfile, d => d.MapFrom(z => z.Profile.General))
                .ForMember(p => p.FootballProfile, d => d.MapFrom(z => z.Profile.Football))
                .ForMember(p => p.Availability, d => d.MapFrom(z => z.Profile.General.Availability))
                .ForMember(p => p.Points, d => d.MapFrom(z => z.Stats.Points))
                .ForMember(p => p.Photo, d => d.MapFrom(z => z.Profile.General.Photo))
                .ForMember(p => p.Tags, d => d.MapFrom(z => z.Profile.General.Tags))
                .ForMember(p => p.Stats, d => d.MapFrom(z => z.Stats.Values))
                .ForMember(p => p.DomainEvents, d => d.Ignore());

        profile.CreateMap<PlayerEntity, PlayerDto>()
                .ForPath(p => p.Stats.Values, d => d.MapFrom(z => z.Stats))
                .ForPath(p => p.Stats.Points, d => d.MapFrom(z => z.Points))
                .ForPath(p => p.Profile.General, d => d.MapFrom(z => z.GeneralProfile))
                .ForPath(p => p.Profile.Football, d => d.MapFrom(z => z.FootballProfile))
                .ForPath(p => p.Profile.General.Photo, d => d.MapFrom(z => z.Photo))
                .ForPath(p => p.Profile.General.Availability, d => d.MapFrom(z => z.Availability))
                .ForPath(p => p.Profile.General.Tags, d => d.MapFrom(z => z.Tags));
    }
}
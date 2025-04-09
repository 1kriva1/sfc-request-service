using AutoMapper;

using SFC.Request.Application.Common.Dto.Common;
using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Application.Common.Dto.Team.General;
public class TeamDto : AuditableDto, IMapFromReverse<TeamEntity>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public TeamProfileDto Profile { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamDto, TeamEntity>()
                .ForMember(p => p.GeneralProfile, d => d.MapFrom(z => z.Profile.General))
                .ForMember(p => p.FinancialProfile, d => d.MapFrom(z => z.Profile.Financial))
                .ForMember(p => p.Availability, d => d.MapFrom(z => z.Profile.General.Availability))
                .ForMember(p => p.Logo, d => d.MapFrom(z => z.Profile.General.Logo))
                .ForMember(p => p.Tags, d => d.MapFrom(z => z.Profile.General.Tags))
                .ForMember(p => p.Shirts, d => d.MapFrom(z => z.Profile.Inventary.Shirts))
                .ForMember(p => p.DomainEvents, d => d.Ignore());

        profile.CreateMap<TeamEntity, TeamDto>()
                .ForPath(p => p.Profile.General, d => d.MapFrom(z => z.GeneralProfile))
                .ForPath(p => p.Profile.Financial, d => d.MapFrom(z => z.FinancialProfile))
                .ForPath(p => p.Profile.General.Logo, d => d.MapFrom(z => z.Logo))
                .ForPath(p => p.Profile.General.Availability, d => d.MapFrom(z => z.Availability))
                .ForPath(p => p.Profile.General.Tags, d => d.MapFrom(z => z.Tags))
                .ForPath(p => p.Profile.Inventary.Shirts, d => d.MapFrom(z => z.Shirts));
    }
}
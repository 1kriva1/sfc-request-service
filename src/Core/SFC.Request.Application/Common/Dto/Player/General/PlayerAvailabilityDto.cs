using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Player;

namespace SFC.Request.Application.Common.Dto.Player.General;

public record PlayerAvailabilityDto : IMapFromReverse<PlayerAvailability>
{
    public TimeSpan? From { get; set; }

    public TimeSpan? To { get; set; }

    public IEnumerable<DayOfWeek> Days { get; set; } = [];

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PlayerAvailabilityDto, PlayerAvailability>()
               .ReverseMap()
               .IgnoreAllNonExisting();
    }
}
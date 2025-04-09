using SFC.Request.Application.Features.Common.Dto.Common;

namespace SFC.Request.Application.Common.Dto.Player.Filters;
public class PlayerGeneralProfileFilterDto
{
    public string? Name { get; set; }

    public string? City { get; set; }

    public IEnumerable<string> Tags { get; set; } = [];

    public RangeLimitDto<short?> Years { get; set; } = default!;

    public PlayerAvailabilityLimitFilterDto Availability { get; set; } = default!;

    public bool? FreePlay { get; set; }

    public bool? HasPhoto { get; set; }
}
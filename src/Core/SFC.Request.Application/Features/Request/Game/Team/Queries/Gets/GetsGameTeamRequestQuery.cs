using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Gets;

public class GetsGameTeamRequestQuery : Request<GetsGameTeamRequestViewModel>
{
    public override RequestId RequestId { get => RequestId.GetsGameTeamRequest; }

    public long GameId { get; set; }
}
using SFC.Request.Application.Common.Enums;
using SFC.Request.Application.Features.Common.Base;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Get;

public class GetGameTeamRequestQuery : Request<GetGameTeamRequestViewModel>
{
    public override RequestId RequestId { get => RequestId.GetGameTeamRequest; }

    public long Id { get; set; }

    public long GameId { get; set; }

    public long TeamId { get; set; }
}
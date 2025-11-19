using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Request.Api.Infrastructure.Extensions;
using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Pagination;
using SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Create;
using SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Find;
using SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Get;
using SFC.Request.Api.Infrastructure.Models.Request.Team.Player.GetAll;
using SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Update.Decline;
using SFC.Request.Application.Features.Common.Base;
using SFC.Request.Application.Features.Request.Team.Player.Commands.Create;
using SFC.Request.Application.Features.Request.Team.Player.Commands.Update;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Dto.Filters;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Get;
using SFC.Request.Application.Features.Request.Team.Player.Queries.GetAll;
using SFC.Request.Infrastructure.Constants;

namespace SFC.Request.Api.Controllers;

[Tags("Team Player Requests")]
[Route("api/Requests")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class TeamPlayerRequestsController : ApiControllerBase
{
    /// <summary>
    /// Create new player request for team.
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="request">Create player request for team request.</param>
    /// <returns>An ActionResult of type CreateTeamPlayerRequestResponse</returns>
    /// <response code="201">Returns **new** created team player request.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPost("Teams/{teamId}/Players/{playerId}")]
    [Authorize(Policy.OwnPlayer)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CreateTeamPlayerRequestResponse>> CreateTeamPlayerRequestAsync(
        [FromRoute] long teamId, [FromRoute] long playerId, [FromBody] CreateTeamPlayerRequestRequest request)
    {
        CreateTeamPlayerRequestCommand command = Mapper.Map<CreateTeamPlayerRequestCommand>(request)
                                                       .SetTeamId(teamId)
                                                       .SetPlayerId(playerId);

        CreateTeamPlayerRequestViewModel model = await Mediator.Send(command)
                                                              .ConfigureAwait(false);

        return CreatedAtRoute("GetTeamPlayerRequest",
            new { teamId = model.Request.Team.Id, playerId = model.Request.Player.Id, requestId = model.Request.Id },
            Mapper.Map<CreateTeamPlayerRequestResponse>(model));
    }

    /// <summary>
    /// Player cancel his/her request to join team team.
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="requestId">Team player request Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if request **successfully** canceled.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when request **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{requestId}/Teams/{teamId}/Players/{playerId}/Cancel")]
    [Authorize(Policy.OwnPlayer)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CancelTeamPlayerRequestAsync(
        [FromRoute] long teamId, [FromRoute] long playerId, [FromRoute] long requestId)
    {
        UpdateTeamPlayerRequestCommand command = RequestStatusEnum.Canceled
            .BuildUpdateTeamPlayerRequestCommand(requestId, teamId, playerId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Decline team request from player by team.
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="requestId">Team player request Id.</param>
    /// <param name="request">Decline team request from player request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if request **successfully** declined.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when request **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{requestId}/Teams/{teamId}/Players/{playerId}/Decline")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> DeclineTeamPlayerRequestAsync(
        [FromRoute] long teamId, [FromRoute] long playerId, [FromRoute] long requestId, [FromBody] DeclineTeamPlayerRequestRequest request)
    {
        UpdateTeamPlayerRequestCommand command = Mapper.Map<UpdateTeamPlayerRequestCommand>(request)
                                                       .SetId(requestId)
                                                       .SetTeamId(teamId)
                                                       .SetPlayerId(playerId)
                                                       .SetStatus(RequestStatusEnum.Declined);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Accept team request from player by team.
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="requestId">Team player request Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if request **successfully** accepted.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when request **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{requestId}/Teams/{teamId}/Players/{playerId}/Accept")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> AcceptTeamPlayerRequestAsync(
        [FromRoute] long teamId, [FromRoute] long playerId, [FromRoute] long requestId)
    {
        UpdateTeamPlayerRequestCommand command = RequestStatusEnum.Accepted
            .BuildUpdateTeamPlayerRequestCommand(requestId, teamId, playerId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return player request for team.
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="requestId">Team player request Id.</param>
    /// <returns>An ActionResult of type GetTeamPlayerRequestResponse</returns>
    /// <response code="200">Returns player request for team model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when request **not found**.</response>
    [HttpGet("{requestId}/Teams/{teamId}/Players/{playerId}", Name = "GetTeamPlayerRequest")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetTeamPlayerRequestResponse>> GetTeamPlayerRequestAsync(
        [FromRoute] long teamId, [FromRoute] long playerId, [FromRoute] long requestId)
    {
        GetTeamPlayerRequestQuery query = new() { Id = requestId, TeamId = teamId, PlayerId = playerId };

        GetTeamPlayerRequestViewModel request = await Mediator.Send(query)
                                                            .ConfigureAwait(false);

        return Ok(Mapper.Map<GetTeamPlayerRequestResponse>(request));
    }

    /// <summary>
    /// Return team player request models by team Id.
    /// </summary>
    /// <param name="teamId">Team unique identifier.</param>
    /// <returns>An ActionResult of type GetAllTeamPlayerRequestsResponse</returns>
    /// <response code="200">Returns team player request models.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Teams/{teamId}/Players")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetAllTeamPlayerRequestsResponse>> GetTeamPlayerRequestsAsync([FromRoute] long teamId)
    {
        GetAllTeamPlayerRequestsQuery query = new() { TeamId = teamId };

        GetAllTeamPlayerRequestsViewModel teamPlayerRequests = await Mediator.Send(query).ConfigureAwait(false);

        return Ok(Mapper.Map<GetAllTeamPlayerRequestsResponse>(teamPlayerRequests));
    }

    /// <summary>
    /// Return list of team player requests.
    /// </summary>
    /// <param name="teamId">Team unique identifier.</param>
    /// <param name="request">Get team player requests request.</param>
    /// <returns>An ActionResult of type GetTeamPlayerRequestsResponse</returns>
    /// <response code="200">Returns list of team player requests with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Teams/{teamId}/Players/Find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetTeamPlayerRequestsResponse>> GetTeamPlayerRequestsAsync([FromRoute] long teamId, [FromQuery] GetTeamPlayerRequestsRequest request)
    {
        BasePaginationRequest<GetTeamPlayerRequestsViewModel, GetTeamPlayerRequestsFilterDto> query =
            Mapper.Map<GetTeamPlayerRequestsQuery>(request)
                  .SetTeamId(teamId);

        GetTeamPlayerRequestsViewModel result = await Mediator.Send(query)
                                                              .ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetTeamPlayerRequestsResponse>(result));
    }
}
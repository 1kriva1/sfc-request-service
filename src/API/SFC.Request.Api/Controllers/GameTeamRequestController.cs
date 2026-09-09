using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Request.Api.Infrastructure.Extensions;
using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Pagination;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Create;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Creates;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Exist;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Find;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Get;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Gets;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Update.Decline;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Team.Update.General;
using SFC.Request.Application.Features.Common.Base;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Create;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Creates;
using SFC.Request.Application.Features.Request.Game.Team.Commands.Update;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Exist;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Find;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Find.Dto.Filters;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Get;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Gets;
using SFC.Request.Infrastructure.Constants;

namespace SFC.Request.Api.Controllers;

/// <summary>
/// Game Team Request controller:
/// - create Request
/// - cancel/accept/refuse Request
/// - get/find Requests
/// </summary>
[Tags("Game Team Requests")]
[Route("api/Requests")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class GameTeamRequestController : ApiControllerBase
{
    /// <summary>
    /// Check if Game Team Request exist.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="status">Game Team status Id.</param>
    /// <returns>An ActionResult of type GameTeamRequestExistResponse</returns>
    /// <response code="200">Returns Game Team Request existence check result.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpGet("Games/{gameId}/Teams/{teamId}")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<GameTeamRequestExistResponse>> GameTeamRequestExistAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromQuery] int? status)
    {
        GameTeamRequestExistQuery query = new() { GameId = gameId, TeamId = teamId, Status = (RequestStatusEnum?)status };

        GameTeamRequestExistViewModel model = await Mediator.Send(query)
                                                           .ConfigureAwait(false);

        return Ok(Mapper.Map<GameTeamRequestExistResponse>(model));
    }

    /// <summary>
    /// Create new Game Request for Team.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="request">Create Game Request for Team request.</param>
    /// <returns>An ActionResult of type CreateGameTeamRequestResponse</returns>
    /// <response code="201">Returns **new** created Game Team Request.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPost("Games/{gameId}/Teams/{teamId}")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CreateGameTeamRequestResponse>> CreateGameTeamRequestAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromBody] CreateGameTeamRequestRequest request)
    {
        CreateGameTeamRequestCommand command = Mapper.Map<CreateGameTeamRequestCommand>(request)
                                                      .SetGameId(gameId)
                                                      .SetTeamId(teamId);

        CreateGameTeamRequestViewModel model = await Mediator.Send(command)
                                                              .ConfigureAwait(false);

        return CreatedAtRoute("GetGameTeamRequest",
            new { gameId, teamId, RequestId = model.Request.Id },
            Mapper.Map<CreateGameTeamRequestResponse>(model));
    }

    /// <summary>
    /// Create new Game Requests for Teams.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="request">Create Game Requests for Teams request.</param>
    /// <returns>An ActionResult of type CreateGameTeamRequestsResponse</returns>
    /// <response code="200">Returns **new** created Game Team Requests.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPost("Games/{gameId}/Teams")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CreatesGameTeamRequestResponse>> CreatesGameTeamRequestAsync(
        [FromRoute] long gameId, [FromBody] CreatesGameTeamRequestRequest request)
    {
        CreatesGameTeamRequestCommand command = Mapper.Map<CreatesGameTeamRequestCommand>(request)
                                                       .SetGameId(gameId);

        CreatesGameTeamRequestViewModel model = await Mediator.Send(command)
                                                               .ConfigureAwait(false);

        return Ok(Mapper.Map<CreatesGameTeamRequestResponse>(model));
    }

    /// <summary>
    /// Update Game Request for Team by Game.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="requestId">Game Team Request Id.</param>
    /// <param name="request">Update Game Request for Team request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if Request **successfully** updated.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when Request **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{requestId}/Games/{gameId}/Teams/{teamId}")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> UpdateGameTeamRequestAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromRoute] long requestId, [FromBody] UpdateGameTeamRequestRequest request)
    {
        UpdateGameTeamRequestCommand command = Mapper.Map<UpdateGameTeamRequestCommand>(request)
                                                      .SetId(requestId)
                                                      .SetGameId(gameId)
                                                      .SetTeamId(teamId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Cancel Game Request for Team by Game.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="requestId">Game Team Request Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if Request **successfully** canceled.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when Request **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{requestId}/Games/{gameId}/Teams/{teamId}/Cancel")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CancelGameTeamRequestAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromRoute] long requestId)
    {
        UpdateGameTeamRequestCommand command = RequestStatusEnum.Canceled
            .BuildUpdateGameTeamRequestCommand(requestId, gameId, teamId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Decline Game Request for Team by Team.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="requestId">Game Team Request Id.</param>
    /// <param name="request">Decline Game Request for Team request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if Request **successfully** declined.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when Request **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{requestId}/Games/{gameId}/Teams/{teamId}/Decline")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> DeclineGameTeamRequestAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromRoute] long requestId, [FromBody] DeclineGameTeamRequestRequest request)
    {
        UpdateGameTeamRequestCommand command = Mapper.Map<UpdateGameTeamRequestCommand>(request)
                                                      .SetId(requestId)
                                                      .SetGameId(gameId)
                                                      .SetTeamId(teamId)
                                                      .SetStatus(RequestStatusEnum.Declined);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Accept Game Request for Team by Team.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="requestId">Game Team Request Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if Request **successfully** accepted.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when Request **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{requestId}/Games/{gameId}/Teams/{teamId}/Accept")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> AcceptGameTeamRequestAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromRoute] long requestId)
    {
        UpdateGameTeamRequestCommand command = RequestStatusEnum.Accepted
            .BuildUpdateGameTeamRequestCommand(requestId, gameId, teamId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return Game Request for Team.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="requestId">Game Team Request Id.</param>
    /// <returns>An ActionResult of type GetGameTeamRequestResponse</returns>
    /// <response code="200">Returns Game Request for Team model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when Request **not found**.</response>
    [HttpGet("{requestId}/Games/{gameId}/Teams/{teamId}", Name = "GetGameTeamRequest")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetGameTeamRequestResponse>> GetGameTeamRequestAsync(
        [FromRoute] long gameId, [FromRoute] long teamId, [FromRoute] long requestId)
    {
        GetGameTeamRequestQuery query = new() { Id = requestId, GameId = gameId, TeamId = teamId };

        GetGameTeamRequestViewModel Request = await Mediator.Send(query)
                                                            .ConfigureAwait(false);

        return Ok(Mapper.Map<GetGameTeamRequestResponse>(Request));
    }

    /// <summary>
    /// Return Game Team Request models by Game Id.
    /// </summary>
    /// <param name="gameId">Game unique identifier.</param>
    /// <returns>An ActionResult of type GetAllGameTeamRequestsResponse</returns>
    /// <response code="200">Returns Game Team Request models.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Games/{gameId}/Teams")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetsGameTeamRequestResponse>> GetsGameTeamRequestAsync([FromRoute] long gameId)
    {
        GetsGameTeamRequestQuery query = new() { GameId = gameId };

        GetsGameTeamRequestViewModel gameTeamRequests = await Mediator.Send(query)
                                                               .ConfigureAwait(false);

        return Ok(Mapper.Map<GetsGameTeamRequestResponse>(gameTeamRequests));
    }

    /// <summary>
    /// Return list of Game Team Requests.
    /// </summary>
    /// <param name="gameId">Game unique identifier.</param>
    /// <param name="request">Get Game Team Requests request.</param>
    /// <returns>An ActionResult of type GetGameTeamRequestsResponse</returns>
    /// <response code="200">Returns list of Game Team Requests with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Games/{gameId}/Teams/Find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetGameTeamRequestsResponse>> GetGameTeamRequestsAsync([FromRoute] long gameId, [FromQuery] GetGameTeamRequestsRequest request)
    {
        BasePaginationRequest<GetGameTeamRequestsViewModel, GetGameTeamRequestsFilterDto> query =
            Mapper.Map<GetGameTeamRequestsQuery>(request)
                  .SetGameId(gameId);

        GetGameTeamRequestsViewModel result = await Mediator.Send(query)
                                                             .ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetGameTeamRequestsResponse>(result));
    }
}
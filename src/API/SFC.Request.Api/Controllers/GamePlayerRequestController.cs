using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Request.Api.Infrastructure.Extensions;
using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Pagination;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Create;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Creates;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Exist;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Find;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Get;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Gets;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Update.Decline;
using SFC.Request.Api.Infrastructure.Models.Request.Game.Player.Update.General;
using SFC.Request.Application.Features.Common.Base;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Create;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Creates;
using SFC.Request.Application.Features.Request.Game.Player.Commands.Update;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Exist;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Find;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Find.Dto.Filters;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Get;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Gets;
using SFC.Request.Infrastructure.Constants;

namespace SFC.Request.Api.Controllers;

/// <summary>
/// Game player Request controller:
/// - create Request
/// - cancel/accept/refuse Request
/// - get/find Requests
/// </summary>
[Tags("Game Player Requests")]
[Route("api/Requests")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class GamePlayerRequestController : ApiControllerBase
{
    /// <summary>
    /// Check if Game player Request exist.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="status">Game player status Id.</param>
    /// <returns>An ActionResult of type GamePlayerRequestExistResponse</returns>
    /// <response code="200">Returns Game player Request existence check result.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpGet("Games/{gameId}/Players/{playerId}")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<GamePlayerRequestExistResponse>> GamePlayerRequestExistAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromQuery] int? status)
    {
        GamePlayerRequestExistQuery query = new() { GameId = gameId, PlayerId = playerId, Status = (RequestStatusEnum?)status };

        GamePlayerRequestExistViewModel model = await Mediator.Send(query)
                                                             .ConfigureAwait(false);

        return Ok(Mapper.Map<GamePlayerRequestExistResponse>(model));
    }

    /// <summary>
    /// Create new Game Request for player.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="request">Create Game Request for player request.</param>
    /// <returns>An ActionResult of type CreateGamePlayerRequestResponse</returns>
    /// <response code="201">Returns **new** created Game player Request.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPost("Games/{gameId}/Players/{playerId}")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CreateGamePlayerRequestResponse>> CreateGamePlayerRequestAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromBody] CreateGamePlayerRequestRequest request)
    {
        CreateGamePlayerRequestCommand command = Mapper.Map<CreateGamePlayerRequestCommand>(request)
                                                      .SetGameId(gameId)
                                                      .SetPlayerId(playerId);

        CreateGamePlayerRequestViewModel model = await Mediator.Send(command)
                                                              .ConfigureAwait(false);

        return CreatedAtRoute("GetGamePlayerRequest",
            new { gameId, playerId, RequestId = model.Request.Id },
            Mapper.Map<CreateGamePlayerRequestResponse>(model));
    }

    /// <summary>
    /// Create new Game Requests for players.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="request">Create Game Requests for players request.</param>
    /// <returns>An ActionResult of type CreateGamePlayerRequestsResponse</returns>
    /// <response code="200">Returns **new** created Game player Requests.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPost("Games/{gameId}/Players")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<CreatesGamePlayerRequestResponse>> CreatesGamePlayerRequestAsync(
        [FromRoute] long gameId, [FromBody] CreatesGamePlayerRequestRequest request)
    {
        CreatesGamePlayerRequestCommand command = Mapper.Map<CreatesGamePlayerRequestCommand>(request)
                                                       .SetGameId(gameId);

        CreatesGamePlayerRequestViewModel model = await Mediator.Send(command)
                                                               .ConfigureAwait(false);

        return Ok(Mapper.Map<CreatesGamePlayerRequestResponse>(model));
    }

    [HttpPut("{requestId}/Games/{gameId}/Players/{playerId}")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> UpdateGamePlayerRequestAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromRoute] long requestId, [FromBody] UpdateGamePlayerRequestRequest request)
    {
        UpdateGamePlayerRequestCommand command = Mapper.Map<UpdateGamePlayerRequestCommand>(request)
                                                      .SetId(requestId)
                                                      .SetGameId(gameId)
                                                      .SetPlayerId(playerId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Cancel Game Request for player by Game.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="requestId">Game player Request Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if Request **successfully** canceled.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when Request **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{requestId}/Games/{gameId}/Players/{playerId}/Cancel")]
    [Authorize(Policy.OwnGame)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CancelGamePlayerRequestAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromRoute] long requestId)
    {
        UpdateGamePlayerRequestCommand command = RequestStatusEnum.Canceled
            .BuildUpdateGamePlayerRequestCommand(requestId, gameId, playerId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Decline Game Request for player by player.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="requestId">Game player Request Id.</param>
    /// <param name="request">Decline Game Request for player request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if Request **successfully** declined.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when Request **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{requestId}/Games/{gameId}/Players/{playerId}/Decline")]
    [Authorize(Policy.OwnPlayer)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> DeclineGamePlayerRequestAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromRoute] long requestId, [FromBody] DeclineGamePlayerRequestRequest request)
    {
        UpdateGamePlayerRequestCommand command = Mapper.Map<UpdateGamePlayerRequestCommand>(request)
                                                      .SetId(requestId)
                                                      .SetGameId(gameId)
                                                      .SetPlayerId(playerId)
                                                      .SetStatus(RequestStatusEnum.Declined);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Accept Game Request for player by player.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="requestId">Game player Request Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if Request **successfully** accepted.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when Request **not found**.</response>
    /// <response code="409">Returns when **flow validation** errors.</response>
    [HttpPut("{requestId}/Games/{gameId}/Players/{playerId}/Accept")]
    [Authorize(Policy.OwnPlayer)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult> AcceptGamePlayerRequestAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromRoute] long requestId)
    {
        UpdateGamePlayerRequestCommand command = RequestStatusEnum.Accepted
            .BuildUpdateGamePlayerRequestCommand(requestId, gameId, playerId);

        await Mediator.Send(command)
                      .ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return Game Request for player.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="playerId">Player Id.</param>
    /// <param name="requestId">Game player Request Id.</param>
    /// <returns>An ActionResult of type GetGamePlayerRequestResponse</returns>
    /// <response code="200">Returns Game Request for player model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when Request **not found**.</response>
    [HttpGet("{requestId}/Games/{gameId}/Players/{playerId}", Name = "GetGamePlayerRequest")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetGamePlayerRequestResponse>> GetGamePlayerRequestAsync(
        [FromRoute] long gameId, [FromRoute] long playerId, [FromRoute] long requestId)
    {
        GetGamePlayerRequestQuery query = new() { Id = requestId, GameId = gameId, PlayerId = playerId };

        GetGamePlayerRequestViewModel request = await Mediator.Send(query)
                                                            .ConfigureAwait(false);

        return Ok(Mapper.Map<GetGamePlayerRequestResponse>(request));
    }

    /// <summary>
    /// Return Game player Request models by Game Id.
    /// </summary>
    /// <param name="gameId">Game unique identifier.</param>
    /// <returns>An ActionResult of type GetAllGamePlayerRequestsResponse</returns>
    /// <response code="200">Returns Game player Request models.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Games/{gameId}/Players")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetsGamePlayerRequestResponse>> GetGamePlayerRequestsAsync([FromRoute] long gameId)
    {
        GetsGamePlayerRequestQuery query = new() { GameId = gameId };

        GetsGamePlayerRequestViewModel gamePlayerRequests = await Mediator.Send(query)
                                                               .ConfigureAwait(false);

        return Ok(Mapper.Map<GetsGamePlayerRequestResponse>(gamePlayerRequests));
    }

    /// <summary>
    /// Return list of Game player Requests.
    /// </summary>
    /// <param name="gameId">Game unique identifier.</param>
    /// <param name="request">Get Game player Requests request.</param>
    /// <returns>An ActionResult of type GetGamePlayerRequestsResponse</returns>
    /// <response code="200">Returns list of Game player Requests with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Games/{gameId}/Players/Find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetGamePlayerRequestsResponse>> GetGamePlayerRequestsAsync([FromRoute] long gameId, [FromQuery] GetGamePlayerRequestsRequest request)
    {
        BasePaginationRequest<GetGamePlayerRequestsViewModel, GetGamePlayerRequestsFilterDto> query =
            Mapper.Map<GetGamePlayerRequestsQuery>(request)
                  .SetGameId(gameId);

        GetGamePlayerRequestsViewModel result = await Mediator.Send(query)
                                                             .ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetGamePlayerRequestsResponse>(result));
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Request.Api.Infrastructure.Extensions;
using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Pagination;
using SFC.Request.Api.Infrastructure.Models.Request.Create;
using SFC.Request.Api.Infrastructure.Models.Request.Find;
using SFC.Request.Api.Infrastructure.Models.Request.Get;
using SFC.Request.Api.Infrastructure.Models.Request.Update;
using SFC.Request.Application.Features.Common.Base;
using SFC.Request.Application.Features.Request.Commands.Create;
using SFC.Request.Application.Features.Request.Commands.Update;
using SFC.Request.Application.Features.Request.Queries.Find;
using SFC.Request.Application.Features.Request.Queries.Find.Dto.Filters;
using SFC.Request.Application.Features.Request.Queries.Get;
using SFC.Request.Infrastructure.Constants;

namespace SFC.Request.Api.Controllers;

[Tags("Requests")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class RequestsController : ApiControllerBase
{
    /// <summary>
    /// Create new request.
    /// </summary>
    /// <param name="request">Create request request.</param>
    /// <returns>An ActionResult of type CreateRequestResponse</returns>
    /// <response code="201">Returns **new** created request.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpPost]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CreateRequestResponse>> CreateRequestAsync([FromBody] CreateRequestRequest request)
    {
        CreateRequestCommand command = Mapper.Map<CreateRequestCommand>(request);

        CreateRequestViewModel model = await Mediator.Send(command).ConfigureAwait(false);

        return CreatedAtRoute("GetRequest", new { id = model.Request.Id }, Mapper.Map<CreateRequestResponse>(model));
    }

    /// <summary>
    /// Update existing request.
    /// </summary>
    /// <param name="id">Request unique identifier.</param>
    /// <param name="request">Update request request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if request updated **successfully**.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpPut("{id}")]
    [Authorize(Policy.OwnRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> UpdateRequestAsync([FromRoute] long id, [FromBody] UpdateRequestRequest request)
    {
        UpdateRequestCommand command = Mapper.Map<UpdateRequestCommand>(request)
                                                     .SetRequestId(id);

        await Mediator.Send(command).ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return request model by unique identifier.
    /// </summary>
    /// <param name="id">Request unique identifier.</param>
    /// <returns>An ActionResult of type GetRequestResponse</returns>
    /// <response code="200">Returns request model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when request **not found** by unique identifier.</response>
    [HttpGet("{id}", Name = "GetRequest")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetRequestResponse>> GetRequestAsync([FromRoute] long id)
    {
        GetRequestQuery query = new() { Id = id };

        GetRequestViewModel request = await Mediator.Send(query).ConfigureAwait(false);

        return Ok(Mapper.Map<GetRequestResponse>(request));
    }

    /// <summary>
    /// Return list of requests
    /// </summary>
    /// <param name="request">Get requests request.</param>
    /// <returns>An ActionResult of type GetRequestsResponse</returns>
    /// <response code="200">Returns list of requests with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetRequestsResponse>> GetRequestsAsync([FromQuery] GetRequestsRequest request)
    {
        BasePaginationRequest<GetRequestsViewModel, GetRequestsFilterDto> query = Mapper.Map<GetRequestsQuery>(request);

        GetRequestsViewModel result = await Mediator.Send(query).ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetRequestsResponse>(result));
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Data.GetAll;
using SFC.Request.Application.Features.Request.Data.Queries.GetAll;
using SFC.Request.Infrastructure.Constants;

namespace SFC.Request.Api.Controllers;

[Tags("Request Data")]
[Route("api/Requests/Data")]
[Authorize(Policy.General)]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
public class RequestDataController : ApiControllerBase
{
    /// <summary>
    /// Return all available request data types.
    /// </summary>
    /// <returns>An ActionResult of type GetAllRequestDataResponse</returns>
    /// <response code="200">Returns all available **data types**.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetAllRequestDataResponse>> GetAllAsync()
    {
        GetAllRequestDataQuery query = new();

        GetAllRequestDataViewModel model = await Mediator.Send(query).ConfigureAwait(true);

        return Ok(Mapper.Map<GetAllRequestDataResponse>(model));
    }
}
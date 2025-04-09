using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using SFC.Request.Application.Interfaces.Common;

namespace SFC.Request.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    private IMapper? _mapper;

    private IUriService? _uriService;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetRequiredService<IMapper>();

    protected IUriService UriService => _uriService ??= HttpContext.RequestServices.GetRequiredService<IUriService>();
}
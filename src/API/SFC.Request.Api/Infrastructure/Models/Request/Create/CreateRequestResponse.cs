using AutoMapper;

using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Commands.Create;

namespace SFC.Request.Api.Infrastructure.Models.Request.Create;

/// <summary>
/// **Create** request response model.
/// </summary>
public class CreateRequestResponse :
    BaseErrorResponse, IMapFrom<CreateRequestViewModel>
{
    /// <summary>
    /// Request model.
    /// </summary>
    public RequestModel Request { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateRequestViewModel, CreateRequestResponse>()
                                                   .IgnoreAllNonExisting();
}
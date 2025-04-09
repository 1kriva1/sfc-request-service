using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Commands.Update;

namespace SFC.Request.Api.Infrastructure.Models.Request.Update;

/// <summary>
/// **Update** request request.
/// </summary>
public class UpdateRequestRequest : IMapTo<UpdateRequestCommand>
{
    /// <summary>
    /// Request model.
    /// </summary>
    public UpdateRequestModel Request { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateRequestRequest, UpdateRequestCommand>()
                                                   .IgnoreAllNonExisting();
}
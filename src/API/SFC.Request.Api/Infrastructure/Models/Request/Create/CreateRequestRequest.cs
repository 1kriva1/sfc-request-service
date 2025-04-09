using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Commands.Create;

namespace SFC.Request.Api.Infrastructure.Models.Request.Create;

/// <summary>
/// **Create** Request request.
/// </summary>
public class CreateRequestRequest : IMapTo<CreateRequestCommand>
{
    /// <summary>
    /// Request model.
    /// </summary>
    public CreateRequestModel Request { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateRequestRequest, CreateRequestCommand>()
                                                   .IgnoreAllNonExisting();
}
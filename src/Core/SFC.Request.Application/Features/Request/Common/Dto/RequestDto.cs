using AutoMapper;

using SFC.Request.Application.Common.Mappings.Interfaces;

namespace SFC.Request.Application.Features.Request.Common.Dto;
public class RequestDto : IMapFrom<RequestEntity>
{
    public long Id { get; set; }
}
using SFC.Request.Application.Features.Request.Data.Queries.Common.Dto;

namespace SFC.Request.Application.Features.Request.Data.Queries.GetAll;

public record GetAllRequestDataViewModel
{
    public IEnumerable<DataValueDto> RequestStatuses { get; init; } = [];
}
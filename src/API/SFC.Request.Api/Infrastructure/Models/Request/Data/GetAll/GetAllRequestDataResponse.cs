using SFC.Request.Api.Infrastructure.Models.Base;
using SFC.Request.Api.Infrastructure.Models.Request.Data.Common;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Request.Data.Queries.GetAll;

namespace SFC.Request.Api.Infrastructure.Models.Request.Data.GetAll;

/// <summary>
/// Contain all available request **data types**.
/// </summary>
public class GetAllRequestDataResponse : BaseErrorResponse, IMapFrom<GetAllRequestDataViewModel>
{
    /// <summary>
    /// Request statuses.
    /// </summary>
    public IEnumerable<DataValueModel> RequestStatuses { get; init; } = [];
}
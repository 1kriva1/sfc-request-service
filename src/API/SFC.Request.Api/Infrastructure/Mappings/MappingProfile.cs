using System.Reflection;

using Google.Protobuf.WellKnownTypes;

using SFC.Request.Api.Infrastructure.Models.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Base;
using SFC.Request.Application.Features.Common.Dto.Common;
using SFC.Request.Application.Features.Common.Dto.Pagination;
using SFC.Request.Application.Features.Request.Common.Dto;
using SFC.Request.Application.Features.Request.Queries.Find;
using SFC.Request.Application.Features.Request.Queries.Find.Dto.Filters;
using SFC.Request.Application.Features.Request.Queries.Get;

namespace SFC.Request.Api.Infrastructure.Mappings;

public class MappingProfile : BaseMappingProfile
{
    protected override Assembly Assembly => Assembly.GetExecutingAssembly();

    public MappingProfile() : base()
    {
        ApplyCustomMappings();
    }

    private void ApplyCustomMappings()
    {
        #region Simple types

        CreateMap<DateTime, Timestamp>()
            .ConvertUsing(value => DateTime.SpecifyKind(value, DateTimeKind.Utc).ToTimestamp());

        CreateMap<TimeSpan, Duration>()
            .ConvertUsing(value => Duration.FromTimeSpan(value));

        CreateMap<Duration, TimeSpan>()
            .ConvertUsing(value => value.ToTimeSpan());

        #endregion Simple types

        #region Generic types

        CreateMap(typeof(RangeLimitModel<>), typeof(RangeLimitDto<>));

        #endregion Generic types

        #region Complex types

        // contracts
        CreateMapRequestContracts();

        #endregion Complex types        
    }

    private void CreateMapRequestContracts()
    {
        // get request
        CreateMap<RequestDto, SFC.Request.Contracts.Models.Request.Request>();
        CreateMap<GetRequestViewModel, SFC.Request.Contracts.Messages.Get.GetRequestResponse>();
        CreateMap<SFC.Request.Contracts.Messages.Get.GetRequestRequest, GetRequestQuery>();
        CreateMap<RequestDto, SFC.Request.Contracts.Headers.AuditableHeader>()
            .IgnoreAllNonExisting();

        // get requests
        // (filters)
        CreateMap<SFC.Request.Contracts.Messages.Find.GetRequestsRequest, GetRequestsQuery>();
        CreateMap<SFC.Request.Contracts.Models.Common.Pagination, PaginationDto>();
        CreateMap<SFC.Request.Contracts.Models.Common.Sorting, SortingDto>();
        CreateMap<SFC.Request.Contracts.Messages.Find.Filters.GetRequestsFilter, GetRequestsFilterDto>();
        CreateMap(typeof(SFC.Request.Contracts.Models.Common.RangeLimit), typeof(RangeLimitDto<>));
        // (result)
        CreateMap<GetRequestsViewModel, SFC.Request.Contracts.Messages.Find.GetRequestsResponse>();
        CreateMap<SFC.Request.Application.Features.Request.Common.Dto.RequestDto, SFC.Request.Contracts.Models.Request.Request>();
        // (headers)
        CreateMap<PageMetadataDto, SFC.Request.Contracts.Headers.PaginationHeader>()
            .IgnoreAllNonExisting();
    }
}
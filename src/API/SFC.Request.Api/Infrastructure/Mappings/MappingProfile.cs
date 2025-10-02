using System.Reflection;

using Google.Protobuf.WellKnownTypes;

using SFC.Request.Api.Infrastructure.Models.Common;
using SFC.Request.Api.Infrastructure.Models.Request.Team.Player.Common;
using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Base;
using SFC.Request.Application.Features.Common.Dto.Common;
using SFC.Request.Application.Features.Common.Dto.Pagination;
using SFC.Request.Application.Features.Request.Data.Queries.Common.Dto;
using SFC.Request.Application.Features.Request.Data.Queries.GetAll;
using SFC.Request.Application.Features.Request.Team.Player.Common.Dto;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Dto.Filters;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Get;

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

        // data
        CreateMapRequestDataContracts();

        // contracts
        CreateMapRequestContracts();

        #endregion Complex types        
    }

    private void CreateMapRequestDataContracts()
    {
        CreateMap<DataValueDto, SFC.Request.Contracts.Models.Request.Data.DataValue>();
        CreateMap<GetAllRequestDataViewModel, SFC.Request.Contracts.Messages.Request.Data.GetAll.GetAllRequestDataResponse>();
    }

    private void CreateMapRequestContracts()
    {
        // get request
        CreateMap<TeamPlayerRequestDto, SFC.Request.Contracts.Models.Request.TeamPlayerRequest>();
        CreateMap<GetTeamPlayerRequestViewModel, SFC.Request.Contracts.Messages.Request.Team.Player.Get.GetTeamPlayerRequestResponse>();
        CreateMap<SFC.Request.Contracts.Messages.Request.Team.Player.Get.GetTeamPlayerRequestRequest, GetTeamPlayerRequestQuery>();
        CreateMap<TeamPlayerRequestDto, SFC.Request.Contracts.Headers.AuditableHeader>()
            .IgnoreAllNonExisting();

        // get requests
        // (filters)
        CreateMap<SFC.Request.Contracts.Messages.Request.Team.Player.Find.GetTeamPlayerRequestsRequest, GetTeamPlayerRequestsQuery>();
        CreateMap<SFC.Request.Contracts.Models.Common.Pagination, PaginationDto>();
        CreateMap<SFC.Request.Contracts.Models.Common.Sorting, SortingDto>();
        CreateMap<SFC.Request.Contracts.Messages.Request.Team.Player.Find.Filters.GetTeamPlayerRequestsFilter, GetTeamPlayerRequestsFilterDto>();
        CreateMap(typeof(SFC.Request.Contracts.Models.Common.RangeLimit), typeof(RangeLimitDto<>));
        // (result)
        CreateMap<GetTeamPlayerRequestsViewModel, SFC.Request.Contracts.Messages.Request.Team.Player.Find.GetTeamPlayerRequestsResponse>();
        CreateMap<TeamPlayerRequestDto, SFC.Request.Contracts.Models.Request.TeamPlayerRequest>();
        // (headers)
        CreateMap<PageMetadataDto, SFC.Request.Contracts.Headers.PaginationHeader>()
            .IgnoreAllNonExisting();
    }
}
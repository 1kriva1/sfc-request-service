using AutoMapper;

using MediatR;

using SFC.Request.Application.Features.Common.Dto.Pagination;
using SFC.Request.Application.Features.Common.Models.Find;
using SFC.Request.Application.Features.Common.Models.Find.Filters;
using SFC.Request.Application.Features.Common.Models.Find.Paging;
using SFC.Request.Application.Features.Common.Models.Find.Sorting;
using SFC.Request.Application.Features.Request.Team.Player.Common.Dto;
using SFC.Request.Application.Features.Request.Team.Player.Queries.Find.Extensions;
using SFC.Request.Application.Interfaces.Common;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Team.Player;
using SFC.Request.Domain.Entities.Request.Team.Player;

namespace SFC.Request.Application.Features.Request.Team.Player.Queries.Find;
public class GetTeamPlayerRequestsQueryHandler(
    IMapper mapper,
    IDateTimeService dateTimeService,
    ITeamPlayerRequestRepository requestRepository)
    : IRequestHandler<GetTeamPlayerRequestsQuery, GetTeamPlayerRequestsViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly ITeamPlayerRequestRepository _requestRepository = requestRepository;

    public async Task<GetTeamPlayerRequestsViewModel> Handle(GetTeamPlayerRequestsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<TeamPlayerRequest>> filters = request.Filter.BuildSearchFilters(_dateTimeService.DateNow);

        IEnumerable<Sorting<TeamPlayerRequest, dynamic>>? sorting = request.Sorting.BuildRequestSearchSorting();

        FindParameters<TeamPlayerRequest> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<TeamPlayerRequest>(filters),
            Sorting = new Sortings<TeamPlayerRequest>(sorting)
        };

        PagedList<TeamPlayerRequest> pageList = await _requestRepository.FindAsync(parameters)
                                                             .ConfigureAwait(true);

        return new GetTeamPlayerRequestsViewModel
        {
            Items = _mapper.Map<IEnumerable<TeamPlayerRequestDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}
using AutoMapper;

using MediatR;

using SFC.Request.Application.Features.Common.Dto.Pagination;
using SFC.Request.Application.Features.Common.Models.Find;
using SFC.Request.Application.Features.Common.Models.Find.Filters;
using SFC.Request.Application.Features.Common.Models.Find.Paging;
using SFC.Request.Application.Features.Common.Models.Find.Sorting;
using SFC.Request.Application.Features.Request.Game.Team.Common.Dto;
using SFC.Request.Application.Features.Request.Game.Team.Queries.Find.Extensions;
using SFC.Request.Application.Interfaces.Common;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Team;
using SFC.Request.Domain.Entities.Request.Game.Team;

namespace SFC.Request.Application.Features.Request.Game.Team.Queries.Find;
public class GetGameTeamRequestsQueryHandler(
    IMapper mapper,
    IDateTimeService dateTimeService,
    IGameTeamRequestRepository gameTeamRequestRepository)
    : IRequestHandler<GetGameTeamRequestsQuery, GetGameTeamRequestsViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IGameTeamRequestRepository _gameTeamRequestRepository = gameTeamRequestRepository;

    public async Task<GetGameTeamRequestsViewModel> Handle(GetGameTeamRequestsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<GameTeamRequest>> filters = request.Filter.BuildSearchFilters(_dateTimeService.DateNow);

        IEnumerable<Sorting<GameTeamRequest, dynamic>> sorting = request.Sorting.BuildGameTeamRequestSorting();

        FindParameters<GameTeamRequest> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<GameTeamRequest>(filters),
            Sorting = new Sortings<GameTeamRequest>(sorting)
        };

        PagedList<GameTeamRequest> pageList = await _gameTeamRequestRepository.FindAsync(parameters)
                                                                                .ConfigureAwait(true);

        return new GetGameTeamRequestsViewModel
        {
            Items = _mapper.Map<IEnumerable<GameTeamRequestDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}
using AutoMapper;

using MediatR;

using SFC.Request.Application.Features.Common.Dto.Pagination;
using SFC.Request.Application.Features.Common.Models.Find;
using SFC.Request.Application.Features.Common.Models.Find.Filters;
using SFC.Request.Application.Features.Common.Models.Find.Paging;
using SFC.Request.Application.Features.Common.Models.Find.Sorting;
using SFC.Request.Application.Features.Request.Game.Player.Common.Dto;
using SFC.Request.Application.Features.Request.Game.Player.Queries.Find.Extensions;
using SFC.Request.Application.Interfaces.Common;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Game.Player;
using SFC.Request.Domain.Entities.Request.Game.Player;

namespace SFC.Request.Application.Features.Request.Game.Player.Queries.Find;
public class GetGamePlayerRequestsQueryHandler(
    IMapper mapper,
    IDateTimeService dateTimeService,
    IGamePlayerRequestRepository gamePlayerRequestRepository)
    : IRequestHandler<GetGamePlayerRequestsQuery, GetGamePlayerRequestsViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IGamePlayerRequestRepository _gamePlayerRequestRepository = gamePlayerRequestRepository;

    public async Task<GetGamePlayerRequestsViewModel> Handle(GetGamePlayerRequestsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<GamePlayerRequest>> filters = request.Filter.BuildSearchFilters(_dateTimeService.DateNow);

        IEnumerable<Sorting<GamePlayerRequest, dynamic>> sorting = request.Sorting.BuildGamePlayerRequestSorting();

        FindParameters<GamePlayerRequest> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<GamePlayerRequest>(filters),
            Sorting = new Sortings<GamePlayerRequest>(sorting)
        };

        PagedList<GamePlayerRequest> pageList = await _gamePlayerRequestRepository.FindAsync(parameters)
                                                                                .ConfigureAwait(true);

        return new GetGamePlayerRequestsViewModel
        {
            Items = _mapper.Map<IEnumerable<GamePlayerRequestDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}
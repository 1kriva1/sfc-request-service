using AutoMapper;

using MediatR;

using SFC.Request.Application.Features.Common.Dto.Pagination;
using SFC.Request.Application.Features.Common.Models.Find;
using SFC.Request.Application.Features.Common.Models.Find.Filters;
using SFC.Request.Application.Features.Common.Models.Find.Paging;
using SFC.Request.Application.Features.Common.Models.Find.Sorting;
using SFC.Request.Application.Features.Request.Common.Dto;
using SFC.Request.Application.Features.Request.Queries.Find.Extensions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request;

namespace SFC.Request.Application.Features.Request.Queries.Find;
public class GetRequestsQueryHandler(
    IMapper mapper,
    IRequestRepository requestRepository)
    : IRequestHandler<GetRequestsQuery, GetRequestsViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IRequestRepository _requestRepository = requestRepository;

    public async Task<GetRequestsViewModel> Handle(GetRequestsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Filter<RequestEntity>> filters = request.Filter.BuildSearchFilters();

        IEnumerable<Sorting<RequestEntity, dynamic>>? sorting = request.Sorting.BuildRequestSearchSorting();

        FindParameters<RequestEntity> parameters = new()
        {
            Pagination = _mapper.Map<Pagination>(request.Pagination),
            Filters = new Filters<RequestEntity>(filters),
            Sorting = new Sortings<RequestEntity>(sorting)
        };

        PagedList<RequestEntity> pageList = await _requestRepository
                                                             .FindAsync(parameters)
                                                             .ConfigureAwait(true);

        return new GetRequestsViewModel
        {
            Items = _mapper.Map<IEnumerable<RequestDto>>(pageList),
            Metadata = _mapper.Map<PageMetadataDto>(pageList)
        };
    }
}
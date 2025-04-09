using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request;

namespace SFC.Request.Application.Features.Request.Queries.Get;
public class GetRequestQueryHandler(IMapper mapper, IRequestRepository requestRepository)
    : IRequestHandler<GetRequestQuery, GetRequestViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IRequestRepository _requestRepository = requestRepository;

    public async Task<GetRequestViewModel> Handle(GetRequestQuery request, CancellationToken cancellationToken)
    {
        RequestEntity requestEntity = await _requestRepository.GetByIdAsync(request.Id).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.RequestNotFound);

        return _mapper.Map<GetRequestViewModel>(requestEntity);
    }
}
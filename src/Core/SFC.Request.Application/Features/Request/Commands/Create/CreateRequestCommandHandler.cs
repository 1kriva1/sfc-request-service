using AutoMapper;

using MediatR;

using SFC.Request.Application.Interfaces.Persistence.Repository.Request;
using SFC.Request.Domain.Events.Request;

namespace SFC.Request.Application.Features.Request.Commands.Create;
public class CreateRequestCommandHandler(
    IMapper mapper,
    IRequestRepository requestRepository)
    : IRequestHandler<CreateRequestCommand, CreateRequestViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IRequestRepository _requestRepository = requestRepository;

    public async Task<CreateRequestViewModel> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
    {
        RequestEntity requestEntity = _mapper.Map<RequestEntity>(request.Request);

        requestEntity.AddDomainEvent(new RequestCreatedEvent(requestEntity));

        await _requestRepository.AddAsync(requestEntity)
                                .ConfigureAwait(false);

        return _mapper.Map<CreateRequestViewModel>(request);
    }
}
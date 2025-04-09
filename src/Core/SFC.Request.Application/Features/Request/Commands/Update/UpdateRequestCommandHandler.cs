using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Constants;
using SFC.Request.Application.Common.Exceptions;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request;
using SFC.Request.Domain.Events.Request;

namespace SFC.Request.Application.Features.Request.Commands.Update;
public class UpdateRequestCommandHandler(IMapper mapper, IRequestRepository requestRepository)
    : IRequestHandler<UpdateRequestCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IRequestRepository _requestRepository = requestRepository;

    public async Task Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
    {
        RequestEntity requestEntity = await _requestRepository.GetByIdAsync(request.Id).ConfigureAwait(true)
            ?? throw new NotFoundException(Localization.RequestNotFound);

        RequestEntity updatedRequest = _mapper.Map(request.Request, requestEntity);

        updatedRequest.AddDomainEvent(new RequestUpdatedEvent(updatedRequest));

        await _requestRepository.UpdateAsync(updatedRequest)
                                        .ConfigureAwait(false);
    }
}
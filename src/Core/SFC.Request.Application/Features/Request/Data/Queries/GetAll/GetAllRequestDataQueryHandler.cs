using AutoMapper;

using MediatR;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Features.Request.Data.Queries.Common.Dto;
using SFC.Request.Application.Interfaces.Request.Data;
using SFC.Request.Application.Interfaces.Request.Data.Models;

namespace SFC.Request.Application.Features.Request.Data.Queries.GetAll;

public class GetAllRequestDataQueryHandler(IMapper mapper, IRequestDataService requestDataService)
    : IRequestHandler<GetAllRequestDataQuery, GetAllRequestDataViewModel>
{
    private readonly IMapper _mapper = mapper;
    private readonly IRequestDataService _requestDataService = requestDataService;

    public async Task<GetAllRequestDataViewModel> Handle(GetAllRequestDataQuery request, CancellationToken cancellationToken)
    {
        GetAllRequestDataModel model = await _requestDataService.GetAllRequestDataAsync().ConfigureAwait(true);

        return new GetAllRequestDataViewModel
        {
            RequestStatuses = _mapper.Map<IEnumerable<DataValueDto>>(model.RequestStatuses.Localize())
        };
    }
}
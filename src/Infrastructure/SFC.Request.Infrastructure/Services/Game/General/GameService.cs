using AutoMapper;

using Microsoft.Extensions.Configuration;

using SFC.Game.Contracts.Messages.Game.General.Get;
using SFC.Request.Application.Common.Dto.Game.General;
using SFC.Request.Application.Interfaces.Game.General;
using SFC.Request.Infrastructure.Extensions.Grpc;

using static SFC.Game.Contracts.Services.GameService;

namespace SFC.Request.Infrastructure.Services.Game.General;
public class GameService(
    GameServiceClient client,
    IMapper mapper,
    IConfiguration configuration) : IGameService
{
    private readonly GameServiceClient _client = client;
    private readonly IMapper _mapper = mapper;
    private readonly IConfiguration _configuration = configuration;

    public async Task<GameDto?> GetGameAsync(long id, CancellationToken cancellationToken = default)
    {
        GetGameRequest request = _mapper.Map<GetGameRequest>(id);

        return await GrpcClientExtensions.CallWithAuditableAsync(
            _client.GetGameAsync,
            request,
            _configuration,
            (response) => _mapper.Map<GameDto>(response.Game),
            null,
            cancellationToken).ConfigureAwait(true);
    }
}
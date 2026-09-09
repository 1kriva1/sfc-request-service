using SFC.Request.Api.Services;

namespace SFC.Request.Api.Infrastructure.Extensions;

public static class GrpcExtensions
{
    public static WebApplication UseGrpc(this WebApplication app)
    {
        app.MapGrpcService<RequestDataService>();
        app.MapGrpcService<TeamPlayerRequestService>();
        app.MapGrpcService<GamePlayerRequestService>();
        app.MapGrpcService<GameTeamRequestService>();

        return app;
    }
}
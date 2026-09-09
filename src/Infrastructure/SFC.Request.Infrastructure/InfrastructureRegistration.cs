using System.Reflection;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using SFC.Request.Application.Interfaces.Common;
using SFC.Request.Application.Interfaces.Game.General;
using SFC.Request.Application.Interfaces.Game.Player;
using SFC.Request.Application.Interfaces.Game.Team;
using SFC.Request.Application.Interfaces.Identity;
using SFC.Request.Application.Interfaces.Metadata;
using SFC.Request.Application.Interfaces.Player;
using SFC.Request.Application.Interfaces.Reference;
using SFC.Request.Application.Interfaces.Request.Data;
using SFC.Request.Application.Interfaces.Request.Game.Player;
using SFC.Request.Application.Interfaces.Request.Game.Team;
using SFC.Request.Application.Interfaces.Request.Team.Player;
using SFC.Request.Application.Interfaces.Team.General;
using SFC.Request.Application.Interfaces.Team.Player;
using SFC.Request.Infrastructure.Authorization.OwnGame;
using SFC.Request.Infrastructure.Authorization.OwnPlayer;
using SFC.Request.Infrastructure.Authorization.OwnRequest;
using SFC.Request.Infrastructure.Authorization.OwnTeam;
using SFC.Request.Infrastructure.Extensions;
using SFC.Request.Infrastructure.Extensions.Grpc;
using SFC.Request.Infrastructure.Services.Common;
using SFC.Request.Infrastructure.Services.Game.General;
using SFC.Request.Infrastructure.Services.Game.Player;
using SFC.Request.Infrastructure.Services.Game.Team;
using SFC.Request.Infrastructure.Services.Hosted;
using SFC.Request.Infrastructure.Services.Identity;
using SFC.Request.Infrastructure.Services.Metadata;
using SFC.Request.Infrastructure.Services.Player;
using SFC.Request.Infrastructure.Services.Reference;
using SFC.Request.Infrastructure.Services.Request.Data;
using SFC.Request.Infrastructure.Services.Request.Game.Player;
using SFC.Request.Infrastructure.Services.Request.Game.Team;
using SFC.Request.Infrastructure.Services.Request.Team.Player;
using SFC.Request.Infrastructure.Services.Team.General;
using SFC.Request.Infrastructure.Services.Team.Player;

using TeamPlayerRequestService = SFC.Request.Infrastructure.Services.Request.Team.Player.TeamPlayerRequestService;

namespace SFC.Request.Infrastructure;
public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.Services.AddAutoMapper(config => { }, Assembly.GetExecutingAssembly());

        builder.Services.AddHangfire(builder.Configuration);

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAccessTokenManagement();

        builder.Services.AddRedis(builder.Configuration);

        builder.AddMassTransit();

        builder.Services.AddCache(builder.Configuration);

        builder.Services.AddGrpc(builder.Configuration, builder.Environment);

        builder.Services.AddSingleton<IUriService>(o =>
        {
            IHttpContextAccessor accessor = o.GetRequiredService<IHttpContextAccessor>();
            HttpRequest request = accessor.HttpContext!.Request;
            return new UriService(string.Concat(request.Scheme, "://", request.Host.ToUriComponent()));
        });

        // custom services
        builder.Services.AddTransient<IMetadataService, MetadataService>();
        builder.Services.AddTransient<IDateTimeService, DateTimeService>();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IUserSeedService, UserSeedService>();
        builder.Services.AddTransient<IPlayerSeedService, PlayerSeedService>();
        builder.Services.AddTransient<ITeamSeedService, TeamSeedService>();
        builder.Services.AddTransient<ITeamPlayerSeedService, TeamPlayerSeedService>();
        builder.Services.AddTransient<IGameSeedService, GameSeedService>();
        builder.Services.AddTransient<IGamePlayerSeedService, GamePlayerSeedService>();
        builder.Services.AddTransient<IGameTeamSeedService, GameTeamSeedService>();
        builder.Services.AddTransient<IRequestDataService, RequestDataService>();
        builder.Services.AddTransient<ITeamPlayerRequestService, TeamPlayerRequestService>();
        builder.Services.AddTransient<ITeamPlayerRequestSeedService, TeamPlayerRequestSeedService>();
        builder.Services.AddTransient<IGamePlayerRequestService, GamePlayerRequestService>();
        builder.Services.AddTransient<IGamePlayerRequestSeedService, GamePlayerRequestSeedService>();
        builder.Services.AddTransient<IGameTeamRequestService, GameTeamRequestService>();
        builder.Services.AddTransient<IGameTeamRequestSeedService, GameTeamRequestSeedService>();

        // grpc
        builder.Services.AddTransient<IIdentityService, IdentityService>();
        builder.Services.AddTransient<IPlayerService, PlayerService>();
        builder.Services.AddTransient<ITeamService, TeamService>();
        builder.Services.AddTransient<IGameService, GameService>();

        // references
        builder.Services.AddScoped<IIdentityReference, IdentityReference>();
        builder.Services.AddScoped<IPlayerReference, PlayerReference>();
        builder.Services.AddScoped<ITeamReference, TeamReference>();
        builder.Services.AddScoped<IGameReference, GameReference>();

        // hosted services
        builder.Services.AddHostedService<DatabaseResetHostedService>();
        builder.Services.AddHostedService<DataInitializationHostedService>();
        builder.Services.AddHostedService<JobsInitializationHostedService>();

        // authorization
        builder.Services.AddScoped<IAuthorizationHandler, OwnRequestHandler>();
        builder.Services.AddScoped<IAuthorizationHandler, OwnPlayerHandler>();
        builder.Services.AddScoped<IAuthorizationHandler, OwnTeamHandler>();
        builder.Services.AddScoped<IAuthorizationHandler, OwnGameHandler>();
    }
}
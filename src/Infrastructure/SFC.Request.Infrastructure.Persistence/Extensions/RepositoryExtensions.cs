using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Request.Application.Common.Settings;
using SFC.Request.Application.Interfaces.Persistence.Repository.Common;
using SFC.Request.Application.Interfaces.Persistence.Repository.Data;
using SFC.Request.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Request.Application.Interfaces.Persistence.Repository.Metadata;
using SFC.Request.Application.Interfaces.Persistence.Repository.Player;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Data;
using SFC.Request.Application.Interfaces.Persistence.Repository.Request.Team.Player;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.General;
using SFC.Request.Application.Interfaces.Persistence.Repository.Team.Player;
using SFC.Request.Infrastructure.Persistence.Repositories.Common;
using SFC.Request.Infrastructure.Persistence.Repositories.Data;
using SFC.Request.Infrastructure.Persistence.Repositories.Data.Cache;
using SFC.Request.Infrastructure.Persistence.Repositories.Identity;
using SFC.Request.Infrastructure.Persistence.Repositories.Metadata;
using SFC.Request.Infrastructure.Persistence.Repositories.Player;
using SFC.Request.Infrastructure.Persistence.Repositories.Request.Data;
using SFC.Request.Infrastructure.Persistence.Repositories.Request.Data.Cache;
using SFC.Request.Infrastructure.Persistence.Repositories.Request.Team.Player;
using SFC.Request.Infrastructure.Persistence.Repositories.Team.Data;
using SFC.Request.Infrastructure.Persistence.Repositories.Team.Data.Cache;
using SFC.Request.Infrastructure.Persistence.Repositories.Team.General;
using SFC.Request.Infrastructure.Persistence.Repositories.Team.Player;

namespace SFC.Request.Infrastructure.Persistence.Extensions;
public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
        services.AddScoped<IMetadataRepository, MetadataRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<ITeamPlayerRequestRepository, TeamPlayerRequestRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<ITeamPlayerRepository, TeamPlayerRepository>();

        CacheSettings? cacheSettings = configuration
           .GetSection(CacheSettings.SectionKey)
           .Get<CacheSettings>();

        if (cacheSettings?.Enabled ?? false)
        {
            // data
            services.AddScoped<FootballPositionRepository>();
            services.AddScoped<IFootballPositionRepository, FootballPositionCacheRepository>();
            services.AddScoped<GameStyleRepository>();
            services.AddScoped<IGameStyleRepository, GameStyleCacheRepository>();
            services.AddScoped<StatCategoryRepository>();
            services.AddScoped<IStatCategoryRepository, StatCategoryCacheRepository>();
            services.AddScoped<StatSkillRepository>();
            services.AddScoped<IStatSkillRepository, StatSkillCacheRepository>();
            services.AddScoped<StatTypeRepository>();
            services.AddScoped<IStatTypeRepository, StatTypeCacheRepository>();
            services.AddScoped<WorkingFootRepository>();
            services.AddScoped<IWorkingFootRepository, WorkingFootCacheRepository>();
            services.AddScoped<ShirtRepository>();
            services.AddScoped<IShirtRepository, ShirtCacheRepository>();

            // request
            services.AddScoped<RequestStatusRepository>();
            services.AddScoped<IRequestStatusRepository, RequestStatusCacheRepository>();

            // team
            services.AddScoped<TeamPlayerStatusRepository>();
            services.AddScoped<ITeamPlayerStatusRepository, TeamPlayerStatusCacheRepository>();
        }
        else
        {
            // data
            services.AddScoped<IFootballPositionRepository, FootballPositionRepository>();
            services.AddScoped<IGameStyleRepository, GameStyleRepository>();
            services.AddScoped<IStatCategoryRepository, StatCategoryRepository>();
            services.AddScoped<IStatSkillRepository, StatSkillRepository>();
            services.AddScoped<IStatTypeRepository, StatTypeRepository>();
            services.AddScoped<IWorkingFootRepository, WorkingFootRepository>();
            services.AddScoped<IShirtRepository, ShirtRepository>();

            // request
            services.AddScoped<IRequestStatusRepository, RequestStatusRepository>();

            // team
            services.AddScoped<ITeamPlayerStatusRepository, TeamPlayerStatusRepository>();
        }

        return services;
    }
}
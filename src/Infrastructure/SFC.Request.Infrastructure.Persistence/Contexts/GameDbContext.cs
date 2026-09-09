using Microsoft.EntityFrameworkCore;

using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Domain.Entities.Game.Data;
using SFC.Request.Domain.Entities.Game.General;
using SFC.Request.Domain.Entities.Game.Player;
using SFC.Request.Domain.Entities.Game.Team;
using SFC.Request.Infrastructure.Persistence.Configurations.Game.Data;
using SFC.Request.Infrastructure.Persistence.Configurations.Game.General;
using SFC.Request.Infrastructure.Persistence.Configurations.Game.Player;
using SFC.Request.Infrastructure.Persistence.Configurations.Game.Team;
using SFC.Request.Infrastructure.Persistence.Constants;
using SFC.Request.Infrastructure.Persistence.Interceptors;

namespace SFC.Request.Infrastructure.Persistence.Contexts;
public class GameDbContext(
    DbContextOptions<GameDbContext> options,
    AuditableEntitySaveChangesInterceptor auditableInterceptor,
    DataEntitySaveChangesInterceptor dataEntityInterceptor,
    UserEntitySaveChangesInterceptor userEntityInterceptor,
    DispatchDomainEventsSaveChangesInterceptor eventsInterceptor)
    : BaseDbContext<GameDbContext>(options, eventsInterceptor), IGameDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableInterceptor = auditableInterceptor;
    private readonly DataEntitySaveChangesInterceptor _dataEntityInterceptor = dataEntityInterceptor;
    private readonly UserEntitySaveChangesInterceptor _userEntityInterceptor = userEntityInterceptor;

    #region General

    public IQueryable<GameEntity> Games => Set<GameEntity>();

    public IQueryable<GameGeneralProfile> GeneralProfiles => Set<GameGeneralProfile>();

    public IQueryable<GameFinancialProfile> FinancialProfiles => Set<GameFinancialProfile>();

    public IQueryable<GameInventaryProfile> InventaryProfiles => Set<GameInventaryProfile>();

    public IQueryable<GameAvailability> Availabilities => Set<GameAvailability>();

    public IQueryable<GameTag> Tags => Set<GameTag>();

    public IQueryable<GamePlayer> GamePlayers => Set<GamePlayer>();

    public IQueryable<GameTeam> GameTeams => Set<GameTeam>();

    #endregion General

    #region Data

    public IQueryable<GameStatus> GameStatuses => Set<GameStatus>();

    public IQueryable<GamePlayerStatus> GamePlayerStatuses => Set<GamePlayerStatus>();

    public IQueryable<GameTeamStatus> GameTeamStatuses => Set<GameTeamStatus>();

    public IQueryable<GameTeamIndex> GameTeamIndexes => Set<GameTeamIndex>();

    #endregion Data

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.HasDefaultSchema(DatabaseConstants.GameSchemaName);

        // data
        DataDbContext.ApplyDataConfigurations(modelBuilder);

        // identity
        IdentityDbContext.ApplyIdentityConfigurations(modelBuilder, Database.IsSqlServer());

        // player
        PlayerDbContext.ApplyPlayerConfigurations(modelBuilder);

        // team
        TeamDbContext.ApplyTeamConfigurations(modelBuilder);

        // game
        ApplyGameConfigurations(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableInterceptor);
        optionsBuilder.AddInterceptors(_dataEntityInterceptor);
        optionsBuilder.AddInterceptors(_userEntityInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public static void ApplyGameConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GameStatusConfiguration());

        modelBuilder.ApplyConfiguration(new GamePlayerStatusConfiguration());

        modelBuilder.ApplyConfiguration(new GameTeamStatusConfiguration());

        modelBuilder.ApplyConfiguration(new GameTeamIndexConfiguration());

        modelBuilder.ApplyConfiguration(new GameAvailabilityConfiguration());

        modelBuilder.ApplyConfiguration(new GameConfiguration());

        modelBuilder.ApplyConfiguration(new GameFinancialProfileConfiguration());

        modelBuilder.ApplyConfiguration(new GameGeneralProfileConfiguration());

        modelBuilder.ApplyConfiguration(new GameInventaryProfileConfiguration());

        modelBuilder.ApplyConfiguration(new GameTagConfiguration());

        modelBuilder.ApplyConfiguration(new GamePlayerConfiguration());

        modelBuilder.ApplyConfiguration(new GameTeamConfiguration());
    }
}
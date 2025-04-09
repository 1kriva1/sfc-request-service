using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using SFC.Request.Application.Interfaces.Persistence.Context;
using SFC.Request.Infrastructure.Persistence.Contexts;
using SFC.Request.Infrastructure.Persistence.Extensions;
using SFC.Request.Infrastructure.Persistence.Interceptors;

namespace SFC.Request.Infrastructure.Persistence;
public static class PersistenceRegistration
{
    public static void AddPersistenceServices(this WebApplicationBuilder builder)
    {
        // contexts
        builder.Services.AddDbContext<MetadataDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<DataDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<IdentityDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<RequestDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<PlayerDbContext>(builder.Configuration, builder.Environment);
        builder.Services.AddDbContext<TeamDbContext>(builder.Configuration, builder.Environment);

        // interceptors
        builder.Services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<DispatchDomainEventsSaveChangesInterceptor>();
        builder.Services.AddScoped<DataEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<UserEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<PlayerEntitySaveChangesInterceptor>();
        builder.Services.AddScoped<TeamEntitySaveChangesInterceptor>();

        // contexts by interfaces
        builder.Services.AddScoped<IMetadataDbContext, MetadataDbContext>();
        builder.Services.AddScoped<IDataDbContext, DataDbContext>();
        builder.Services.AddScoped<IIdentityDbContext, IdentityDbContext>();
        builder.Services.AddScoped<IRequestDbContext, RequestDbContext>();
        builder.Services.AddScoped<IPlayerDbContext, PlayerDbContext>();
        builder.Services.AddScoped<ITeamDbContext, TeamDbContext>();

        // repositories
        builder.Services.AddRepositories(builder.Configuration);
    }
}
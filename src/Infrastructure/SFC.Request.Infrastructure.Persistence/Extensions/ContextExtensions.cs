using System.Threading;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SFC.Request.Infrastructure.Persistence.Extensions;

namespace SFC.Request.Infrastructure.Persistence.Extensions;

public static class ContextExtensions
{
    public static void AddDbContext<T>(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment) where T : DbContext
    {
        bool isDevelopment = environment.IsDevelopment();

        services.AddDbContext<T>(options => options
            .UseSqlServer(configuration.GetConnectionString("Database"), b =>
            {
                b.MigrationsAssembly(typeof(T).Assembly.FullName);
                b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            })
            .EnableDetailedErrors(isDevelopment)
            .EnableSensitiveDataLogging(isDevelopment)
        );
    }

    public static async Task ClearAsync<T>(this DbContext context, CancellationToken cancellationToken = default)
    where T : class
    {
        ArgumentNullException.ThrowIfNull(context);

        // DELETE is executed immediately, before any later inserts
        await context.Set<T>().ExecuteDeleteAsync(cancellationToken).ConfigureAwait(false);

        // Detach stale tracked instances of this type only
        foreach (EntityEntry<T> entry in context.ChangeTracker.Entries<T>().ToList())
        {
            entry.State = EntityState.Detached;
        }
    }
}
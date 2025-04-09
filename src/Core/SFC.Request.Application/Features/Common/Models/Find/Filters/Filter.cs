using System.Linq.Expressions;

using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Application.Features.Common.Models.Find.Filters;

/// <summary>
/// Filter class.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
public class Filter<TEntity>
{
    /// <summary>
    /// Condition to define if filter expression will be used during query to database.
    /// </summary>
    public bool Condition { get; set; }

    /// <summary>
    /// Expression for filtering during quering to database.
    /// </summary>
    public Expression<Func<TEntity, bool>> Expression { get; set; } = default!;
}
﻿using SFC.Request.Application.Features.Common.Models.Find.Filters;
using SFC.Request.Application.Features.Common.Models.Find.Paging;
using SFC.Request.Application.Features.Common.Models.Find.Sorting;

namespace SFC.Request.Application.Features.Common.Models.Find;

/// <summary>
/// Compose class for execute find.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
public class FindParameters<TEntity>
{
    public Filters<TEntity>? Filters { get; set; }

    public Sortings<TEntity>? Sorting { get; set; }

    public required Pagination Pagination { get; set; }
}
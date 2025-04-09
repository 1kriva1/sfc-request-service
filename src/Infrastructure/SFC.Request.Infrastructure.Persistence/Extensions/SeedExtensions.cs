﻿using Microsoft.EntityFrameworkCore;

using SFC.Request.Application.Interfaces.Common;
using SFC.Request.Domain.Common;
using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Infrastructure.Persistence.Extensions;
public static class SeedExtensions
{
    public static void SeedEnumValues<TEntity, TEnum>(this ModelBuilder builder, Func<TEnum, TEntity> converter)
       where TEntity : EnumEntity<TEnum>, new()
       where TEnum : struct
    {
        IEnumerable<TEntity> metadataServices = Enum.GetValues(typeof(TEnum)).Cast<object>()
            .Select(value => converter((TEnum)value));
        builder.Entity<TEntity>().HasData(metadataServices);
    }

    public static void SeedDataEnumValues<TEntity, TEnum>(this ModelBuilder builder, Func<TEnum, TEntity> converter)
        where TEntity : EnumDataEntity<TEnum>
        where TEnum : struct
    {
        IEnumerable<TEntity> metadataServices = Enum.GetValues(typeof(TEnum)).Cast<object>()
            .Select(value => converter((TEnum)value));

        builder.Entity<TEntity>().HasData(metadataServices);
    }

    public static TEntity SetCreatedDate<TEntity>(this TEntity entity, IDateTimeService dateTimeService)
        where TEntity : IDataEntity
    {
        entity.CreatedDate = dateTimeService.Now;
        return entity;
    }
}
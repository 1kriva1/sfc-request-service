﻿using SFC.Request.Application.Interfaces.Persistence.Repository.Data;
using SFC.Request.Domain.Entities.Data;
using SFC.Request.Infrastructure.Persistence.Contexts;

namespace SFC.Request.Infrastructure.Persistence.Repositories.Data;
public class StatCategoryRepository(DataDbContext context)
    : DataRepository<StatCategory, StatCategoryEnum>(context), IStatCategoryRepository
{ }
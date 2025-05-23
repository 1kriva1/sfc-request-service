﻿using SFC.Request.Domain.Entities.Request.Data;

namespace SFC.Request.Application.Interfaces.Request.Data.Models;
public record GetAllRequestDataModel
{
    public IEnumerable<RequestStatus> RequestStatuses { get; init; } = [];
}
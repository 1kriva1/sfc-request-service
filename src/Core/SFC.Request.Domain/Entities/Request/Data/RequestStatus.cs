﻿using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Request.Data;
public class RequestStatus : EnumDataEntity<RequestStatusEnum>
{
    public RequestStatus() : base() { }

    public RequestStatus(RequestStatusEnum enumType) : base(enumType) { }
}
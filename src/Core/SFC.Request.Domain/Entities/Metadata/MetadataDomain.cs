﻿using SFC.Request.Domain.Common;

namespace SFC.Request.Domain.Entities.Metadata;
public class MetadataDomain : EnumEntity<MetadataDomainEnum>
{
    public MetadataDomain() : base() { }

    public MetadataDomain(MetadataDomainEnum enumType) : base(enumType) { }
}
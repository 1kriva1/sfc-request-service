using AutoMapper;

using SFC.Request.Application.Common.Extensions;
using SFC.Request.Application.Common.Mappings.Converters.File;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Application.Features.Common.Dto.Common;
using SFC.Request.Domain.Entities.Team.General;

namespace SFC.Request.Application.Common.Dto.Team.General;
public class TeamLogoDto : FileDto, IMapFromReverse<TeamLogo>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamLogo, TeamLogoDto>();

        profile.CreateMap<string?, TeamLogoDto?>()
               .ConvertUsing<Base64StringToFileTypeConverter<TeamLogoDto>>();

        profile.CreateMap<TeamLogoDto?, string?>()
               .ConvertUsing<FileToBase64StringTypeConverter<TeamLogoDto>>();

        profile.CreateMap<TeamLogoDto, TeamLogo>()
               .IgnoreAllNonExisting();
    }
}
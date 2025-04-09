using SFC.Request.Application.Common.Dto.Data;
using SFC.Request.Application.Common.Mappings.Interfaces;
using SFC.Request.Domain.Entities.Team.Data;

namespace SFC.Request.Application.Features.Team.Data.Common.Dto;
public class TeamPlayerStatusDto : DataDto, IMapTo<TeamPlayerStatus> { }
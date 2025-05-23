using AutoMapper;

using SFC.Request.Application.Interfaces.Request.Data.Models;
using SFC.Request.Messages.Commands.Common;
using SFC.Request.Messages.Events.Request.Data;

using RequestDataValue = SFC.Request.Messages.Models.Data.DataValue;
using TeamDataValue = SFC.Team.Messages.Models.Data.DataValue;
using TeamInitializeData = SFC.Team.Messages.Commands.Request.Data.InitializeData;

namespace SFC.Request.Infrastructure.Extensions;
public static class MessagesExtensions
{
    public static DataInitialized BuildRequestDataInitializedEvent(this IMapper mapper, GetAllRequestDataModel model)
    {
        DataInitialized message = new()
        {
            RequestStatuses = mapper.Map<IEnumerable<RequestDataValue>>(model.RequestStatuses)
        };

        return message;
    }

    public static TeamInitializeData BuildInitializeDataCommand(this IMapper mapper, GetTeamDataModel model)
    {
        TeamInitializeData message = new()
        {
            RequestStatuses = mapper.Map<IEnumerable<TeamDataValue>>(model.RequestStatuses)
        };

        return message;
    }
    public static T SetCommandInitiator<T>(this T command, string initiator) where T : InitiatorCommand
    {
        command.Initiator = initiator;
        return command;
    }
}
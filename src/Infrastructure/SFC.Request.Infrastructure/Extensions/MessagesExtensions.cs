using SFC.Request.Messages.Commands.Common;

namespace SFC.Request.Infrastructure.Extensions;
public static class MessagesExtensions
{
    public static T SetCommandInitiator<T>(this T command, string initiator) where T : InitiatorCommand
    {
        command.Initiator = initiator;
        return command;
    }
}
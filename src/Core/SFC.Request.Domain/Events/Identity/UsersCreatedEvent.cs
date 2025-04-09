using SFC.Request.Domain.Common;
using SFC.Request.Domain.Entities.Identity;

namespace SFC.Request.Domain.Events.Identity;
public class UsersCreatedEvent(IEnumerable<User> users) : BaseEvent
{
    public IEnumerable<User> Users { get; } = users;
}
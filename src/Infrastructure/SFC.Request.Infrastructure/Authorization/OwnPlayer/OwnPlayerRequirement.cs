using Microsoft.AspNetCore.Authorization;

namespace SFC.Request.Infrastructure.Authorization.OwnPlayer;
public class OwnPlayerRequirement : IAuthorizationRequirement
{
    public OwnPlayerRequirement() { }

    public override string ToString()
    {
        return "OwnPlayerRequirement: Requires user has be owner of resource.";
    }
}
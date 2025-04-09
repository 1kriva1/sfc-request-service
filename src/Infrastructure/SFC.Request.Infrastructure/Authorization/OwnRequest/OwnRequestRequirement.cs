using Microsoft.AspNetCore.Authorization;

namespace SFC.Request.Infrastructure.Authorization.OwnRequest;
public class OwnRequestRequirement : IAuthorizationRequirement
{
    public OwnRequestRequirement() { }

    public override string ToString()
    {
        return "OwnRequestRequirement: Requires user has be owner of resource.";
    }
}
using Microsoft.AspNetCore.Http;

using SFC.Request.Application.Interfaces.Identity;
using SFC.Request.Infrastructure.Extensions;

namespace SFC.Request.Infrastructure.Services.Identity;
public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Guid? GetUserId() => _httpContextAccessor.GetUserId();
}
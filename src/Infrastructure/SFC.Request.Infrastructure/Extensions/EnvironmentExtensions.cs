using SFC.Request.Infrastructure.Constants;

namespace SFC.Request.Infrastructure.Extensions;
public static class EnvironmentExtensions
{
    public static bool IsRunningInContainer => Environment.GetEnvironmentVariable(EnvironmentConstants.RunningInContainer) == "true";
}
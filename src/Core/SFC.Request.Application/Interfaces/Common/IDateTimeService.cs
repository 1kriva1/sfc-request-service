namespace SFC.Request.Application.Interfaces.Common;

/// <summary>
/// Data and time service.
/// </summary>
public interface IDateTimeService
{
    DateTime Now { get; }

    DateTime DateNow { get; }
}
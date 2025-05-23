using SFC.Request.Application.Common.Constants;
using SFC.Request.Domain.Common.Interfaces;

namespace SFC.Request.Application.Common.Extensions;
public static class LocalizationExtensions
{
    public static void Localize(this IEnumEntity value) => value.Title = Localization.GetDataValue(value.Title);

    public static IEnumerable<T> Localize<T>(this IEnumerable<T> values)
        where T : IEnumEntity
    {
        foreach (IEnumEntity value in values)
        {
            value.Localize();
        }

        return values;
    }
}
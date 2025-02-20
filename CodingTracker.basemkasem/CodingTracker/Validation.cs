using System.Globalization;

namespace CodingTracker;

internal static class Validation
{
    public static (bool Check, DateTime Value) ValidateTime(this string time)
    {
        return (DateTime.TryParseExact(time, "dd/MM/yyyy hh:mm", new CultureInfo("fr-FR"),DateTimeStyles.None,out DateTime t), t);
    }

}

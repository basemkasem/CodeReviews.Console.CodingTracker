namespace CodingTracker;

internal static class Validation
{
    public static (bool Check, DateTime Value) ValidateTime(this string time)
    {
        return (DateTime.TryParse(time, out DateTime t), t);
    }

}

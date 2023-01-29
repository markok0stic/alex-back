namespace MusiciansAbilities.Helpers;

public static class DateTimeHelper
{
    private const int Difference = +1;
    private static DateTime GetDtNow(string zone = "") {
        DateTime now = DateTime.UtcNow;
        try
        {
            now = now.AddHours(Difference);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return now;
    }
        
    public static DateTime GetDateTimeNow(string zone = "") {
        DateTime now = GetDtNow(zone);
        return now.AddSeconds(-10);
    }
}

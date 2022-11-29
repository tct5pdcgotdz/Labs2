namespace Banks.Entities;

public static class Time
{
    private static DateTime _timeNow = DateTime.Now;

    public static void AddMonths(int monthsCount)
    {
        _timeNow = _timeNow.AddMonths(monthsCount);
    }

    public static void AddDays(int daysCount)
    {
        _timeNow = _timeNow.AddDays(daysCount);
    }

    public static DateTime GetTimeNow()
    {
        return _timeNow;
    }
}
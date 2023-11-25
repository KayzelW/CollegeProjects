namespace Time;

public struct Time
{
    private int Seconds;

    public Time(int hours, int minutes, int seconds)
    {
        this.Seconds = hours * 3600 + minutes * 60 + seconds;
        CheckSecondsBelowZero();
    }

    public Time(int totalSeconds) : this()
    {
        this.Seconds = totalSeconds;
        CheckSecondsBelowZero();
    }

    public static Time FromDateTime(DateTime time) 
        => new Time(time.Hour, time.Minute, time.Second);

    public static Time FromTotalSeconds(int totalSeconds)
    {
        return new Time(totalSeconds);
    }

    public static Time FromTimeString(string timeString)
    {
        string[] parts = timeString.Split(':');
        if (parts.Length == 3 && int.TryParse(parts[0], out int hours) && int.TryParse(parts[1], out int minutes) && int.TryParse(parts[2], out int secs))
        {
            return new Time(hours, minutes, secs);
        }
        else
        {
            throw new ArgumentException("Invalid time string format");
        }
    }

    #region methods
    private void CheckSecondsBelowZero() 
        => this.Seconds = this.Seconds < 0 ? 0 : this.Seconds;

    public static int DifferenceInSeconds(Time time1, Time time2)
        => Math.Abs(time1.Seconds - time2.Seconds);

    public static Time AddSeconds(Time time, int secondsToAdd)
    {
        time.Seconds += secondsToAdd;
        return time;
    }

    public static Time SubtractSeconds(Time time, int secondsToSubtract)
    {
        time.Seconds -= secondsToSubtract;
        if (time.Seconds < 0)
        {
            time.Seconds = 0;
        }
        return time;
    }

    public static bool Equals(Time time1, Time time2)
        => time1.Seconds == time2.Seconds;

    public static int ToSeconds(Time time)
        => time.Seconds;

    public static int ToMinutes(Time time)
        => (int)(time.Seconds / 60.0 + 0.5);

    public static void PrintTime(Time time)
    {
        Console.WriteLine($"{time.Seconds / 3600:D2}:{(time.Seconds % 3600) / 60:D2}:{time.Seconds % 60:D2}");
    }
    #endregion
}
/* также тестовый main
public class Program
{
    public static void Main()
    {
        Time time1 = new Time(1, 30, 0);
        Time time2 = new Time(0, 45, 0);

        Time result1 = Time.AddSeconds(time1, Time.ToSeconds(time2));
        Time result2 = Time.SubtractSeconds(time1, Time.ToSeconds(time2));

        Time.PrintTime(result1);
        Time.PrintTime(result2);

        Time time3 = Time.FromDateTime(DateTime.Now);
        Time time4 = Time.FromTotalSeconds(5000);
        Time time5 = Time.FromTimeString("12:34:56");

        Time.PrintTime(time3);
        Time.PrintTime(time4);
        Time.PrintTime(time5);
    }
}
*/
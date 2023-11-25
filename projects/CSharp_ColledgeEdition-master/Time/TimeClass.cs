namespace Time;

public class TimeClass
{
    private int seconds = 0;
    public int Seconds
    {
        get { return seconds; }
        private set { seconds = (value < 0) ? 0 : value; }
    }
    public int ToSeconds => this.Seconds;
    public int ToMinutes => this.Seconds / 60;
    public int ToHours => this.Seconds / 3600;
    public TimeClass()
    {
        this.Seconds = 0;
    }

    #region methods
    public override string ToString()
        => $"{Seconds / 3600:D2}:{Seconds % 3600 / 60:D2}:{Seconds % 60:D2}";
    public bool Equals(TimeClass otherTime)
        => this.seconds == otherTime.seconds;
    public void SubtractSeconds(int secondsToSubtract)
        => this.Seconds -= secondsToSubtract;
    public void AddSeconds(int secondsToAdd)
        => this.Seconds += secondsToAdd;
    public int DifferenceInSeconds(TimeClass otherTime)
        => Math.Abs(this.Seconds - otherTime.Seconds);
    public static TimeClass operator +(TimeClass time1, TimeClass time2)
        => new TimeClass(time1.Seconds + time2.Seconds);
    public static TimeClass operator -(TimeClass time1, TimeClass time2)
    {
        int resultSeconds = time1.Seconds - time2.Seconds;
        return new TimeClass(resultSeconds < 0 ? 0 : resultSeconds);
    }
    #endregion

    #region constructors
    public TimeClass(DateTime time)
        => this.Seconds = time.Hour * 3600 + time.Minute * 60 + time.Second;

    public TimeClass(int totalSeconds)
        => this.Seconds = totalSeconds;

    public TimeClass(int hours, int minutes, int seconds)
        => this.Seconds = hours * 3600 + minutes * 60 + seconds;

    public TimeClass(string timeString)
    {
        string[] parts = timeString.Split(':');
        if (parts.Length == 3 && int.TryParse(parts[0], out int hours) && int.TryParse(parts[1], out int minutes) && int.TryParse(parts[2], out int secs))
        {
            this.Seconds = hours * 3600 + minutes * 60 + secs;
        }
        else
        {
            throw new ArgumentException("Invalid time string format");
        }
    }
    #endregion
}

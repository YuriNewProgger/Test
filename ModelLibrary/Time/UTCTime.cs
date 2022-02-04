namespace ModelLibrary.Time;

public class UTCTime : ITime
{
    public DateTime GetTime()
    {
        return DateTime.UtcNow;
    }
}
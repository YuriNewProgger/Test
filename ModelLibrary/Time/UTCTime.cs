namespace ModelLibrary.Time;

public class UtcClock : IClock
{
    public TimeOnly GetTime()
    {
        return new TimeOnly( DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, DateTime.UtcNow.Second);
        
    }
}
namespace ModelLibrary.Time;

public class LocalTime : IClock
{
    public TimeOnly GetTime() => new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute);
    
}

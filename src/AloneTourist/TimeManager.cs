namespace AloneTourist;

public class TimeManager
{
    private DateTime currentTime;
    private readonly DateTime endTime;

    public TimeManager(int startHour = 8, int endHour = 20)
    {
        currentTime = DateTime.Today.AddHours(startHour);
        endTime = DateTime.Today.AddHours(endHour);
    }

    public DateTime CurrentTime => currentTime;
    public bool IsTimeUp => currentTime >= endTime;
    
    public void AdvanceTime(TimeSpan amount, Tourist tourist)
    {
        currentTime = currentTime.Add(amount);
        tourist.PassTime(amount);
    }

    public string GetCurrentTime()
    {
        return currentTime.ToString("HH:mm");
    }

    public string GetTimeLeft()
    {
        var remaining = endTime - currentTime;
        return remaining > TimeSpan.Zero ? remaining.ToString(@"hh\:mm") : "00:00";
    }

    public void Reset()
    {
        currentTime = DateTime.Today.AddHours(8);
    }
}
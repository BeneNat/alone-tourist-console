namespace AloneTourist;

public class Park : BaseAttraction
{
    public Park(string name, string description)
    {
        Name = name;
        Description = description;
        Symbol = 'P';
    }

    public override void Visit(Tourist tourist, TimeManager timeManager)
    {
        const int visitMinutes = 30;
        
        tourist.AddLog($"Relaxed at {Name}");
        LogVisit(tourist);
        timeManager.AdvanceTime(TimeSpan.FromMinutes(visitMinutes), tourist);
    }
}
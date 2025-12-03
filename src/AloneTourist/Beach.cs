namespace AloneTourist;

public class Beach : BaseAttraction
{
    public Beach(string name, string description)
    {
        Name = name;
        Description = description;
        Symbol = 'B';
    }

    public override void Visit(Tourist tourist, TimeManager timeManager)
    {
        const int visitMinutes = 60;
        
        tourist.AddLog($"Visited and relaxed {Name}.");
        tourist.Inventory.AddPhoto(new Photo($"{Name}", DateTime.Now));
        tourist.AddLog($"Took a photo at {Name}.");
        LogVisit(tourist);
        timeManager.AdvanceTime(TimeSpan.FromMinutes(visitMinutes), tourist);
    }
}
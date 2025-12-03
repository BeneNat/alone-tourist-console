namespace AloneTourist;

public class Castle : BaseAttraction
{
    private decimal entryFee;

    public Castle(string name, string description, decimal entryFee = 15.5m)
    {
        Name = name;
        Description = description;
        this.entryFee = entryFee;
        Symbol = 'Z';
    }

    public override void Visit(Tourist tourist, TimeManager timeManager)
    {
        const int visitMinutes = 30;
        
        if (tourist.SpendMoney(entryFee))
        {
            tourist.AddLog($"Paid {entryFee} zl to enter {Name}.");
            tourist.Inventory.AddPhoto(new Photo($"{Name} Exhibit", DateTime.Now));
            tourist.AddLog($"Took a photo inside {Name}.");
            LogVisit(tourist);
            timeManager.AdvanceTime(TimeSpan.FromMinutes(visitMinutes), tourist);
        }
        else
        {
            tourist.AddLog($"Could not afford to enter {Name}.");
        }
    }
}
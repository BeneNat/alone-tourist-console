namespace AloneTourist;

public class Museum : BaseAttraction
{
    private decimal entryFee;

    public Museum(string name, string description, decimal entryFee = 20m)
    {
        Name = name;
        Description = description;
        this.entryFee = entryFee;
        Symbol = 'M';
    }

    public override void Visit(Tourist tourist, TimeManager timeManager)
    {
        const int visitMinutes = 45;
        
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
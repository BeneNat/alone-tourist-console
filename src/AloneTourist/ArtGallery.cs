namespace AloneTourist;

public class ArtGallery : BaseAttraction
{
    private decimal entryFee;

    public ArtGallery(string name, string description, decimal entryFee = 35m)
    {
        Name = name;
        Description = description;
        this.entryFee = entryFee;
        Symbol = 'G';
    }

    public override void Visit(Tourist tourist, TimeManager timeManager)
    {
        const int visitMinutes = 45;
        
        if (tourist.SpendMoney(entryFee))
        {
            tourist.AddLog($"Paid {entryFee} zl to enter {Name}.");
            tourist.Inventory.AddPhoto(new Photo($"{Name}: work of art", DateTime.Now));
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
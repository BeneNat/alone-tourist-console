namespace AloneTourist;

public class Theatre : BaseAttraction
{
    private decimal entryFee;

    public Theatre(string name, string description, decimal entryFee = 20m)
    {
        Name = name;
        Description = description;
        this.entryFee = entryFee;
        Symbol = 'T';
    }

    public override void Visit(Tourist tourist, TimeManager timeManager)
    {
        const int visitMinutes = 90;
        
        if (tourist.SpendMoney(entryFee))
        {
            tourist.AddLog($"Paid {entryFee} zl to enter {Name}.");
            tourist.AddLog("You relax by watching a theater play.");
            LogVisit(tourist);
            timeManager.AdvanceTime(TimeSpan.FromMinutes(visitMinutes), tourist);
        }
        else
        {
            tourist.AddLog($"Could not afford to enter {Name}.");
        }
    }
}
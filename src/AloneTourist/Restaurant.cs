namespace AloneTourist;

public class Restaurant : BaseAttraction
{
    private decimal foodPrice;
    private int foodRestoreAmount;
    private int thirstRestoreAmount;
    
    public Restaurant(string name, string description, decimal foodPrice = 25m, int foodRestoreAmount = 40, int thirstRestoreAmount = 10)
    {
        Name = name;
        Description = description;
        this.foodPrice = foodPrice;
        this.foodRestoreAmount = foodRestoreAmount;
        this.thirstRestoreAmount = thirstRestoreAmount;
        Symbol = 'R';
    }

    public override void Visit(Tourist tourist, TimeManager timeManager)
    {
        const int visitMinutes = 40;

        if (tourist.SpendMoney(foodPrice))
        {
            tourist.Eat(foodRestoreAmount);
            tourist.Drink(thirstRestoreAmount);
            tourist.AddLog($"Ate at {Name} for {foodPrice} zl (+{foodRestoreAmount} hunger, +{thirstRestoreAmount} thirst).");
            timeManager.AdvanceTime(TimeSpan.FromMinutes(visitMinutes), tourist);
            LogVisit(tourist);
        }
        else
        {
            tourist.AddLog($"Couldn't afford food at {Name} ({foodPrice} zl).");
        }
    }
}
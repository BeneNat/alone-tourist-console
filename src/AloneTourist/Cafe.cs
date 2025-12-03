namespace AloneTourist;

public class Cafe : BaseAttraction
{
    private decimal drinkPrice;
    private int thirstRestoreAmount;
    private int foodRestoreAmount;

    public Cafe(string name, string description, decimal drinkPrice = 15m, int thirstRestoreAmount = 30, int foodRestoreAmount = 10)
    {
        Name = name;
        Description = description;
        this.drinkPrice = drinkPrice;
        this.thirstRestoreAmount = thirstRestoreAmount;
        this.foodRestoreAmount = foodRestoreAmount;
        Symbol = 'C';
    }
    
    public override void Visit(Tourist tourist, TimeManager timeManager)
    {
        const int visitMinutes = 30;

        if (tourist.SpendMoney(drinkPrice))
        {
            tourist.Drink(thirstRestoreAmount);
            tourist.Eat(foodRestoreAmount);
            tourist.AddLog($"Drank something at {Name} for {drinkPrice} zl (+{thirstRestoreAmount} thirst, +{foodRestoreAmount} hunger).");
            timeManager.AdvanceTime(TimeSpan.FromMinutes(visitMinutes), tourist);
            LogVisit(tourist);
        }
        else
        {
            tourist.AddLog($"Couldn't afford a drink at {Name} ({drinkPrice} zl).");
        }
    }
}
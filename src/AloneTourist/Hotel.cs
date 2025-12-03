namespace AloneTourist;

public class Hotel : BaseAttraction
{
    public Hotel()
    {
        Name = "Hotel";
        Description = "Starting point";
        Symbol = 'H';
    }

    public override void Visit(Tourist tourist, TimeManager timeManager)
    {
        tourist.Eat(20);
        tourist.Drink(20);
        tourist.AddLog("Returned to the hotel to rest or grab something.");
        LogVisit(tourist);
    }
}
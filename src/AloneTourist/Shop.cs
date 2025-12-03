namespace AloneTourist;

public class Shop : IAttraction
{
    public string Name { get; }
    public string Description { get; }
    private readonly Souvenir souvenir;
    public char Symbol => 'Y';

    public Shop(string name, string description, Souvenir souvenir)
    {
        Name = name;
        Description = description;
        this.souvenir = souvenir;
    }

    //public void Interact(Tourist tourist)
    public void Visit(Tourist tourist, TimeManager timeManager)
    {
        const int visitMinutes = 20;
        
        if (tourist == null) return;

        if (tourist.Money >= souvenir.Price)
        {
            tourist.SpendMoney(souvenir.Price);
            tourist.Inventory.AddSouvenir(souvenir);
            tourist.AddLog($"Bought {souvenir.Name} at {Name}.");
            timeManager.AdvanceTime(TimeSpan.FromMinutes(visitMinutes), tourist);
        }
        else
        {
            tourist.InteractionLog.Add($"{Name}: Not enough money for {souvenir.Name}.");
        }
        
    }
}
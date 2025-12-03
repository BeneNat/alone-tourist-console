namespace AloneTourist;

public class SouvenirShop : BaseAttraction
{
    private List<Souvenir> availableSouvenirs = new List<Souvenir>
    {
        new Souvenir("Keychain", 8, "Nice keychain with city symbol."),
        new Souvenir("Postcard", 4, "Postcard with city landmark."),
        new Souvenir("Magnet", 7, "A magnet that can be attached, for example, to the refrigerator."),
        new Souvenir("Mini Statue", 25, "Some kind of paperweight."),
        new Souvenir("T-shirt", 30, "You'll wear it once but it has a cool print.")
    };

    public SouvenirShop(string name, string description)
    {
        Name = name;
        Description = description;
        Symbol = 'S';
    }

    public override void Visit(Tourist tourist, TimeManager timeManager)
    {
        const int visitMinutes = 20;
        int consoleWidth = Console.WindowWidth;

        int padding = (consoleWidth - Name.Length) / 2;
        string centeredName = new string(' ', Math.Max(padding, 0)) + Name;
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', consoleWidth));
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(centeredName);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('-', consoleWidth));
        Console.ResetColor();
        
        Console.WriteLine("Available souevenirs:");

        for (int i = 0; i < availableSouvenirs.Count; i++)
        {
            var item = availableSouvenirs[i];
            Console.WriteLine($"{i+1}. {item.Name} - {item.Price} zl - {item.Description}");
        }
        
        Console.Write("Select a souvenir to buy (0 to cancel): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= availableSouvenirs.Count)
        {
            var selected = availableSouvenirs[choice - 1];
            if (tourist.Money >= selected.Price)
            {
                tourist.SpendMoney(selected.Price);
                tourist.Inventory.AddSouvenir(selected);
                Console.WriteLine($"You bought a {selected.Name} for {selected.Price} zl.");
                tourist.AddLog($"Bought {selected.Name} at {Name}.");
            }
            else
            {
                Console.WriteLine("Not enough money to buy this souvenir.");
                tourist.AddLog($"Not enough money to buy {selected.Name}");
            }
            LogVisit(tourist);
            timeManager.AdvanceTime(TimeSpan.FromMinutes(visitMinutes), tourist);
        }
        else
        {
            Console.WriteLine("Cancelled or invalid choice.");
            tourist.AddLog("Cancelled or invalid choice.");
        }
        Console.ResetColor();
    }
}
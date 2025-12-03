namespace AloneTourist;

public class Tourist
{
    private decimal money;
    private Position position;
    
    public string Name { get; }
    public Inventory Inventory { get; }
    public List<string> InteractionLog { get; private set; }
    public int Hunger { get; private set; } = 100;
    public int Thirst { get; private set; } = 100;

    public decimal Money
    {
        get => money;
        private set => money = value >= 0 ? value : 0;
    }

    public Position Position
    {
        get => position;
        private set => position = value;
    }

    public Tourist(string name, decimal startingMoney, Position startPosition)
    {
        Name = name;
        Money = startingMoney;
        Position = startPosition;
        Inventory = new Inventory();
        InteractionLog = new List<string>();
    }

    public bool SpendMoney(decimal amount)
    {
        if (amount <= Money)
        {
            Money -= amount;
            return true;
        }

        return false;
    }

    public void AddLog(string logEntry)
    {
        InteractionLog.Add($"{DateTime.Now:HH:mm} - {logEntry}");
    }

    public void Move(Direction direction)
    {
        Position = Position.Move(direction);
    }

    public void MoveTo(Position position)
    {
        Position = position;
    }

    public void PassTime(TimeSpan timePassed)
    {
        int hours = (int)Math.Ceiling(timePassed.TotalHours);
        Hunger = Math.Max(0, Hunger - 5 * hours);
        Thirst = Math.Max(0, Thirst - 8 * hours);
    }

    public void Eat(int amount)
    {
        Hunger = Math.Min(100, Hunger + amount);
    }

    public void Drink(int amount)
    {
        Thirst = Math.Min(100, Thirst + amount);
    }

    public void RestAtHotel()
    {
        Hunger = 100;
        Thirst = 100;
        AddLog("You rested at the hotel. Hunger and thirst restored.");
    }
}
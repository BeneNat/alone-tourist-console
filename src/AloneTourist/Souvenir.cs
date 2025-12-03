namespace AloneTourist;

public class Souvenir
{
    public string Name { get; }
    public decimal Price { get; }
    public string Description { get; }

    public Souvenir(string name, decimal price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
    }

    public override string ToString() => $"{Name} ({Price} zl) - {Description}";
}
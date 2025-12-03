namespace AloneTourist;

public interface IAttraction
{
    string Name { get; }
    string Description { get; }
    public char Symbol { get; }
    //void Interact(Tourist tourist);
    void Visit(Tourist tourist, TimeManager timeManager);
}
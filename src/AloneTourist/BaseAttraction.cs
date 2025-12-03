namespace AloneTourist;

public abstract class BaseAttraction : IAttraction
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public char Symbol { get; protected set; }

    public abstract void Visit(Tourist tourist, TimeManager timeManager);

    protected void LogVisit(Tourist tourist)
    {
        tourist.AddLog($"Visited: {Name}");
    }
}
namespace AloneTourist;

public class Landmark : IAttraction
{
    public string Name { get; }
    public string Description { get; }
    public char Symbol => 'L';

    public Landmark(string name, string description)
    {
        Name = name;
        Description = description;
    }

    //public void Interact(Tourist tourist)
    public void Visit(Tourist tourist, TimeManager timeManager)
    {
        const int visitMinutes = 30;
        
        if (tourist == null) return;

        var photo = new Photo(Name, DateTime.Now);
        tourist.Inventory.AddPhoto(photo);
        tourist.InteractionLog.Add($"{Name}: Took a photo.");
        timeManager.AdvanceTime(TimeSpan.FromMinutes(visitMinutes), tourist);
    }
}
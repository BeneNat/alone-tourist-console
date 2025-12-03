namespace AloneTourist;

public class Inventory
{
    private readonly List<Souvenir> souvenirs = new();
    private readonly List<Photo> photos = new();

    public IReadOnlyList<Souvenir> Souvenirs => souvenirs.AsReadOnly();
    public IReadOnlyList<Photo> Photos => photos.AsReadOnly();

    public void AddSouvenir(Souvenir souvenir)
    {
        if (souvenir != null)
        {
            souvenirs.Add(souvenir);
        }
    }
    
    public void AddPhoto(Photo photo)
    {
        if (photo != null)
        {
            photos.Add(photo);
        }
    }

    public string GetInventorySummary()
    {
        var souvenirList = souvenirs.Any()
            ? string.Join("\n", souvenirs.Select(s => $"- {s}"))
            : "No souvenirs collected";

        var photoCount = photos.Count();
        var photoSummary = $"Photos taken: {photoCount}";

        return $"Souvenirs:\n{souvenirList}\n{photoSummary}";
    }
}
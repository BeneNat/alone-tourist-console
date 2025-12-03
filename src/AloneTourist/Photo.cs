using System.Globalization;

namespace AloneTourist;

public class Photo
{
    public string PlaceName { get; }
    public DateTime TimeTaken { get; }

    public Photo(string placeName, DateTime timeTaken)
    {
        PlaceName = placeName;
        TimeTaken = timeTaken;
    }

    public override string ToString() => $"Photo at {PlaceName} - {TimeTaken:t}";
}
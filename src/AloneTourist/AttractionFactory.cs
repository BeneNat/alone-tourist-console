namespace AloneTourist;

public static class AttractionFactory
{
    private static Random random = new Random();

    public static IAttraction CreateAttraction(string type)
    {
        return type.ToLower() switch
        {
            "museum" => new Museum("City Museum", "Explore the city's rich history."),
            "park" => new Park("Green Park", "A relaxing place with trees."),
            "castle" => new Castle("Royal Castle", "Medieval architecture and exhibits."),
            "restaurant" => new Restaurant("Bistro 24", "A cozy local restaurant."),
            "beach" => new Beach("Sunny Beach", "Enjoy the sun and waves."),
            "shop" => new SouvenirShop("Bazaar", "Buy tourist trinkets."),
            "theatre" => new Theatre("Old Theatre", "Live plays and performances."),
            "gallery" => new ArtGallery("Modern Gallery", "Contemporary art."),
            "landmark" => new Landmark("City Landmark", "Somewhere to admire the view."),
            "coffee" => new Cafe("Coffeeland", "Warm drinks and rest"),
            "stall" => new Shop("Small Stall", "The little stall of the old lady", new Souvenir("Handmade mug", 20, "Locally handcrafted mug")),
            _ => new Landmark("City Landmark", "Somewhere to admire the view."),
        };
    }

    public static IAttraction CreateRandomAttraction()
    {
        string[] types = { "museum", "park", "castle", "restaurant", "beach", "shop", "theatre", "gallery", "landmark", "coffee", "stall" };
        string randomType = types[random.Next(types.Length)];
        return CreateAttraction(randomType);
    }
}
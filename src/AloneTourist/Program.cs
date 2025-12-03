namespace AloneTourist;

internal class Program
{
    static void Main(string[] args)
    {
        // First test of map and Tourist
        /*var tourist = new Tourist("Oliwia", 100m, new Position(0, 0));
        var cityMap = new CityMap(5, 5);
        
        cityMap.AddAttraction(new Position(1, 1), new Shop("Gift Shop", "Local souvenirs", new Souvenir("Mug", 30m, "Ceramic Mug")));
        cityMap.AddAttraction(new Position(2, 2), new Landmark("Old Tower", "Historical Tower"));
        
        cityMap.Render(tourist.Position);
        
        tourist.Move(Direction.Right); // (1, 0)
        tourist.Move(Direction.Down); // (1, 1)
        var attraction = cityMap.GetAttractionAt(tourist.Position);
        attraction?.Interact(tourist);
        
        Console.WriteLine(tourist.Inventory.GetInventorySummary());*/
        
        // Second test - moving around map and game loop
        var game = new GameEngine();
        game.Start();
    }
}
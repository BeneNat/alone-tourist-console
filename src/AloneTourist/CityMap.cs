namespace AloneTourist;

public class CityMap
{
    private readonly int width;
    private readonly int height;
    private readonly Dictionary<Position, IAttraction> attractions = new();

    public int Width => width;
    public int Height => height;

    public CityMap(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void AddAttraction(Position position, IAttraction attraction)
    {
        if (position.X >= 0 && position.X < width &&
            position.Y >= 0 && position.Y < height && attraction != null)
        {
            attractions[position] = attraction;
        }
    }

    public IAttraction? GetAttractionAt(Position position)
    {
        attractions.TryGetValue(position, out var attraction);
        return attraction;
    }

    public void Render(Position touristPosition)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("City Map:");
        Console.ResetColor();

        int mapWidth = width * 2;
        int consoleWidth = Console.WindowWidth;
        int margin = (consoleWidth - mapWidth) / 2;
        
        for(int y=0; y<height; y++)
        {
            Console.Write(new string(' ', margin));
            for (int x = 0; x < width; x++)
            {
                var pos = new Position(x, y);
                
                if(touristPosition.Equals(pos))
                    Console.Write("@ ");
                //else if(attractions.ContainsKey(pos))
                    //Console.Write("# ");
                else if(attractions.TryGetValue(pos, out var attraction))
                    Console.Write($"{attraction.Symbol} ");
                else
                    Console.Write(". ");
            }
            Console.WriteLine();
        }
    }
}
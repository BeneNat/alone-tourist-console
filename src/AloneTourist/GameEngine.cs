using System.Reflection;

namespace AloneTourist;

public class GameEngine
{
    private CityMap cityMap;
    private Tourist tourist;
    private bool isRunning;
    private TimeManager timeManager;
    private readonly Position hotelPosition = new Position(0, 0);
    private int currentDay = 1;
    private int totalDays = 3;

    public void Start()
    {
        InitializeGame();

        while (currentDay <= totalDays)
        {
            int consoleWidth = Console.WindowWidth;
            
            StartDay();
            EndDay();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('═', consoleWidth));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"End of Day {currentDay} Summary:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('═', consoleWidth));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Returned to hotel at {timeManager.GetCurrentTime()}");
            Console.WriteLine($"Inventory: {tourist.Inventory.GetInventorySummary()}");
            Console.WriteLine($"Money: {tourist.Money} zl");
            Console.ResetColor();
            
            if (currentDay < totalDays)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Press any key to continue to day {currentDay + 1}...");
                Console.ReadKey();
                Console.ResetColor();
                currentDay++;
                timeManager.Reset();
            }
            else
            {
                Console.WriteLine("\nAll days of the trip have come to an end!");
                DisplaySummary();
                break;
            }
        }
        
        Console.WriteLine("\nThanks for playing!");
    }

    private void InitializeGame()
    {
        int consoleWidth = Console.WindowWidth;
        string title = "Welcome to Alone Tourist!";

        int padding = (consoleWidth - title.Length) / 2;
        string centeredTitle = new string(' ', Math.Max(padding, 0)) + title;
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', consoleWidth));
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(centeredTitle);
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', consoleWidth));
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("Enter your tourist's name: ");
        Console.ResetColor();
        string name = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(name))
            name = "Anonymous";
        
        
        decimal startingMoney = 0;
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("Choose difficulty (Easy/Medium/Hard/Custom): ");
        Console.ResetColor();
        var difficulty = Console.ReadLine().Trim().ToLower();
        
        switch (difficulty)
        {
            case "easy": 
                startingMoney = 1000m;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Easy selected – You start well-funded!");
                Console.ResetColor();
                break;
            case "medium":
                startingMoney = 500m;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Medium selected – A balanced challenge.");
                Console.ResetColor();
                break;
            case "hard":
                startingMoney = 200m;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hard selected – You'll need to plan wisely!");
                Console.ResetColor();
                break;
            case "custom":
                bool validMoney = false;
                while (!validMoney)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Enter starting money (e.g. 500): ");
                    Console.ResetColor();
                    string? input = Console.ReadLine();
                    validMoney = decimal.TryParse(input, out startingMoney) && startingMoney > 0;

                    if (!validMoney)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Please enter a valid amount (greater than 0).");
                        Console.ResetColor();
                    }
                }
                break;
            default:
                startingMoney = 500m;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Defaulting to Medium difficulty.");
                Console.ResetColor();
                break;
        }
        
        //tourist = new Tourist("Oliwia", 250m, new Position(0, 0));
        tourist = new Tourist(name, startingMoney, new Position(0, 0));
        // Creating Map
        cityMap = new CityMap(20, 10);
        timeManager = new TimeManager();
        
        cityMap.AddAttraction(hotelPosition, new Hotel());
        
        //cityMap.AddAttraction(new Position(1, 1), new Shop("Gift Shop", "Local souvenirs", new Souvenir("Mug", 30m, "Ceramic Mug")));
        //cityMap.AddAttraction(new Position(2, 2), new Landmark("Old Tower", "Historical Tower"));
        
        Random random = new Random();
        // Creating attractions
        for (int i = 0; i < 40; i++)
        {
            Position pos;
            do
            {
                pos = new Position(random.Next(20), random.Next(10));
            }
            while (pos.X == 0 && pos.Y == 0 || cityMap.GetAttractionAt(pos) != null);

            var attraction = AttractionFactory.CreateRandomAttraction();
            cityMap.AddAttraction(pos, attraction);
        }
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\nPreparing the city map...");
        Console.WriteLine("All set! Your journey begins now. Press any key to start your trip!");
        Console.ReadKey();
        Console.ResetColor();
    }

    private void DisplayStatus()
    {
        //Console.WriteLine($"Time: {timeManager.GetCurrentTime()} | Time left: {timeManager.GetTimeLeft()}");
        //Console.WriteLine($"Hunger: {tourist.Hunger}/100 | Thirst: {tourist.Thirst}/100");
        
        int consoleWidth = Console.WindowWidth;
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"\nHunger: {tourist.Hunger}/100     Thirst: {tourist.Thirst}/100");
        Console.WriteLine($"Location: ({tourist.Position.X}, {tourist.Position.Y})   Money: {tourist.Money} zl");
        Console.ResetColor();
        if (tourist.Hunger < 20)
            tourist.AddLog("You are very hungry!");
            //Console.WriteLine("> You are very hungry!");
        if (tourist.Thirst < 20)
            tourist.AddLog("You are very thirsty!");
            //Console.WriteLine("> You are very thirsty!");
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{new string('-', consoleWidth)}");
        Console.WriteLine("Inventory:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(tourist.Inventory.GetInventorySummary());
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{new string('-', consoleWidth)}");
        Console.WriteLine("Log:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Gray;
        if (tourist.InteractionLog != null && tourist.InteractionLog.Any())
        {
            foreach (var log in tourist.InteractionLog.TakeLast(5))
            {
                Console.WriteLine($"> {log}");
            }
        }
        else
        {
            Console.WriteLine("> No interactions yet.");
        }
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', consoleWidth));
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"Controls: W/S/A/D = move | H = return to hotel | L = Legend | Q = quit");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', consoleWidth));
        Console.ResetColor();
    }

    private void DisplaySummary()
    {
        int consoleWidth = Console.WindowWidth;
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', consoleWidth));
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Trip Summary:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', consoleWidth));
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"> Tourist: {tourist.Name}");
        Console.WriteLine($"> Money left: {tourist.Money} zl");
        Console.WriteLine($"> Time ended: {timeManager.GetCurrentTime()}");
        Console.WriteLine("> Inventory:");
        Console.WriteLine($"> {tourist.Inventory.GetInventorySummary()}");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{new string('-', consoleWidth)}");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("Thanks for playing! Press any key to exit...");
        Console.ReadKey();
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{new string('-', consoleWidth)}");
        Console.ResetColor();
    }

    private bool IsPositioninBounds(Position pos)
    {
        return pos.X >= 0 && pos.X < cityMap.Width &&
               pos.Y >= 0 && pos.Y < cityMap.Height;
    }
    
    private void HandleInput()
    {
        var key = Console.ReadKey(true).Key;

        switch(key)
        {
            case ConsoleKey.W:
                //tourist.Move(Direction.Up);
                var directionW = Direction.Up;
                var newPositionW = tourist.Position.Move(directionW);

                if (IsPositioninBounds(newPositionW))
                {
                    tourist.Move(directionW);
                }
                else
                {
                    tourist.AddLog("You can't move outside the city!");
                }
                break;
            case ConsoleKey.S:
                //tourist.Move(Direction.Down);
                var directionS = Direction.Down;
                var newPositionS = tourist.Position.Move(directionS);

                if (IsPositioninBounds(newPositionS))
                {
                    tourist.Move(directionS);
                }
                else
                {
                    tourist.AddLog("You can't move outside the city!");
                }
                break;
            case ConsoleKey.A:
                //tourist.Move(Direction.Left);
                var directionA = Direction.Left;
                var newPositionA = tourist.Position.Move(directionA);

                if (IsPositioninBounds(newPositionA))
                {
                    tourist.Move(directionA);
                }
                else
                {
                    tourist.AddLog("You can't move outside the city!");
                }
                break;
            case ConsoleKey.D:
                //tourist.Move(Direction.Right);
                var directionD = Direction.Right;
                var newPositionD = tourist.Position.Move(directionD);

                if (IsPositioninBounds(newPositionD))
                {
                    tourist.Move(directionD);
                }
                else
                {
                    tourist.AddLog("You can't move outside the city!");
                }
                break;
            case ConsoleKey.Q:
                Console.WriteLine("\nYou decided to end the trip early.");
                DisplaySummary();
                Environment.Exit(0);
                break;
            case ConsoleKey.H:
                Console.Clear();
                tourist.MoveTo(hotelPosition);
                EndDay();
                tourist.RestAtHotel();
                isRunning = false;  // zakończ dzień
                break;
            case ConsoleKey.L:
                Console.WriteLine("\nLegend:");
                Console.WriteLine("@ = You, H = Hotel, S = Shop, R = Restaurant, C = Cafe, L = Landmark, T = Theatre");
                Console.WriteLine("G = Gallery, Z = Zoo/Castle, M = Museum, B = Beach, P = Park, Y = Stall");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            default:
                return;
        }

        if (timeManager.IsTimeUp)
        {
            tourist.AddLog("Time's up! Your sightseeing day is over.");
            Console.WriteLine("Time's up! Your sightseeing day is over.");
            isRunning = false;
        }
        
        if (tourist.Hunger == 0 || tourist.Thirst == 0)
        {
            tourist.AddLog("You collapsed from exhaustion! Day ends early.");
            Console.WriteLine("You collapsed from exhaustion! Day ends early.");
            isRunning = false;
        }

        var attraction = cityMap.GetAttractionAt(tourist.Position);
        //attraction?.Interact(tourist);
        attraction?.Visit(tourist, timeManager);
    }

    private void StartDay()
    {
        isRunning = true;
        tourist.MoveTo(hotelPosition);

        while (isRunning)
        {
            Console.Clear();
            //Console.WriteLine($"Day {currentDay} of {totalDays}");
            int consoleWidth = Console.WindowWidth;
            string dayInfo = $" Day {currentDay} of {totalDays} ";
            string timeInfo = $"Time: {timeManager.GetCurrentTime()} | Left: {timeManager.GetTimeLeft()}";
    
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('═', consoleWidth));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(dayInfo.PadRight(consoleWidth - timeInfo.Length) + timeInfo);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('═', consoleWidth));
            Console.ResetColor();
            cityMap.Render(tourist.Position);
            DisplayStatus();
            HandleInput();

            if (timeManager.IsTimeUp)
            {
                Console.Clear();
                Console.WriteLine("End of the day!");
                if (tourist.Position != hotelPosition)
                {
                    Console.WriteLine("Automatically returning to the hotel...");
                    tourist.MoveTo(hotelPosition);
                }

                break;
            }
        }
    }

    private void EndDay()
    {
        int consoleWidth = Console.WindowWidth;
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', consoleWidth));
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"Day {currentDay} ended.");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(new string('═', consoleWidth));
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"Position: ({tourist.Position.X}, {tourist.Position.Y})");

        if (tourist.Position != hotelPosition)
        {
            Console.WriteLine("Tourist is coming back to hotel for the night...");
            tourist.MoveTo(hotelPosition);
        }
        
        Console.WriteLine($"> Tourist balance: {tourist.Money} zl");
        Console.WriteLine("Inventory: ");
        Console.WriteLine($"{tourist.Inventory.GetInventorySummary()}");
        Console.ResetColor();
        
        tourist.RestAtHotel();
    }
}
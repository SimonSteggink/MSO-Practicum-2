namespace Programming_Learning_App;

public class ConsoleUI
{
    private BlockProgram? current;
    private IProgramParser parser = new TextProgramParser();
    private ExampleProgramProvider examples;
    private StatsCalculator stats = new StatsCalculator();

    public ConsoleUI()
    {
        examples = new ExampleProgramProvider(parser);
    }

    public void Run()
    {
        while (current == null)
        {
            Console.WriteLine("Choose a program:");
            Console.WriteLine("1. Basic example");
            Console.WriteLine("2. Advanced example");
            Console.WriteLine("3. Expert example");
            Console.WriteLine("4. Random example");
            Console.WriteLine("Or type the location of a program file.");

            string? input = Console.ReadLine();
            if (input == null)
            {
                return;
            }

            try
            {
                switch (input)
                {
                    case "1":
                        current = examples.Basic();
                        break;
                    case "2":
                        current = examples.Advanced();
                        break;
                    case "3":
                        current = examples.Expert();
                        break;
                    case "4":
                        current = examples.Random();
                        break;
                    default:
                        current = parser.Parse(File.ReadAllText(input.Trim().Trim('"')));
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not load program: " + e.Message);
            }
        }

        while (true)
        {
            Console.WriteLine("1. Execute program");
            Console.WriteLine("2. Calculate metrics");

            string? input = Console.ReadLine();

            if (input == null)
            {
                return;
            }
            else if (input == "1")
            {
                Execute();
                break;
            }
            else if (input == "2")
            {
                ShowMetrics();
                break;
            }
        }
    }

    private void Execute()
    {
        ExecutionResult result = current!.Execute();
        string text = "";
        for (int i = 0; i < result.Trace.Count; i++)
        {
            if (i + 1 == result.Trace.Count)
            {
                text += result.Trace[i] + ".";
            }
            else
            {
                text += result.Trace[i] + ", ";
            }
        }

        Console.WriteLine(text);

        string facingText = "";
        switch (result.FinalFacing)
        {
            case Direction.North:
                facingText = "north";
                break;
            case Direction.East:
                facingText = "east";
                break;
            case Direction.South:
                facingText = "south";
                break;
            case Direction.West:
                facingText = "west";
                break;
        }

        Console.WriteLine("End state (" + result.FinalPosition.X + "," + result.FinalPosition.Y + ") facing " + facingText + ".");
    }

    private void ShowMetrics()
    {
        ProgramStats result = stats.Calculate(current!);
        Console.WriteLine("No. of commands: " + result.Commands);
        Console.WriteLine("Max nesting: " + result.MaxNesting);
        Console.WriteLine("No. of repeats: " + result.Repeats);
    }
}

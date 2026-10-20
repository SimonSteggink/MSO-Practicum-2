namespace Programming_Learning_App;

public class ConsoleUI
{
    private BlockProgram? current;
    private IProgramParser parser = new TextProgramParser();
    private ExampleProgramProvider examples;
    private ProgramStats stats;

    public ConsoleUI() 
    {
        examples = new ExampleProgramProvider(parser);
        current = examples.RandomProgram();
    }

    public void Run() 
    {
        ExecutionResult result = current.Execute();
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

        Console.WriteLine("End state (" + result.FinalPosition.X + "," + result.FinalPosition.X + ") facing " + facingText + ".");
    }
}
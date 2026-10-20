namespace Programming_Learning_App;


public struct ExecutionResult
{
    public List<string> Trace;
    public Position FinalPosition;
    public Direction FinalFacing;
}

public struct Position
{
    public int X;
    public int Y;
}

public enum Direction
{
    North,
    East,
    South,
    West
}

public enum TurnDirection 
{
    Left,
    Right
}

public class BlockProgram
{
    public string Name;
    public List<ICommand> Commands;

    public BlockProgram(string name, List<ICommand> commands) 
    {
        Name = name;
        Commands = commands;
    }

    public ExecutionResult Execute()
    {
        ExecutionContext context = new ExecutionContext();

        for (int i = 0; i < Commands.Count; i++)
        {
            Commands[i].Execute(context);
        }

        ExecutionResult result = new ExecutionResult();
        result.Trace = context.Trace;
        result.FinalPosition = context.Character.Position;
        result.FinalFacing = context.Character.Facing;
        return result;
    }
}
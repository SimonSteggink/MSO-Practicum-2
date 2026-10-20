namespace Programming_Learning_App;


struct ExecutionResult 
{
    public List<string> Trace;
    public Position FinalPosition;
    public Direction FinalFacing;
}

struct Position
{
    public int X;
    public int Y;
}

enum Direction
{
    North,
    East,
    South,
    West
}

enum TurnDirection 
{
    Left,
    Right
}

public class BlockProgram
{
    string Name;
    List<ICommand> Commands;

    public ExecutionResult Execute() 
    {
        
    }
}
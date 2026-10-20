namespace Programming_Learning_App;

public interface ICommand 
{
    public void Execute(Character character);
}

public class MoveCommand : ICommand 
{
    private int Steps;

    public MoveCommand(int steps) 
    {
        Steps = steps;
    }

    public void Execute(Character character) 
    {
        character.MoveForward();
    }
}

public class TurnCommand : ICommand
{
    private TurnDirection Turn;

    public TurnCommand(TurnDirection turn)
    {
        Turn = turn;
    } 

    public void Execute(Character character)
    {
        character.Turn(Turn);
    }
}

public class RepeatCommand : ICommand
{
    private int Count;
    private List<ICommand> Commands;

    public RepeatCommand(int count, List<ICommand> commands)
    {
        Count = count;
        Commands = commands;
    }

    public void Execute(Character character)
    {
        for (int i = 0; i < Count; i++) 
        {
            for (int j = 0; j < Commands.Count; j++) 
            {
                Commands[j].Execute(character);
            }
        }
    }
}

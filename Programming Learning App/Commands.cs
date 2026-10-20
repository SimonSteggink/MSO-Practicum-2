namespace Programming_Learning_App;

public interface ICommand 
{
    public void Execute(Character character);
}

public class MoveCommand : ICommand 
{
    int Steps;
    public void Execute(Character character) 
    { 
    
    }
}

public class TurnCommand : ICommand
{
    TurnDirection Turn; 
    public void Execute(Character character)
    {

    }
}

public class RepeatCommand : ICommand
{
    int Count;
    List<ICommand> Commands;
    public void Execute(Character character)
    {

    }
}

namespace Programming_Learning_App;

public interface ICommand
{
    public void Execute(ExecutionContext context);
}

public class MoveCommand : ICommand
{
    public int Steps;

    public MoveCommand(int steps)
    {
        Steps = steps;
    }

    public void Execute(ExecutionContext context)
    {
        for (int i = 0; i < Steps; i++)
        {
            context.Character.MoveForward();
        }

        context.Trace.Add("Move " + Steps);
    }
}

public class TurnCommand : ICommand
{
    public TurnDirection Turn;

    public TurnCommand(TurnDirection turn)
    {
        Turn = turn;
    }

    public void Execute(ExecutionContext context)
    {
        context.Character.Turn(Turn);

        if (Turn == TurnDirection.Left)
        {
            context.Trace.Add("Turn left");
        }
        else
        {
            context.Trace.Add("Turn right");
        }
    }
}

public class RepeatCommand : ICommand
{
    public int Times;
    public List<ICommand> Body;

    public RepeatCommand(int count, List<ICommand> commands)
    {
        Times = count;
        Body = commands;
    }

    public void Execute(ExecutionContext context)
    {
        for (int i = 0; i < Times; i++)
        {
            for (int j = 0; j < Body.Count; j++)
            {
                Body[j].Execute(context);
            }
        }
    }
}

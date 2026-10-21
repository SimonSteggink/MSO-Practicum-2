namespace UnitTests;
using Programming_Learning_App;

public class StatsCalculator
{
    [Fact]
    public void StatsCalculator_ShouldCalculateCommands1()
    {
        var commands = new List<ICommand>
        {
            new MoveCommand(2),
            new TurnCommand(TurnDirection.Left),
            new RepeatCommand(2, new List<ICommand> { new MoveCommand(1) })
        };
        var BlockProgram = new BlockProgram("Test1", commands);

        var Stats = new Programming_Learning_App.StatsCalculator().Calculate(BlockProgram);
        Assert.Equal(4, Stats.Commands);

    }

    [Fact]
    public void StatsCalculator_ShouldCalculateCommands2()
    {
        var commands = new List<ICommand>
        {
            new MoveCommand(2),
            new TurnCommand(TurnDirection.Left),
            new RepeatCommand(2, new List<ICommand> { new RepeatCommand(2, new List<ICommand> { }) })
        };
        var BlockProgram = new BlockProgram("Test1", commands);

        var Stats = new Programming_Learning_App.StatsCalculator().Calculate(BlockProgram);
        Assert.Equal(4, Stats.Commands);

    }

    [Fact]
    public void StatsCalculator_ShouldCalculateRepeats()
    {
        var commands = new List<ICommand>
        {
            new MoveCommand(2),
            new TurnCommand(TurnDirection.Left),
            new RepeatCommand(2, new List<ICommand> { new RepeatCommand(2, new List<ICommand> { new MoveCommand(1) }) })
        };
        var BlockProgram = new BlockProgram("Test1", commands);
        var Stats = new Programming_Learning_App.StatsCalculator().Calculate(BlockProgram);
        Assert.Equal(2, Stats.Repeats);
    }

    [Fact]
    public void StatsCalculator_ShouldCalculateMaxNesting()
    {
        var commands = new List<ICommand>
        {
            new MoveCommand(2),
            new TurnCommand(TurnDirection.Left),
            new RepeatCommand(2, new List<ICommand> { new RepeatCommand(2, new List<ICommand> { new MoveCommand(1) }) })
        };
        var BlockProgram = new BlockProgram("Test1", commands);
        var Stats = new Programming_Learning_App.StatsCalculator().Calculate(BlockProgram);
        Assert.Equal(2, Stats.MaxNesting);
    }
}


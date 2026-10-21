namespace UnitTests;
using Programming_Learning_App;

public class UnitTest1
{
    [Fact]
    public void StatsCalculator_ShouldCalculateCommands()
    {
        var commands = new List<ICommand>
        {
            new MoveCommand(2),
            new TurnCommand(TurnDirection.Left),
            new RepeatCommand(2, new List<ICommand> { new MoveCommand(1) })
        };
        var BlockProgram = new BlockProgram("Test1", commands);

        var Stats = new StatsCalculator().Calculate(BlockProgram);
        Assert.Equal(4, Stats.Commands);

    }
}
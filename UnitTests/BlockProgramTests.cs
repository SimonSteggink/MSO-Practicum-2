namespace UnitTests;
using Programming_Learning_App;

public class BlockProgramTests
{
    [Fact]
    public void BlockProgram_ShouldReturnFinalPosition()
    {
        var commands = new List<ICommand>
        {
            new MoveCommand(2),
            new TurnCommand(TurnDirection.Left),
            new MoveCommand(1)
        };
        var blockProgram = new Programming_Learning_App.BlockProgram("Test1", commands);

        var result = blockProgram.Execute();

        Assert.Equal(2, result.FinalPosition.X);
        Assert.Equal(-1, result.FinalPosition.Y);
        Assert.Equal(Direction.North, result.FinalFacing);
    }

    [Fact]
    public void BlockProgram_ShouldTraceExecutedCommands()
    {
        var commands = new List<ICommand>
        {
            new MoveCommand(2),
            new TurnCommand(TurnDirection.Right)
        };
        var blockProgram = new Programming_Learning_App.BlockProgram("Test2", commands);

        var result = blockProgram.Execute();

        Assert.Equal(new List<string> { "Move 2", "Turn right" }, result.Trace);
    }
}

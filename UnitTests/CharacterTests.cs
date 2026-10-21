namespace UnitTests;
using Programming_Learning_App;

public class CharacterTests
{
    [Fact]
    public void Character_ShouldMoveEastByDefault()
    {
        var character = new Programming_Learning_App.Character();

        character.MoveForward();

        Assert.Equal(1, character.Position.X);
        Assert.Equal(0, character.Position.Y);
    }

    [Fact]
    public void Character_ShouldTurnLeftFromEastToNorth()
    {
        var character = new Programming_Learning_App.Character();

        character.Turn(TurnDirection.Left);

        Assert.Equal(Direction.North, character.Facing);
    }
}

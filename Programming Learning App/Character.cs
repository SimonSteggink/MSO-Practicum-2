namespace Programming_Learning_App;

public class Character
{
    private Position position;
    private Direction Facing;
    private List<Position> Path;

    public Character() {
        
    }

    public void Turn(TurnDirection dir) 
    {
        if (dir == TurnDirection.Left) 
        {
            switch (Facing)
            {
                case Direction.North:
                    Facing = Direction.West;
                    break;
                case Direction.East:
                    Facing = Direction.North;
                    break;
                case Direction.South:
                    Facing = Direction.East;
                    break;
                case Direction.West:
                    Facing = Direction.South;
                    break;
            }
        }
        else 
        {
            switch (Facing)
            {
                case Direction.North:
                    Facing = Direction.East;
                    break;
                case Direction.East:
                    Facing = Direction.South;
                    break;
                case Direction.South:
                    Facing = Direction.West;
                    break;
                case Direction.West:
                    Facing = Direction.North;
                    break;
            }
        }
    }

    public void MoveForward() 
    {
        switch (Facing) 
        {
            case Direction.North:
                position.Y--;
                break;
            case Direction.East:
                position.X++;
                break;
            case Direction.South:
                position.Y++;
                break;
            case Direction.West:
                position.X--;
                break;
        }

        Path.Add(position);
    }
}
namespace RobotSim.Domain;

public class Robot(Position position, int degrees)
{
    private static readonly Dictionary<string, int> CardinalToDegrees = new()
    {
        {"NORTH", 0},
        {"EAST", 90},
        {"SOUTH", 180},
        {"WEST", 270}
    };

    // the _modulus function is needed because % operator doesn't turn
    // negative remainders to positive in C# (it does in python though)
    private readonly Func<int, int, int> _modulus = (k,n) => (k %= n) < 0 ? k + n : k;

    public Position Position { get; set; } = position;
    public int Degrees { get; set; } = degrees;

    public static Robot? Parse(string placeCommand)
    {
        string?[] placementData = placeCommand.Split(' ')[1].Split(',');
        var xOk = int.TryParse(placementData[0], out var x);
        var yOk = int.TryParse(placementData[1], out var y);
        var degreesOk = CardinalToDegrees.TryGetValue(placementData[2]!, out var degrees);

        return xOk && yOk && degreesOk
            ? new Robot(new Position(x, y), degrees)
            : null;
    }

    public void Move()
    {
        Position = new Position(
            Position.X + (int)Math.Round(Math.Sin(this.Degrees * Math.PI / 180),2),
            Position.Y + (int)Math.Round(Math.Cos(this.Degrees * Math.PI / 180),2));
    }

    public override string ToString() => 
        $"{Position.X},{Position.Y},{CardinalToDegrees.First(x => x.Value == Degrees).Key}";

    public void TurnLeft()
    {
        Degrees = _modulus(Degrees - 90, 360);
    }

    public void TurnRight()
    {
        Degrees = _modulus(Degrees + 90, 360);
    }
}
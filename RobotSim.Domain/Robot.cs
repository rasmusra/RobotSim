namespace RobotSim.Domain;

public class Robot(Position position, uint degrees)
{
    private static readonly Dictionary<string, uint> CardinalToDegrees = new()
    {
        {"NORTH", 0},
        {"EAST", 90},
        {"SOUTH", 180},
        {"WEST", 270}
    };

    public static Robot? Parse(string placeCommand)
    {
        string?[] placementData = placeCommand.Split(' ')[1].Split(',');
        var xOk = uint.TryParse(placementData[0], out var x);
        var yOk = uint.TryParse(placementData[1], out var y);
        var degreesOk = CardinalToDegrees.TryGetValue(placementData[2]!, out var degrees);

        return xOk && yOk && degreesOk
            ? new Robot(new Position(x, y), degrees)
            : null;
    }

    public Position Position { get; set; } = position;
    public uint Degrees { get; set; } = degrees;

    public void Move()
    {
        Position = new Position(
            Position.X + (uint)Math.Round(Math.Sin(this.Degrees * Math.PI / 180),2),
            Position.Y + (uint)Math.Round(Math.Cos(this.Degrees * Math.PI / 180),2));
    }

    public override string ToString() => 
        $"{Position.X},{Position.Y},{CardinalToDegrees.First(x => x.Value == Degrees).Key}";     
}
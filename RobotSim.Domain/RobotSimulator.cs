namespace RobotSim.Domain;

public class RobotSimulator(Surface surface, Action<string> report)
{
    private readonly Action<string> _report = report;
    private readonly Surface _surface = surface;
    private Position _position = null!;
    private string? _cardinalDirection;

    public void Process(string userCommand)
    {
        if (userCommand.StartsWith("PLACE"))
        {
            string?[] placementData = userCommand.Split(' ')[1].Split(',');
            uint.TryParse(placementData[0], out var xPosition);
            uint.TryParse(placementData[1], out var yPosition);
            var position = new Position(xPosition, yPosition);
            var cardinalDirection = placementData[2];

            if (_surface.InBounds(position))
            {
                _position = position;
                _cardinalDirection = cardinalDirection;
            }
        }
        else if (userCommand == "REPORT")
        {
            if (_position != null && _cardinalDirection != null)
            {
                _report($"{_position.X},{_position.Y},{_cardinalDirection}");
            }
        }
    }
}
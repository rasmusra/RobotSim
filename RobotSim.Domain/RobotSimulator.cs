namespace RobotSim.Domain;

public class RobotSimulator(Surface surface, Action<string> report)
{
    private readonly Action<string> _report = report;
    private readonly Surface _surface = surface;
    private string? _xPosition;
    private string? _yPosition;
    private string? _cardinalDirection;

    public void Process(string userCommand)
    {
        if (userCommand.StartsWith("PLACE"))
        {
            string?[] placementData = userCommand.Split(' ')[1].Split(',');
            _xPosition = placementData[0];
            _yPosition = placementData[1];
            _cardinalDirection = placementData[2];
        }
        else if (userCommand == "REPORT")
        {
            _report($"{_xPosition},{_yPosition},{_cardinalDirection}");
        }
    }
}
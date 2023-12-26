namespace RobotSim.Domain;

public class RobotSimulator(Surface surface, Action<string> report)
{
    private readonly Action<string> _report = report;
    private readonly Surface _surface = surface;

    public void Process(string userCommand)
    {
    }
}
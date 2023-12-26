using System.ComponentModel.DataAnnotations;

namespace RobotSim.Domain;

public class RobotSimulator(Surface surface, Action<string> report)
{
    private readonly Action<string> _report = report;
    private readonly Surface _surface = surface;
    private Robot? _robot = null;

    public void Process(string userCommand)
    {

        if (userCommand.StartsWith("PLACE"))
        {
            var newRobot = Robot.Parse(userCommand)!;

            if (_surface.InBounds(newRobot.Position))
            {
                _robot = newRobot;
            }
        }
        else switch (userCommand)
        {
            case "REPORT":
                if (_robot != null)
                {
                    _report(_robot.ToString()!);
                }

                break;

            case "MOVE":
                _robot?.Move();
                break;
        }
    }
}
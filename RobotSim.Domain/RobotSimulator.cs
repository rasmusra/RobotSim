using System.ComponentModel.DataAnnotations;

namespace RobotSim.Domain;

public class RobotSimulator(Surface surface, Action<string> report)
{
    private readonly Action<string> _report = report;
    private readonly Surface _surface = surface;
    private Robot? _robot = null;

    public void Process(string userCommand)
    {
        // TODO: should we use a regex here?
        // TODO: should we use a switch expression here?
        // TODO: what about a CommandParser class?
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
                // TODO: keep checking null feels very error prone. How can we avoid?
                if (_robot != null)
                {
                    _report(_robot.ToString()!);
                }

                break;

            case "MOVE":
                // TODO: keep checking null feels very error prone. How can we avoid?
                if (_robot != null)
                {
                    // TODO: a robot factory could keep this logic
                    var newRobot = new Robot(_robot.Position, _robot.Degrees);
                    newRobot.Move();

                    if (_surface.InBounds(newRobot.Position))
                    {
                        _robot = newRobot;
                    }
                }

                break;
        }
    }
}
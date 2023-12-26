namespace RobotSim.Domain;

public class RobotSimulator(Surface surface, Action<string> report)
{
    private Robot? _robot;

    public void Process(string userCommand)
    {
        // TODO: what about a CommandParser class?
        if (userCommand.StartsWith("PLACE"))
        {
            var newRobot = Robot.Parse(userCommand);
            _robot = newRobot != null && surface.InBounds(newRobot.Position)
                ? newRobot
                : _robot; // keep the old robot if the new one is invalid
        }
        else switch (userCommand)
        {
            case "REPORT":
                if (_robot != null)
                {
                    report(_robot.ToString()!);
                }

                break;

            case "MOVE":
                if (_robot != null)
                {
                    // TODO: a robot factory to keep this logic?
                    var newRobot = new Robot(_robot.Position, _robot.Degrees);
                    newRobot.Move();

                    if (surface.InBounds(newRobot.Position))
                    {
                        _robot = newRobot;
                    }
                }

                break;

            case "LEFT":
                _robot?.TurnLeft();
                break;

            case "RIGHT":
                _robot?.TurnRight();
                break;
        }
    }
}
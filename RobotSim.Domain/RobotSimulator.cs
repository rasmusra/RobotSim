namespace RobotSim.Domain;

public class RobotSimulator(Surface surface, Action<string> report)
{
    private Robot? _robot = null;

    public void Process(string userCommand)
    {
        // TODO: what about a CommandParser class?
        if (userCommand.StartsWith("PLACE"))
        {
            var newRobot = Robot.Parse(userCommand);

            if (newRobot != null && surface.InBounds(newRobot.Position))
            {
                _robot = newRobot;
            }
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
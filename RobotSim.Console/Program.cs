using RobotSim.Domain;

namespace RobotSim.Console;

class Program
{
    static void Main(string[] args)
    {
        var surface = new Surface(new Position(0, 0), new Position(4, 4));

        while (true)
        {
            var userCommand = System.Console.ReadLine();
        }
    }
}

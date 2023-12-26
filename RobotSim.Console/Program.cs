using RobotSim.Domain;

namespace RobotSim.Console;

class Program
{
    static void Main(string[] args)
    {
        var surface = new Surface(new Position(0, 0), new Position(4, 4));
        var robotSimulator = new RobotSimulator(surface, System.Console.WriteLine);

        while (true)
        {
            var userCommand = System.Console.ReadLine();
            robotSimulator.Process(userCommand!);
        }
    }
}

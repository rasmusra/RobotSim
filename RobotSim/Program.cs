namespace RobotSim;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        while (true)
        {
            Console.WriteLine("Enter a command:");
            var command = Console.ReadLine();
            if (command == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine($"You entered: {command}");
            }
        }   
    }
}

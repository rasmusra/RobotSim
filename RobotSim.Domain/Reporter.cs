namespace RobotSim.Domain
{
    public class Reporter
    {
        public virtual void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}

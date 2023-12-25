namespace RobotSim.Model
{
    public class Position
    {
        public uint X { get; }
        public uint Y { get; }

        public Position(uint x, uint y)
        {
            X = x;
            Y = y;
        }
    }
}
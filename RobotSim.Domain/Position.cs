namespace RobotSim.Domain
{
    public class Position(uint x, uint y)
    {
        public uint X { get; } = x;
        public uint Y { get; } = y;
    }
}
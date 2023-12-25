namespace RobotSim
{
    public class Surface
    {
        public Surface(uint width, uint height)
        {
            Width = width;
            Height = height;
        }

        public uint Width { get; }
        public uint Height { get; }
    }
}
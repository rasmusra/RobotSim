namespace RobotSim.Model
{
    public class Surface
    {
        private readonly Position _p1;
        private readonly Position _p2;

        public Surface(Position p1, Position p2)
        {
            _p1 = p1;
            _p2 = p2;
        }

        public bool InBounds(Position position)
        {
            return position.X >= _p1.X && position.X <= _p2.X && position.Y >= _p1.Y && position.Y <= _p2.Y;
        }
    }
}
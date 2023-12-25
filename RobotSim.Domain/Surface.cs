namespace RobotSim.Domain
{
    public class Surface(Position p1, Position p2)
    {
        private readonly Position _southWestCorner = new(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
        private readonly Position _northEastCorner = new(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y));

        public bool InBounds(Position position)
        {
            return position.X >= _southWestCorner.X &&
                   position.X <= _northEastCorner.X &&
                   position.Y >= _southWestCorner.Y &&
                   position.Y <= _northEastCorner.Y;
        }
    }
}
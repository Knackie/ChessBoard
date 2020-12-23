namespace Utils
{
    public class Coordinate
    {
        public static Coordinate OutOfBoard = new Coordinate(-1, -1);

        public readonly int X;

        public readonly int Y;

        public Coordinate(int x, int y)
            => (X, Y) = (x, y);
    }
}
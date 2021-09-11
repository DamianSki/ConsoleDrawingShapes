namespace ConsoleDrawingShapes
{
    internal struct Point
    {
        public Point(int x, int y, char color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public int X { get; }
        public int Y { get; }
        public char Color { get; }
    }
}

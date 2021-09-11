using System;

namespace ConsoleDrawingShapes
{
    internal class Rectangle : Figure
    {
        public Rectangle(int x1, int y1, int x2, int y2, char color) : base(x1, y1, color)
        {
            if (x1 == x2 && y1 == y2)
                throw new ArgumentException("Locations for both coordinates cannot be identical!");

            X2 = x2;
            Y2 = y2;
        }

        public int X2 { get; }
        public int Y2 { get; }

        public override Point[] Draw()
        {
            throw new NotImplementedException();
        }
    }
}

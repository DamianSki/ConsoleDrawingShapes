using ConsoleDrawingShapes.Extensions;
using System;
using System.Linq;

namespace ConsoleDrawingShapes
{
    internal class Line : Figure
    {
        public Line(int x1, int y1, int x2, int y2, char color) : base(x1, y1, color)
        {
            if (x1 == x2 && y1 == y2)
                throw new ArgumentException("Locations for both coordinates cannot be identical!");

            if (x1 != x2 && y1 != y2)
                throw new ArgumentException("Currently only horizontal or vertical lines are supported!");

            X2 = x2;
            Y2 = y2;
        }
        public int X2 { get; }        
        public int Y2 { get; }

        public override Point[] Draw()
        {
            if (X1 == X2)
            {
                var start = Y2 > Y1 ? Y1 : Y2;
                var end = Y2 < Y1 ? Y1 : Y2;

                return (start, end).Range().Select(y => new Point(X1, y, Color)).ToArray();
            }

            if (Y1 == Y2)
            {
                var start = X2 > X1 ? X1 : X2;
                var end = X2 < X1 ? X1 : X2;
                
                return (start, end).Range().Select(x => new Point(x, Y1, Color)).ToArray();
            }

            throw new NotImplementedException();
        }
    }
}

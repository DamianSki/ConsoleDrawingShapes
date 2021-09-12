using ConsoleDrawingShapes.Extensions;
using System;
using System.Linq;

namespace ConsoleDrawingShapes
{
    internal class Rectangle : Figure
    {
        public Rectangle(int x1, int y1, int x2, int y2, char color) : base(x1, y1, color)
        {
            if (x1 == x2 || y1 == y2)
                throw new ArgumentException("Locations for both coordinates X1 and X2 or Y1 and Y2 cannot be identical!");

            X2 = x2;
            Y2 = y2;
        }

        public int X2 { get; }
        public int Y2 { get; }
        public override Point[] Draw()
        {
            var xLeft = X1 < X2 ? X1 : X2;
            var xRight = X1 > X2 ? X1 : X2;

            var yTop = Y1 < Y2 ? Y1 : Y2;
            var yBottom = Y1 > Y2 ? Y1 : Y2;

            var topHorizontalLine = (xLeft, xRight).Range().Select(x => new Point(yTop, x, Color));                        
            var bottomHorizontalLine = (xLeft, xRight).Range().Select(x => new Point(yBottom, x, Color));

            var lefVerticalLine = (yTop + 1, yBottom - 1).Range().Select(y => new Point(y, xLeft,  Color));
            var rightVerticalLine = (yTop + 1, yBottom - 1).Range().Select(y => new Point(y, xRight, Color));

            return topHorizontalLine.Concat(bottomHorizontalLine).Concat(lefVerticalLine).Concat(rightVerticalLine).ToArray();
        }        
    }
}

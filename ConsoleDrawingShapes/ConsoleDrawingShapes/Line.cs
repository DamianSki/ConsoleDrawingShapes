using System;

namespace ConsoleDrawingShapes
{
    internal class Line : Figure
    {
        public Line(int x1, int y1, int x2, int y2, char color) : base(x1, y1, color)
        {            
            X2 = x2;
            Y2 = y2;
        }

        public int X2 { get; }        
        public int Y2 { get; }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}

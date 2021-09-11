namespace ConsoleDrawingShapes
{
    internal abstract class Figure
    {        
        public Figure(int x1, int y1, char color)
        {
            X1 = x1;
            Y1 = y1;
            Color = color;
        }

        public int X1 { get; }
        public int Y1 { get; }
        public char Color { get; }
        public abstract Point[] Draw();
    }
}

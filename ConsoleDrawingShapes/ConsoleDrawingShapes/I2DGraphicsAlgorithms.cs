using System.Collections.Generic;

namespace ConsoleDrawingShapes
{
    internal interface I2DGraphicsAlgorithms
    {
        IList<Point> FindNeigbouhrPoints(int x, int y, char[][] canvas);
    }
}

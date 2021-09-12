using System.Collections.Generic;

namespace ConsoleDrawingShapes
{
    internal class Graphics2DAlgorithms : I2DGraphicsAlgorithms
    {
        public IList<Point> FindNeigbouhrPoints(int x, int y, char [][] canvas)
        {
            var canvasMaxWidth = canvas[0].Length - 1;
            var canvasMinWidth = 1;
            var canvasMaxHeight = canvas.Length - 1;
            var canvasMinHeight = 1;

            var result = new List<Point>();
            var visited = new bool[canvas.Length][];

            for (int i = 0; i < canvas.Length; i++)
                visited[i] = new bool[canvas[0].Length];

            result.Add(new Point(x, y, canvas[x][y]));
            visited[x][y] = true;

            var stack = new Stack<Point>();
            stack.Push(result[0]);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                var currX = current.X;
                var currY = current.Y;
                var currColor = current.Color;

                if (currX + 1 < canvasMaxHeight && currColor ==  canvas[currX + 1][currY] && !visited[currX + 1][currY]) //go right
                {
                    visited[currX + 1][currY] = true;
                    var point = new Point(currX + 1, currY, currColor);
                    stack.Push(point);
                    result.Add(point);
                }

                if (currX - 1 >= canvasMinWidth && currColor == canvas[currX - 1][currY] && !visited[currX - 1][currY]) //go left
                {
                    visited[currX - 1][currY] = true;
                    var point = new Point(currX - 1, currY, currColor);
                    stack.Push(point);
                    result.Add(point);
                }

                if (currY + 1 < canvasMaxWidth && currColor == canvas[currX][currY + 1] && !visited[currX][currY + 1]) //go bottom
                {
                    visited[currX][currY + 1] = true;
                    var point = new Point(currX, currY + 1, currColor);
                    stack.Push(point);
                    result.Add(point);
                }

                if (currY - 1 >= canvasMinHeight && currColor == canvas[currX][currY - 1] && !visited[currX][currY - 1]) //go top
                {
                    visited[currX][currY - 1] = true;
                    var point = new Point(currX, currY - 1, currColor);
                    stack.Push(point);
                    result.Add(point);
                }
            }

            return result;
        }
    }
}

using ConsoleDrawingShapes.Extensions;
using System;
using System.Linq;

namespace ConsoleDrawingShapes
{
    public sealed class Canvas
    {
        private Canvas(int width, int height)
        {
            if (width < 1 || width > maxWidth || height < 1 || height > maxHeigh)
                throw new ArgumentOutOfRangeException("Canvas max width: 300, heigh: 300!");

            _width = width + 2;
            _height = height + 2;

            _content = InitContent(_width, _height);
        }

        I2DGraphicsAlgorithms _algorithms = new Graphics2DAlgorithms();

        private const int maxWidth = 300;
        private const int maxHeigh = 300;

        private readonly int _width;
        private readonly int _height;
        private readonly char[,] _content;
        private const char DefaultColor = 'x';

        private char[,] InitContent(int width, int height)
        {
            var content = new char[height, width];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    content[y, x] = ' ';

            for (int x = 0; x < width; x++)
            {
                content[0, x] = '-';
                content[height - 1, x] = '-';
            }

            for (int y = 1; y < height - 1; y++)
            {
                content[y, 0] = '|';
                content[y, width - 1] = '|';
            }


            return content;
        }

        public char[][] Render() => _content.ToCompoundArray();

        /// <summary>
        /// Create canvas with specified with and heigh.
        /// </summary>
        /// <param name="width">The maximum width is 300</param>
        /// <param name="heigh">The maximum width is 300</param>
        public static Canvas Create(int width, int heigh) => new Canvas(width, heigh);

        public void DrawLine(int x1, int y1, int x2, int y2, char color = DefaultColor) =>
            Draw(new Line(x1, y1, x2, y2, color).Draw());

        public void DrawRectangle(int x1, int y1, int x2, int y2, char color = DefaultColor) =>
            Draw(new Rectangle(x1, y1, x2, y2, color).Draw());

        public void Fill(int x, int y, char color = DefaultColor)
        {
            var content = _content.ToCompoundArray();
            var points = _algorithms.FindNeigbouhrPoints(x, y, content)
                .Select(p => new Point(p.X, p.Y, color)).ToArray(); ;

            Draw(points);
        }

        /// <summary>
        /// This is just simple method that apply changes on cavas. For this simple app it is enought to just make validaiton inside and insert points to "content"
        /// </summary>
        /// <param name="points"></param>
        private void Draw(Point[] points)
        {
            Validate(points);
            points.ToList().ForEach(p => _content[p.X, p.Y] = p.Color);
        }

        /// <summary>
        /// This is just simple method for checking invariants volioation. Validation process i critical for all applications istead of throwing exceptions return Reult<>.Fail() or Result<>.Success()
        /// </summary>
        /// <param name="points"></param>
        private void Validate(Point[] points)
        {
            var xMin = points.Select(p => p.X).Min();
            var xMax = points.Select(p => p.X).Max();

            var yMin = points.Select(p => p.Y).Min();
            var yMax = points.Select(p => p.Y).Max();

            if (xMin < 1 || xMax > maxWidth || yMin < 1 || yMax > maxHeigh)
                throw new InvalidOperationException($"Figur sizes excedeed max canvas sizes widht: {_width} height: {_height}");
        }                
    }
}

using System;

namespace ConsoleDrawingShapes
{
    public sealed class Canvas
    {
        private Canvas(int width, int height) {
            if (width < 1 || width > 300)
                throw new ArgumentOutOfRangeException();

            _width = width + 2;

            if (height < 1 || height > 300)
                throw new ArgumentOutOfRangeException();

            _height = height + 2;
        }

        private readonly int _width;
        private readonly int _height;

        /// <summary>
        /// Create canvas with specified with and heigh.
        /// </summary>
        /// <param name="width">The maximum width is 300</param>
        /// <param name="heigh">The maximum width is 300</param>
        public static Canvas Create(int width, int heigh) => new Canvas(width, heigh);

        public void DrawLine(int x1, int y1, int x2, int y2)
        { 
        
        }

        public void DrawRectangle(int x1, int y1, int x2, int y2)
        { 
        
        }

        public void Fill(int x, int y, char colour)
        { 

        }

        private void DrawPoint(int x, int y, char colour)
        { 
        
        }
    }
}

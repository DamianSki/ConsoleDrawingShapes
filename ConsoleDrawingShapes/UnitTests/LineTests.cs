using ConsoleDrawingShapes;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class LineTests
    {
        [Theory]
        [InlineData(1, 2, 1, 3)]
        [InlineData(2, 2, 3, 2)]
        public void Line_Create_Successful(int x1, int y1, int x2, int y2)
        {
            var line = new Line(x1, y1, x2, y2, 'b');

            line.Should().NotBeNull();
            line.X1.Should().Be(x1);
            line.Y1.Should().Be(y1);
            line.X2.Should().Be(x2);
            line.Y2.Should().Be(y2);
            line.Color.Should().Be('b');
        }

        [Theory]
        [InlineData(1, 1, 1, 1)]
        [InlineData(1, 2, 3, 4)]
        public void Line_Create_UnSuccessful(int x1, int y1, int x2, int y2)
        {
            Action action = () => new Line(x1, y1, x2, y2, 'b');

            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(1, 2, 6, 2, 6)]
        [InlineData(1, 3, 16, 3, 16)]
        [InlineData(3, 3, -2, 3, 6)]
        public void Line_DrawHorizontal_Successful(int x1, int y1, int x2, int y2, int numOfPoints)
        {
            var line = new Line(x1, y1, x2, y2, 'b');

            var points = line.Draw();

            points.Length.Should().Be(numOfPoints);
            points.Select(p => p.Should().Be(y1));
        }

        [Theory]
        [InlineData(6, 1, 6, 4, 4)]
        [InlineData(1, 1, 1, -3, 5)]
        public void Line_DrawVertical_Successful(int x1, int y1, int x2, int y2, int numOfPoints)
        {
            var line = new Line(x1, y1, x2, y2, 'b');

            var points = line.Draw();

            points.Length.Should().Be(numOfPoints);
            points.Select(p => p.Should().Be(y1));
        }
    }
}

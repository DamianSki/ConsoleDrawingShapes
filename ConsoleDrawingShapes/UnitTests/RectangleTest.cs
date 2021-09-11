using ConsoleDrawingShapes;
using FluentAssertions;
using System;
using Xunit;

namespace UnitTests
{
    public class RectangleTest
    {
        [Theory]
        [InlineData(1, 2, 4, 3)]
        [InlineData(2, 2, 3, 4)]
        public void Rectangle_Create_Successful(int x1, int y1, int x2, int y2)
        {
            var line = new Rectangle(x1, y1, x2, y2, 'b');

            line.Should().NotBeNull();
            line.X1.Should().Be(x1);
            line.Y1.Should().Be(y1);
            line.X2.Should().Be(x2);
            line.Y2.Should().Be(y2);
            line.Color.Should().Be('b');
        }

        [Theory]
        [InlineData(1, 2, 1, 31)]
        [InlineData(11, 3, 2, 3)]
        [InlineData(1, 3, 1, 3)]
        public void Rectangle_Create_UnSuccessful(int x1, int y1, int x2, int y2)
        {
            Action action = () => new Rectangle(x1, y1, x2, y2, 'b');

            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(1, 1, 2, 2, 4)]
        [InlineData(-1, -1, 1, 1, 8)]
        [InlineData(1, 1, 3, 3, 8)]
        [InlineData(1, 1, 4, 4, 12)]

        public void Rectangle_Draw_Successful(int x1, int y1, int x2, int y2, int numberOfPoints)
        {
            var rectangle = new Rectangle(x1, y1, x2, y2, 'b');

            var points = rectangle.Draw();

            points.Should().NotBeEmpty();
            points.Length.Should().Be(numberOfPoints);
        }
    }
}

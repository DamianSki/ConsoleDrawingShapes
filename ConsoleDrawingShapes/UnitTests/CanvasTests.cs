using ConsoleDrawingShapes;
using FluentAssertions;
using System;
using Xunit;

namespace UnitTests
{
    public class CanvasTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 10)]
        [InlineData(10, 0)]
        [InlineData(-1, 10)]
        [InlineData(-1, -1)]
        [InlineData(-10, -1)]
        [InlineData(301, 20)]
        [InlineData(301, 302)]
        [InlineData(15, 302)]
        public void Create_Canvas_Unsuccessful(int width, int height)
        {
            Action action = () => Canvas.Create(width, height);
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(1, 10)]
        [InlineData(10, 1)]
        [InlineData(300, 10)]
        [InlineData(10, 300)]
        [InlineData(300, 300)]
        public void Create_Canvas_Successful(int width, int height)
        {
            var canvas = Canvas.Create(width, height);

            canvas.Should().NotBeNull();
            canvas.Should().BeOfType<Canvas>();
        }
    }
}

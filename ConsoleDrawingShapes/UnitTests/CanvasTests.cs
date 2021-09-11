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
    }
}

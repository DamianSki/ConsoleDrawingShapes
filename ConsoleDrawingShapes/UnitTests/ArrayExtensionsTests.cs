using ConsoleDrawingShapes.Extensions;
using FluentAssertions;
using Xunit;

namespace UnitTests
{
    public class ArrayExtensionsTests
    {
        [Fact]

        public void ArrayExtensions_ToCompoundArray()
        {
            var array = new int[,] { 
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 }
            };

            var result = array.ToCompoundArray();
            result.Length.Should().Be(2);
            result[0].Length.Should().Be(4);

            result[0][0].Should().Be(1);
            result[0][1].Should().Be(2);
            result[1][0].Should().Be(5);
            result[1][3].Should().Be(8);
        }
    }
}

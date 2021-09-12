using ConsoleDrawingShapes;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class Graphics2dAlgorithmsTests
    {
        private Graphics2DAlgorithms _algorithm;

        public Graphics2dAlgorithmsTests()
        {
            _algorithm = new Graphics2DAlgorithms();
        }

        [Fact]
        public void CanvasType1()
        {
            var canvas = new char[][] { 
                new char[] { '-', '-', '-', '-', '-' },
                new char[] { '|', 'x', 'x', 'x', '|' },
                new char[] { '|', 'x', 'x', 'x', '|' },
                new char[] { '|', 'x', 'x', 'x', '|' },
                new char[] { '-', '-', '-', '-', '-' }
            };

            var result = _algorithm.FindNeigbouhrPoints(2, 2, canvas);

            result.Count.Should().Be(9);
            result.Any(p => p.X == 1 && p.Y == 1).Should().BeTrue();
            result.Any(p => p.X == 2 && p.Y == 2).Should().BeTrue();
            result.Any(p => p.X == 3 && p.Y == 3).Should().BeTrue();
        }

        [Fact]
        public void CanvasType2()
        {
            var canvas = new char[][] {
                new char[] { '-', '-', '-', '-', '-', '-', '-' },
                new char[] { '|', 'x', 'x', 'x', 'p', 'x', '|' },
                new char[] { '|', 'x', 'x', 'x', 'p', 'p', '|' },
                new char[] { '|', 'o', 'x', 'x', 'x', 'x', '|' },
                new char[] { '-', '-', '-', '-', '-', '-', '-' }
            };

            var result = _algorithm.FindNeigbouhrPoints(2, 2, canvas);

            result.Count.Should().Be(10);
            result.Any(p => p.X == 4 && p.Y == 1).Should().BeFalse();
            result.Any(p => p.X == 1 && p.Y == 4).Should().BeFalse();
            result.Any(p => p.X == 1 && p.Y == 5).Should().BeFalse();
            result.Any(p => p.X == 2 && p.Y == 4).Should().BeFalse(); 
            result.Any(p => p.X == 2 && p.Y == 4).Should().BeFalse(); 
        }

        [Fact]
        public void CanvasType3()
        {
            var canvas = new char[][] {
                new char[] { '-', '-', '-', '-', '-', '-', '-' },
                new char[] { '|', 'x', 'x', 'p', 'x', 'x', '|' },
                new char[] { '|', 'x', 'x', 'p', 'x', 'x', '|' },
                new char[] { '|', 'o', 'o', 'x', 'x', 'x', '|' },
                new char[] { '|', 'o', 'o', 'x', 'x', 'x', '|' },
                new char[] { '|', 'o', 'o', 'x', 'x', 'x', '|' },
                new char[] { '|', 'o', 'o', 'x', 'x', 'x', '|' },
                new char[] { '-', '-', '-', '-', '-', '-', '-' }
            };

            var result = _algorithm.FindNeigbouhrPoints(2, 2, canvas);

            result.Count.Should().Be(4);
            result.Any(p => p.X == 1 && p.Y == 3).Should().BeFalse();
            result.Any(p => p.X == 1 && p.Y == 4).Should().BeFalse();
            result.Any(p => p.X == 4 && p.Y == 4).Should().BeFalse();
        }
    }
}

using System.Collections.Generic;

namespace ConsoleDrawingShapes.Extensions
{
    internal static class RangeExtensions
    {
        public static IEnumerable<int> Range(this (int start, int end) range)
        {
            for (int i = range.start; i <= range.end; i++)
                yield return i;
        }
    }
}

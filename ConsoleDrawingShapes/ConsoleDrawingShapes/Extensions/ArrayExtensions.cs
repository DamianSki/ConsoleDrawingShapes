using System;
using System.Text;

namespace ConsoleDrawingShapes.Extensions
{
    internal static class ArrayExtensions
    {
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            var result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        public static string ToStringLines(this char[][] array)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++) { 
                sb.AppendLine(new string(array[i]));
            }

            return sb.ToString();
        }

        public static T[][] ToCompoundArray<T>(this T[,] array)
        {
            var heigh = array.GetUpperBound(0) + 1;
            var width = array.GetUpperBound(1) + 1;

            var copy = new T[heigh][];

            for (int x = 0; x < heigh; x++)
            {
                copy[x] = new T[width];
                for (int y = 0; y < width; y++)
                    copy[x][y] = array[x, y];
            }

            return copy;
        }
    }
}

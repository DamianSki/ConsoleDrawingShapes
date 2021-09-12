using System;
using System.Text;

namespace ConsoleDrawingShapes.Extensions
{
    internal static class Extensions
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
    }
}

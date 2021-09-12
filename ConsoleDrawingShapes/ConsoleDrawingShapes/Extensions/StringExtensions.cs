using System.Text.RegularExpressions;

namespace ConsoleDrawingShapes.Extensions
{
    internal static class StringExtensions
    {
        public static string RemoveWhitespace(this string input) =>
            Regex.Replace(input, @"\s+", " ");
    }    
}

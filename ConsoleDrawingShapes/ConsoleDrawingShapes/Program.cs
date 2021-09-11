using System;

namespace ConsoleDrawingShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Drawing applicaiton!");
            Console.WriteLine("Damian Sobanski");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine("How to use the applicaiton? !nsert 'h'!");

            bool @continue;
            do
            {
                @continue = CommandsExecutor.Execute(Console.ReadLine());
            } while (@continue);

            Console.WriteLine("====================");
            Console.WriteLine("Thank you for using!");
        }

        private static class CommandsExecutor
        {
            /// <summary>
            /// Lets assume this is logger
            /// </summary>
            /// <param name="error"></param>
            private static void Logger(string error) => Console.WriteLine(error);

            private static (string operation, string[] attributes) ExtractActionWithAttributes(string line)
            {
                return (string.Empty, new[] { string.Empty, string.Empty });
            }

            private static void ChooseAction(string operation, string[] attributes)
            {
                if (string.IsNullOrEmpty(operation))
                    throw new ArgumentException("Command is required!");

                switch (operation.ToLower()) {
                    case "c":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Unknown operation!");
                }                    
            }

            public static bool Execute(string line)
            {
                try
                {
                    if (string.IsNullOrEmpty(line))
                        throw new ArgumentException("Line content is required!");

                    var (action, attributes) = ExtractActionWithAttributes(line);

                    if (action == "q")
                        return false;

                    ChooseAction(action, attributes);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Logger(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Logger(ex.Message);
                }
                catch (Exception ex)
                {
                    Logger(ex.Message);
                }

                return true;
            }
        }
    }
}

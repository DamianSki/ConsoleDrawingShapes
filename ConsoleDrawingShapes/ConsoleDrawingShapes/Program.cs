using ConsoleDrawingShapes.Extensions;
using System;

namespace ConsoleDrawingShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================++++++====================");
            Console.WriteLine("C w h - create a new canvas, w - width h - height");
            Console.WriteLine("L x1 y1 x2 y2 - create a new line from (x1,y1) to (x2,y2)");
            Console.WriteLine("R x1 y1 x2 y2 - Should create a new rectangle, upper left corner (x1,y1), lower right corner is (x2,y2)");
            Console.WriteLine("B x y c  - Should fill the entire area connected to (x,y) with colour c");
            Console.WriteLine("Q  - Should quit the program");
            Console.WriteLine("====================++++++====================");
            Console.WriteLine("");

            bool @continue;
            do
            {
                @continue = CommandsExecutor.Execute(Console.ReadLine());
            } while (@continue);

            Console.WriteLine("====================++++++====================");
            Console.WriteLine("Thank you for using!");
            Console.WriteLine("====================++++++====================");
        }

        private static class CommandsExecutor
        {
            private static IOutput _output = new Monitor();

            /// <summary>
            /// Lets assume this is logger
            /// </summary>
            /// <param name="error"></param>
            private static void Logger(string error) => Console.WriteLine(error);                        
            private static Canvas _canvas;
            private static (string operation, string[] attributes) ExtractActionWithAttributes(string line)
            {
                if (string.IsNullOrEmpty(line))
                    throw new ArgumentException("Unknown command!");

                var items = line.RemoveWhitespace().Split(' ');

                if (items.Length == 1)
                    return (items[0], new string[] { });

                return (items[0].ToLower(), items.SubArray(1, items.Length - 1));
            }

            /// <summary>
            /// This is simple switch. In case there is more commands justified is to create Command type which wrap canvas.method() execution and can validate himself. Command.Execute(), Command.Validate()
            /// </summary>
            /// <param name="action"></param>
            /// <param name="attributes"></param>
            private static char[][] ExecuteAction(string action, string[] attributes)
            {
                void ValidationPolicy1()
                {
                    if (_canvas == null)
                        throw new Exception("Canvas must be created before!");
                }

                void ValidationPolicy2(string a1, string a2, string a3, string a4)
                {
                    if (attributes.Length != 4
                        || !int.TryParse(a1, out int x1)
                        || !int.TryParse(a2, out int y1)
                        || !int.TryParse(a3, out int x2)
                        || !int.TryParse(a4, out int y2))
                        throw new ArgumentException("Incorect attributes!");
                }

                /// <summary>
                /// This is command type in this simple example it is just method
                /// </summary>
                /// <param name="attributes"></param>
                /// <returns></returns>
                Canvas CreateCanvas(string[] attributes)
                {
                    if (attributes.Length != 2 || !int.TryParse(attributes[0], out int width) || !int.TryParse(attributes[1], out int height))
                        throw new ArgumentOutOfRangeException("Create canvas incorrect attributes!");

                    return Canvas.Create(width, height);
                }

                /// <summary>
                /// This is command type in this simple example it is just method
                /// </summary>
                /// <param name="attributes"></param>
                /// <returns></returns>
                Canvas DrawLine(string[] attributes)
                {
                    ValidationPolicy1();
                    ValidationPolicy2(attributes[0], attributes[1], attributes[2], attributes[3]);

                    var x1 = int.Parse(attributes[0]);
                    var y1 = int.Parse(attributes[1]);
                    var x2 = int.Parse(attributes[2]);
                    var y2 = int.Parse(attributes[3]);
                        
                    _canvas.DrawLine(x1, y1, x2, y2);

                    return _canvas;
                }

                /// <summary>
                /// This is command type in this simple example it is just method
                /// </summary>
                /// <param name="attributes"></param>
                /// <returns></returns>
                Canvas DrawRectangle(string[] attributes)
                {
                    ValidationPolicy1();
                    ValidationPolicy2(attributes[0], attributes[1], attributes[2], attributes[3]);

                    var x1 = int.Parse(attributes[0]);
                    var y1 = int.Parse(attributes[1]);
                    var x2 = int.Parse(attributes[2]);
                    var y2 = int.Parse(attributes[3]);

                    _canvas.DrawRectangle(x1, y1, x2, y2);
                    return _canvas;
                }

                //Commands factory
                Canvas CommandsInterpreter(string action, string[] attributes)
                {
                    return action switch
                    {
                        "c" => CreateCanvas(attributes),
                        "l" => DrawLine(attributes),
                        "r" => DrawRectangle(attributes),
                        "b" => throw new InvalidOperationException("Operation not supported!"),
                        _ => throw new ArgumentOutOfRangeException("Unknown operation!")
                    };
                }

                _canvas = CommandsInterpreter(action, attributes);
                return _canvas.Render();
            }
                                  
            public static bool Execute(string line)
            {
                try
                {
                    var (action, attributes) = ExtractActionWithAttributes(line);

                    if (action == "q")
                        return false;

                    var content = ExecuteAction(action, attributes);                    
                    _output.Send(content.ToStringLines());
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

        private interface IOutput
        {
            void Send(string content);
        }

        private class Monitor : IOutput
        {
            public void Send(string content) => Console.WriteLine(content);
        }
    }
}

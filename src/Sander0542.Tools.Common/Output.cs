using System;

namespace Sander0542.Tools.Common
{
    public static class Output
    {
        public static void Write(string value, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            if (foreground.HasValue)
            {
                Console.ForegroundColor = foreground.Value;
            }

            if (background.HasValue)
            {
                Console.BackgroundColor = background.Value;
            }

            Console.Write(value);

            if (foreground.HasValue || background.HasValue)
            {
                Console.ResetColor();
            }
        }
        
        public static void WriteLine(string value, ConsoleColor? foreground = null, ConsoleColor? background = null)
        {
            if (foreground.HasValue)
            {
                Console.ForegroundColor = foreground.Value;
            }

            if (background.HasValue)
            {
                Console.BackgroundColor = background.Value;
            }

            Console.WriteLine(value);

            if (foreground.HasValue || background.HasValue)
            {
                Console.ResetColor();
            }
        }
    }
}

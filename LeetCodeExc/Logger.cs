using System;

namespace LeetCodeExc
{
    class Logger
    {
        private static string LogPadding = new string(' ', 8);

        public static void Log(string message, bool withPadding = true)
        {
            var padding = withPadding ? LogPadding : "";
            Console.Write(padding + message);
        }

        public static void LogLine(string message, bool withPadding = true)
        {
            var padding = withPadding ? LogPadding : "";
            Console.WriteLine(padding + message);
        }
    }
}

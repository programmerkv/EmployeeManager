using System;

namespace EmployeeManager.Extensions
{
    public static class ConsoleExtension
    {
        public static void WriteInfo(this string content)
        {
            Console.WriteLine(content);
        }

        public static void WriteError(this string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }
    }
}
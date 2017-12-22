using System;

namespace EmployeeManager.Extensions
{
    public static class ArrayExtension
    {
        private static string[] MakeSub(string[] a, int startIndex, int length)
        {
            var b = new string[length];
            Array.Copy(a, startIndex, b, 0, length);
            return b;
        }

        public static string[] MakeTail(this string[] a)
        {
            return MakeSub(a, 1, a.Length - 1);
        }
    }
}
using System;
using System.Globalization;

namespace EmployeeManager.Extensions
{
    public static class DateTimeExtension
    {
        private static readonly CultureInfo Ci = new CultureInfo("en-US");

        public static bool ConvertToDateTime(this string raw, out DateTime result)
        {
            return DateTime.TryParseExact(raw, "dd/MM/yyyy", Ci, DateTimeStyles.None, out result);
        }
    }
}
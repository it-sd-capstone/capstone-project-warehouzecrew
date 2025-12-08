using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorderPointSystem.Services
{
    internal static class GlobalDate
    {
        public static DateTime date = DateTime.UtcNow;
        public static void nextDay() {
            // Advance the global date by one day
            // But the time to be the same as now
            date = new DateTime(date.Year, date.Month, date.Day, DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, DateTime.UtcNow.Second, DateTime.UtcNow.Millisecond, DateTimeKind.Utc).AddDays(1);
        }

        public static DateTime GetUpdatedDate()
        {
            return new DateTime(date.Year, date.Month, date.Day, DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, DateTime.UtcNow.Second, DateTime.UtcNow.Millisecond, DateTimeKind.Utc);
        }
    }
}

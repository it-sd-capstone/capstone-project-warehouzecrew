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
        public static void nextDay() { date = date.AddDays(1); }
    }
}

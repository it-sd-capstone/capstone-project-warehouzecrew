using ReorderPointSystem.Data;
using ReorderPointSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace ReorderPointSystem.Services
{
    internal class Analysis
    {
        private InventoryLogRepository logRepo = new InventoryLogRepository();
        private ItemRepository itemRepo = new ItemRepository();
        private List<InventoryLog>? logs = null;
        private List<Item>? current = null;

        public string[] timeLevelIdentities = [ "3 days", "5 days", "week", "2 weeks", "month" ];
        public int[] timeLevelDays = [3, 5, 7, 14, 30];

        public int logCount = -1;                // count of how many logs there are
        public int itemCount = -1;               // count of how many item types there are
        public int[][]? history = null;          // int[day][item] history of quantities
        public DateTime[]? dates = null;         // DateTime[day] history of dates in logs
        public int[]? grossGains = null;         // int[item] gross all time gains
        public int[]? grossLosses = null;        // int[item] gross all time losses
        public int[][]? totalGains = null;       // int[timespan][item] total gains over x days
        public int[][]? predictLinear = null;    // int[timespan][item] predicted gains based on last x days
        public int[][]? predictParabola = null;  // int[timespan][item] predicted gains based on last x days
        public int[][]? predictExponent = null;  // int[timespan][item] predicted gains based on last x days

        public bool initialize()
        {
            logs = logRepo.GetAll();
            current = itemRepo.GetAll();
            logCount = logs.Count();
            itemCount = current.Count();
            if (logCount == 0 || itemCount == 0) { return false; }
            createHistory();
            estimateRates();
            return true;
        }
        private void createHistory()
        {
            List<int[]> backwardHistory = [];
            List<DateTime> backwardDates = [];

            int[] start = new int[itemCount];
            for (int i = 0; i < itemCount; i++) // create last day from current quantities
            {
                start[i] = current[i].CurrentAmount;
            }
            backwardHistory.Add((int[])start.Clone());
            backwardDates.Add(GlobalDate.date.Date);

            int[] currentDay = start;
            DateTime date = logs[0].CreatedAt.Date;
            int[] gains = new int[itemCount];
            int[] losses = new int[itemCount];
            for (int i = 0; i < logCount; i++) // step through logs end to start
            {
                var log = logs[i];
                (log.QuantityChange <= 0 ? gains : losses)[log.ItemId - 1] += log.QuantityChange;
                if (log.CreatedAt.Date != date) // IF date is same, continue to update current day ELSE add current day to history and start new current day, which is a clone of current day
                {
                    backwardHistory.Add((int[])currentDay.Clone());
                    backwardDates.Add(log.CreatedAt.Date.AddDays(1));
                    date = log.CreatedAt.Date;
                }
                currentDay[log.ItemId - 1] -= log.QuantityChange; // edit current day log by log by reversing the action of the log. database ids start at 1, not 0, so subtract 1 to get array id
            }
            backwardHistory.Add((int[])currentDay.Clone());
            backwardDates.Add(logs[logCount - 1].CreatedAt.Date);
            grossGains = gains;
            grossLosses = losses;

            // reverse history and dates into exactly sized array
            int historyPoints = backwardHistory.Count();
            history = new int[historyPoints][];
            dates = new DateTime[historyPoints];
            for (int i = 0; i < historyPoints; i++)
            {
                history[i] = backwardHistory[historyPoints - i - 1];
                dates[i] = backwardDates[historyPoints - i - 1];
            }
        }
        private void estimateRates()
        {
            int maxTimeLevel = timeLevelDays.Length - 1;
            int timeLevel = 0;
            List<int[]> validHistory = new List<int[]>();
            for (int i = 0; i < timeLevelDays[maxTimeLevel] + 1; i++)
            {
                if (i >= history.Length) { break; }
                if (i >= timeLevelDays[timeLevel]) { timeLevel++; }
                validHistory.Add(history[history.Length - i - 1]);
            }
            timeLevel--;
            totalGains = new int[timeLevel + 1][];
            predictLinear = new int[timeLevel + 1][];
            predictParabola = new int[timeLevel + 1][];
            predictExponent = new int[timeLevel + 1][];
            for (int i = 0; i <= timeLevel; i++)
            {
                totalGains[i] = calcGainsFromSpan(validHistory[0], validHistory[timeLevelDays[i]]);
                List<int[]> days = validHistory.GetRange(0, timeLevelDays[i]);
                predictLinear[i] = calcLinearFromDays(days);
                Point[][] controlPoints = calcControlPointsFromDays(days);
                predictParabola[i] = calcParabolaFromControlPoints(controlPoints, timeLevelDays[i] + 1);
                predictExponent[i] = calcExponentFromControlPoints(controlPoints, timeLevelDays[i] + 1);
            }
        }
        private int[] calcGainsFromSpan(int[] start, int[] end)
        {
            int[] spanGains = new int[itemCount];
            for (int i = 0; i < itemCount; i++)
            {
                spanGains[i] = start[i] - end[i];
            }
            return spanGains;
        }
        private int[] calcLinearFromDays(List<int[]> days)
        {
            int[] projected = new int[itemCount];
            int dayCount = days.Count();
            for (int i = 0; i < itemCount; i++)
            {
                // simple linear regression formula (my design, start and end as control points, rest shift trend vertically)
                var startAmt = days[0][i];
                var endAmt = days.Last()[i];
                int mean = 0;
                for (int j = 0; j < dayCount; j++)
                {
                    mean += days[j][i];
                }
                mean = mean / dayCount;
                projected[i] = (endAmt - startAmt) / (dayCount - 1) * ((dayCount + 1) / 2) + mean;
            }
            return projected;
        }
        private Point[][] calcControlPointsFromDays(List<int[]> days)
        {
            Point[][] controlPoints = new Point[itemCount][];
            int dayCount = days.Count();
            for (int i = 0; i < itemCount; i++)
            {
                // cluster points into 3 pools and average each pool
                List<Point> allPoints = new List<Point>();
                for (int j = 0; j < dayCount; j++) { allPoints.Add(new Point(j + 1, days[j][i])); }
                int remaining = dayCount - 3;
                int n1 = remaining / 3;
                int n2 = remaining - n1 * 2;
                int size1 = 1 + n1;
                int size2 = 1 + n2;
                List<Point> pool1 = allPoints.GetRange(0, size1);
                List<Point> pool2 = allPoints.GetRange(size1, size1);
                List<Point> pool3 = allPoints.GetRange(size1 * 2, size2);
                Point avg1 = new Point(0, 0);
                Point avg2 = new Point(0, 0);
                Point avg3 = new Point(0, 0);
                foreach (Point point in pool1) { avg1.X += point.X; avg1.Y += point.Y; }
                foreach (Point point in pool2) { avg2.X += point.X; avg2.Y += point.Y; }
                foreach (Point point in pool3) { avg3.X += point.X; avg3.Y += point.Y; }
                avg1.X /= pool1.Count();
                avg2.X /= pool2.Count();
                avg3.X /= pool3.Count();
                controlPoints[i] = [ avg1, avg2, avg3 ];
            }
            return controlPoints;
        }
        private int[] calcParabolaFromControlPoints(Point[][] controlPoints, int targetDay)
        {
            int[] projected = new int[itemCount];
            for (int i = 0; i < itemCount; i++)
            {
                // precise parabolic formula from 3 points, steps taken from the internet
                Point p1 = controlPoints[i][0];
                Point p2 = controlPoints[i][0];
                Point p3 = controlPoints[i][0];
                double a1 = p2.X * p2.X - p1.X * p1.X;
                double b1 = p2.X - p1.X;
                double d1 = p2.Y - p1.Y;
                double a2 = p3.X * p3.X - p2.X * p2.X;
                double b2 = p3.X - p2.X;
                double d2 = p3.Y - p2.Y;
                double bmult = -(b2 / b1);
                double a3 = bmult * a1 + a2;
                double d3 = bmult * d1 + d2;
                double a = d3 / a3;
                double b = (d1 - a1 * a) / b1;
                double c = p1.Y - a * p1.X * p1.X - b * p1.X;
                projected[i] = (int) (a * targetDay * targetDay + b * targetDay + c);
            }
            return projected;
        }
        private int[] calcExponentFromControlPoints(Point[][] controlPoints, int targetDay)
        {
            int[] projected = new int[itemCount];
            for (int i = 0; i < itemCount; i++)
            {
                // exponential approximation from 3 points, steps designed by me
                Point p1 = controlPoints[i][0];
                Point p2 = controlPoints[i][0];
                Point p3 = controlPoints[i][0];
                int sign = Math.Sign(p3.Y - p1.Y);
                double k1 = 0.0001;
                if (sign != 0)
                {
                    k1 = Math.Max(0.0001, 1 + ((p3.Y - p2.Y) / (p3.X - p2.X) - (p2.Y - p1.Y) / (p2.X - p1.X)) * sign);
                }
                double k0 = 0.0001;
                if (sign != 0)
                {
                    k0 = (p3.Y - p1.Y) / (Math.Pow(k1, p3.X - p1.X) - 1);
                }
                projected[i] = (int) (k0 * Math.Pow(k1, targetDay - p1.X) - k0 + p1.Y);
            }
            return projected;
        }
    }
}

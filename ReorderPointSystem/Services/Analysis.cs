using ReorderPointSystem.Data;
using ReorderPointSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorderPointSystem.Services
{
    internal class Analysis
    {
        private InventoryLogRepository logRepo = new InventoryLogRepository();
        private ItemRepository itemRepo = new ItemRepository();
        List<InventoryLog>? logs = null;
        List<Item>? current = null;
        public int[][]? history = null;
        public DateTime[]? dates = null;
        int[]? grossGains = null;
        int[]? grossLosses = null;
        int logCount = -1;
        int itemCount = -1;
        public bool instantiate()
        {
            logs = logRepo.GetAll();
            current = itemRepo.GetAll();
            logCount = logs.Count();
            itemCount = current.Count();
            if (logCount == 0 || itemCount == 0) { return false; }
            createHistory();
            grossChange();
            return true;
        }
        public void createHistory()
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
            DateTime date = logs[logCount - 1].CreatedAt.Date;
            for (int i = logCount - 1; i >= 0; i--) // step through logs end to start
            {
                if (logs[i].CreatedAt.Date != date) // IF date is same, continue to update current day ELSE add current day to history and start new current day, which is a clone of current day
                {
                    backwardHistory.Add((int[])currentDay.Clone());
                    backwardDates.Add(logs[i].CreatedAt.Date);
                    date = logs[i].CreatedAt.Date;
                }
                currentDay[logs[i].ItemId - 1] -= logs[i].QuantityChange; // edit current day log by log by reversing the action of the log. database ids start at 1, not 0, so subtract 1 to get array id
            }
            backwardHistory.Add((int[])currentDay.Clone());
            backwardDates.Add(logs[0].CreatedAt.Date);
            date = logs[0].CreatedAt.Date;

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
        public void grossChange()
        {
            int[] gains = new int[itemCount];
            int[] losses = new int[itemCount];
            foreach (InventoryLog log in logs)
            {
                (log.QuantityChange >= 0 ? gains : losses)[log.ItemId - 1] += log.QuantityChange;
            }
            grossGains = gains;
            grossLosses = losses;
        }
        // get recent total and real linear rate of change
        // get recent total and real rate of change
        // get recent total and real rate of change
    }
}

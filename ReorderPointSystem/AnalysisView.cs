using ReorderPointSystem.Data;
using ReorderPointSystem.Models;
using ReorderPointSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ReorderPointSystem
{
    public partial class AnalysisView : Form
    {
        public AnalysisView()
        {
            InitializeComponent();
            Analysis analysis = new Analysis();
            if (!analysis.initialize())
            {
                return;
            }
            ItemRepository repo = new ItemRepository();
            Item[] items = repo.GetAll().ToArray();
            // column labels
            historyGrid.Columns.Add("Date", "Date");
            historyRecentGainsGrid.Columns.Add("Over last", "Over last");
            predictionLinearGrid.Columns.Add("By last", "By last"); // by last [3 days/week/2 weeks/month/etc]
            predictionParabolicGrid.Columns.Add("By last", "By last");
            predictionExponentialGrid.Columns.Add("By last", "By last");
            foreach (Item item in items)
            {
                var name = item.Name;
                historyGrid.Columns.Add(name, name);
                historyRecentGainsGrid.Columns.Add(name, name);
                predictionLinearGrid.Columns.Add(name, name);
                predictionParabolicGrid.Columns.Add(name, name);
                predictionExponentialGrid.Columns.Add(name, name);
            }
            // ---------- HISTORY ----------
            // historyGrid
            for (int i = 0; i < analysis.dates.Count(); i++)
            {
                var row = new DataGridViewRow();
                row.CreateCells(historyGrid);
                row.Cells[0].Value = analysis.dates[i].ToString("d");
                var vals = analysis.history[i];
                for (int j = 0; j < vals.Length; j++)
                {
                    row.Cells[j + 1].Value = vals[j].ToString();
                }
                historyGrid.Rows.Add(row);
            }
            // historyRecentGainsGrid

            // ---------- PREDICT ----------
            // predictionLinearGrid

            // predictionParabolicGrid

            // predictionExponentialGrid

        }
    }
}

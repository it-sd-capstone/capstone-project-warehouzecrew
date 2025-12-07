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

namespace ReorderPointSystem
{
    public partial class AnalysisView : Form
    {
        public AnalysisView()
        {
            InitializeComponent();
            historyGrid.Columns.Add("Date", "Date");
            ItemRepository repo = new ItemRepository();
            foreach (Item item in repo.GetAll())
            {
                historyGrid.Columns.Add(item.Name, item.Name);
            }
            Analysis analysis = new Analysis();
            if (!analysis.instantiate()) { return; }
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
        }
    }
}

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
                var row = new List<string>();
                row.Add(analysis.dates[i].ToString());
                foreach (int count in analysis.history[i])
                {
                    row.Add(count.ToString());
                }
                historyGrid.Rows.Add(row);
            }
        }
    }
}

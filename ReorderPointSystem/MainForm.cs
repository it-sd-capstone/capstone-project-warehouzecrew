using System.Diagnostics;
using ReorderPointSystem.Data;

namespace ReorderPointSystem
{
    public partial class MainForm : Form
    {
        private void DisableProductInfoOptions()
        {
            ItemInfoGroupBox.Enabled = false;
        }

        private void EnableProductInfoOptions()
        {
            ItemInfoGroupBox.Enabled = true;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void EnableTestModeChkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (EnableTestModeChkbx.Checked == true)
            {
                AddTestDataBtn.Visible = true;
                SimDayBtn.Visible = true;
            }
            else
            {
                AddTestDataBtn.Visible = false;
                SimDayBtn.Visible = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Database.Initialize();
            DisableProductInfoOptions();
        }

        private void SimDayBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddTestDataBtn_Click(object sender, EventArgs e)
        {

        }

        private void SubmitItemBtn_Click(object sender, EventArgs e)
        {

        }

        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {

        }

        private void DeleteItemBtn_Click(object sender, EventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {

        }

        private void EditItemBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddToOrderBtn_Click(object sender, EventArgs e)
        {

        }

        private void DeletePendingOrderBtn_Click(object sender, EventArgs e)
        {

        }

        private void EditOrderAmtBtn_Click(object sender, EventArgs e)
        {

        }
    }
}

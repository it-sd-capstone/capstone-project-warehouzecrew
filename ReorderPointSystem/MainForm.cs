using System.Data.SQLite;
using System.Diagnostics;
using ReorderPointSystem.Data;

namespace ReorderPointSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Helper function to disable editing item information
        private void DisableProductInfoOptions()
        {
            ItemInfoGroupBox.Enabled = false;
        }

        // Helper function to enable editing item information
        private void EnableProductInfoOptions()
        {
            ItemInfoGroupBox.Enabled = true;
        }

        // Form load events, all will happen before the form displays to the user
        private void MainForm_Load(object sender, EventArgs e)
        {
            Database.Initialize();
        }

        // Display or hide the Simulation buttons
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

        // When the simulate day button is pressed, each item in the DB has a chance to deplete a random amount of stock
        private void SimDayBtn_Click(object sender, EventArgs e)
        {
            
        }

        // Insert dummy records into the DB for testing purposes
        private void AddTestDataBtn_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = Database.GetConnection();
            String[] categories = new String[] { "Produce", "Office-Supplies", "Home-Goods", "Raw-Materials", "Electronics", "Groceries" };

            // for each category, if they aren't already in the categories table, add them. 
            foreach (String str in categories)
            {
                String selectCommand = "SELECT id FROM categories WHERE name = \'" + str + "\'";
                SQLiteCommand selectCMD = new SQLiteCommand(selectCommand, conn);
                SQLiteDataReader reader = selectCMD.ExecuteReader();
                selectCMD.Dispose();
                if (!reader.HasRows)
                {
                    String insertCommand = "INSERT INTO categories (name) VALUES (\'" + str + "\')";
                    SQLiteCommand insertCMD = new SQLiteCommand(insertCommand, conn);
                    Debug.WriteLine(str + " was added.");
                    insertCMD.ExecuteNonQuery();
                    insertCMD.Dispose();
                }
                else
                {
                    Debug.WriteLine(str + " already exists in the table.");
                }
                reader.Close();
            }

            int[] itemCategoryID = new int[] { 1, 2, 3, 4, 5, 6, 1, 2, 3, 4 };
            String[] itemNames = new String[] { "Lettuce", "Staples", "Curtains", "Plywood", "GPU", "Cheerios", "Cucumbers", "Pencils", "Paper", "Linseed-oil" };
            String[] itemDescription = new String[] { "", "", "", "", "", "", "", "", "", "" };
            int[] itemCurrAmt = new int[] { 10, 3000, 5, 100, 5, 27, 95, 200, 4570, 46 };
            int[] itemReorderPoint = new int[] { 5, 1000, 2, 50, 3, 20, 50, 120, 2000, 25 };
            int[] itemReorderAmt = new int[] { 20, 4000, 8, 200, 12, 80, 200, 480, 8000, 100 };

            // add sample items if they dont already exist
            for (int i = 0; i < itemNames.Length; i++)
            {
                String selectCommand2 = "SELECT id FROM items WHERE name = \'" + itemNames[i] + "\'";
                SQLiteCommand selectCMD2 = new SQLiteCommand(selectCommand2, conn);
                SQLiteDataReader reader2 = selectCMD2.ExecuteReader();
                selectCMD2.Dispose();
                if (!reader2.HasRows)
                {

                    String insertCommand2 = "INSERT INTO items (category_id, name, description, current_amount, reorder_point, max_amount) VALUES " +
                        "(\'" + itemCategoryID[i] + "\', " +
                        "\'" + itemNames[i] + "\', " +
                        "\'" + itemDescription[i] + "\', " +
                        "\'" + itemCurrAmt[i] + "\', " +
                        "\'" + itemReorderPoint[i] + "\', " +
                        "\'" + itemReorderAmt[i] + "\')";
                    SQLiteCommand insertCMD2 = new SQLiteCommand(insertCommand2, conn);
                    insertCMD2.ExecuteNonQuery();
                    insertCMD2.Dispose();
                }
                else
                {
                    Debug.WriteLine(itemNames[i] + " already exists in the table.");
                }
            }
                conn.Close();
        }

        // IF the item displayed is already in the DB, update the record for said item
        // ELSE create a new item in the BD with the properties set by the user
        private void SubmitItemBtn_Click(object sender, EventArgs e)
        {

        }

        // Clear the item information in the item info group box. If the text boxes are disabled, also enable them
        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {

        }

        // Remove the selected item from the Items DB, If an item is selected
        private void DeleteItemBtn_Click(object sender, EventArgs e)
        {

        }

        // Filter the items listed in the ItemsListBox box based on the text in the ItemSearchTextBox
        private void SearchBtn_Click(object sender, EventArgs e)
        {

        }

        // Enables the controls in the ItemInfoGroupBox for editing
        private void EditItemBtn_Click(object sender, EventArgs e)
        {

        }

        // Add the highlighted item to a pending order. If no pending orders exist, also create a new pending order
        private void AddToOrderBtn_Click(object sender, EventArgs e)
        {

        }

        // Remove the pending order from the PendingOrdersListBox
        // WILL NOT STOP THE ORDER FROM BEING RECREATED IF AN ITEM IS BELOW REORDER THRESHOLD
        private void DeletePendingOrderBtn_Click(object sender, EventArgs e)
        {

        }

        // Edit the amount of an item to be ordered, from within a pending order
        private void EditOrderAmtBtn_Click(object sender, EventArgs e)
        {

        }
    }
}

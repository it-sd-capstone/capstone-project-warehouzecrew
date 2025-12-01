using System.Data.SQLite;
using System.Diagnostics;
using System.Xml.Serialization;
using ReorderPointSystem.Data;
using ReorderPointSystem.Models;
using ReorderPointSystem.Services;

namespace ReorderPointSystem
{
    public partial class MainForm : Form
    {

        private List<Item> itemsList;
        private List<Item> pendingOrder;
        private List<Category> categories;
        private List<Reorder> reorders;
        private Item selectedItem;
        private UIController controller = new UIController(new InventoryManager());
        public MainForm()
        {
            InitializeComponent();

            //Sets up GridView 
            SetupGridColumns();
        }
        private void SetupGridColumns()
        {
            ItemsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ItemsGridView.Columns.Clear();

            // Create columns on percentages or total element space
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Id";
            idColumn.HeaderText = "ID";
            idColumn.FillWeight = 20; // 20% of total width

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.FillWeight = 50; // 50% of total width

            DataGridViewTextBoxColumn qtyColumn = new DataGridViewTextBoxColumn();
            qtyColumn.Name = "CurrentAmount";
            qtyColumn.HeaderText = "Quantity";
            qtyColumn.FillWeight = 30; // 30% of total width

            // Add columns to grid
            ItemsGridView.Columns.Add(idColumn);
            ItemsGridView.Columns.Add(nameColumn);
            ItemsGridView.Columns.Add(qtyColumn);
        }

        // Helper function to disable editing item information
        private void DisableProductInfoOptions()
        {
            ItemNameTextBox.Enabled = false;
            CurrentQtyTextBox.Enabled = false;
            ReorderMaxTextBox.Enabled = false;
            ReorderPointTextBox.Enabled = false;
            EnableReorderChkbx.Enabled = false;
            SubmitItemBtn.Enabled = false;
            DeleteItemBtn.Enabled = false;
            CategoryComboBox.Enabled = false;
            ClearFieldsBtn.Enabled = true;
        }

        // Helper function to enable editing item information
        private void EnableProductInfoOptions()
        {
            ItemNameTextBox.Enabled = true;
            CurrentQtyTextBox.Enabled = true;
            ReorderMaxTextBox.Enabled = true;
            ReorderPointTextBox.Enabled = true;
            EnableReorderChkbx.Enabled = true;
            SubmitItemBtn.Enabled = true;
            DeleteItemBtn.Enabled = true;
            CategoryComboBox.Enabled = true;
        }

        // Helper function to reload data from the DB after an edit/delete has been made
        private void ReloadDB()
        {
            itemsList = controller.LoadItems();
            DisplayItems(itemsList);
        }

        // recursive helper function to continue checking for reorder items
        private async Task CheckReorders()
        {
            await Task.Delay(5000);
            pendingOrder = controller.ProcessLowStockReorders(itemsList);
            if (pendingOrder.Count > 0 && PendingOrderListBox.Items.Count == 0)
            {
                String searchStr = "SELECT COUNT(\'id\') FROM reorders";
                SQLiteConnection conn = Database.GetConnection();
                SQLiteCommand cmd = new SQLiteCommand(searchStr, conn);
                int orderID;
                int.TryParse(cmd.ExecuteScalar().ToString(), out orderID);
                PendingOrderListBox.Items.Add("WIP Order ID: " + orderID);
            }
            CheckReorders();
        }

        // helper function to load all current categories on form load
        private void LoadCategories()
        {
            CategoryRepository cats = new CategoryRepository();
            categories = cats.GetAll();
            CategoryComboBox.Items.Clear();
            CategoryComboBox.DataSource = categories;
            CategoryComboBox.ValueMember = "Id";
            CategoryComboBox.DisplayMember = "Name";
        }

        // Helper function to load Orders on form load
        private void LoadOrders()
        {
            reorders = controller.LoadOrders();
            CurrentOrdersListBox.DataSource = reorders;
            CurrentOrdersListBox.ValueMember = "Id";
            CategoryComboBox.DisplayMember = "ItemId";
        }

        // Form load events, all will happen before the form displays to the user
        private void MainForm_Load(object sender, EventArgs e)
        {
            Database.Initialize();
            ReloadDB();
            LoadCategories();
            LoadOrders();
            CheckReorders();
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
            SQLiteConnection conn = Database.GetConnection();
            Random rand = new Random();
            foreach (Item item in itemsList)
            {
                int num = rand.Next(100);
                if (num >= 50)
                {
                    int decrease = Math.Min(rand.Next(100), item.CurrentAmount);
                    String updateStr = "UPDATE items SET current_amount = \'" + decrease + "\' WHERE id = \'" + item.Id + "\'";
                    SQLiteCommand cmd = new SQLiteCommand(updateStr, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            ReloadDB();
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

                    String insertCommand2 = "INSERT INTO items (category_id, name, description, current_amount, reorder_point, max_amount, created_at, updated_at) VALUES " +
                        "(\'" + itemCategoryID[i] + "\', " +
                        "\'" + itemNames[i] + "\', " +
                        "\'" + itemDescription[i] + "\', " +
                        "\'" + itemCurrAmt[i] + "\', " +
                        "\'" + itemReorderPoint[i] + "\', " +
                        "\'" + itemReorderAmt[i] + "\', " +
                        "\'" + DateTime.Now + "\', " +
                        "\'" + DateTime.Now + "\')";
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
            if (selectedItem != null)
            {
                int curAmt;
                int reorderPt;
                int maxAmt;
                int id = selectedItem.Id;
                String name = ItemNameTextBox.Text;
                bool isValidCur = int.TryParse(CurrentQtyTextBox.Text.ToString(), out curAmt);
                bool isValidReorder = int.TryParse(ReorderPointTextBox.Text.ToString(), out reorderPt);
                bool isValidMax = int.TryParse(ReorderMaxTextBox.Text.ToString(), out maxAmt);
                if (isValidCur && isValidMax && isValidReorder && name != String.Empty)
                {
                    String sql = "UPDATE items SET name = \'" + name +
                        "\', current_amount = \'" + curAmt +
                        "\', reorder_point = \'" + reorderPt +
                        "\', max_amount = \'" + maxAmt +
                        "\', updated_at = DATETIME(\'now\'), category_id = \'" + CategoryComboBox.SelectedValue +
                        "\' WHERE id = \'" + id + "\'";
                    SQLiteConnection conn = Database.GetConnection();
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("One of your edited fields is not a valid input, please revise and re-submit", "Error: Invalid Input");
                }
            }
            else
            {
                int curAmt;
                int reorderPt;
                int maxAmt;
                String name = ItemNameTextBox.Text;
                String description = ItemDescriptionLabel.Text;
                bool isValidCur = int.TryParse(CurrentQtyTextBox.Text.ToString(), out curAmt);
                bool isValidReorder = int.TryParse(ReorderPointTextBox.Text.ToString(), out reorderPt);
                bool isValidMax = int.TryParse(ReorderMaxTextBox.Text.ToString(), out maxAmt);
                if (isValidCur && isValidMax && isValidReorder && name != String.Empty)
                {
                    String sql = "INSERT INTO items (category_id, name, description, current_amount, reorder_point, max_amount, created_at, updated_at) " +
                    "VALUES (\'" + CategoryComboBox.SelectedValue +
                    "\', \'" + name +
                    "\', \'" + description +
                    "\', \'" + curAmt +
                    "\', \'" + reorderPt +
                    "\', \'" + maxAmt +
                    "\', DATETIME(\'now\'), DATETIME(\'now\'))";
                    SQLiteConnection conn = Database.GetConnection();
                    SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("One of your fields is not a valid input, please revise and re-submit", "Error: Invalid Input");
                }
            }
            ReloadDB();
        }

        // Clear the item information in the item info group box. If the text boxes are disabled, also enable them
        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {
            if (ItemInfoGroupBox.Enabled == false)
            {
                ItemInfoGroupBox.Enabled = true;
            }
            ItemNameTextBox.Text = string.Empty;
            EnableReorderChkbx.Checked = false;
            CurrentQtyTextBox.Text = string.Empty;
            ReorderPointTextBox.Text = string.Empty;
            ReorderMaxTextBox.Text = string.Empty;
            selectedItem = null;
            EnableProductInfoOptions();
            DeleteItemBtn.Enabled = false;
        }

        // Remove the selected item from the Items DB, If an item is selected
        private void DeleteItemBtn_Click(object sender, EventArgs e)
        {
            if (ItemsGridView.CurrentRow != null)
            {
                String sql = "DELETE FROM items WHERE id = \'" + selectedItem.Id + "\'";
                Console.WriteLine(sql);
                SQLiteConnection conn = Database.GetConnection();
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("You must select an item before you can delete it.", "Error - No selected Item");
            }
            ReloadDB();
        }

        // Filter the items listed in the ItemsListBox box based on the text in the ItemSearchTextBox
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            itemsList = controller.SearchItems(ItemSearchTextBox.Text);
            ItemsGridView.Rows.Clear();

            foreach (var item in itemsList)
            {
                ItemsGridView.Rows.Add(item.Id, item.Name, item.CurrentAmount);
            }

            ClearFieldsBtn_Click(sender, e);
            if (ItemsGridView.Rows.Count > 0)
            {
                ItemsGridView.CurrentCell = ItemsGridView.Rows[0].Cells[0];
                int id = (int)ItemsGridView.Rows[0].Cells["Id"].Value;
                selectedItem = itemsList.FirstOrDefault(x => x.Id == id);
            }
        }

        // Enables the controls in the ItemInfoGroupBox for editing
        private void EditItemBtn_Click(object sender, EventArgs e)
        {
            if (ItemsGridView.SelectedRows.Count > 0)
            {
                var row = ItemsGridView.SelectedRows[0];

                int id = (int)row.Cells["Id"].Value;

                selectedItem = itemsList.FirstOrDefault(item => item.Id == id);

                // If the item exists, populate the fields and enable editing
                if (selectedItem != null)
                {
                    ItemNameTextBox.Text = selectedItem.Name;
                    CurrentQtyTextBox.Text = selectedItem.CurrentAmount.ToString();
                    ReorderPointTextBox.Text = selectedItem.ReorderPoint.ToString();
                    ReorderMaxTextBox.Text = selectedItem.MaxAmount.ToString();
                    ItemDescriptionLabel.Text = selectedItem.Description;
                    CategoryComboBox.SelectedValue = selectedItem.CategoryId;

                    // Enable editing controls
                    EnableProductInfoOptions();
                }
            }
            else
            {
                MessageBox.Show("You must select an item before you can edit it.", "Error - No selected Item");
            }
        }

        // Add the highlighted item to a pending order. If no pending orders exist, also create a new pending order
        private void AddToOrderBtn_Click(object sender, EventArgs e)
        {
            if (ItemsGridView.CurrentRow != null)
            {
                if (selectedItem != null)
                {
                    Item copy = selectedItem;
                    pendingOrder.Add(copy);
                    OrderItemsListBox.DataSource = null;
                    OrderItemsListBox.DataSource = pendingOrder;
                }
                else
                {
                    MessageBox.Show("Select an item first, please.", "Error: no item Selected");
                }
            }
            else
            {
                MessageBox.Show("You must select an item before you can add it to an order.", "Error - No selected Item");
            }
        }

        // Remove the pending order from the PendingOrdersListBox
        // WILL NOT STOP THE ORDER FROM BEING RECREATED IF AN ITEM IS BELOW REORDER THRESHOLD
        private void DeletePendingOrderBtn_Click(object sender, EventArgs e)
        {
            if (PendingOrderListBox.SelectedIndex != -1)
            {
                PendingOrderListBox.Items.Clear();
                PendingOrderListBox.SelectedIndex = -1;
                PendingOrderListBox.Refresh();
                pendingOrder.Clear();
                OrderItemsListBox.DataSource = null;
                OrderItemsListBox.DataSource = pendingOrder;
            }
            else
            {
                MessageBox.Show("You must select an order before you can delete it.", "Error - No selected order");
            }
        }

        // Edit the amount of an item to be ordered, from within a pending order
        private void EditOrderAmtBtn_Click(object sender, EventArgs e)
        {
            if (OrderItemsListBox.SelectedIndex != -1)
            {
                int qty;
                bool validQty = int.TryParse(EditOrderAmtTextBox.Text.ToString(), out qty);
                if (validQty)
                {
                    pendingOrder[OrderItemsListBox.SelectedIndex].MaxAmount = qty;
                }
                OrderItemsListBox.DataSource = null;
                OrderItemsListBox.DataSource = pendingOrder;
            }
            else
            {
                MessageBox.Show("You must select an item before you can edit it's order quantity.", "Error - No selected item");
            }
        }

        private void DisplayItems(List<Item> items)
        {
            ItemsGridView.Rows.Clear();

            foreach (var item in items)
            {
                ItemsGridView.Rows.Add(item.Id, item.Name, item.CurrentAmount);
            }

            // Select the first row if available
            if (ItemsGridView.Rows.Count > 0)
            {
                ItemsGridView.CurrentCell = ItemsGridView.Rows[0].Cells[0];
                int id = (int)ItemsGridView.Rows[0].Cells["Id"].Value;
                selectedItem = items.FirstOrDefault(x => x.Id == id);
            }
        }

        private void ItemsGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ItemsGridView.SelectedRows.Count > 0)
            {
                var row = ItemsGridView.SelectedRows[0];

                // Safely get the ID value
                if (row.Cells["Id"].Value != null)
                {
                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    selectedItem = itemsList.FirstOrDefault(item => item.Id == id);

                    if (selectedItem != null)
                    {
                        DisableProductInfoOptions();
                        ItemNameTextBox.Text = selectedItem.Name;
                        CurrentQtyTextBox.Text = selectedItem.CurrentAmount.ToString();
                        ReorderPointTextBox.Text = selectedItem.ReorderPoint.ToString();
                        ReorderMaxTextBox.Text = selectedItem.MaxAmount.ToString();
                        ItemDescriptionLabel.Text = selectedItem.Description;
                        CategoryComboBox.SelectedValue = selectedItem.CategoryId;
                    }
                }
            }
        }

        private void SubmitPendingOrderButton_Click(object sender, EventArgs e)
        {
            // TODO DB structure needs to be revisited to allow for PK/FK matching in reorder table before completing
        }

        private void PendingOrderListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PendingOrderListBox.SelectedIndex != -1)
            {
                OrderItemsListBox.DataSource = pendingOrder;
            }
            else
            {
                MessageBox.Show("Error: no selected index");
            }
        }

        private void OrderItemsListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            String name = ((Item)e.ListItem).Name;
            String id = ((Item)e.ListItem).Id.ToString();
            String qty = ((Item)e.ListItem).MaxAmount.ToString();

            e.Value = name.ToUpper() + "     ID=" + id + "      OrderQTY=" + qty;
        }

        private void OrderItemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OrderItemsListBox.SelectedIndex != -1)
            {
                EditOrderAmtBtn.Enabled = true;
                EditOrderAmtTextBox.Enabled = true;
                EditOrderAmtTextBox.Text = pendingOrder[OrderItemsListBox.SelectedIndex].MaxAmount.ToString();
            }
        }

        private void SortByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Utilizing this method from the UI controller
            UpdateItemsDisplay();

        }

        private void RefreshButtonClick(object sender, EventArgs e)
        {
            var items = controller.LoadItems();

            DisplayItems(items);
        }

        private void UpdateItemsDisplay()
        {
            var items = controller.LoadItems();

            if (SortByComboBox.SelectedItem is string sortCriteria)
                items = controller.SortItems(items, sortCriteria);

            // Clear rows and add only the relevant columns
            ItemsGridView.Rows.Clear();
            foreach (var item in items)
            {
                ItemsGridView.Rows.Add(item.Id, item.Name, item.CurrentAmount);
            }

            if (ItemsGridView.Rows.Count > 0)
                ItemsGridView.Rows[0].Selected = true;
        }

    }
}

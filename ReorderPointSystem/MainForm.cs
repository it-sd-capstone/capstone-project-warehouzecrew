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
        private List<Item> manualOrderItems;
        private List<Category> categories;
        private List<Reorder> reorders;
        private Item selectedItem;
        private String orderSelection = "";

        private UIController controller = new UIController(new InventoryManager());

        private bool isEditingItemName = false;
        private Dictionary<int, string> categoryLookup;

        public MainForm()
        {
            Database.Initialize();

            InitializeComponent();

            LoadCategories();

            SetupGridColumns();
            
        }
        private void SetupGridColumns()
        {
            ItemsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ItemsGridView.MultiSelect = false;
            ItemsGridView.ColumnCount = 4;

            OrderItemsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PastOrderDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ItemsGridView.Columns.Clear();
            OrderItemsDataGrid.Columns.Clear();
            PastOrderDataGridView.Columns.Clear();

            // Create columns on percentages or total element space
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "Id";
            idColumn.HeaderText = "ID";
            idColumn.DataPropertyName = "Id";
            idColumn.FillWeight = 20; // 20% of total width

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.DataPropertyName = "Name";
            nameColumn.FillWeight = 50; // 50% of total width

            DataGridViewTextBoxColumn catColumn = new DataGridViewTextBoxColumn();
            catColumn.Name = "Category";
            catColumn.HeaderText = "Category";
            catColumn.DataPropertyName = "CategoryID"; // Maps to Item.CategoryID property
            catColumn.FillWeight = 20;// 20% of total width

            DataGridViewTextBoxColumn qtyColumn = new DataGridViewTextBoxColumn();
            qtyColumn.Name = "CurrentAmount";
            qtyColumn.HeaderText = "Quantity";
            qtyColumn.DataPropertyName = "CurrentAmount";
            qtyColumn.FillWeight = 10; // 10% of total width

            //Order Items Grid Columns
            DataGridViewTextBoxColumn orderItemIdColumn = new DataGridViewTextBoxColumn();
            orderItemIdColumn.Name = "Id";
            orderItemIdColumn.HeaderText = "Item ID";
            orderItemIdColumn.FillWeight = 20; // 20% of total width

            DataGridViewTextBoxColumn OrderItemNameColumn = new DataGridViewTextBoxColumn();
            OrderItemNameColumn.Name = "Name";
            OrderItemNameColumn.HeaderText = "Name";
            OrderItemNameColumn.FillWeight = 50; // 50% of total width

            DataGridViewTextBoxColumn OrderItemQtyColumn = new DataGridViewTextBoxColumn();
            OrderItemQtyColumn.Name = "ReorderQty";
            OrderItemQtyColumn.HeaderText = "Order Amount";
            OrderItemQtyColumn.FillWeight = 30; // 30% of total width

            //Past Orders grid columns
            DataGridViewTextBoxColumn pastOrderIDColumn = new DataGridViewTextBoxColumn();
            pastOrderIDColumn.Name = "Id";
            pastOrderIDColumn.HeaderText = "Order ID";
            pastOrderIDColumn.FillWeight = 20; // 20% of total width

            DataGridViewTextBoxColumn pastOrderDateColumn = new DataGridViewTextBoxColumn();
            pastOrderDateColumn.Name = "Created";
            pastOrderDateColumn.HeaderText = "Date Submitted";
            pastOrderDateColumn.FillWeight = 40; // 40% of total width

            DataGridViewTextBoxColumn pastOrderStatusColumn = new DataGridViewTextBoxColumn();
            pastOrderStatusColumn.Name = "Status";
            pastOrderStatusColumn.HeaderText = "Status";
            pastOrderStatusColumn.FillWeight = 40; // 40% of total width

            // Add columns to grid
            ItemsGridView.Columns.Add(idColumn);
            ItemsGridView.Columns.Add(nameColumn);
            ItemsGridView.Columns.Add(qtyColumn);
            ItemsGridView.Columns.Add(catColumn);
            

            OrderItemsDataGrid.Columns.Add(orderItemIdColumn);
            OrderItemsDataGrid.Columns.Add(OrderItemNameColumn);
            OrderItemsDataGrid.Columns.Add(OrderItemQtyColumn);

            PastOrderDataGridView.Columns.Add(pastOrderIDColumn);
            PastOrderDataGridView.Columns.Add(pastOrderDateColumn);
            PastOrderDataGridView.Columns.Add(pastOrderStatusColumn);

        }

        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(NewCategoryTextBox.Text))
            {
                NewCategoryTextBox.Text = "Enter new category name";
                NewCategoryTextBox.ForeColor = Color.Gray;
            }

            // Disables placeholder ONLY when editing ItemName
            if (!isEditingItemName && string.IsNullOrWhiteSpace(ItemNameTextBox.Text))
            {
                ItemNameTextBox.Text = "Enter item name";
                ItemNameTextBox.ForeColor = Color.Gray;
            }
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
            AddNewCatCheckBox.Enabled = true;
            ItemDescriptionTextBox.Enabled = false;
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
            AddNewCatCheckBox.Enabled = true;
            ItemDescriptionTextBox.Enabled = true;
        }

        // Helper function to reload data from the DB after an edit/delete has been made
        private void ReloadDB()
        {
            itemsList = controller.LoadItems();
            DisplayItems(itemsList);
            SetPlaceholder();
        }

        // recursive helper function to continue checking for reorder items
        private async Task CheckReorders()
        {
            await Task.Delay(7000);
            
            pendingOrder = controller.ProcessLowStockReorders(itemsList, reorders);
            if (manualOrderItems != null && manualOrderItems.Count > 0)
            {
                foreach (Item item in manualOrderItems)
                {
                    pendingOrder.Add(item);
                }
            }
            if (pendingOrder.Count > 0 && PendingOrderListBox.Items.Count == 0)
            {
                String searchStr = "SELECT COUNT(\'id\') FROM reorders";
                SQLiteConnection conn = Database.GetConnection();
                SQLiteCommand cmd = new SQLiteCommand(searchStr, conn);
                int orderID;
                int.TryParse(cmd.ExecuteScalar().ToString(), out orderID);
                PendingOrderListBox.Items.Add("WIP Order ID: " + (1 + orderID));
            }
            CheckReorders();
        }

        // helper function to load all current categories on form load
        private void LoadCategories()
        {
            CategoryRepository repo = new CategoryRepository();
            categories = repo.GetAll();

            CategoryComboBox.DataSource = null;
            CategoryComboBox.DataSource = categories;
            CategoryComboBox.ValueMember = "Id";
            CategoryComboBox.DisplayMember = "Name";

            // Build category, essential for proper name lookup 
            categoryLookup = categories.ToDictionary(c => c.Id, c => c.Name);
        }


        // Helper function to load Orders on form load
        private void LoadOrders()
        {
            reorders = controller.LoadOrders();
            PastOrderDataGridView.Rows.Clear();
            foreach (Reorder order in reorders)
            {
                PastOrderDataGridView.Rows.Add(order.Id, order.CreatedAt, order.Status);
            }

        }

        // Form load events, all will happen before the form displays to the user
        private void MainForm_Load(object sender, EventArgs e)
        {
            ReloadDB();
            LoadCategories();
            LoadOrders();
            CheckReorders();
            ClearFieldsBtn_Click(sender, e);
            SetPlaceholder();
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
            using (SQLiteConnection conn = Database.GetConnection())
            {
                Random rand = new Random();

                foreach (Item item in itemsList)
                {
                    int num = rand.Next(100);
                    if (num >= 50)
                    {
                        int decrease = Math.Min(rand.Next(100), item.CurrentAmount);
                        string updateStr = "UPDATE items SET current_amount = @decrease WHERE id = @id";
                        using (SQLiteCommand cmd = new SQLiteCommand(updateStr, conn))
                        {
                            cmd.Parameters.AddWithValue("@decrease", decrease);
                            cmd.Parameters.AddWithValue("@id", item.Id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            LoadCategories();
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
            int reorderEnabled = 1;

            // add sample items if they dont already exist
            for (int i = 0; i < itemNames.Length; i++)
            {
                String selectCommand2 = "SELECT id FROM items WHERE name = \'" + itemNames[i] + "\'";
                SQLiteCommand selectCMD2 = new SQLiteCommand(selectCommand2, conn);
                SQLiteDataReader reader2 = selectCMD2.ExecuteReader();
                selectCMD2.Dispose();
                if (!reader2.HasRows)
                {

                    String insertCommand2 = "INSERT INTO items (category_id, name, description, current_amount, reorder_point, max_amount, reorder_enabled, created_at, updated_at) VALUES " +
                        "(\'" + itemCategoryID[i] + "\', " +
                        "\'" + itemNames[i] + "\', " +
                        "\'" + itemDescription[i] + "\', " +
                        "\'" + itemCurrAmt[i] + "\', " +
                        "\'" + itemReorderPoint[i] + "\', " +
                        "\'" + itemReorderAmt[i] + "\', " +
                        "\'" + reorderEnabled + "\', " +
                        "\'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\', " +
                        "\'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\')";
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
                int reorderEnabled;
                int id = selectedItem.Id;
                String name = ItemNameTextBox.Text;
                bool isValidCur = int.TryParse(CurrentQtyTextBox.Text.ToString(), out curAmt);
                bool isValidReorder = int.TryParse(ReorderPointTextBox.Text.ToString(), out reorderPt);
                bool isValidMax = int.TryParse(ReorderMaxTextBox.Text.ToString(), out maxAmt);
                String description = ItemDescriptionTextBox.Text;
                if (EnableReorderChkbx.Checked)
                {
                    reorderEnabled = 1;
                }
                else
                {
                    reorderEnabled = 0;
                }
                if (isValidCur && isValidMax && isValidReorder && name != String.Empty)
                {
                    String sql = "UPDATE items SET name = '" + name +
                        "', current_amount = '" + curAmt +
                        "', reorder_point = '" + reorderPt +
                        "', max_amount = '" + maxAmt +
                        "', reorder_enabled = '" + reorderEnabled +
                        "', description = '" + ItemDescriptionTextBox.Text +
                        "', updated_at = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                        "', category_id = '" + CategoryComboBox.SelectedValue +
                        "' WHERE id = '" + id + "'";
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
                int reorderEnabled;
                String name = ItemNameTextBox.Text;
                String description = ItemDescriptionTextBox.Text;
                bool isValidCur = int.TryParse(CurrentQtyTextBox.Text.ToString(), out curAmt);
                bool isValidReorder = int.TryParse(ReorderPointTextBox.Text.ToString(), out reorderPt);
                bool isValidMax = int.TryParse(ReorderMaxTextBox.Text.ToString(), out maxAmt);
                if (EnableReorderChkbx.Checked)
                {
                    reorderEnabled = 1;
                }
                else
                {
                    reorderEnabled = 0;
                }
                if (isValidCur && isValidMax && isValidReorder && name != String.Empty)
                {
                    String sql = "INSERT INTO items (category_id, name, description, current_amount, reorder_point, reorder_enabled, max_amount, created_at, updated_at) " +
                    "VALUES ('" + CategoryComboBox.SelectedValue +
                    "', '" + name +
                    "', '" + description +
                    "', '" + curAmt +
                    "', '" + reorderPt +
                    "', '" + reorderEnabled +
                    "', '" + maxAmt +
                    "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                    "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                    "');";
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
            CategoryComboBox.SelectedIndex = 0;
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

                if (selectedItem != null)
                {
                    // Only disable placeholder for THIS textbox
                    isEditingItemName = true;

                    ItemNameTextBox.Text = selectedItem.Name;
                    ItemNameTextBox.ForeColor = Color.Black;

                    CurrentQtyTextBox.Text = selectedItem.CurrentAmount.ToString();
                    ReorderPointTextBox.Text = selectedItem.ReorderPoint.ToString();
                    ReorderMaxTextBox.Text = selectedItem.MaxAmount.ToString();
                    ItemDescriptionTextBox.Text = selectedItem.Description;
                    CategoryComboBox.SelectedValue = selectedItem.CategoryId;
                    ItemDescriptionTextBox.Text = selectedItem.Description;

                    EnableProductInfoOptions();

                    ItemNameTextBox.Focus();
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
                    if (PendingOrderListBox.Items.Count == 0)
                    {
                        String searchStr = "SELECT COUNT(\'id\') FROM reorders";
                        SQLiteConnection conn = Database.GetConnection();
                        SQLiteCommand cmd = new SQLiteCommand(searchStr, conn);
                        int orderID;
                        int.TryParse(cmd.ExecuteScalar().ToString(), out orderID);
                        PendingOrderListBox.Items.Add("WIP Order ID: " + (1 + orderID));
                    }
                    if (pendingOrder == null)
                    {
                        pendingOrder = new List<Item> { };
                    }
                    pendingOrder.Add(copy);
                    if (manualOrderItems == null)
                    {
                        manualOrderItems = new List<Item> { };
                    }
                    manualOrderItems.Add(copy);
                    OrderItemsDataGrid.Rows.Clear();
                    foreach (Item item in pendingOrder)
                    {
                        OrderItemsDataGrid.Rows.Add(item.Id, item.Name, item.MaxAmount);
                    }
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
                manualOrderItems = null;
                OrderItemsDataGrid.Rows.Clear();
            }
            else
            {
                MessageBox.Show("You must select an order before you can delete it.", "Error - No selected order");
            }
        }

        // Edit the amount of an item to be ordered, from within a pending order
        private void EditOrderAmtBtn_Click(object sender, EventArgs e)
        {
            if (OrderItemsDataGrid.SelectedRows.Count == 1)
            {
                if (!orderSelection.Equals("") && !orderSelection.Equals("Past"))
                {
                    int qty;
                    bool validQty = int.TryParse(EditOrderAmtTextBox.Text.ToString(), out qty);
                    if (validQty)
                    {
                        var row = OrderItemsDataGrid.SelectedRows[0];
                        pendingOrder[row.Index].MaxAmount = qty;
                    }
                    OrderItemsDataGrid.Rows.Clear();
                    foreach (Item item in pendingOrder)
                    {
                        OrderItemsDataGrid.Rows.Add(item.Id, item.Name, item.MaxAmount);
                    }
                    EditOrderAmtBtn.Enabled = false;
                    EditOrderAmtTextBox.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You cannot change the quantity on a past order.", "Error - can't edit past order");
                }
            }
            else
            {
                MessageBox.Show("You must select an item before you can edit it's order quantity.", "Error - No selected item");
            }
        }

        private void DisplayItems(List<Item> items)
        {
            if (categoryLookup == null || categoryLookup.Count == 0)
            LoadCategories();

            ItemsGridView.Rows.Clear();

            foreach (var item in items)
            {
                // Retrieve the Category Name from lookup (Connecting on CategoryId)
                string categoryName = categoryLookup.ContainsKey(item.CategoryId)
                    ? categoryLookup[item.CategoryId]
                    : "Unknown";

                // Add the categoryName instead of CategoryId
                ItemsGridView.Rows.Add(
                    item.Id,
                    item.Name,
                    item.CurrentAmount,
                    categoryName       
                );
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
                        ItemDescriptionTextBox.Text = selectedItem.Description;
                        CategoryComboBox.SelectedValue = selectedItem.CategoryId;
                        EnableReorderChkbx.Checked = selectedItem.ReorderEnabled;
                        ItemDescriptionTextBox.Text = selectedItem.Description;
                    }
                }
            }
        }

        private void SubmitPendingOrderButton_Click(object sender, EventArgs e)
        {
            // Add all items into a single reorder
            Reorder reorder = new Reorder();
            foreach (Item item in pendingOrder)
            {
                reorder.Items.Add(new ReorderItem(item.Id, item.MaxAmount));
            }
            controller.GetInventoryManager().GetReorderRepository().Add(reorder);

            LoadOrders();
            DeletePendingOrderBtn_Click(sender, e);
        }

        private void PendingOrderListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PendingOrderListBox.SelectedIndex != -1)
            {
                orderSelection = "Pending";
                OrderItemsDataGrid.Rows.Clear();
                foreach (Item item in pendingOrder)
                {
                    OrderItemsDataGrid.Rows.Add(item.Id, item.Name, item.MaxAmount);
                }
            }
            else
            {
                MessageBox.Show("Error: no selected index");
            }
        }

        // Leave for future implementations of specified sorting (like on isolation on Category-specific sorts)
        //private void UpdateItemsDisplay()
        //{
        //    var items = controller.LoadItems();

        //    ItemsGridView.Rows.Clear();

        //    foreach (var item in items)
        //    {
        //        ItemsGridView.Rows.Add(item.Id, item.Name, item.CurrentAmount);
        //    }

        //    if (ItemsGridView.Rows.Count > 0)
        //        ItemsGridView.Rows[0].Selected = true;

        //    foreach (DataGridViewColumn column in ItemsGridView.Columns)
        //    {
        //        column.SortMode = DataGridViewColumnSortMode.Automatic;
        //    }
        //}

        private void OrderItemsDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (OrderItemsDataGrid.SelectedRows.Count > 0)
            {
                var row = OrderItemsDataGrid.SelectedRows[0];
                EditOrderAmtBtn.Enabled = true;
                EditOrderAmtTextBox.Enabled = true;
                EditOrderAmtTextBox.Text = row.Cells["ReorderQty"].Value.ToString();

            }
        }

        private void CurrentOrdersListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            int id = ((Reorder)e.ListItem).Id;

            DateTime created = ((Reorder)e.ListItem).CreatedAt;
            String status = ((Reorder)e.ListItem).Status;

            e.Value = "Order " + id + ": " + created + " --- " + status;
        }

        private void OrderRecievedBtn_Click(object sender, EventArgs e)
        {
            if (PastOrderDataGridView.SelectedRows.Count > 0)
            {
                var row = PastOrderDataGridView.SelectedRows[0];

                if (!row.Cells["Status"].Value.Equals("Complete"))
                {
                    int id;
                    int.TryParse(row.Cells["Id"].Value.ToString(), out id);
                    Reorder reorder = controller.GetInventoryManager().GetReorderRepository().GetById(id);
                    if (reorder != null)
                    {
                        foreach (ReorderItem reorderItem in reorder.Items)
                        {
                            Item item = itemsList.Find(x => x.Id == reorderItem.ItemId);
                            if (item != null)
                            {
                                item.AddStock(reorderItem.Quantity);
                                controller.GetInventoryManager().updateItem(item);
                            }
                        }
                        reorder.MarkComplete();
                        controller.GetInventoryManager().GetReorderRepository().Update(reorder);
                    }
                    LoadOrders();
                    ReloadDB();

                }
                else
                {
                    MessageBox.Show("You cannot recieve an order that's already been recieved.", "Error - order already complete");
                }
            }
            else
            {
                MessageBox.Show("You must select an order before you can recieve it.", "Error - no order selected");
            }
        }

        private void PastOrderDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (PastOrderDataGridView.SelectedRows.Count > 0)
            {
                EditOrderAmtBtn.Enabled = false;
                EditOrderAmtTextBox.Enabled = false;
                orderSelection = "Past";
                var row = PastOrderDataGridView.SelectedRows[0];
                int id;
                int.TryParse(row.Cells["Id"].Value.ToString(), out id);
                List<ReorderItem> items = controller.GetInventoryManager().GetReorderRepository().GetById(id).Items;
                OrderItemsDataGrid.Rows.Clear();
                foreach ( ReorderItem item in items )
                {
                    OrderItemsDataGrid.Rows.Add(item.ItemId, itemsList.Find(x => x.Id == item.ItemId).Name, item.Quantity);
                }
                if (!row.Cells["Status"].Value.Equals("Complete"))
                {
                    OrderRecievedBtn.Enabled = true;
                } else
                {
                    OrderRecievedBtn.Enabled = false;
                }
            }
        }
        private void SubmitNewCategoryBtn_Click(object sender, EventArgs e)
        {
            string newCategoryName = NewCategoryTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(newCategoryName))
            {
                MessageBox.Show("Please enter a category name.", "Invalid Input");
                return;
            }

            using (SQLiteConnection conn = Database.GetConnection())
            {
                string checkSql = "SELECT COUNT(*) FROM categories WHERE name = @name";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@name", newCategoryName);
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Category already exists.", "Duplicate Category");
                        return;
                    }
                }

                string insertSql = "INSERT INTO categories (name) VALUES (@name)";
                using (SQLiteCommand insertCmd = new SQLiteCommand(insertSql, conn))
                {
                    insertCmd.Parameters.AddWithValue("@name", newCategoryName);
                    insertCmd.ExecuteNonQuery();
                }
            }

            LoadCategories();

            if (!string.IsNullOrWhiteSpace(ItemNameTextBox.Text))
            {
                CategoryComboBox.SelectedIndex = CategoryComboBox.FindStringExact(newCategoryName);
            }

            AddNewCatCheckBox.Checked = false;

            MessageBox.Show($"Category '{newCategoryName}' added successfully!", "Success");
        }


        private void AddNewCategory_CheckChanged(object sender, EventArgs e)
        {
            if (AddNewCatCheckBox.Checked)
            {
                NewCategoryTextBox.Visible = true;
                SubmitNewCategoryBtn.Visible = true;
                NewCategoryNameLabel.Visible = true;

                CategoryComboBox.Enabled = false;
            }
            else
            {
                NewCategoryTextBox.Visible = false;
                SubmitNewCategoryBtn.Visible = false;
                NewCategoryNameLabel.Visible = false;

                CategoryComboBox.Enabled = true;

                NewCategoryTextBox.Text = String.Empty;
            }
            SetPlaceholder();
        }

        // Placeholder text logic for textboxes
        private void ItemNameTextBox_Enter(object sender, EventArgs e)
        {
            if (isEditingItemName)
                return;

            if (ItemNameTextBox.ForeColor == Color.Gray)
            {
                ItemNameTextBox.Text = "";
                ItemNameTextBox.ForeColor = Color.Black;
            }
        }

        private void ItemNameTextBox_Leave(object sender, EventArgs e)
        {
            if (!isEditingItemName)
                SetPlaceholder();
        }


        private void NewCategoryTextBox_Enter(object sender, EventArgs e)
        {
            {
                if (NewCategoryTextBox.ForeColor == Color.Gray)
                {
                    NewCategoryTextBox.Text = "";
                    NewCategoryTextBox.ForeColor = Color.Black;
                }
            }
        }

        private void NewCategoryTextBox_Leave(object sender, EventArgs e)
        {
            SetPlaceholder();
        }
    }
}

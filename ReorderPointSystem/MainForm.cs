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

        private List<Item> itemsList = new List<Item>();
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
            catColumn.DataPropertyName = "CategoryID";
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

        // Helper function to reload items
        private void LoadItems()
        {
            itemsList.Clear();
            itemsList.AddRange(controller.LoadItems());
            DisplayItems(itemsList);
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

        // Helper function to load all current categories on form load
        private void LoadCategories()
        {
            CategoryRepository repo = new CategoryRepository();
            categories = repo.GetAll();

            CategoryComboBox.DataSource = null;
            CategoryComboBox.DataSource = categories;
            CategoryComboBox.ValueMember = "Id";
            CategoryComboBox.DisplayMember = "Name";

            categoryLookup = categories.ToDictionary(c => c.Id, c => c.Name);

            DeleteCatCheckBox.Checked = false;
            AddNewCatCheckBox.Checked = false;

            SubmitNewCategoryBtn.Visible = false;
            SubmitNewCategoryBtn.Text = "Submit New Category";

            NewCategoryTextBox.Visible = false;
            NewCategoryTextBox.Text = string.Empty;
            NewCategoryNameLabel.Visible = false;

            CategoryComboBox.Enabled = true;
            CategoryComboBox.SelectedIndex = 0;
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

        private void DisplayItems(List<Item> items)
        {
            if (categoryLookup == null || categoryLookup.Count == 0)
                LoadCategories();

            ItemsGridView.Rows.Clear();
            ItemsGridView.SuspendLayout();

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

            ItemsGridView.ResumeLayout();

            // Select the first row if available
            if (ItemsGridView.Rows.Count > 0)
            {
                ItemsGridView.CurrentCell = ItemsGridView.Rows[0].Cells[0];
                int id = (int)ItemsGridView.Rows[0].Cells["Id"].Value;
                selectedItem = items.FirstOrDefault(x => x.Id == id);
            }
        }

        // DoubleBuffer
        private void EnableDoubleBuffering(DataGridView dataGridView)
        {
            typeof(DataGridView)
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(dataGridView, true, null);

            dataGridView.EnableHeadersVisualStyles = false;
        }

        /*----------------------------/
        ******  Event Handlers  ******
        /--------------------------*/

        /***** Form Events *****/
        // Form load events, all will happen before the form displays to the user
        private void MainForm_Load(object sender, EventArgs e)
        {
            EnableDoubleBuffering(ItemsGridView);
            EnableDoubleBuffering(PastOrderDataGridView);
            EnableDoubleBuffering(OrderItemsDataGrid);

            LoadItems();
            LoadCategories();
            LoadOrders();
            _ = CheckReorders();
            ClearFieldsBtn_Click(sender, e);
            //this.BeginInvoke(new Action(() =>
            //{
            //    ItemNameTextBox.Focus();
            //    ItemNameTextBox.Select();
            //}));

        }

        /***** Simulation Mode Events *****/

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
            Random rand = new Random();
            foreach (Item item in itemsList)
            {
                int num = rand.Next(100);
                if (num >= 50)
                {
                    int decrease = Math.Min(rand.Next(100), item.CurrentAmount);
                    if (decrease > 0)
                    {
                        item.RemoveStock(decrease);
                        controller.GetInventoryManager().GetItemRepository().Update(item);
                    }
                }
            }

            LoadCategories();
            LoadItems();
        }


        // Insert dummy records into the DB for testing purposes
        private void AddTestDataBtn_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = Database.GetConnection())
            {
                string[] categoryNames =
                {
            "Produce", "Office-Supplies", "Home-Goods",
            "Raw-Materials", "Electronics", "Groceries"
        };

                // Ensure each category exists in DB
                foreach (string cat in categoryNames)
                {
                    string checkSql = "SELECT id FROM categories WHERE name = @name";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@name", cat);
                        var result = checkCmd.ExecuteScalar();

                        if (result == null)
                        {
                            string insertSql = "INSERT INTO categories (name) VALUES (@name)";
                            using (SQLiteCommand insertCmd = new SQLiteCommand(insertSql, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@name", cat);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                Dictionary<string, int> categoryLookup = new Dictionary<string, int>();

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT id, name FROM categories", conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categoryLookup[reader.GetString(1)] = reader.GetInt32(0);
                    }
                }

                string[] itemNames =
                {
            "Lettuce", "Staples", "Curtains", "Plywood", "GPU",
            "Cheerios", "Cucumbers", "Pencils", "Paper", "Linseed-oil"
        };

                string[] itemCategories =
                {
            "Produce", "Office-Supplies", "Home-Goods", "Raw-Materials", "Electronics",
            "Groceries", "Produce", "Office-Supplies", "Office-Supplies", "Raw-Materials"
        };

                string[] itemDescription = { "Non-pesticide, Iceberg", "", "Silk, 20 in. x 48 in.", "", "AMD Threadripper 7995WX", "", "", "Bic, Mechanical 7 mm.", "", "Boiled 1 gal." };
                int[] itemCurrAmt = { 10, 3000, 5, 100, 5, 27, 95, 200, 4570, 46 };
                int[] itemReorderPoint = { 5, 1000, 2, 50, 3, 20, 50, 120, 2000, 25 };
                int[] itemReorderAmt = { 20, 4000, 8, 200, 12, 80, 200, 480, 8000, 100 };

                int reorderEnabled = 1;

                for (int i = 0; i < itemNames.Length; i++)
                {
                    // Building categoryId dynamically from lookup
                    int categoryId = categoryLookup[itemCategories[i]];

                    string checkSql = "SELECT id FROM items WHERE name = @name";
                    using (SQLiteCommand checkCmd = new SQLiteCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@name", itemNames[i]);
                        var exists = checkCmd.ExecuteScalar();

                        if (exists == null)
                        {
                            string insertSql =
                                @"INSERT INTO items 
                          (category_id, name, description, current_amount, reorder_point, max_amount, reorder_enabled, created_at, updated_at)
                          VALUES 
                          (@catId, @name, @desc, @cur, @reorderPt, @maxAmt, @enabled, DATETIME('now'), DATETIME('now'))";

                            using (SQLiteCommand insertCmd = new SQLiteCommand(insertSql, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@catId", categoryId);
                                insertCmd.Parameters.AddWithValue("@name", itemNames[i]);
                                insertCmd.Parameters.AddWithValue("@desc", itemDescription[i]);
                                insertCmd.Parameters.AddWithValue("@cur", itemCurrAmt[i]);
                                insertCmd.Parameters.AddWithValue("@reorderPt", itemReorderPoint[i]);
                                insertCmd.Parameters.AddWithValue("@maxAmt", itemReorderAmt[i]);
                                insertCmd.Parameters.AddWithValue("@enabled", reorderEnabled);

                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }

            ShowSuccess("Test data inserted successfully!");
            LoadCategories();
            LoadItems();
        }

        /*****  Item Info Panel Events  *****/

        // IF the item displayed is already in the DB, update the record for said item
        // ELSE create a new item in the BD with the properties set by the user
        private void SubmitItemBtn_Click(object sender, EventArgs e)
        {
            int id = selectedItem != null ? selectedItem.Id : -1;
            String name = ItemNameTextBox.Text;
            String description = ItemDescriptionTextBox.Text;
            int curAmt = Validator.SanitizeInt(CurrentQtyTextBox.Text.ToString());
            int curCat = Validator.SanitizeInt(CategoryComboBox.SelectedValue?.ToString());
            int reorderPt = Validator.SanitizeInt(ReorderPointTextBox.Text.ToString());
            int maxAmt = Validator.SanitizeInt(ReorderMaxTextBox.Text.ToString());
            bool reorderEnabled = EnableReorderChkbx.Checked;

            // Validate inputs
            if (!Validator.IsValidString(name))
            {
                ShowError("Please ensure the name text field contains valid characters.");
                ItemNameTextBox.Focus();
                ItemNameTextBox.SelectAll();
                return;
            }
            else if (id > 0 && !Validator.IsValidInt(id))
            {
                ShowError("Internal error regarding item id");
                return;
            }
            else if (!string.IsNullOrEmpty(description) && !Validator.IsValidString(description))
            {
                ShowError("Please ensure the description text field contains valid characters.");
                return;
            }
            else if (!Validator.IsValidInt(curAmt))
            {
                ShowError("Please ensure the current amount field contains a valid number.");
                CurrentQtyTextBox.Focus();
                CurrentQtyTextBox.SelectAll();
                return;
            }
            else if (!Validator.IsValidInt(curCat))
            {
                ShowError("Please ensure a valid category is selected.");
                return;
            }
            else if (!Validator.IsValidInt(reorderPt))
            {
                ShowError("Please ensure the reorder point field contains a valid number.");
                ReorderPointTextBox.Focus();
                ReorderPointTextBox.SelectAll();
                return;
            }
            else if (!Validator.IsValidInt(maxAmt))
            {
                ShowError("Please ensure the max amount field contains a valid number.");
                ReorderMaxTextBox.Focus();
                ReorderMaxTextBox.SelectAll();
                return;
            }

            // All validations passed, proceed to add/update item
            Item item = new Item()
            {
                CategoryId = curCat,
                Name = name,
                Description = description,
                CurrentAmount = curAmt,
                ReorderPoint = reorderPt,
                MaxAmount = maxAmt,
                ReorderEnabled = reorderEnabled
            };

            if (id.Equals(-1)) // New item
            {
                var result = controller.GetInventoryManager().addItem(item);
                if (result != null)
                {
                    ShowSuccess("Item added successfully");
                    LoadItems();
                }
                else
                {
                    ShowError("Internal error adding item");
                }
            }
            else // Update existing item
            {
                item.Id = id;
                var result = controller.GetInventoryManager().updateItem(item);
                if (result)
                {
                    ShowSuccess("Item updated successfully");
                    LoadItems();
                }
                else
                {
                    ShowError("Internal error updating item");
                }
            }
        }

        // Clear the item information in the item info group box. If the text boxes are disabled, also enable them
        private void ClearFieldsBtn_Click(object sender, EventArgs e)
        {
            LoadCategories();

            if (!ItemInfoGroupBox.Enabled)
                ItemInfoGroupBox.Enabled = true;

            isEditingItemName = false;

            CategoryComboBox.SelectedIndex = 0;
            ItemNameTextBox.Text = string.Empty;
            EnableReorderChkbx.Checked = false;
            CurrentQtyTextBox.Text = string.Empty;
            ReorderPointTextBox.Text = string.Empty;
            ReorderMaxTextBox.Text = string.Empty;
            ItemDescriptionTextBox.Text = string.Empty;
            selectedItem = null;
            EnableProductInfoOptions();

            DeleteItemBtn.Enabled = false;

            ItemNameTextBox.Focus();
        }


        // Remove the selected item from the Items DB, If an item is selected
        private void DeleteItemBtn_Click(object sender, EventArgs e)
        {
            if (selectedItem == null || string.IsNullOrWhiteSpace(ItemNameTextBox.Text))
            {
                MessageBox.Show("Must select a valid item to delete first.", "Error - No valid item");
                return;
            }

            var confirmResult = MessageBox.Show($"Are you sure you want to delete '{selectedItem.Name}'?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                controller.GetInventoryManager().deleteItem(selectedItem.Id);
                ShowSuccess("Item deleted successfully");

                // Clear form and reload
                ClearFieldsBtn_Click(sender, e);
                LoadCategories();
                LoadItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting item: {ex.Message}", "Error");
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
                    isEditingItemName = true;

                    ItemNameTextBox.Text = selectedItem.Name;

                    CurrentQtyTextBox.Text = selectedItem.CurrentAmount.ToString();
                    ReorderPointTextBox.Text = selectedItem.ReorderPoint.ToString();
                    ReorderMaxTextBox.Text = selectedItem.MaxAmount.ToString();

                    if (!string.IsNullOrWhiteSpace(selectedItem.Description))
                    {
                        ItemDescriptionTextBox.Text = selectedItem.Description;
                    }
                    else
                    {
                        ItemDescriptionTextBox.Text = string.Empty;
                    }

                    LoadCategories();

                    CategoryComboBox.SelectedValue = selectedItem.CategoryId;

                    EnableProductInfoOptions();

                    ItemNameTextBox.Focus();
                }
            }
            else
            {
                ShowError("You must select an item before you can edit it.");
            }
        }



        private void SubmitNewCategoryBtn_Click(object sender, EventArgs e)
        {
            if (SubmitNewCategoryBtn.Text == "Delete Category")
            {
                if (CategoryComboBox.SelectedItem == null)
                {
                    ShowError("No category selected to delete.");
                    return;
                }

                string selectedCategoryName = CategoryComboBox.Text;
                int selectedCategoryId = (int)CategoryComboBox.SelectedValue;

                if (selectedCategoryName == "General")
                {
                    ShowError("The 'General' category cannot be deleted.");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete the category '{selectedCategoryName}'?",
                    "Are you sure?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                    return;

                try
                {
                    bool deleteSuccess = controller.GetInventoryManager().GetCategoryRepository().Delete(selectedCategoryId);
                    if (!deleteSuccess)
                    {
                        ShowError("Category not deleted; possible invalid category id.");
                        return;
                    }
                    LoadCategories();
                    ShowSuccess($"Category '{selectedCategoryName}' deleted successfully.");
                }
                catch (InvalidOperationException ex)
                {
                    ShowError("Cannot delete category with associated items. Please reassign or delete those items first.");
                    return;
                }
                catch (Exception ex)
                {
                    ShowError("An internal error has occurred: " + ex.Message);
                    return;
                }
            }
            else
            {
                string newCategoryName = NewCategoryTextBox.Text.Trim();

                // Validate
                if (!Validator.IsValidString(newCategoryName))
                {
                    ShowError("Please enter a valid category name.");
                    return;
                }

                // Add category
                var addedCategory = controller.GetInventoryManager().GetCategoryRepository().Add(new Category { Name = newCategoryName });
                if (addedCategory == null)
                {
                    ShowError("Category already exists.");
                    return;
                }

                LoadCategories();
                MessageBox.Show($"Category '{newCategoryName}' added successfully!");

                int newIndex = CategoryComboBox.FindStringExact(newCategoryName);
                if (newIndex >= 0)
                    CategoryComboBox.SelectedIndex = newIndex;

                AddNewCatCheckBox.Checked = false;
            }
        }

        private void AddNewCategory_CheckChanged(object sender, EventArgs e)
        {
            bool isChecked = AddNewCatCheckBox.Checked;

            NewCategoryTextBox.Visible = isChecked;
            NewCategoryNameLabel.Visible = isChecked;

            CategoryComboBox.Enabled = !isChecked;

            SubmitNewCategoryBtn.Visible = isChecked || DeleteCatCheckBox.Checked;
            SubmitNewCategoryBtn.Text = isChecked ? "Submit New Category" :
                                          (DeleteCatCheckBox.Checked ? "Delete Category" : "Submit New Category");

            if (!isChecked)
            {
                NewCategoryTextBox.Text = string.Empty;
            }
        }


        private void NewCategoryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SubmitNewCategoryBtn_Click(sender, e);

                e.SuppressKeyPress = true;
            }
        }

        private void DeleteCatCheckBox_CheckChanged(object sender, EventArgs e)
        {
            SubmitNewCategoryBtn.Visible = AddNewCatCheckBox.Checked || DeleteCatCheckBox.Checked;

            if (DeleteCatCheckBox.Checked)
            {
                SubmitNewCategoryBtn.Text = "Delete Category";
            }
            else
            {
                SubmitNewCategoryBtn.Text = "Submit New Category";

                AddNewCategory_CheckChanged(AddNewCatCheckBox, EventArgs.Empty);
            }
        }

        private void ReorderPointTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /*****  Items List Panel Events  *****/

        // Handling selection change in the ItemsGridView to display item details
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

            DeleteCatCheckBox.Checked = false;
        }

        // Filter the items listed in the ItemsListBox box based on the text in the ItemSearchTextBox
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            // Fetch all items
            if (string.IsNullOrEmpty(ItemSearchTextBox.Text))
            {
                LoadItems();
                return;
            }

            // Search query
            List<Item>? searchResults = controller.SearchItems(ItemSearchTextBox.Text);
            if (searchResults == null)
            {
                ShowError("Invalid search input. Ensure it contains valid characters and is between 1 and 50 characters");
            }
            else if (searchResults.Count == 0)
            {
                ShowInfo("No results found");
            }
            else
            {
                DisplayItems(searchResults);
            }
        }

        // On pressing "Enter" in the search box, trigger the search button click event
        private void ItemSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBtn_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Add the highlighted item to a pending order. If no pending orders exist, also create a new pending order
        private void AddToOrderBtn_Click(object sender, EventArgs e)
        {
            if (ItemsGridView.CurrentRow != null || selectedItem != null)
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
                ShowError("You must select an item.");

            }
        }


        /*****  Orders Panel Events  *****/

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
                ShowError("Please select an order to delete.");
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
                    ShowError("You cannot change the quantity on a past order.");
                }
            }
            else
            {
                ShowError("You must select an item before you can edit it's order quantity.");
            }
        }

        // Submit the pending order to the Reorders DB
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

        // When a pending order is selected, display its items in the OrderItemsDataGrid
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
                ShowError("You must select a pending order before you can view its items.");
            }
        }

        // When an item in the OrderItemsDataGrid is selected, enable editing controls
        private void OrderItemsDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (OrderItemsDataGrid.SelectedRows.Count > 0)
            {
                var row = OrderItemsDataGrid.SelectedRows[0];
                if (orderSelection.Equals("Pending"))
                {
                    EditOrderAmtBtn.Enabled = true;
                    EditOrderAmtTextBox.Enabled = true;
                }
                EditOrderAmtTextBox.Text = row.Cells["ReorderQty"].Value.ToString();

            }
        }

        // Format the display of current orders in the CurrentOrdersListBox
        private void CurrentOrdersListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            int id = ((Reorder)e.ListItem).Id;

            DateTime created = ((Reorder)e.ListItem).CreatedAt;
            String status = ((Reorder)e.ListItem).Status;

            e.Value = "Order " + id + ": " + created + " --- " + status;
        }

        // When an order is recieved, update each item's stock and mark the order as complete
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
                    LoadItems();

                }
                else
                {
                    ShowError("You cannot receive an order that's already been received.");
                }
            }
            else
            {
                ShowError("You must select an order before you can receive it.");
            }
        }

        // When a past order is selected, display its items in the OrderItemsDataGrid
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
                foreach (ReorderItem item in items)
                {
                    OrderItemsDataGrid.Rows.Add(item.ItemId, item.Name, item.Quantity);
                }
                if (!row.Cells["Status"].Value.Equals("Complete"))
                {
                    OrderRecievedBtn.Enabled = true;
                }
                else
                {
                    OrderRecievedBtn.Enabled = false;
                }
            }
        }

        // Utility functions
        private void ShowError(string message)
        {
            MessageBox.Show(
                message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private void ShowInfo(string message)
        {
            MessageBox.Show(
                message,
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(
                message,
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void SaveCsvToFile(string csvContent, string defaultFileName)
        {
            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save CSV Export";
            sfd.Filter = "CSV Files (*.csv)|*.csv";
            sfd.FileName = defaultFileName;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, csvContent);
                MessageBox.Show("Export complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnExportItems_Click(object sender, EventArgs e)
        {
            var repo = new ItemRepository();
            var items = repo.GetAll();

            string csv = CSVExport.ExportItems(items);
            SaveCsvToFile(csv, "items_export.csv");
        }

        private void BtnExportCategories_Click(object sender, EventArgs e)
        {
            var repo = new CategoryRepository();
            var categories = repo.GetAll();

            string csv = CSVExport.ExportCategories(categories);
            SaveCsvToFile(csv, "categories_export.csv");
        }

        private void BtnExportReorders_Click(object sender, EventArgs e)
        {
            var repo = new ReorderRepository();
            var reorders = repo.GetAll();

            string csv = CSVExport.ExportReorders(reorders);
            SaveCsvToFile(csv, "reorders_export.csv");
        }

        private void BtnExportLogs_Click(object sender, EventArgs e)
        {
            var repo = new InventoryLogRepository();
            var logs = repo.GetAll();

            string csv = CSVExport.ExportInventoryLogs(logs);
            SaveCsvToFile(csv, "inventory_logs_export.csv");
        }
    }
}


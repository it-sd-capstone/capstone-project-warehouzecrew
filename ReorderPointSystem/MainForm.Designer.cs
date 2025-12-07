namespace ReorderPointSystem
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EnableTestModeChkbx = new CheckBox();
            SimDayBtn = new Button();
            AddTestDataBtn = new Button();
            ItemInfoGroupBox = new GroupBox();
            DeleteCatLabel = new Label();
            DeleteCatCheckBox = new CheckBox();
            NewCategoryNameLabel = new Label();
            AddNewCatLabel = new Label();
            AddNewCatCheckBox = new CheckBox();
            SubmitNewCategoryBtn = new Button();
            EditItemBtn = new Button();
            NewCategoryTextBox = new TextBox();
            CategoryComboBoxLabel = new Label();
            CategoryComboBox = new ComboBox();
            EnableReorderLabel = new Label();
            EnableReorderChkbx = new CheckBox();
            DeleteItemBtn = new Button();
            ClearFieldsBtn = new Button();
            SubmitItemBtn = new Button();
            ItemDescriptionGroupBox = new GroupBox();
            ItemDescriptionTextBox = new TextBox();
            ReorderMaxTextBox = new TextBox();
            ReorderPointTextBox = new TextBox();
            CurrentQtyTextBox = new TextBox();
            MaxAmtLabel = new Label();
            ReorderPointLabel = new Label();
            CurrentAmountLabel = new Label();
            ItemNameTextBox = new TextBox();
            ItemNameLabel = new Label();
            ItemsListGroupBox = new GroupBox();
            ItemsGridView = new DataGridView();
            AddToOrderBtn = new Button();
            ItemSearchTextBox = new TextBox();
            SearchBtn = new Button();
            PendingOrdersGroupBox = new GroupBox();
            SubmitPendingOrderButton = new Button();
            DeletePendingOrderBtn = new Button();
            PendingOrderListBox = new ListBox();
            CurrentOrdersGroupBox = new GroupBox();
            PastOrderDataGridView = new DataGridView();
            OrderItemsGroupBox = new GroupBox();
            OrderItemsDataGrid = new DataGridView();
            EditOrderAmtTextBox = new TextBox();
            EditOrderAmtBtn = new Button();
            OrderRecievedBtn = new Button();
            BtnExportItems = new Button();
            BtnExportCategories = new Button();
            BtnExportReorders = new Button();
            BtnExportLogs = new Button();
            ItemInfoGroupBox.SuspendLayout();
            ItemDescriptionGroupBox.SuspendLayout();
            ItemsListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ItemsGridView).BeginInit();
            PendingOrdersGroupBox.SuspendLayout();
            CurrentOrdersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PastOrderDataGridView).BeginInit();
            OrderItemsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OrderItemsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // EnableTestModeChkbx
            // 
            EnableTestModeChkbx.AutoSize = true;
            EnableTestModeChkbx.Location = new Point(33, 1551);
            EnableTestModeChkbx.Margin = new Padding(6, 6, 6, 6);
            EnableTestModeChkbx.Name = "EnableTestModeChkbx";
            EnableTestModeChkbx.Size = new Size(319, 36);
            EnableTestModeChkbx.TabIndex = 0;
            EnableTestModeChkbx.Text = "Enable Simulation Mode?";
            EnableTestModeChkbx.UseVisualStyleBackColor = true;
            EnableTestModeChkbx.CheckedChanged += EnableTestModeChkbx_CheckedChanged;
            // 
            // SimDayBtn
            // 
            SimDayBtn.Location = new Point(368, 1542);
            SimDayBtn.Margin = new Padding(6, 6, 6, 6);
            SimDayBtn.Name = "SimDayBtn";
            SimDayBtn.Size = new Size(176, 49);
            SimDayBtn.TabIndex = 0;
            SimDayBtn.Text = "Simulate Day";
            SimDayBtn.UseVisualStyleBackColor = true;
            SimDayBtn.Visible = false;
            SimDayBtn.Click += SimDayBtn_Click;
            // 
            // AddTestDataBtn
            // 
            AddTestDataBtn.Location = new Point(574, 1541);
            AddTestDataBtn.Margin = new Padding(6, 6, 6, 6);
            AddTestDataBtn.Name = "AddTestDataBtn";
            AddTestDataBtn.Size = new Size(167, 49);
            AddTestDataBtn.TabIndex = 0;
            AddTestDataBtn.Text = "Add Test Data";
            AddTestDataBtn.UseVisualStyleBackColor = true;
            AddTestDataBtn.Visible = false;
            AddTestDataBtn.Click += AddTestDataBtn_Click;
            // 
            // ItemInfoGroupBox
            // 
            ItemInfoGroupBox.Controls.Add(DeleteCatLabel);
            ItemInfoGroupBox.Controls.Add(DeleteCatCheckBox);
            ItemInfoGroupBox.Controls.Add(NewCategoryNameLabel);
            ItemInfoGroupBox.Controls.Add(AddNewCatLabel);
            ItemInfoGroupBox.Controls.Add(AddNewCatCheckBox);
            ItemInfoGroupBox.Controls.Add(SubmitNewCategoryBtn);
            ItemInfoGroupBox.Controls.Add(EditItemBtn);
            ItemInfoGroupBox.Controls.Add(NewCategoryTextBox);
            ItemInfoGroupBox.Controls.Add(CategoryComboBoxLabel);
            ItemInfoGroupBox.Controls.Add(CategoryComboBox);
            ItemInfoGroupBox.Controls.Add(EnableReorderLabel);
            ItemInfoGroupBox.Controls.Add(EnableReorderChkbx);
            ItemInfoGroupBox.Controls.Add(DeleteItemBtn);
            ItemInfoGroupBox.Controls.Add(ClearFieldsBtn);
            ItemInfoGroupBox.Controls.Add(SubmitItemBtn);
            ItemInfoGroupBox.Controls.Add(ItemDescriptionGroupBox);
            ItemInfoGroupBox.Controls.Add(ReorderMaxTextBox);
            ItemInfoGroupBox.Controls.Add(ReorderPointTextBox);
            ItemInfoGroupBox.Controls.Add(CurrentQtyTextBox);
            ItemInfoGroupBox.Controls.Add(MaxAmtLabel);
            ItemInfoGroupBox.Controls.Add(ReorderPointLabel);
            ItemInfoGroupBox.Controls.Add(CurrentAmountLabel);
            ItemInfoGroupBox.Controls.Add(ItemNameTextBox);
            ItemInfoGroupBox.Controls.Add(ItemNameLabel);
            ItemInfoGroupBox.Location = new Point(22, 26);
            ItemInfoGroupBox.Margin = new Padding(6, 6, 6, 6);
            ItemInfoGroupBox.Name = "ItemInfoGroupBox";
            ItemInfoGroupBox.Padding = new Padding(6, 6, 6, 6);
            ItemInfoGroupBox.Size = new Size(1515, 591);
            ItemInfoGroupBox.TabIndex = 0;
            ItemInfoGroupBox.TabStop = false;
            ItemInfoGroupBox.Text = "Item Info";
            // 
            // DeleteCatLabel
            // 
            DeleteCatLabel.AutoSize = true;
            DeleteCatLabel.Location = new Point(1005, 181);
            DeleteCatLabel.Margin = new Padding(6, 0, 6, 0);
            DeleteCatLabel.Name = "DeleteCatLabel";
            DeleteCatLabel.Size = new Size(183, 32);
            DeleteCatLabel.TabIndex = 16;
            DeleteCatLabel.Text = "Delete category";
            // 
            // DeleteCatCheckBox
            // 
            DeleteCatCheckBox.AutoSize = true;
            DeleteCatCheckBox.Location = new Point(966, 181);
            DeleteCatCheckBox.Margin = new Padding(6, 6, 6, 6);
            DeleteCatCheckBox.Name = "DeleteCatCheckBox";
            DeleteCatCheckBox.Size = new Size(28, 27);
            DeleteCatCheckBox.TabIndex = 15;
            DeleteCatCheckBox.UseVisualStyleBackColor = true;
            DeleteCatCheckBox.CheckedChanged += DeleteCatCheckBox_CheckChanged;
            // 
            // NewCategoryNameLabel
            // 
            NewCategoryNameLabel.AutoSize = true;
            NewCategoryNameLabel.Location = new Point(13, 254);
            NewCategoryNameLabel.Margin = new Padding(6, 0, 6, 0);
            NewCategoryNameLabel.Name = "NewCategoryNameLabel";
            NewCategoryNameLabel.Size = new Size(186, 32);
            NewCategoryNameLabel.TabIndex = 0;
            NewCategoryNameLabel.Text = "Category Name:";
            NewCategoryNameLabel.Visible = false;
            // 
            // AddNewCatLabel
            // 
            AddNewCatLabel.AutoSize = true;
            AddNewCatLabel.Location = new Point(804, 181);
            AddNewCatLabel.Margin = new Padding(6, 0, 6, 0);
            AddNewCatLabel.Name = "AddNewCatLabel";
            AddNewCatLabel.Size = new Size(156, 32);
            AddNewCatLabel.TabIndex = 0;
            AddNewCatLabel.Text = "Add category";
            // 
            // AddNewCatCheckBox
            // 
            AddNewCatCheckBox.AutoSize = true;
            AddNewCatCheckBox.Location = new Point(765, 181);
            AddNewCatCheckBox.Margin = new Padding(6, 6, 6, 6);
            AddNewCatCheckBox.Name = "AddNewCatCheckBox";
            AddNewCatCheckBox.Size = new Size(28, 27);
            AddNewCatCheckBox.TabIndex = 7;
            AddNewCatCheckBox.UseVisualStyleBackColor = true;
            AddNewCatCheckBox.CheckedChanged += AddNewCategory_CheckChanged;
            // 
            // SubmitNewCategoryBtn
            // 
            SubmitNewCategoryBtn.Location = new Point(765, 235);
            SubmitNewCategoryBtn.Margin = new Padding(6, 6, 6, 6);
            SubmitNewCategoryBtn.Name = "SubmitNewCategoryBtn";
            SubmitNewCategoryBtn.Size = new Size(260, 62);
            SubmitNewCategoryBtn.TabIndex = 9;
            SubmitNewCategoryBtn.Text = "Submit New Category";
            SubmitNewCategoryBtn.UseVisualStyleBackColor = true;
            SubmitNewCategoryBtn.Visible = false;
            SubmitNewCategoryBtn.Click += SubmitNewCategoryBtn_Click;
            // 
            // EditItemBtn
            // 
            EditItemBtn.Location = new Point(1283, 254);
            EditItemBtn.Margin = new Padding(6, 6, 6, 6);
            EditItemBtn.Name = "EditItemBtn";
            EditItemBtn.Size = new Size(212, 98);
            EditItemBtn.TabIndex = 12;
            EditItemBtn.Text = "Edit Item";
            EditItemBtn.UseVisualStyleBackColor = true;
            EditItemBtn.Click += EditItemBtn_Click;
            // 
            // NewCategoryTextBox
            // 
            NewCategoryTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NewCategoryTextBox.Location = new Point(197, 235);
            NewCategoryTextBox.Margin = new Padding(6, 6, 6, 6);
            NewCategoryTextBox.Name = "NewCategoryTextBox";
            NewCategoryTextBox.PlaceholderText = "Enter new category name";
            NewCategoryTextBox.Size = new Size(522, 50);
            NewCategoryTextBox.TabIndex = 8;
            NewCategoryTextBox.Visible = false;
            NewCategoryTextBox.KeyDown += NewCategoryTextBox_KeyDown;
            // 
            // CategoryComboBoxLabel
            // 
            CategoryComboBoxLabel.AutoSize = true;
            CategoryComboBoxLabel.Location = new Point(63, 164);
            CategoryComboBoxLabel.Margin = new Padding(6, 0, 6, 0);
            CategoryComboBoxLabel.Name = "CategoryComboBoxLabel";
            CategoryComboBoxLabel.Size = new Size(132, 32);
            CategoryComboBoxLabel.TabIndex = 0;
            CategoryComboBoxLabel.Text = "Categories:";
            // 
            // CategoryComboBox
            // 
            CategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CategoryComboBox.FormattingEnabled = true;
            CategoryComboBox.Location = new Point(197, 158);
            CategoryComboBox.Margin = new Padding(6, 6, 6, 6);
            CategoryComboBox.Name = "CategoryComboBox";
            CategoryComboBox.Size = new Size(522, 40);
            CategoryComboBox.TabIndex = 5;
            // 
            // EnableReorderLabel
            // 
            EnableReorderLabel.AutoSize = true;
            EnableReorderLabel.Location = new Point(804, 137);
            EnableReorderLabel.Margin = new Padding(6, 0, 6, 0);
            EnableReorderLabel.Name = "EnableReorderLabel";
            EnableReorderLabel.Size = new Size(290, 32);
            EnableReorderLabel.TabIndex = 0;
            EnableReorderLabel.Text = "Disable automatic reorder";
            // 
            // EnableReorderChkbx
            // 
            EnableReorderChkbx.AutoSize = true;
            EnableReorderChkbx.Location = new Point(765, 139);
            EnableReorderChkbx.Margin = new Padding(6, 6, 6, 6);
            EnableReorderChkbx.Name = "EnableReorderChkbx";
            EnableReorderChkbx.Size = new Size(28, 27);
            EnableReorderChkbx.TabIndex = 6;
            EnableReorderChkbx.UseVisualStyleBackColor = true;
            // 
            // DeleteItemBtn
            // 
            DeleteItemBtn.Location = new Point(1283, 476);
            DeleteItemBtn.Margin = new Padding(6, 6, 6, 6);
            DeleteItemBtn.Name = "DeleteItemBtn";
            DeleteItemBtn.Size = new Size(212, 98);
            DeleteItemBtn.TabIndex = 14;
            DeleteItemBtn.Text = "Delete Item";
            DeleteItemBtn.UseVisualStyleBackColor = true;
            DeleteItemBtn.Click += DeleteItemBtn_Click;
            // 
            // ClearFieldsBtn
            // 
            ClearFieldsBtn.Location = new Point(1283, 365);
            ClearFieldsBtn.Margin = new Padding(6, 6, 6, 6);
            ClearFieldsBtn.Name = "ClearFieldsBtn";
            ClearFieldsBtn.Size = new Size(212, 98);
            ClearFieldsBtn.TabIndex = 13;
            ClearFieldsBtn.Text = "Clear Fields";
            ClearFieldsBtn.UseVisualStyleBackColor = true;
            ClearFieldsBtn.Click += ClearFieldsBtn_Click;
            // 
            // SubmitItemBtn
            // 
            SubmitItemBtn.Location = new Point(1283, 143);
            SubmitItemBtn.Margin = new Padding(6, 6, 6, 6);
            SubmitItemBtn.Name = "SubmitItemBtn";
            SubmitItemBtn.Size = new Size(212, 98);
            SubmitItemBtn.TabIndex = 11;
            SubmitItemBtn.Text = "Submit Item";
            SubmitItemBtn.UseVisualStyleBackColor = true;
            SubmitItemBtn.Click += SubmitItemBtn_Click;
            // 
            // ItemDescriptionGroupBox
            // 
            ItemDescriptionGroupBox.Controls.Add(ItemDescriptionTextBox);
            ItemDescriptionGroupBox.Location = new Point(11, 309);
            ItemDescriptionGroupBox.Margin = new Padding(6, 6, 6, 6);
            ItemDescriptionGroupBox.Name = "ItemDescriptionGroupBox";
            ItemDescriptionGroupBox.Padding = new Padding(6, 6, 6, 6);
            ItemDescriptionGroupBox.Size = new Size(1255, 265);
            ItemDescriptionGroupBox.TabIndex = 0;
            ItemDescriptionGroupBox.TabStop = false;
            ItemDescriptionGroupBox.Text = "Item Description";
            // 
            // ItemDescriptionTextBox
            // 
            ItemDescriptionTextBox.Location = new Point(11, 41);
            ItemDescriptionTextBox.Margin = new Padding(6, 6, 6, 6);
            ItemDescriptionTextBox.MaxLength = 250;
            ItemDescriptionTextBox.Multiline = true;
            ItemDescriptionTextBox.Name = "ItemDescriptionTextBox";
            ItemDescriptionTextBox.PlaceholderText = "Enter the item description here (size, color, weight, material, etc.)";
            ItemDescriptionTextBox.Size = new Size(1228, 200);
            ItemDescriptionTextBox.TabIndex = 10;
            // 
            // ReorderMaxTextBox
            // 
            ReorderMaxTextBox.Location = new Point(1283, 81);
            ReorderMaxTextBox.Margin = new Padding(6, 6, 6, 6);
            ReorderMaxTextBox.Name = "ReorderMaxTextBox";
            ReorderMaxTextBox.PlaceholderText = "Enter quantity";
            ReorderMaxTextBox.Size = new Size(208, 39);
            ReorderMaxTextBox.TabIndex = 4;
            ReorderMaxTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ReorderPointTextBox
            // 
            ReorderPointTextBox.Location = new Point(1025, 81);
            ReorderPointTextBox.Margin = new Padding(6, 6, 6, 6);
            ReorderPointTextBox.Name = "ReorderPointTextBox";
            ReorderPointTextBox.PlaceholderText = "Enter quantity";
            ReorderPointTextBox.Size = new Size(208, 39);
            ReorderPointTextBox.TabIndex = 3;
            ReorderPointTextBox.TextAlign = HorizontalAlignment.Center;
            ReorderPointTextBox.KeyPress += ReorderPointTextBox_KeyPress;
            // 
            // CurrentQtyTextBox
            // 
            CurrentQtyTextBox.Location = new Point(765, 81);
            CurrentQtyTextBox.Margin = new Padding(6, 6, 6, 6);
            CurrentQtyTextBox.Name = "CurrentQtyTextBox";
            CurrentQtyTextBox.PlaceholderText = "Enter quantity";
            CurrentQtyTextBox.Size = new Size(208, 39);
            CurrentQtyTextBox.TabIndex = 2;
            CurrentQtyTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // MaxAmtLabel
            // 
            MaxAmtLabel.AutoSize = true;
            MaxAmtLabel.Location = new Point(1278, 43);
            MaxAmtLabel.Margin = new Padding(6, 0, 6, 0);
            MaxAmtLabel.Name = "MaxAmtLabel";
            MaxAmtLabel.Size = new Size(242, 32);
            MaxAmtLabel.TabIndex = 0;
            MaxAmtLabel.Text = "Reorder Max Amount";
            // 
            // ReorderPointLabel
            // 
            ReorderPointLabel.AutoSize = true;
            ReorderPointLabel.Location = new Point(1053, 43);
            ReorderPointLabel.Margin = new Padding(6, 0, 6, 0);
            ReorderPointLabel.Name = "ReorderPointLabel";
            ReorderPointLabel.Size = new Size(158, 32);
            ReorderPointLabel.TabIndex = 0;
            ReorderPointLabel.Text = "Reorder Point";
            // 
            // CurrentAmountLabel
            // 
            CurrentAmountLabel.AutoSize = true;
            CurrentAmountLabel.Location = new Point(765, 43);
            CurrentAmountLabel.Margin = new Padding(6, 0, 6, 0);
            CurrentAmountLabel.Name = "CurrentAmountLabel";
            CurrentAmountLabel.Size = new Size(230, 32);
            CurrentAmountLabel.TabIndex = 0;
            CurrentAmountLabel.Text = "Current Qty in Stock";
            // 
            // ItemNameTextBox
            // 
            ItemNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ItemNameTextBox.Location = new Point(197, 68);
            ItemNameTextBox.Margin = new Padding(6, 6, 6, 6);
            ItemNameTextBox.Name = "ItemNameTextBox";
            ItemNameTextBox.PlaceholderText = "Enter item name";
            ItemNameTextBox.Size = new Size(522, 50);
            ItemNameTextBox.TabIndex = 1;
            // 
            // ItemNameLabel
            // 
            ItemNameLabel.AutoSize = true;
            ItemNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ItemNameLabel.Location = new Point(58, 87);
            ItemNameLabel.Margin = new Padding(6, 0, 6, 0);
            ItemNameLabel.Name = "ItemNameLabel";
            ItemNameLabel.Size = new Size(138, 32);
            ItemNameLabel.TabIndex = 0;
            ItemNameLabel.Text = "Item Name:";
            // 
            // ItemsListGroupBox
            // 
            ItemsListGroupBox.Controls.Add(ItemsGridView);
            ItemsListGroupBox.Controls.Add(AddToOrderBtn);
            ItemsListGroupBox.Controls.Add(ItemSearchTextBox);
            ItemsListGroupBox.Controls.Add(SearchBtn);
            ItemsListGroupBox.Location = new Point(22, 629);
            ItemsListGroupBox.Margin = new Padding(6, 6, 6, 6);
            ItemsListGroupBox.Name = "ItemsListGroupBox";
            ItemsListGroupBox.Padding = new Padding(6, 6, 6, 6);
            ItemsListGroupBox.Size = new Size(1515, 900);
            ItemsListGroupBox.TabIndex = 0;
            ItemsListGroupBox.TabStop = false;
            ItemsListGroupBox.Text = "Items List";
            // 
            // ItemsGridView
            // 
            ItemsGridView.AllowUserToAddRows = false;
            ItemsGridView.AllowUserToDeleteRows = false;
            ItemsGridView.AllowUserToResizeColumns = false;
            ItemsGridView.AllowUserToResizeRows = false;
            ItemsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ItemsGridView.BackgroundColor = SystemColors.Window;
            ItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ItemsGridView.Location = new Point(11, 98);
            ItemsGridView.Margin = new Padding(6, 6, 6, 6);
            ItemsGridView.MultiSelect = false;
            ItemsGridView.Name = "ItemsGridView";
            ItemsGridView.ReadOnly = true;
            ItemsGridView.RowHeadersWidth = 82;
            ItemsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ItemsGridView.Size = new Size(1493, 727);
            ItemsGridView.TabIndex = 17;
            ItemsGridView.SelectionChanged += ItemsGridView_SelectionChanged;
            // 
            // AddToOrderBtn
            // 
            AddToOrderBtn.Location = new Point(396, 838);
            AddToOrderBtn.Margin = new Padding(6, 6, 6, 6);
            AddToOrderBtn.Name = "AddToOrderBtn";
            AddToOrderBtn.Size = new Size(730, 49);
            AddToOrderBtn.TabIndex = 18;
            AddToOrderBtn.Text = "Add The Selected Item To A Pending Order";
            AddToOrderBtn.UseVisualStyleBackColor = true;
            AddToOrderBtn.Click += AddToOrderBtn_Click;
            // 
            // ItemSearchTextBox
            // 
            ItemSearchTextBox.Location = new Point(396, 34);
            ItemSearchTextBox.Margin = new Padding(6, 6, 6, 6);
            ItemSearchTextBox.Name = "ItemSearchTextBox";
            ItemSearchTextBox.PlaceholderText = "Search...";
            ItemSearchTextBox.Size = new Size(576, 39);
            ItemSearchTextBox.TabIndex = 15;
            ItemSearchTextBox.KeyDown += ItemSearchTextBox_KeyDown;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(986, 36);
            SearchBtn.Margin = new Padding(6, 6, 6, 6);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(139, 49);
            SearchBtn.TabIndex = 16;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // PendingOrdersGroupBox
            // 
            PendingOrdersGroupBox.Controls.Add(SubmitPendingOrderButton);
            PendingOrdersGroupBox.Controls.Add(DeletePendingOrderBtn);
            PendingOrdersGroupBox.Controls.Add(PendingOrderListBox);
            PendingOrdersGroupBox.Location = new Point(1549, 26);
            PendingOrdersGroupBox.Margin = new Padding(6, 6, 6, 6);
            PendingOrdersGroupBox.Name = "PendingOrdersGroupBox";
            PendingOrdersGroupBox.Padding = new Padding(6, 6, 6, 6);
            PendingOrdersGroupBox.Size = new Size(752, 297);
            PendingOrdersGroupBox.TabIndex = 0;
            PendingOrdersGroupBox.TabStop = false;
            PendingOrdersGroupBox.Text = "Pending Orders";
            // 
            // SubmitPendingOrderButton
            // 
            SubmitPendingOrderButton.Location = new Point(11, 228);
            SubmitPendingOrderButton.Margin = new Padding(6, 6, 6, 6);
            SubmitPendingOrderButton.Name = "SubmitPendingOrderButton";
            SubmitPendingOrderButton.Size = new Size(362, 49);
            SubmitPendingOrderButton.TabIndex = 20;
            SubmitPendingOrderButton.Text = "Submit Selected Pending Order";
            SubmitPendingOrderButton.UseVisualStyleBackColor = true;
            SubmitPendingOrderButton.Click += SubmitPendingOrderButton_Click;
            // 
            // DeletePendingOrderBtn
            // 
            DeletePendingOrderBtn.Location = new Point(381, 228);
            DeletePendingOrderBtn.Margin = new Padding(6, 6, 6, 6);
            DeletePendingOrderBtn.Name = "DeletePendingOrderBtn";
            DeletePendingOrderBtn.Size = new Size(360, 49);
            DeletePendingOrderBtn.TabIndex = 21;
            DeletePendingOrderBtn.Text = "Delete Selected Pending Order";
            DeletePendingOrderBtn.UseVisualStyleBackColor = true;
            DeletePendingOrderBtn.Click += DeletePendingOrderBtn_Click;
            // 
            // PendingOrderListBox
            // 
            PendingOrderListBox.FormattingEnabled = true;
            PendingOrderListBox.Location = new Point(11, 38);
            PendingOrderListBox.Margin = new Padding(6, 6, 6, 6);
            PendingOrderListBox.Name = "PendingOrderListBox";
            PendingOrderListBox.Size = new Size(726, 164);
            PendingOrderListBox.TabIndex = 0;
            PendingOrderListBox.SelectedIndexChanged += PendingOrderListBox_SelectedIndexChanged;
            // 
            // CurrentOrdersGroupBox
            // 
            CurrentOrdersGroupBox.Controls.Add(PastOrderDataGridView);
            CurrentOrdersGroupBox.Location = new Point(1549, 335);
            CurrentOrdersGroupBox.Margin = new Padding(6, 6, 6, 6);
            CurrentOrdersGroupBox.Name = "CurrentOrdersGroupBox";
            CurrentOrdersGroupBox.Padding = new Padding(6, 6, 6, 6);
            CurrentOrdersGroupBox.Size = new Size(752, 787);
            CurrentOrdersGroupBox.TabIndex = 0;
            CurrentOrdersGroupBox.TabStop = false;
            CurrentOrdersGroupBox.Text = "Past Orders";
            // 
            // PastOrderDataGridView
            // 
            PastOrderDataGridView.AllowUserToAddRows = false;
            PastOrderDataGridView.AllowUserToDeleteRows = false;
            PastOrderDataGridView.AllowUserToResizeColumns = false;
            PastOrderDataGridView.AllowUserToResizeRows = false;
            PastOrderDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PastOrderDataGridView.BackgroundColor = SystemColors.Window;
            PastOrderDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PastOrderDataGridView.Location = new Point(11, 41);
            PastOrderDataGridView.Margin = new Padding(6, 6, 6, 6);
            PastOrderDataGridView.MultiSelect = false;
            PastOrderDataGridView.Name = "PastOrderDataGridView";
            PastOrderDataGridView.ReadOnly = true;
            PastOrderDataGridView.RowHeadersWidth = 82;
            PastOrderDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PastOrderDataGridView.Size = new Size(730, 734);
            PastOrderDataGridView.TabIndex = 22;
            PastOrderDataGridView.SelectionChanged += PastOrderDataGridView_SelectionChanged;
            // 
            // OrderItemsGroupBox
            // 
            OrderItemsGroupBox.Controls.Add(OrderItemsDataGrid);
            OrderItemsGroupBox.Location = new Point(1549, 1135);
            OrderItemsGroupBox.Margin = new Padding(6, 6, 6, 6);
            OrderItemsGroupBox.Name = "OrderItemsGroupBox";
            OrderItemsGroupBox.Padding = new Padding(6, 6, 6, 6);
            OrderItemsGroupBox.Size = new Size(752, 395);
            OrderItemsGroupBox.TabIndex = 0;
            OrderItemsGroupBox.TabStop = false;
            OrderItemsGroupBox.Text = "Items In Selected Order";
            // 
            // OrderItemsDataGrid
            // 
            OrderItemsDataGrid.AllowUserToAddRows = false;
            OrderItemsDataGrid.AllowUserToDeleteRows = false;
            OrderItemsDataGrid.AllowUserToResizeColumns = false;
            OrderItemsDataGrid.AllowUserToResizeRows = false;
            OrderItemsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OrderItemsDataGrid.BackgroundColor = SystemColors.Window;
            OrderItemsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OrderItemsDataGrid.Location = new Point(11, 47);
            OrderItemsDataGrid.Margin = new Padding(6, 6, 6, 6);
            OrderItemsDataGrid.MultiSelect = false;
            OrderItemsDataGrid.Name = "OrderItemsDataGrid";
            OrderItemsDataGrid.ReadOnly = true;
            OrderItemsDataGrid.RowHeadersWidth = 82;
            OrderItemsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            OrderItemsDataGrid.Size = new Size(730, 322);
            OrderItemsDataGrid.TabIndex = 23;
            OrderItemsDataGrid.SelectionChanged += OrderItemsDataGrid_SelectionChanged;
            // 
            // EditOrderAmtTextBox
            // 
            EditOrderAmtTextBox.Enabled = false;
            EditOrderAmtTextBox.Location = new Point(1549, 1536);
            EditOrderAmtTextBox.Margin = new Padding(6, 6, 6, 6);
            EditOrderAmtTextBox.Name = "EditOrderAmtTextBox";
            EditOrderAmtTextBox.PlaceholderText = "Enter quantity";
            EditOrderAmtTextBox.Size = new Size(186, 39);
            EditOrderAmtTextBox.TabIndex = 24;
            EditOrderAmtTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // EditOrderAmtBtn
            // 
            EditOrderAmtBtn.Enabled = false;
            EditOrderAmtBtn.Location = new Point(1749, 1536);
            EditOrderAmtBtn.Margin = new Padding(6, 6, 6, 6);
            EditOrderAmtBtn.Name = "EditOrderAmtBtn";
            EditOrderAmtBtn.Size = new Size(321, 49);
            EditOrderAmtBtn.TabIndex = 25;
            EditOrderAmtBtn.Text = "Update Item's Order Quantity";
            EditOrderAmtBtn.UseVisualStyleBackColor = true;
            EditOrderAmtBtn.Click += EditOrderAmtBtn_Click;
            // 
            // OrderRecievedBtn
            // 
            OrderRecievedBtn.Enabled = false;
            OrderRecievedBtn.Location = new Point(2082, 1536);
            OrderRecievedBtn.Margin = new Padding(6, 6, 6, 6);
            OrderRecievedBtn.Name = "OrderRecievedBtn";
            OrderRecievedBtn.Size = new Size(219, 49);
            OrderRecievedBtn.TabIndex = 26;
            OrderRecievedBtn.Text = "Order Recieved";
            OrderRecievedBtn.UseVisualStyleBackColor = true;
            OrderRecievedBtn.Click += OrderRecievedBtn_Click;
            // 
            // BtnExportItems
            // 
            BtnExportItems.Location = new Point(787, 1525);
            BtnExportItems.Name = "BtnExportItems";
            BtnExportItems.Size = new Size(336, 46);
            BtnExportItems.TabIndex = 27;
            BtnExportItems.Text = "Export Items";
            BtnExportItems.UseVisualStyleBackColor = true;
            // 
            // BtnExportCategories
            // 
            BtnExportCategories.Location = new Point(1151, 1525);
            BtnExportCategories.Name = "BtnExportCategories";
            BtnExportCategories.Size = new Size(336, 46);
            BtnExportCategories.TabIndex = 28;
            BtnExportCategories.Text = "Export Categories";
            BtnExportCategories.UseVisualStyleBackColor = true;
            // 
            // BtnExportReorders
            // 
            BtnExportReorders.Location = new Point(787, 1581);
            BtnExportReorders.Name = "BtnExportReorders";
            BtnExportReorders.Size = new Size(336, 46);
            BtnExportReorders.TabIndex = 28;
            BtnExportReorders.Text = "Export Reorders";
            BtnExportReorders.UseVisualStyleBackColor = true;
            // 
            // BtnExportLogs
            // 
            BtnExportLogs.Location = new Point(1151, 1581);
            BtnExportLogs.Name = "BtnExportLogs";
            BtnExportLogs.Size = new Size(336, 46);
            BtnExportLogs.TabIndex = 29;
            BtnExportLogs.Text = "Export Inventory Log";
            BtnExportLogs.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2347, 1628);
            Controls.Add(BtnExportLogs);
            Controls.Add(BtnExportReorders);
            Controls.Add(BtnExportCategories);
            Controls.Add(BtnExportItems);
            Controls.Add(OrderRecievedBtn);
            Controls.Add(CurrentOrdersGroupBox);
            Controls.Add(EditOrderAmtBtn);
            Controls.Add(PendingOrdersGroupBox);
            Controls.Add(EditOrderAmtTextBox);
            Controls.Add(ItemsListGroupBox);
            Controls.Add(OrderItemsGroupBox);
            Controls.Add(ItemInfoGroupBox);
            Controls.Add(AddTestDataBtn);
            Controls.Add(SimDayBtn);
            Controls.Add(EnableTestModeChkbx);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(6, 6, 6, 6);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Reorder Point System";
            Load += MainForm_Load;
            ItemInfoGroupBox.ResumeLayout(false);
            ItemInfoGroupBox.PerformLayout();
            ItemDescriptionGroupBox.ResumeLayout(false);
            ItemDescriptionGroupBox.PerformLayout();
            ItemsListGroupBox.ResumeLayout(false);
            ItemsListGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ItemsGridView).EndInit();
            PendingOrdersGroupBox.ResumeLayout(false);
            CurrentOrdersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PastOrderDataGridView).EndInit();
            OrderItemsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)OrderItemsDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox EnableTestModeChkbx;
        private Button SimDayBtn;
        private Button AddTestDataBtn;
        private GroupBox ItemInfoGroupBox;
        private GroupBox ItemsListGroupBox;
        private GroupBox PendingOrdersGroupBox;
        private GroupBox CurrentOrdersGroupBox;
        private Label CurrentAmountLabel;
        private TextBox ItemNameTextBox;
        private Label ItemNameLabel;
        private GroupBox ItemDescriptionGroupBox;
        private TextBox ReorderMaxTextBox;
        private TextBox ReorderPointTextBox;
        private TextBox CurrentQtyTextBox;
        private Label MaxAmtLabel;
        private Label ReorderPointLabel;
        private Button DeleteItemBtn;
        private Button ClearFieldsBtn;
        private Button SubmitItemBtn;
        private TextBox ItemSearchTextBox;
        private Button SearchBtn;
        private Button EditItemBtn;
        private Label EnableReorderLabel;
        private CheckBox EnableReorderChkbx;
        private ListBox PendingOrderListBox;
        private Button DeletePendingOrderBtn;
        private Button EditOrderAmtBtn;
        private TextBox EditOrderAmtTextBox;
        private GroupBox OrderItemsGroupBox;
        private Button AddToOrderBtn;
        private ListBox CurrentOrdersListBox;
        private Button SubmitPendingOrderButton;
        private Button OrderRecievedBtn;
        private Label CategoryComboBoxLabel;
        private ComboBox CategoryComboBox;
        private DataGridView ItemsGridView;
        private DataGridView OrderItemsDataGrid;
        private Label AddNewCatLabel;
        private CheckBox AddNewCatCheckBox;
        private Button SubmitNewCategoryBtn;
        private TextBox NewCategoryTextBox;
        private Label NewCategoryNameLabel;
        private TextBox ItemDescriptionTextBox;
        private DataGridView PastOrderDataGridView;
        private Label DeleteCatLabel;
        private CheckBox DeleteCatCheckBox;
        private Button BtnExportItems;
        private Button BtnExportCategories;
        private Button BtnExportReorders;
        private Button BtnExportLogs;      
    }
}

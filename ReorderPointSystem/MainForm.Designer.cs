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
            DeleteCategoryBtn = new Button();
            AddCategoryBtn = new Button();
            EditItemBtn = new Button();
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
            SubmitPendingOrderButton = new Button();
            DeletePendingOrderBtn = new Button();
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
            openAnalysisButton = new Button();
            ItemInfoGroupBox.SuspendLayout();
            ItemDescriptionGroupBox.SuspendLayout();
            ItemsListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ItemsGridView).BeginInit();
            CurrentOrdersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PastOrderDataGridView).BeginInit();
            OrderItemsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OrderItemsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // EnableTestModeChkbx
            // 
            EnableTestModeChkbx.AutoSize = true;
            EnableTestModeChkbx.Location = new Point(18, 727);
            EnableTestModeChkbx.Name = "EnableTestModeChkbx";
            EnableTestModeChkbx.Size = new Size(160, 19);
            EnableTestModeChkbx.TabIndex = 0;
            EnableTestModeChkbx.Text = "Enable Simulation Mode?";
            EnableTestModeChkbx.UseVisualStyleBackColor = true;
            EnableTestModeChkbx.CheckedChanged += EnableTestModeChkbx_CheckedChanged;
            // 
            // SimDayBtn
            // 
            SimDayBtn.Location = new Point(198, 723);
            SimDayBtn.Name = "SimDayBtn";
            SimDayBtn.Size = new Size(95, 23);
            SimDayBtn.TabIndex = 0;
            SimDayBtn.Text = "Simulate Day";
            SimDayBtn.UseVisualStyleBackColor = true;
            SimDayBtn.Visible = false;
            SimDayBtn.Click += SimDayBtn_Click;
            // 
            // AddTestDataBtn
            // 
            AddTestDataBtn.Location = new Point(309, 722);
            AddTestDataBtn.Name = "AddTestDataBtn";
            AddTestDataBtn.Size = new Size(90, 23);
            AddTestDataBtn.TabIndex = 0;
            AddTestDataBtn.Text = "Add Test Data";
            AddTestDataBtn.UseVisualStyleBackColor = true;
            AddTestDataBtn.Visible = false;
            AddTestDataBtn.Click += AddTestDataBtn_Click;
            // 
            // ItemInfoGroupBox
            // 
            ItemInfoGroupBox.Controls.Add(DeleteCategoryBtn);
            ItemInfoGroupBox.Controls.Add(AddCategoryBtn);
            ItemInfoGroupBox.Controls.Add(EditItemBtn);
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
            ItemInfoGroupBox.Location = new Point(12, 12);
            ItemInfoGroupBox.Name = "ItemInfoGroupBox";
            ItemInfoGroupBox.Size = new Size(816, 277);
            ItemInfoGroupBox.TabIndex = 0;
            ItemInfoGroupBox.TabStop = false;
            ItemInfoGroupBox.Text = "Item Info";
            // 
            // DeleteCategoryBtn
            // 
            DeleteCategoryBtn.Location = new Point(412, 72);
            DeleteCategoryBtn.Margin = new Padding(2, 1, 2, 1);
            DeleteCategoryBtn.Name = "DeleteCategoryBtn";
            DeleteCategoryBtn.Size = new Size(114, 25);
            DeleteCategoryBtn.TabIndex = 27;
            DeleteCategoryBtn.Text = "Delete";
            DeleteCategoryBtn.UseVisualStyleBackColor = true;
            DeleteCategoryBtn.Click += DeleteCategoryBtn_Click;
            // 
            // AddCategoryBtn
            // 
            AddCategoryBtn.Location = new Point(552, 72);
            AddCategoryBtn.Margin = new Padding(2, 1, 2, 1);
            AddCategoryBtn.Name = "AddCategoryBtn";
            AddCategoryBtn.Size = new Size(114, 25);
            AddCategoryBtn.TabIndex = 27;
            AddCategoryBtn.Text = "Add";
            AddCategoryBtn.UseVisualStyleBackColor = true;
            AddCategoryBtn.Click += AddCategoryBtn_Click;
            // 
            // EditItemBtn
            // 
            EditItemBtn.Location = new Point(691, 119);
            EditItemBtn.Name = "EditItemBtn";
            EditItemBtn.Size = new Size(114, 46);
            EditItemBtn.TabIndex = 12;
            EditItemBtn.Text = "Edit Item";
            EditItemBtn.UseVisualStyleBackColor = true;
            EditItemBtn.Click += EditItemBtn_Click;
            // 
            // CategoryComboBoxLabel
            // 
            CategoryComboBoxLabel.AutoSize = true;
            CategoryComboBoxLabel.Location = new Point(35, 77);
            CategoryComboBoxLabel.Margin = new Padding(2, 0, 2, 0);
            CategoryComboBoxLabel.Name = "CategoryComboBoxLabel";
            CategoryComboBoxLabel.Size = new Size(66, 15);
            CategoryComboBoxLabel.TabIndex = 0;
            CategoryComboBoxLabel.Text = "Categories:";
            CategoryComboBoxLabel.Click += CategoryComboBoxLabel_Click;
            // 
            // CategoryComboBox
            // 
            CategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CategoryComboBox.FormattingEnabled = true;
            CategoryComboBox.Location = new Point(106, 74);
            CategoryComboBox.Name = "CategoryComboBox";
            CategoryComboBox.Size = new Size(283, 23);
            CategoryComboBox.TabIndex = 5;
            // 
            // EnableReorderLabel
            // 
            EnableReorderLabel.AutoSize = true;
            EnableReorderLabel.Location = new Point(483, 101);
            EnableReorderLabel.Name = "EnableReorderLabel";
            EnableReorderLabel.Size = new Size(140, 15);
            EnableReorderLabel.TabIndex = 0;
            EnableReorderLabel.Text = "Enable automatic reorder";
            // 
            // EnableReorderChkbx
            // 
            EnableReorderChkbx.AutoSize = true;
            EnableReorderChkbx.Location = new Point(462, 101);
            EnableReorderChkbx.Name = "EnableReorderChkbx";
            EnableReorderChkbx.Size = new Size(15, 14);
            EnableReorderChkbx.TabIndex = 6;
            EnableReorderChkbx.UseVisualStyleBackColor = true;
            // 
            // DeleteItemBtn
            // 
            DeleteItemBtn.Location = new Point(691, 223);
            DeleteItemBtn.Name = "DeleteItemBtn";
            DeleteItemBtn.Size = new Size(114, 46);
            DeleteItemBtn.TabIndex = 14;
            DeleteItemBtn.Text = "Delete Item";
            DeleteItemBtn.UseVisualStyleBackColor = true;
            DeleteItemBtn.Click += DeleteItemBtn_Click;
            // 
            // ClearFieldsBtn
            // 
            ClearFieldsBtn.Location = new Point(691, 171);
            ClearFieldsBtn.Name = "ClearFieldsBtn";
            ClearFieldsBtn.Size = new Size(114, 46);
            ClearFieldsBtn.TabIndex = 13;
            ClearFieldsBtn.Text = "Clear Fields";
            ClearFieldsBtn.UseVisualStyleBackColor = true;
            ClearFieldsBtn.Click += ClearFieldsBtn_Click;
            // 
            // SubmitItemBtn
            // 
            SubmitItemBtn.Location = new Point(691, 67);
            SubmitItemBtn.Name = "SubmitItemBtn";
            SubmitItemBtn.Size = new Size(114, 46);
            SubmitItemBtn.TabIndex = 11;
            SubmitItemBtn.Text = "Submit Item";
            SubmitItemBtn.UseVisualStyleBackColor = true;
            SubmitItemBtn.Click += SubmitItemBtn_Click;
            // 
            // ItemDescriptionGroupBox
            // 
            ItemDescriptionGroupBox.Controls.Add(ItemDescriptionTextBox);
            ItemDescriptionGroupBox.Location = new Point(6, 119);
            ItemDescriptionGroupBox.Name = "ItemDescriptionGroupBox";
            ItemDescriptionGroupBox.Size = new Size(679, 152);
            ItemDescriptionGroupBox.TabIndex = 0;
            ItemDescriptionGroupBox.TabStop = false;
            ItemDescriptionGroupBox.Text = "Item Description";
            // 
            // ItemDescriptionTextBox
            // 
            ItemDescriptionTextBox.Location = new Point(6, 22);
            ItemDescriptionTextBox.MaxLength = 250;
            ItemDescriptionTextBox.Multiline = true;
            ItemDescriptionTextBox.Name = "ItemDescriptionTextBox";
            ItemDescriptionTextBox.PlaceholderText = "Enter the item description here (size, color, weight, material, etc.)";
            ItemDescriptionTextBox.Size = new Size(667, 124);
            ItemDescriptionTextBox.TabIndex = 10;
            // 
            // ReorderMaxTextBox
            // 
            ReorderMaxTextBox.Location = new Point(691, 38);
            ReorderMaxTextBox.Name = "ReorderMaxTextBox";
            ReorderMaxTextBox.PlaceholderText = "Enter quantity";
            ReorderMaxTextBox.Size = new Size(114, 23);
            ReorderMaxTextBox.TabIndex = 4;
            ReorderMaxTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ReorderPointTextBox
            // 
            ReorderPointTextBox.Location = new Point(552, 38);
            ReorderPointTextBox.Name = "ReorderPointTextBox";
            ReorderPointTextBox.PlaceholderText = "Enter quantity";
            ReorderPointTextBox.Size = new Size(114, 23);
            ReorderPointTextBox.TabIndex = 3;
            ReorderPointTextBox.TextAlign = HorizontalAlignment.Center;
            ReorderPointTextBox.KeyPress += ReorderPointTextBox_KeyPress;
            // 
            // CurrentQtyTextBox
            // 
            CurrentQtyTextBox.Location = new Point(412, 38);
            CurrentQtyTextBox.Name = "CurrentQtyTextBox";
            CurrentQtyTextBox.PlaceholderText = "Enter quantity";
            CurrentQtyTextBox.Size = new Size(114, 23);
            CurrentQtyTextBox.TabIndex = 2;
            CurrentQtyTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // MaxAmtLabel
            // 
            MaxAmtLabel.AutoSize = true;
            MaxAmtLabel.Location = new Point(688, 20);
            MaxAmtLabel.Name = "MaxAmtLabel";
            MaxAmtLabel.Size = new Size(120, 15);
            MaxAmtLabel.TabIndex = 0;
            MaxAmtLabel.Text = "Reorder Max Amount";
            // 
            // ReorderPointLabel
            // 
            ReorderPointLabel.AutoSize = true;
            ReorderPointLabel.Location = new Point(567, 20);
            ReorderPointLabel.Name = "ReorderPointLabel";
            ReorderPointLabel.Size = new Size(79, 15);
            ReorderPointLabel.TabIndex = 0;
            ReorderPointLabel.Text = "Reorder Point";
            // 
            // CurrentAmountLabel
            // 
            CurrentAmountLabel.AutoSize = true;
            CurrentAmountLabel.Location = new Point(412, 20);
            CurrentAmountLabel.Name = "CurrentAmountLabel";
            CurrentAmountLabel.Size = new Size(114, 15);
            CurrentAmountLabel.TabIndex = 0;
            CurrentAmountLabel.Text = "Current Qty in Stock";
            // 
            // ItemNameTextBox
            // 
            ItemNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ItemNameTextBox.Location = new Point(106, 30);
            ItemNameTextBox.Name = "ItemNameTextBox";
            ItemNameTextBox.PlaceholderText = "Enter item name";
            ItemNameTextBox.Size = new Size(283, 29);
            ItemNameTextBox.TabIndex = 1;
            // 
            // ItemNameLabel
            // 
            ItemNameLabel.AutoSize = true;
            ItemNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ItemNameLabel.Location = new Point(31, 41);
            ItemNameLabel.Name = "ItemNameLabel";
            ItemNameLabel.Size = new Size(69, 15);
            ItemNameLabel.TabIndex = 0;
            ItemNameLabel.Text = "Item Name:";
            // 
            // ItemsListGroupBox
            // 
            ItemsListGroupBox.Controls.Add(ItemsGridView);
            ItemsListGroupBox.Controls.Add(AddToOrderBtn);
            ItemsListGroupBox.Controls.Add(ItemSearchTextBox);
            ItemsListGroupBox.Controls.Add(SearchBtn);
            ItemsListGroupBox.Location = new Point(12, 295);
            ItemsListGroupBox.Name = "ItemsListGroupBox";
            ItemsListGroupBox.Size = new Size(816, 422);
            ItemsListGroupBox.TabIndex = 0;
            ItemsListGroupBox.TabStop = false;
            ItemsListGroupBox.Text = "Items List";
            // 
            // ItemsGridView
            // 
            ItemsGridView.AllowUserToAddRows = false;
            ItemsGridView.AllowUserToDeleteRows = false;
            ItemsGridView.AllowUserToResizeRows = false;
            ItemsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ItemsGridView.BackgroundColor = SystemColors.Window;
            ItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ItemsGridView.Location = new Point(6, 46);
            ItemsGridView.MultiSelect = false;
            ItemsGridView.Name = "ItemsGridView";
            ItemsGridView.ReadOnly = true;
            ItemsGridView.RowHeadersWidth = 82;
            ItemsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ItemsGridView.Size = new Size(804, 341);
            ItemsGridView.TabIndex = 17;
            ItemsGridView.SelectionChanged += ItemsGridView_SelectionChanged;
            // 
            // AddToOrderBtn
            // 
            AddToOrderBtn.Location = new Point(213, 393);
            AddToOrderBtn.Name = "AddToOrderBtn";
            AddToOrderBtn.Size = new Size(393, 23);
            AddToOrderBtn.TabIndex = 18;
            AddToOrderBtn.Text = "Add The Selected Item To A Pending Order";
            AddToOrderBtn.UseVisualStyleBackColor = true;
            AddToOrderBtn.Click += AddToOrderBtn_Click;
            // 
            // ItemSearchTextBox
            // 
            ItemSearchTextBox.Location = new Point(213, 16);
            ItemSearchTextBox.Name = "ItemSearchTextBox";
            ItemSearchTextBox.PlaceholderText = "Search...";
            ItemSearchTextBox.Size = new Size(312, 23);
            ItemSearchTextBox.TabIndex = 15;
            ItemSearchTextBox.KeyDown += ItemSearchTextBox_KeyDown;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(531, 17);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(75, 23);
            SearchBtn.TabIndex = 16;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // SubmitPendingOrderButton
            // 
            SubmitPendingOrderButton.Location = new Point(206, 485);
            SubmitPendingOrderButton.Name = "SubmitPendingOrderButton";
            SubmitPendingOrderButton.Size = new Size(195, 23);
            SubmitPendingOrderButton.TabIndex = 20;
            SubmitPendingOrderButton.Text = "Submit Selected Pending Order";
            SubmitPendingOrderButton.UseVisualStyleBackColor = true;
            SubmitPendingOrderButton.Click += SubmitPendingOrderButton_Click;
            // 
            // DeletePendingOrderBtn
            // 
            DeletePendingOrderBtn.Location = new Point(6, 485);
            DeletePendingOrderBtn.Name = "DeletePendingOrderBtn";
            DeletePendingOrderBtn.Size = new Size(194, 23);
            DeletePendingOrderBtn.TabIndex = 21;
            DeletePendingOrderBtn.Text = "Delete Selected Pending Order";
            DeletePendingOrderBtn.UseVisualStyleBackColor = true;
            DeletePendingOrderBtn.Click += DeletePendingOrderBtn_Click;
            // 
            // CurrentOrdersGroupBox
            // 
            CurrentOrdersGroupBox.Controls.Add(SubmitPendingOrderButton);
            CurrentOrdersGroupBox.Controls.Add(DeletePendingOrderBtn);
            CurrentOrdersGroupBox.Controls.Add(PastOrderDataGridView);
            CurrentOrdersGroupBox.Location = new Point(834, 12);
            CurrentOrdersGroupBox.Name = "CurrentOrdersGroupBox";
            CurrentOrdersGroupBox.Size = new Size(405, 514);
            CurrentOrdersGroupBox.TabIndex = 0;
            CurrentOrdersGroupBox.TabStop = false;
            CurrentOrdersGroupBox.Text = "Orders";
            // 
            // PastOrderDataGridView
            // 
            PastOrderDataGridView.AllowUserToAddRows = false;
            PastOrderDataGridView.AllowUserToDeleteRows = false;
            PastOrderDataGridView.AllowUserToResizeRows = false;
            PastOrderDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PastOrderDataGridView.BackgroundColor = SystemColors.Window;
            PastOrderDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PastOrderDataGridView.Location = new Point(6, 19);
            PastOrderDataGridView.MultiSelect = false;
            PastOrderDataGridView.Name = "PastOrderDataGridView";
            PastOrderDataGridView.ReadOnly = true;
            PastOrderDataGridView.RowHeadersWidth = 82;
            PastOrderDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PastOrderDataGridView.Size = new Size(393, 460);
            PastOrderDataGridView.TabIndex = 22;
            PastOrderDataGridView.SelectionChanged += PastOrderDataGridView_SelectionChanged;
            // 
            // OrderItemsGroupBox
            // 
            OrderItemsGroupBox.Controls.Add(OrderItemsDataGrid);
            OrderItemsGroupBox.Location = new Point(834, 532);
            OrderItemsGroupBox.Name = "OrderItemsGroupBox";
            OrderItemsGroupBox.Size = new Size(405, 185);
            OrderItemsGroupBox.TabIndex = 0;
            OrderItemsGroupBox.TabStop = false;
            OrderItemsGroupBox.Text = "Items In Selected Order";
            // 
            // OrderItemsDataGrid
            // 
            OrderItemsDataGrid.AllowUserToAddRows = false;
            OrderItemsDataGrid.AllowUserToDeleteRows = false;
            OrderItemsDataGrid.AllowUserToResizeRows = false;
            OrderItemsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OrderItemsDataGrid.BackgroundColor = SystemColors.Window;
            OrderItemsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OrderItemsDataGrid.Location = new Point(6, 22);
            OrderItemsDataGrid.MultiSelect = false;
            OrderItemsDataGrid.Name = "OrderItemsDataGrid";
            OrderItemsDataGrid.ReadOnly = true;
            OrderItemsDataGrid.RowHeadersWidth = 82;
            OrderItemsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            OrderItemsDataGrid.Size = new Size(393, 151);
            OrderItemsDataGrid.TabIndex = 23;
            OrderItemsDataGrid.SelectionChanged += OrderItemsDataGrid_SelectionChanged;
            // 
            // EditOrderAmtTextBox
            // 
            EditOrderAmtTextBox.Enabled = false;
            EditOrderAmtTextBox.Location = new Point(834, 720);
            EditOrderAmtTextBox.Name = "EditOrderAmtTextBox";
            EditOrderAmtTextBox.PlaceholderText = "Enter quantity";
            EditOrderAmtTextBox.Size = new Size(102, 23);
            EditOrderAmtTextBox.TabIndex = 24;
            EditOrderAmtTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // EditOrderAmtBtn
            // 
            EditOrderAmtBtn.Enabled = false;
            EditOrderAmtBtn.Location = new Point(942, 720);
            EditOrderAmtBtn.Name = "EditOrderAmtBtn";
            EditOrderAmtBtn.Size = new Size(173, 23);
            EditOrderAmtBtn.TabIndex = 25;
            EditOrderAmtBtn.Text = "Update Item's Order Quantity";
            EditOrderAmtBtn.UseVisualStyleBackColor = true;
            EditOrderAmtBtn.Click += EditOrderAmtBtn_Click;
            // 
            // OrderRecievedBtn
            // 
            OrderRecievedBtn.Enabled = false;
            OrderRecievedBtn.Location = new Point(1121, 720);
            OrderRecievedBtn.Name = "OrderRecievedBtn";
            OrderRecievedBtn.Size = new Size(118, 23);
            OrderRecievedBtn.TabIndex = 26;
            OrderRecievedBtn.Text = "Order Recieved";
            OrderRecievedBtn.UseVisualStyleBackColor = true;
            OrderRecievedBtn.Click += OrderRecievedBtn_Click;
            // 
            // BtnExportItems
            // 
            BtnExportItems.Location = new Point(92, 750);
            BtnExportItems.Margin = new Padding(2, 1, 2, 1);
            BtnExportItems.Name = "BtnExportItems";
            BtnExportItems.Size = new Size(181, 22);
            BtnExportItems.TabIndex = 27;
            BtnExportItems.Text = "Export Items";
            BtnExportItems.UseVisualStyleBackColor = true;
            BtnExportItems.Click += BtnExportItems_Click;
            // 
            // BtnExportCategories
            // 
            BtnExportCategories.Location = new Point(462, 750);
            BtnExportCategories.Margin = new Padding(2, 1, 2, 1);
            BtnExportCategories.Name = "BtnExportCategories";
            BtnExportCategories.Size = new Size(181, 22);
            BtnExportCategories.TabIndex = 28;
            BtnExportCategories.Text = "Export Categories";
            BtnExportCategories.UseVisualStyleBackColor = true;
            BtnExportCategories.Click += BtnExportCategories_Click;
            // 
            // BtnExportReorders
            // 
            BtnExportReorders.Location = new Point(277, 750);
            BtnExportReorders.Margin = new Padding(2, 1, 2, 1);
            BtnExportReorders.Name = "BtnExportReorders";
            BtnExportReorders.Size = new Size(181, 22);
            BtnExportReorders.TabIndex = 28;
            BtnExportReorders.Text = "Export Reorders";
            BtnExportReorders.UseVisualStyleBackColor = true;
            BtnExportReorders.Click += BtnExportReorders_Click;
            // 
            // BtnExportLogs
            // 
            BtnExportLogs.Location = new Point(647, 750);
            BtnExportLogs.Margin = new Padding(2, 1, 2, 1);
            BtnExportLogs.Name = "BtnExportLogs";
            BtnExportLogs.Size = new Size(181, 22);
            BtnExportLogs.TabIndex = 29;
            BtnExportLogs.Text = "Export Inventory Log";
            BtnExportLogs.UseVisualStyleBackColor = true;
            BtnExportLogs.Click += BtnExportLogs_Click;
            // 
            // openAnalysisButton
            // 
            openAnalysisButton.Location = new Point(516, 722);
            openAnalysisButton.Margin = new Padding(2, 1, 2, 1);
            openAnalysisButton.Name = "openAnalysisButton";
            openAnalysisButton.Size = new Size(181, 22);
            openAnalysisButton.TabIndex = 27;
            openAnalysisButton.Text = "Analysis";
            openAnalysisButton.UseVisualStyleBackColor = true;
            openAnalysisButton.Click += openAnalysisButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 774);
            Controls.Add(BtnExportLogs);
            Controls.Add(BtnExportReorders);
            Controls.Add(BtnExportCategories);
            Controls.Add(BtnExportItems);
            Controls.Add(openAnalysisButton);
            Controls.Add(OrderRecievedBtn);
            Controls.Add(CurrentOrdersGroupBox);
            Controls.Add(EditOrderAmtBtn);
            Controls.Add(EditOrderAmtTextBox);
            Controls.Add(ItemsListGroupBox);
            Controls.Add(OrderItemsGroupBox);
            Controls.Add(ItemInfoGroupBox);
            Controls.Add(AddTestDataBtn);
            Controls.Add(SimDayBtn);
            Controls.Add(EnableTestModeChkbx);
            FormBorderStyle = FormBorderStyle.Fixed3D;
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
        private TextBox ItemDescriptionTextBox;
        private DataGridView PastOrderDataGridView;
        private Label DeleteCatLabel;
        private CheckBox DeleteCatCheckBox;
        private Button BtnExportItems;
        private Button BtnExportCategories;
        private Button BtnExportReorders;
        private Button BtnExportLogs;      
        private Button openAnalysisButton;
        private Button DeleteCategoryBtn;
        private Button AddCategoryBtn;
    }
}

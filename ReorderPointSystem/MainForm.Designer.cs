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
            AddTestDataBtn.Location = new Point(311, 723);
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
            ItemInfoGroupBox.Location = new Point(12, 12);
            ItemInfoGroupBox.Name = "ItemInfoGroupBox";
            ItemInfoGroupBox.Size = new Size(816, 277);
            ItemInfoGroupBox.TabIndex = 0;
            ItemInfoGroupBox.TabStop = false;
            ItemInfoGroupBox.Text = "Item Info";
            // 
            // DeleteCatLabel
            // 
            DeleteCatLabel.AutoSize = true;
            DeleteCatLabel.Location = new Point(573, 85);
            DeleteCatLabel.Name = "DeleteCatLabel";
            DeleteCatLabel.Size = new Size(94, 15);
            DeleteCatLabel.TabIndex = 16;
            DeleteCatLabel.Text = "Delete category?";
            // 
            // DeleteCatCheckBox
            // 
            DeleteCatCheckBox.AutoSize = true;
            DeleteCatCheckBox.Location = new Point(552, 85);
            DeleteCatCheckBox.Name = "DeleteCatCheckBox";
            DeleteCatCheckBox.Size = new Size(15, 14);
            DeleteCatCheckBox.TabIndex = 15;
            DeleteCatCheckBox.UseVisualStyleBackColor = true;
            DeleteCatCheckBox.CheckedChanged += DeleteCatCheckBox_CheckChanged;
            // 
            // NewCategoryNameLabel
            // 
            NewCategoryNameLabel.AutoSize = true;
            NewCategoryNameLabel.Location = new Point(7, 119);
            NewCategoryNameLabel.Name = "NewCategoryNameLabel";
            NewCategoryNameLabel.Size = new Size(93, 15);
            NewCategoryNameLabel.TabIndex = 0;
            NewCategoryNameLabel.Text = "Category Name:";
            NewCategoryNameLabel.Visible = false;
            // 
            // AddNewCatLabel
            // 
            AddNewCatLabel.AutoSize = true;
            AddNewCatLabel.Location = new Point(433, 85);
            AddNewCatLabel.Name = "AddNewCatLabel";
            AddNewCatLabel.Size = new Size(108, 15);
            AddNewCatLabel.TabIndex = 0;
            AddNewCatLabel.Text = "Add new category?";
            // 
            // AddNewCatCheckBox
            // 
            AddNewCatCheckBox.AutoSize = true;
            AddNewCatCheckBox.Location = new Point(412, 85);
            AddNewCatCheckBox.Name = "AddNewCatCheckBox";
            AddNewCatCheckBox.Size = new Size(15, 14);
            AddNewCatCheckBox.TabIndex = 7;
            AddNewCatCheckBox.UseVisualStyleBackColor = true;
            AddNewCatCheckBox.CheckedChanged += AddNewCategory_CheckChanged;
            // 
            // SubmitNewCategoryBtn
            // 
            SubmitNewCategoryBtn.Location = new Point(412, 110);
            SubmitNewCategoryBtn.Name = "SubmitNewCategoryBtn";
            SubmitNewCategoryBtn.Size = new Size(140, 29);
            SubmitNewCategoryBtn.TabIndex = 9;
            SubmitNewCategoryBtn.Text = "Submit New Category";
            SubmitNewCategoryBtn.UseVisualStyleBackColor = true;
            SubmitNewCategoryBtn.Visible = false;
            SubmitNewCategoryBtn.Click += SubmitNewCategoryBtn_Click;
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
            // NewCategoryTextBox
            // 
            NewCategoryTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NewCategoryTextBox.Location = new Point(106, 110);
            NewCategoryTextBox.Name = "NewCategoryTextBox";
            NewCategoryTextBox.Size = new Size(283, 29);
            NewCategoryTextBox.TabIndex = 8;
            NewCategoryTextBox.Visible = false;
            NewCategoryTextBox.Enter += NewCategoryTextBox_Enter;
            NewCategoryTextBox.KeyDown += NewCategoryTextBox_KeyDown;
            NewCategoryTextBox.Leave += NewCategoryTextBox_Leave;
            // 
            // CategoryComboBoxLabel
            // 
            CategoryComboBoxLabel.AutoSize = true;
            CategoryComboBoxLabel.Location = new Point(34, 77);
            CategoryComboBoxLabel.Name = "CategoryComboBoxLabel";
            CategoryComboBoxLabel.Size = new Size(66, 15);
            CategoryComboBoxLabel.TabIndex = 0;
            CategoryComboBoxLabel.Text = "Categories:";
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
            EnableReorderLabel.Location = new Point(433, 64);
            EnableReorderLabel.Name = "EnableReorderLabel";
            EnableReorderLabel.Size = new Size(161, 15);
            EnableReorderLabel.TabIndex = 0;
            EnableReorderLabel.Text = "Allow automated reordering?";
            // 
            // EnableReorderChkbx
            // 
            EnableReorderChkbx.AutoSize = true;
            EnableReorderChkbx.Location = new Point(412, 65);
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
            ItemDescriptionGroupBox.Location = new Point(6, 145);
            ItemDescriptionGroupBox.Name = "ItemDescriptionGroupBox";
            ItemDescriptionGroupBox.Size = new Size(676, 124);
            ItemDescriptionGroupBox.TabIndex = 0;
            ItemDescriptionGroupBox.TabStop = false;
            ItemDescriptionGroupBox.Text = "Item Description";
            // 
            // ItemDescriptionTextBox
            // 
            ItemDescriptionTextBox.Location = new Point(6, 19);
            ItemDescriptionTextBox.MaxLength = 250;
            ItemDescriptionTextBox.Multiline = true;
            ItemDescriptionTextBox.Name = "ItemDescriptionTextBox";
            ItemDescriptionTextBox.Size = new Size(663, 96);
            ItemDescriptionTextBox.TabIndex = 10;
            // 
            // ReorderMaxTextBox
            // 
            ReorderMaxTextBox.Location = new Point(691, 38);
            ReorderMaxTextBox.Name = "ReorderMaxTextBox";
            ReorderMaxTextBox.Size = new Size(114, 23);
            ReorderMaxTextBox.TabIndex = 4;
            ReorderMaxTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ReorderPointTextBox
            // 
            ReorderPointTextBox.Location = new Point(552, 38);
            ReorderPointTextBox.Name = "ReorderPointTextBox";
            ReorderPointTextBox.Size = new Size(114, 23);
            ReorderPointTextBox.TabIndex = 3;
            ReorderPointTextBox.TextAlign = HorizontalAlignment.Center;
            ReorderPointTextBox.KeyPress += ReorderPointTextBox_KeyPress;
            // 
            // CurrentQtyTextBox
            // 
            CurrentQtyTextBox.Location = new Point(412, 38);
            CurrentQtyTextBox.Name = "CurrentQtyTextBox";
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
            ItemNameTextBox.Location = new Point(106, 32);
            ItemNameTextBox.Name = "ItemNameTextBox";
            ItemNameTextBox.Size = new Size(283, 29);
            ItemNameTextBox.TabIndex = 1;
            ItemNameTextBox.Enter += ItemNameTextBox_Enter;
            ItemNameTextBox.Leave += ItemNameTextBox_Leave;
            // 
            // ItemNameLabel
            // 
            ItemNameLabel.AutoSize = true;
            ItemNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ItemNameLabel.Location = new Point(10, 36);
            ItemNameLabel.Name = "ItemNameLabel";
            ItemNameLabel.Size = new Size(90, 21);
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
            ItemsGridView.AllowUserToResizeColumns = false;
            ItemsGridView.AllowUserToResizeRows = false;
            ItemsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ItemsGridView.BackgroundColor = SystemColors.Window;
            ItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ItemsGridView.Location = new Point(6, 46);
            ItemsGridView.MultiSelect = false;
            ItemsGridView.Name = "ItemsGridView";
            ItemsGridView.ReadOnly = true;
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
            // PendingOrdersGroupBox
            // 
            PendingOrdersGroupBox.Controls.Add(SubmitPendingOrderButton);
            PendingOrdersGroupBox.Controls.Add(DeletePendingOrderBtn);
            PendingOrdersGroupBox.Controls.Add(PendingOrderListBox);
            PendingOrdersGroupBox.Location = new Point(834, 12);
            PendingOrdersGroupBox.Name = "PendingOrdersGroupBox";
            PendingOrdersGroupBox.Size = new Size(405, 139);
            PendingOrdersGroupBox.TabIndex = 0;
            PendingOrdersGroupBox.TabStop = false;
            PendingOrdersGroupBox.Text = "Pending Orders";
            // 
            // SubmitPendingOrderButton
            // 
            SubmitPendingOrderButton.Location = new Point(6, 107);
            SubmitPendingOrderButton.Name = "SubmitPendingOrderButton";
            SubmitPendingOrderButton.Size = new Size(195, 23);
            SubmitPendingOrderButton.TabIndex = 20;
            SubmitPendingOrderButton.Text = "Submit Selected Pending Order";
            SubmitPendingOrderButton.UseVisualStyleBackColor = true;
            SubmitPendingOrderButton.Click += SubmitPendingOrderButton_Click;
            // 
            // DeletePendingOrderBtn
            // 
            DeletePendingOrderBtn.Location = new Point(205, 107);
            DeletePendingOrderBtn.Name = "DeletePendingOrderBtn";
            DeletePendingOrderBtn.Size = new Size(194, 23);
            DeletePendingOrderBtn.TabIndex = 21;
            DeletePendingOrderBtn.Text = "Delete Selected Pending Order";
            DeletePendingOrderBtn.UseVisualStyleBackColor = true;
            DeletePendingOrderBtn.Click += DeletePendingOrderBtn_Click;
            // 
            // PendingOrderListBox
            // 
            PendingOrderListBox.FormattingEnabled = true;
            PendingOrderListBox.ItemHeight = 15;
            PendingOrderListBox.Location = new Point(6, 18);
            PendingOrderListBox.Name = "PendingOrderListBox";
            PendingOrderListBox.Size = new Size(393, 79);
            PendingOrderListBox.TabIndex = 0;
            PendingOrderListBox.SelectedIndexChanged += PendingOrderListBox_SelectedIndexChanged;
            // 
            // CurrentOrdersGroupBox
            // 
            CurrentOrdersGroupBox.Controls.Add(PastOrderDataGridView);
            CurrentOrdersGroupBox.Location = new Point(834, 157);
            CurrentOrdersGroupBox.Name = "CurrentOrdersGroupBox";
            CurrentOrdersGroupBox.Size = new Size(405, 369);
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
            PastOrderDataGridView.Location = new Point(6, 19);
            PastOrderDataGridView.MultiSelect = false;
            PastOrderDataGridView.Name = "PastOrderDataGridView";
            PastOrderDataGridView.ReadOnly = true;
            PastOrderDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PastOrderDataGridView.Size = new Size(393, 344);
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
            OrderItemsDataGrid.AllowUserToResizeColumns = false;
            OrderItemsDataGrid.AllowUserToResizeRows = false;
            OrderItemsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            OrderItemsDataGrid.BackgroundColor = SystemColors.Window;
            OrderItemsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OrderItemsDataGrid.Location = new Point(6, 22);
            OrderItemsDataGrid.MultiSelect = false;
            OrderItemsDataGrid.Name = "OrderItemsDataGrid";
            OrderItemsDataGrid.ReadOnly = true;
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
            EditOrderAmtTextBox.Size = new Size(102, 23);
            EditOrderAmtTextBox.TabIndex = 24;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 761);
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
    }
}

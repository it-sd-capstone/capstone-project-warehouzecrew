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
            ItemInfoGroupBox = new GroupBox();
            CategoryComboBoxLabel = new Label();
            CategoryComboBox = new ComboBox();
            EnableReorderLabel = new Label();
            EnableReorderChkbx = new CheckBox();
            DeleteItemBtn = new Button();
            ClearFieldsBtn = new Button();
            SubmitItemBtn = new Button();
            ItemDescriptionGroupBox = new GroupBox();
            ItemDescriptionLabel = new Label();
            ReorderMaxTextBox = new TextBox();
            ReorderPointTextBox = new TextBox();
            CurrentQtyTextBox = new TextBox();
            MaxAmtLabel = new Label();
            ReorderPointLabel = new Label();
            CurrentAmountLabel = new Label();
            ItemNameTextBox = new TextBox();
            ItemNameLabel = new Label();
            panelModeContainer = new Panel();
            panelDefaultMode = new Panel();
            ExportCSVBtn = new Button();
            SimPanel = new Panel();
            SimDayBtn = new Button();
            AddTestDataBtn = new Button();
            ItemsListGroupBox = new GroupBox();
            SortByComboBox = new ComboBox();
            RefreshButton = new Button();
            AddToOrderBtn = new Button();
            EditItemBtn = new Button();
            ItemSearchTextBox = new TextBox();
            SearchBtn = new Button();
            ItemsListBox = new ListBox();
            PendingOrdersGroupBox = new GroupBox();
            SubmitPendingOrderButton = new Button();
            DeletePendingOrderBtn = new Button();
            PendingOrderListBox = new ListBox();
            CurrentOrdersGroupBox = new GroupBox();
            CurrentOrdersListBox = new ListBox();
            OrderItemsGroupBox = new GroupBox();
            OrderItemsListBox = new ListBox();
            EditOrderAmtTextBox = new TextBox();
            EditOrderAmtBtn = new Button();
            OrderRecievedBtn = new Button();
            ItemInfoGroupBox.SuspendLayout();
            ItemDescriptionGroupBox.SuspendLayout();
            panelDefaultMode.SuspendLayout();
            SimPanel.SuspendLayout();
            ItemsListGroupBox.SuspendLayout();
            PendingOrdersGroupBox.SuspendLayout();
            CurrentOrdersGroupBox.SuspendLayout();
            OrderItemsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // EnableTestModeChkbx
            // 
            EnableTestModeChkbx.AutoSize = true;
            EnableTestModeChkbx.Location = new Point(21, 1558);
            EnableTestModeChkbx.Margin = new Padding(6);
            EnableTestModeChkbx.Name = "EnableTestModeChkbx";
            EnableTestModeChkbx.Size = new Size(319, 36);
            EnableTestModeChkbx.TabIndex = 0;
            EnableTestModeChkbx.Text = "Enable Simulation Mode?";
            EnableTestModeChkbx.UseVisualStyleBackColor = true;
            EnableTestModeChkbx.CheckedChanged += EnableTestModeChkbx_CheckedChanged;
            // 
            // ItemInfoGroupBox
            // 
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
            ItemInfoGroupBox.Controls.Add(panelModeContainer);
            ItemInfoGroupBox.Location = new Point(22, 26);
            ItemInfoGroupBox.Margin = new Padding(6);
            ItemInfoGroupBox.Name = "ItemInfoGroupBox";
            ItemInfoGroupBox.Padding = new Padding(6);
            ItemInfoGroupBox.Size = new Size(752, 1504);
            ItemInfoGroupBox.TabIndex = 3;
            ItemInfoGroupBox.TabStop = false;
            ItemInfoGroupBox.Text = "Item Info";
            // 
            // CategoryComboBoxLabel
            // 
            CategoryComboBoxLabel.AutoSize = true;
            CategoryComboBoxLabel.Location = new Point(56, 339);
            CategoryComboBoxLabel.Margin = new Padding(6, 0, 6, 0);
            CategoryComboBoxLabel.Name = "CategoryComboBoxLabel";
            CategoryComboBoxLabel.Size = new Size(132, 32);
            CategoryComboBoxLabel.TabIndex = 15;
            CategoryComboBoxLabel.Text = "Categories:";
            // 
            // CategoryComboBox
            // 
            CategoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CategoryComboBox.FormattingEnabled = true;
            CategoryComboBox.Location = new Point(254, 333);
            CategoryComboBox.Margin = new Padding(6);
            CategoryComboBox.Name = "CategoryComboBox";
            CategoryComboBox.Size = new Size(453, 40);
            CategoryComboBox.TabIndex = 14;
            // 
            // EnableReorderLabel
            // 
            EnableReorderLabel.AutoSize = true;
            EnableReorderLabel.Location = new Point(189, 147);
            EnableReorderLabel.Margin = new Padding(6, 0, 6, 0);
            EnableReorderLabel.Name = "EnableReorderLabel";
            EnableReorderLabel.Size = new Size(551, 32);
            EnableReorderLabel.TabIndex = 13;
            EnableReorderLabel.Text = "Selected Item Allows Automatic Reorder Flagging?";
            // 
            // EnableReorderChkbx
            // 
            EnableReorderChkbx.AutoSize = true;
            EnableReorderChkbx.Location = new Point(123, 149);
            EnableReorderChkbx.Margin = new Padding(6);
            EnableReorderChkbx.Name = "EnableReorderChkbx";
            EnableReorderChkbx.Size = new Size(28, 27);
            EnableReorderChkbx.TabIndex = 12;
            EnableReorderChkbx.UseVisualStyleBackColor = true;
            // 
            // DeleteItemBtn
            // 
            DeleteItemBtn.Location = new Point(524, 1365);
            DeleteItemBtn.Margin = new Padding(6);
            DeleteItemBtn.Name = "DeleteItemBtn";
            DeleteItemBtn.Size = new Size(212, 126);
            DeleteItemBtn.TabIndex = 11;
            DeleteItemBtn.Text = "Delete Item";
            DeleteItemBtn.UseVisualStyleBackColor = true;
            DeleteItemBtn.Click += DeleteItemBtn_Click;
            // 
            // ClearFieldsBtn
            // 
            ClearFieldsBtn.Location = new Point(267, 1365);
            ClearFieldsBtn.Margin = new Padding(6);
            ClearFieldsBtn.Name = "ClearFieldsBtn";
            ClearFieldsBtn.Size = new Size(212, 126);
            ClearFieldsBtn.TabIndex = 10;
            ClearFieldsBtn.Text = "Clear";
            ClearFieldsBtn.UseVisualStyleBackColor = true;
            ClearFieldsBtn.Click += ClearFieldsBtn_Click;
            // 
            // SubmitItemBtn
            // 
            SubmitItemBtn.Location = new Point(15, 1365);
            SubmitItemBtn.Margin = new Padding(6);
            SubmitItemBtn.Name = "SubmitItemBtn";
            SubmitItemBtn.Size = new Size(212, 126);
            SubmitItemBtn.TabIndex = 9;
            SubmitItemBtn.Text = "Submit";
            SubmitItemBtn.UseVisualStyleBackColor = true;
            SubmitItemBtn.Click += SubmitItemBtn_Click;
            // 
            // ItemDescriptionGroupBox
            // 
            ItemDescriptionGroupBox.Controls.Add(ItemDescriptionLabel);
            ItemDescriptionGroupBox.Location = new Point(11, 431);
            ItemDescriptionGroupBox.Margin = new Padding(6);
            ItemDescriptionGroupBox.Name = "ItemDescriptionGroupBox";
            ItemDescriptionGroupBox.Padding = new Padding(6);
            ItemDescriptionGroupBox.Size = new Size(730, 922);
            ItemDescriptionGroupBox.TabIndex = 8;
            ItemDescriptionGroupBox.TabStop = false;
            ItemDescriptionGroupBox.Text = "Item Description";
            // 
            // ItemDescriptionLabel
            // 
            ItemDescriptionLabel.Location = new Point(11, 41);
            ItemDescriptionLabel.Margin = new Padding(6, 0, 6, 0);
            ItemDescriptionLabel.Name = "ItemDescriptionLabel";
            ItemDescriptionLabel.Size = new Size(700, 943);
            ItemDescriptionLabel.TabIndex = 0;
            // 
            // ReorderMaxTextBox
            // 
            ReorderMaxTextBox.Location = new Point(500, 247);
            ReorderMaxTextBox.Margin = new Padding(6);
            ReorderMaxTextBox.Name = "ReorderMaxTextBox";
            ReorderMaxTextBox.Size = new Size(208, 39);
            ReorderMaxTextBox.TabIndex = 7;
            ReorderMaxTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ReorderPointTextBox
            // 
            ReorderPointTextBox.Location = new Point(254, 247);
            ReorderPointTextBox.Margin = new Padding(6);
            ReorderPointTextBox.Name = "ReorderPointTextBox";
            ReorderPointTextBox.Size = new Size(208, 39);
            ReorderPointTextBox.TabIndex = 6;
            ReorderPointTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // CurrentQtyTextBox
            // 
            CurrentQtyTextBox.Location = new Point(11, 247);
            CurrentQtyTextBox.Margin = new Padding(6);
            CurrentQtyTextBox.Name = "CurrentQtyTextBox";
            CurrentQtyTextBox.Size = new Size(208, 39);
            CurrentQtyTextBox.TabIndex = 5;
            CurrentQtyTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // MaxAmtLabel
            // 
            MaxAmtLabel.AutoSize = true;
            MaxAmtLabel.Location = new Point(494, 209);
            MaxAmtLabel.Margin = new Padding(6, 0, 6, 0);
            MaxAmtLabel.Name = "MaxAmtLabel";
            MaxAmtLabel.Size = new Size(242, 32);
            MaxAmtLabel.TabIndex = 4;
            MaxAmtLabel.Text = "Reorder Max Amount";
            // 
            // ReorderPointLabel
            // 
            ReorderPointLabel.AutoSize = true;
            ReorderPointLabel.Location = new Point(286, 209);
            ReorderPointLabel.Margin = new Padding(6, 0, 6, 0);
            ReorderPointLabel.Name = "ReorderPointLabel";
            ReorderPointLabel.Size = new Size(158, 32);
            ReorderPointLabel.TabIndex = 3;
            ReorderPointLabel.Text = "Reorder Point";
            // 
            // CurrentAmountLabel
            // 
            CurrentAmountLabel.AutoSize = true;
            CurrentAmountLabel.Location = new Point(11, 209);
            CurrentAmountLabel.Margin = new Padding(6, 0, 6, 0);
            CurrentAmountLabel.Name = "CurrentAmountLabel";
            CurrentAmountLabel.Size = new Size(230, 32);
            CurrentAmountLabel.TabIndex = 2;
            CurrentAmountLabel.Text = "Current Qty in Stock";
            // 
            // ItemNameTextBox
            // 
            ItemNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ItemNameTextBox.Location = new Point(189, 68);
            ItemNameTextBox.Margin = new Padding(6);
            ItemNameTextBox.Name = "ItemNameTextBox";
            ItemNameTextBox.Size = new Size(530, 50);
            ItemNameTextBox.TabIndex = 1;
            // 
            // ItemNameLabel
            // 
            ItemNameLabel.AutoSize = true;
            ItemNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ItemNameLabel.Location = new Point(11, 68);
            ItemNameLabel.Margin = new Padding(6, 0, 6, 0);
            ItemNameLabel.Name = "ItemNameLabel";
            ItemNameLabel.Size = new Size(186, 45);
            ItemNameLabel.TabIndex = 0;
            ItemNameLabel.Text = "Item Name:";
            // 
            // panelModeContainer
            // 
            panelModeContainer.Location = new Point(3, 1500);
            panelModeContainer.Name = "panelModeContainer";
            panelModeContainer.Size = new Size(752, 98);
            panelModeContainer.TabIndex = 7;
            // 
            // panelDefaultMode
            // 
            panelDefaultMode.Controls.Add(ExportCSVBtn);
            panelDefaultMode.Location = new Point(15, 0);
            panelDefaultMode.Name = "panelDefaultMode";
            panelDefaultMode.Size = new Size(377, 82);
            panelDefaultMode.TabIndex = 7;
            // 
            // ExportCSVBtn
            // 
            ExportCSVBtn.Location = new Point(60, 6);
            ExportCSVBtn.Name = "ExportCSVBtn";
            ExportCSVBtn.Size = new Size(250, 62);
            ExportCSVBtn.TabIndex = 7;
            ExportCSVBtn.Text = "CSV Export";
            ExportCSVBtn.UseVisualStyleBackColor = true;
            ExportCSVBtn.Click += ExportCSVBtn_Click;
            // 
            // SimPanel
            // 
            SimPanel.Controls.Add(panelDefaultMode);
            SimPanel.Controls.Add(SimDayBtn);
            SimPanel.Controls.Add(AddTestDataBtn);
            SimPanel.Location = new Point(344, 1529);
            SimPanel.Name = "SimPanel";
            SimPanel.Size = new Size(414, 95);
            SimPanel.TabIndex = 7;
            // 
            // SimDayBtn
            // 
            SimDayBtn.Location = new Point(15, 16);
            SimDayBtn.Margin = new Padding(6);
            SimDayBtn.Name = "SimDayBtn";
            SimDayBtn.Size = new Size(176, 49);
            SimDayBtn.TabIndex = 1;
            SimDayBtn.Text = "Simulate Day";
            SimDayBtn.UseVisualStyleBackColor = true;
            SimDayBtn.Visible = false;
            SimDayBtn.Click += SimDayBtn_Click;
            // 
            // AddTestDataBtn
            // 
            AddTestDataBtn.Location = new Point(225, 16);
            AddTestDataBtn.Margin = new Padding(6);
            AddTestDataBtn.Name = "AddTestDataBtn";
            AddTestDataBtn.Size = new Size(167, 49);
            AddTestDataBtn.TabIndex = 2;
            AddTestDataBtn.Text = "Add Test Data";
            AddTestDataBtn.UseVisualStyleBackColor = true;
            AddTestDataBtn.Visible = false;
            AddTestDataBtn.Click += AddTestDataBtn_Click;
            // 
            // ItemsListGroupBox
            // 
            ItemsListGroupBox.Controls.Add(SortByComboBox);
            ItemsListGroupBox.Controls.Add(RefreshButton);
            ItemsListGroupBox.Controls.Add(AddToOrderBtn);
            ItemsListGroupBox.Controls.Add(EditItemBtn);
            ItemsListGroupBox.Controls.Add(ItemSearchTextBox);
            ItemsListGroupBox.Controls.Add(SearchBtn);
            ItemsListGroupBox.Controls.Add(ItemsListBox);
            ItemsListGroupBox.Location = new Point(786, 26);
            ItemsListGroupBox.Margin = new Padding(6);
            ItemsListGroupBox.Name = "ItemsListGroupBox";
            ItemsListGroupBox.Padding = new Padding(6);
            ItemsListGroupBox.Size = new Size(752, 1562);
            ItemsListGroupBox.TabIndex = 4;
            ItemsListGroupBox.TabStop = false;
            ItemsListGroupBox.Text = "Items List";
            // 
            // SortByComboBox
            // 
            SortByComboBox.FormattingEnabled = true;
            SortByComboBox.Items.AddRange(new object[] { "Alphabetical (A to Z)", "Alphabetical (Z to A)", "Quantity (Low to High)", "Quantity (High to Low)", "Date Added (Newest)", "Date Added (Oldest)" });
            SortByComboBox.Location = new Point(11, 38);
            SortByComboBox.Margin = new Padding(6, 4, 6, 4);
            SortByComboBox.Name = "SortByComboBox";
            SortByComboBox.Size = new Size(548, 40);
            SortByComboBox.TabIndex = 6;
            SortByComboBox.Text = "Sort By";
            SortByComboBox.SelectedIndexChanged += SortByComboBox_SelectedIndexChanged;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(602, 36);
            RefreshButton.Margin = new Padding(6, 4, 6, 4);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(139, 47);
            RefreshButton.TabIndex = 5;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButtonClick;
            // 
            // AddToOrderBtn
            // 
            AddToOrderBtn.Location = new Point(11, 1491);
            AddToOrderBtn.Margin = new Padding(6);
            AddToOrderBtn.Name = "AddToOrderBtn";
            AddToOrderBtn.Size = new Size(730, 49);
            AddToOrderBtn.TabIndex = 4;
            AddToOrderBtn.Text = "Add The Selected Item To A Pending Order";
            AddToOrderBtn.UseVisualStyleBackColor = true;
            AddToOrderBtn.Click += AddToOrderBtn_Click;
            // 
            // EditItemBtn
            // 
            EditItemBtn.Location = new Point(11, 1429);
            EditItemBtn.Margin = new Padding(6);
            EditItemBtn.Name = "EditItemBtn";
            EditItemBtn.Size = new Size(730, 49);
            EditItemBtn.TabIndex = 3;
            EditItemBtn.Text = "Edit The Highlighted Item";
            EditItemBtn.UseVisualStyleBackColor = true;
            EditItemBtn.Click += EditItemBtn_Click;
            // 
            // ItemSearchTextBox
            // 
            ItemSearchTextBox.Location = new Point(11, 1367);
            ItemSearchTextBox.Margin = new Padding(6);
            ItemSearchTextBox.Name = "ItemSearchTextBox";
            ItemSearchTextBox.Size = new Size(576, 39);
            ItemSearchTextBox.TabIndex = 2;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(602, 1365);
            SearchBtn.Margin = new Padding(6);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(139, 49);
            SearchBtn.TabIndex = 1;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // ItemsListBox
            // 
            ItemsListBox.FormattingEnabled = true;
            ItemsListBox.Location = new Point(11, 115);
            ItemsListBox.Margin = new Padding(6);
            ItemsListBox.Name = "ItemsListBox";
            ItemsListBox.Size = new Size(726, 1220);
            ItemsListBox.TabIndex = 0;
            ItemsListBox.SelectedIndexChanged += ItemsListBox_SelectedIndexChanged;
            ItemsListBox.Format += ItemsListBox_Format;
            // 
            // PendingOrdersGroupBox
            // 
            PendingOrdersGroupBox.Controls.Add(SubmitPendingOrderButton);
            PendingOrdersGroupBox.Controls.Add(DeletePendingOrderBtn);
            PendingOrdersGroupBox.Controls.Add(PendingOrderListBox);
            PendingOrdersGroupBox.Location = new Point(1549, 26);
            PendingOrdersGroupBox.Margin = new Padding(6);
            PendingOrdersGroupBox.Name = "PendingOrdersGroupBox";
            PendingOrdersGroupBox.Padding = new Padding(6);
            PendingOrdersGroupBox.Size = new Size(752, 297);
            PendingOrdersGroupBox.TabIndex = 4;
            PendingOrdersGroupBox.TabStop = false;
            PendingOrdersGroupBox.Text = "Pending Orders";
            // 
            // SubmitPendingOrderButton
            // 
            SubmitPendingOrderButton.Location = new Point(24, 228);
            SubmitPendingOrderButton.Margin = new Padding(6);
            SubmitPendingOrderButton.Name = "SubmitPendingOrderButton";
            SubmitPendingOrderButton.Size = new Size(349, 49);
            SubmitPendingOrderButton.TabIndex = 5;
            SubmitPendingOrderButton.Text = "Submit Selected Pending Order";
            SubmitPendingOrderButton.UseVisualStyleBackColor = true;
            SubmitPendingOrderButton.Click += SubmitPendingOrderButton_Click;
            // 
            // DeletePendingOrderBtn
            // 
            DeletePendingOrderBtn.Location = new Point(381, 228);
            DeletePendingOrderBtn.Margin = new Padding(6);
            DeletePendingOrderBtn.Name = "DeletePendingOrderBtn";
            DeletePendingOrderBtn.Size = new Size(349, 49);
            DeletePendingOrderBtn.TabIndex = 4;
            DeletePendingOrderBtn.Text = "Delete Selected Pending Order";
            DeletePendingOrderBtn.UseVisualStyleBackColor = true;
            DeletePendingOrderBtn.Click += DeletePendingOrderBtn_Click;
            // 
            // PendingOrderListBox
            // 
            PendingOrderListBox.FormattingEnabled = true;
            PendingOrderListBox.Location = new Point(11, 47);
            PendingOrderListBox.Margin = new Padding(6);
            PendingOrderListBox.Name = "PendingOrderListBox";
            PendingOrderListBox.Size = new Size(726, 164);
            PendingOrderListBox.TabIndex = 0;
            PendingOrderListBox.SelectedIndexChanged += PendingOrderListBox_SelectedIndexChanged;
            // 
            // CurrentOrdersGroupBox
            // 
            CurrentOrdersGroupBox.Controls.Add(CurrentOrdersListBox);
            CurrentOrdersGroupBox.Location = new Point(1549, 335);
            CurrentOrdersGroupBox.Margin = new Padding(6);
            CurrentOrdersGroupBox.Name = "CurrentOrdersGroupBox";
            CurrentOrdersGroupBox.Padding = new Padding(6);
            CurrentOrdersGroupBox.Size = new Size(752, 787);
            CurrentOrdersGroupBox.TabIndex = 5;
            CurrentOrdersGroupBox.TabStop = false;
            CurrentOrdersGroupBox.Text = "Currently Active Orders";
            // 
            // CurrentOrdersListBox
            // 
            CurrentOrdersListBox.FormattingEnabled = true;
            CurrentOrdersListBox.Location = new Point(11, 47);
            CurrentOrdersListBox.Margin = new Padding(6);
            CurrentOrdersListBox.Name = "CurrentOrdersListBox";
            CurrentOrdersListBox.Size = new Size(704, 708);
            CurrentOrdersListBox.TabIndex = 0;
            // 
            // OrderItemsGroupBox
            // 
            OrderItemsGroupBox.Controls.Add(OrderItemsListBox);
            OrderItemsGroupBox.Location = new Point(1549, 1135);
            OrderItemsGroupBox.Margin = new Padding(6);
            OrderItemsGroupBox.Name = "OrderItemsGroupBox";
            OrderItemsGroupBox.Padding = new Padding(6);
            OrderItemsGroupBox.Size = new Size(752, 395);
            OrderItemsGroupBox.TabIndex = 1;
            OrderItemsGroupBox.TabStop = false;
            OrderItemsGroupBox.Text = "Items In Selected Order";
            // 
            // OrderItemsListBox
            // 
            OrderItemsListBox.FormattingEnabled = true;
            OrderItemsListBox.Location = new Point(11, 47);
            OrderItemsListBox.Margin = new Padding(6);
            OrderItemsListBox.Name = "OrderItemsListBox";
            OrderItemsListBox.Size = new Size(704, 324);
            OrderItemsListBox.TabIndex = 0;
            OrderItemsListBox.SelectedIndexChanged += OrderItemsListBox_SelectedIndexChanged;
            OrderItemsListBox.Format += OrderItemsListBox_Format;
            // 
            // EditOrderAmtTextBox
            // 
            EditOrderAmtTextBox.Enabled = false;
            EditOrderAmtTextBox.Location = new Point(1560, 1538);
            EditOrderAmtTextBox.Margin = new Padding(6);
            EditOrderAmtTextBox.Name = "EditOrderAmtTextBox";
            EditOrderAmtTextBox.Size = new Size(141, 39);
            EditOrderAmtTextBox.TabIndex = 2;
            // 
            // EditOrderAmtBtn
            // 
            EditOrderAmtBtn.Enabled = false;
            EditOrderAmtBtn.Location = new Point(1716, 1536);
            EditOrderAmtBtn.Margin = new Padding(6);
            EditOrderAmtBtn.Name = "EditOrderAmtBtn";
            EditOrderAmtBtn.Size = new Size(321, 49);
            EditOrderAmtBtn.TabIndex = 3;
            EditOrderAmtBtn.Text = "Update Item's Order Quantity";
            EditOrderAmtBtn.UseVisualStyleBackColor = true;
            EditOrderAmtBtn.Click += EditOrderAmtBtn_Click;
            // 
            // OrderRecievedBtn
            // 
            OrderRecievedBtn.Enabled = false;
            OrderRecievedBtn.Location = new Point(2048, 1536);
            OrderRecievedBtn.Margin = new Padding(6);
            OrderRecievedBtn.Name = "OrderRecievedBtn";
            OrderRecievedBtn.Size = new Size(219, 49);
            OrderRecievedBtn.TabIndex = 6;
            OrderRecievedBtn.Text = "Order Recieved";
            OrderRecievedBtn.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2347, 1623);
            Controls.Add(SimPanel);
            Controls.Add(EnableTestModeChkbx);
            Controls.Add(OrderRecievedBtn);
            Controls.Add(CurrentOrdersGroupBox);
            Controls.Add(EditOrderAmtBtn);
            Controls.Add(PendingOrdersGroupBox);
            Controls.Add(EditOrderAmtTextBox);
            Controls.Add(ItemsListGroupBox);
            Controls.Add(OrderItemsGroupBox);
            Controls.Add(ItemInfoGroupBox);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(6);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Reorder Point System";
            Load += MainForm_Load;
            ItemInfoGroupBox.ResumeLayout(false);
            ItemInfoGroupBox.PerformLayout();
            ItemDescriptionGroupBox.ResumeLayout(false);
            panelDefaultMode.ResumeLayout(false);
            SimPanel.ResumeLayout(false);
            ItemsListGroupBox.ResumeLayout(false);
            ItemsListGroupBox.PerformLayout();
            PendingOrdersGroupBox.ResumeLayout(false);
            CurrentOrdersGroupBox.ResumeLayout(false);
            OrderItemsGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox EnableTestModeChkbx;
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
        private Label ItemDescriptionLabel;
        private ListBox ItemsListBox;
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
        private ListBox OrderItemsListBox;
        private Button AddToOrderBtn;
        private ListBox CurrentOrdersListBox;
        private Button RefreshButton;
        private ComboBox SortByComboBox;
        private Button SubmitPendingOrderButton;
        private Button OrderRecievedBtn;
        private Label CategoryComboBoxLabel;
        private ComboBox CategoryComboBox;
        private Panel panelDefaultMode;
        private Button ExportCSVBtn;
        private Button SimDayBtn;
        private Button AddTestDataBtn;
        private Panel panelModeContainer;
        private Panel SimPanel;
    }
}

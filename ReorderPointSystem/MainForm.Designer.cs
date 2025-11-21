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
            ItemsListGroupBox = new GroupBox();
            SortByComboBox = new ComboBox();
            RefreshButton = new Button();
            AddToOrderBtn = new Button();
            EditItemBtn = new Button();
            ItemSearchTextBox = new TextBox();
            SearchBtn = new Button();
            ItemsListBox = new ListBox();
            PendingOrdersGroupBox = new GroupBox();
            DeletePendingOrderBtn = new Button();
            PendingOrderListBox = new ListBox();
            CurrentOrdersGroupBox = new GroupBox();
            CurrentOrdersListBox = new ListBox();
            OrderItemsGroupBox = new GroupBox();
            OrderItemsListBox = new ListBox();
            EditOrderAmtTextBox = new TextBox();
            EditOrderAmtBtn = new Button();
            ItemInfoGroupBox.SuspendLayout();
            ItemDescriptionGroupBox.SuspendLayout();
            ItemsListGroupBox.SuspendLayout();
            PendingOrdersGroupBox.SuspendLayout();
            CurrentOrdersGroupBox.SuspendLayout();
            OrderItemsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // EnableTestModeChkbx
            // 
            EnableTestModeChkbx.AutoSize = true;
            EnableTestModeChkbx.Location = new Point(21, 969);
            EnableTestModeChkbx.Margin = new Padding(3, 4, 3, 4);
            EnableTestModeChkbx.Name = "EnableTestModeChkbx";
            EnableTestModeChkbx.Size = new Size(205, 24);
            EnableTestModeChkbx.TabIndex = 0;
            EnableTestModeChkbx.Text = "Enable Simulation  Mode?";
            EnableTestModeChkbx.UseVisualStyleBackColor = true;
            EnableTestModeChkbx.CheckedChanged += EnableTestModeChkbx_CheckedChanged;
            // 
            // SimDayBtn
            // 
            SimDayBtn.Location = new Point(214, 964);
            SimDayBtn.Margin = new Padding(3, 4, 3, 4);
            SimDayBtn.Name = "SimDayBtn";
            SimDayBtn.Size = new Size(109, 31);
            SimDayBtn.TabIndex = 1;
            SimDayBtn.Text = "Simulate Day";
            SimDayBtn.UseVisualStyleBackColor = true;
            SimDayBtn.Visible = false;
            SimDayBtn.Click += SimDayBtn_Click;
            // 
            // AddTestDataBtn
            // 
            AddTestDataBtn.Location = new Point(329, 964);
            AddTestDataBtn.Margin = new Padding(3, 4, 3, 4);
            AddTestDataBtn.Name = "AddTestDataBtn";
            AddTestDataBtn.Size = new Size(129, 31);
            AddTestDataBtn.TabIndex = 2;
            AddTestDataBtn.Text = "Add Test DB Data";
            AddTestDataBtn.UseVisualStyleBackColor = true;
            AddTestDataBtn.Visible = false;
            AddTestDataBtn.Click += AddTestDataBtn_Click;
            // 
            // ItemInfoGroupBox
            // 
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
            ItemInfoGroupBox.Location = new Point(14, 16);
            ItemInfoGroupBox.Margin = new Padding(3, 4, 3, 4);
            ItemInfoGroupBox.Name = "ItemInfoGroupBox";
            ItemInfoGroupBox.Padding = new Padding(3, 4, 3, 4);
            ItemInfoGroupBox.Size = new Size(463, 940);
            ItemInfoGroupBox.TabIndex = 3;
            ItemInfoGroupBox.TabStop = false;
            ItemInfoGroupBox.Text = "Item Info";
            // 
            // EnableReorderLabel
            // 
            EnableReorderLabel.AutoSize = true;
            EnableReorderLabel.Location = new Point(117, 92);
            EnableReorderLabel.Name = "EnableReorderLabel";
            EnableReorderLabel.Size = new Size(347, 20);
            EnableReorderLabel.TabIndex = 13;
            EnableReorderLabel.Text = "Selected Item Allows Automatic Reorder Flagging?";
            // 
            // EnableReorderChkbx
            // 
            EnableReorderChkbx.AutoSize = true;
            EnableReorderChkbx.Location = new Point(75, 93);
            EnableReorderChkbx.Margin = new Padding(3, 4, 3, 4);
            EnableReorderChkbx.Name = "EnableReorderChkbx";
            EnableReorderChkbx.Size = new Size(18, 17);
            EnableReorderChkbx.TabIndex = 12;
            EnableReorderChkbx.UseVisualStyleBackColor = true;
            // 
            // DeleteItemBtn
            // 
            DeleteItemBtn.Location = new Point(307, 853);
            DeleteItemBtn.Margin = new Padding(3, 4, 3, 4);
            DeleteItemBtn.Name = "DeleteItemBtn";
            DeleteItemBtn.Size = new Size(130, 79);
            DeleteItemBtn.TabIndex = 11;
            DeleteItemBtn.Text = "Delete Item";
            DeleteItemBtn.UseVisualStyleBackColor = true;
            DeleteItemBtn.Click += DeleteItemBtn_Click;
            // 
            // ClearFieldsBtn
            // 
            ClearFieldsBtn.Location = new Point(157, 853);
            ClearFieldsBtn.Margin = new Padding(3, 4, 3, 4);
            ClearFieldsBtn.Name = "ClearFieldsBtn";
            ClearFieldsBtn.Size = new Size(130, 79);
            ClearFieldsBtn.TabIndex = 10;
            ClearFieldsBtn.Text = "Clear";
            ClearFieldsBtn.UseVisualStyleBackColor = true;
            ClearFieldsBtn.Click += ClearFieldsBtn_Click;
            // 
            // SubmitItemBtn
            // 
            SubmitItemBtn.Location = new Point(7, 853);
            SubmitItemBtn.Margin = new Padding(3, 4, 3, 4);
            SubmitItemBtn.Name = "SubmitItemBtn";
            SubmitItemBtn.Size = new Size(130, 79);
            SubmitItemBtn.TabIndex = 9;
            SubmitItemBtn.Text = "Submit";
            SubmitItemBtn.UseVisualStyleBackColor = true;
            SubmitItemBtn.Click += SubmitItemBtn_Click;
            // 
            // ItemDescriptionGroupBox
            // 
            ItemDescriptionGroupBox.Controls.Add(ItemDescriptionLabel);
            ItemDescriptionGroupBox.Location = new Point(7, 212);
            ItemDescriptionGroupBox.Margin = new Padding(3, 4, 3, 4);
            ItemDescriptionGroupBox.Name = "ItemDescriptionGroupBox";
            ItemDescriptionGroupBox.Padding = new Padding(3, 4, 3, 4);
            ItemDescriptionGroupBox.Size = new Size(449, 633);
            ItemDescriptionGroupBox.TabIndex = 8;
            ItemDescriptionGroupBox.TabStop = false;
            ItemDescriptionGroupBox.Text = "Item Description";
            // 
            // ItemDescriptionLabel
            // 
            ItemDescriptionLabel.Location = new Point(7, 25);
            ItemDescriptionLabel.Name = "ItemDescriptionLabel";
            ItemDescriptionLabel.Size = new Size(431, 589);
            ItemDescriptionLabel.TabIndex = 0;
            // 
            // ReorderMaxTextBox
            // 
            ReorderMaxTextBox.Location = new Point(307, 155);
            ReorderMaxTextBox.Margin = new Padding(3, 4, 3, 4);
            ReorderMaxTextBox.Name = "ReorderMaxTextBox";
            ReorderMaxTextBox.Size = new Size(130, 27);
            ReorderMaxTextBox.TabIndex = 7;
            ReorderMaxTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ReorderPointTextBox
            // 
            ReorderPointTextBox.Location = new Point(157, 155);
            ReorderPointTextBox.Margin = new Padding(3, 4, 3, 4);
            ReorderPointTextBox.Name = "ReorderPointTextBox";
            ReorderPointTextBox.Size = new Size(130, 27);
            ReorderPointTextBox.TabIndex = 6;
            ReorderPointTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // CurrentQtyTextBox
            // 
            CurrentQtyTextBox.Location = new Point(7, 155);
            CurrentQtyTextBox.Margin = new Padding(3, 4, 3, 4);
            CurrentQtyTextBox.Name = "CurrentQtyTextBox";
            CurrentQtyTextBox.Size = new Size(130, 27);
            CurrentQtyTextBox.TabIndex = 5;
            CurrentQtyTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // MaxAmtLabel
            // 
            MaxAmtLabel.AutoSize = true;
            MaxAmtLabel.Location = new Point(304, 131);
            MaxAmtLabel.Name = "MaxAmtLabel";
            MaxAmtLabel.Size = new Size(151, 20);
            MaxAmtLabel.TabIndex = 4;
            MaxAmtLabel.Text = "Reorder Max Amount";
            // 
            // ReorderPointLabel
            // 
            ReorderPointLabel.AutoSize = true;
            ReorderPointLabel.Location = new Point(176, 131);
            ReorderPointLabel.Name = "ReorderPointLabel";
            ReorderPointLabel.Size = new Size(99, 20);
            ReorderPointLabel.TabIndex = 3;
            ReorderPointLabel.Text = "Reorder Point";
            // 
            // CurrentAmountLabel
            // 
            CurrentAmountLabel.AutoSize = true;
            CurrentAmountLabel.Location = new Point(7, 131);
            CurrentAmountLabel.Name = "CurrentAmountLabel";
            CurrentAmountLabel.Size = new Size(140, 20);
            CurrentAmountLabel.TabIndex = 2;
            CurrentAmountLabel.Text = "Current Qty in Stock";
            // 
            // ItemNameTextBox
            // 
            ItemNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ItemNameTextBox.Location = new Point(117, 43);
            ItemNameTextBox.Margin = new Padding(3, 4, 3, 4);
            ItemNameTextBox.Name = "ItemNameTextBox";
            ItemNameTextBox.Size = new Size(327, 34);
            ItemNameTextBox.TabIndex = 1;
            // 
            // ItemNameLabel
            // 
            ItemNameLabel.AutoSize = true;
            ItemNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ItemNameLabel.Location = new Point(7, 43);
            ItemNameLabel.Name = "ItemNameLabel";
            ItemNameLabel.Size = new Size(112, 28);
            ItemNameLabel.TabIndex = 0;
            ItemNameLabel.Text = "Item Name:";
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
            ItemsListGroupBox.Location = new Point(483, 16);
            ItemsListGroupBox.Margin = new Padding(3, 4, 3, 4);
            ItemsListGroupBox.Name = "ItemsListGroupBox";
            ItemsListGroupBox.Padding = new Padding(3, 4, 3, 4);
            ItemsListGroupBox.Size = new Size(463, 976);
            ItemsListGroupBox.TabIndex = 4;
            ItemsListGroupBox.TabStop = false;
            ItemsListGroupBox.Text = "Items List";
            // 
            // SortByComboBox
            // 
            SortByComboBox.FormattingEnabled = true;
            SortByComboBox.Items.AddRange(new object[] { "Alphabetical (A to Z)", "Alphabetical (Z to A)", "Quantity (Low to High)", "Quantity (High to Low)", "Date Added (Newest)", "Date Added (Oldest)" });
            SortByComboBox.Location = new Point(7, 24);
            SortByComboBox.Name = "SortByComboBox";
            SortByComboBox.Size = new Size(339, 28);
            SortByComboBox.TabIndex = 6;
            SortByComboBox.Text = "Sort By";
            SortByComboBox.SelectedIndexChanged += SortByComboBox_SelectedIndexChanged;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(379, 23);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(77, 29);
            RefreshButton.TabIndex = 5;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButtonClick;
            // 
            // AddToOrderBtn
            // 
            AddToOrderBtn.Location = new Point(7, 932);
            AddToOrderBtn.Margin = new Padding(3, 4, 3, 4);
            AddToOrderBtn.Name = "AddToOrderBtn";
            AddToOrderBtn.Size = new Size(449, 31);
            AddToOrderBtn.TabIndex = 4;
            AddToOrderBtn.Text = "Add The Selected Item To A Pending Order";
            AddToOrderBtn.UseVisualStyleBackColor = true;
            AddToOrderBtn.Click += AddToOrderBtn_Click;
            // 
            // EditItemBtn
            // 
            EditItemBtn.Location = new Point(7, 893);
            EditItemBtn.Margin = new Padding(3, 4, 3, 4);
            EditItemBtn.Name = "EditItemBtn";
            EditItemBtn.Size = new Size(449, 31);
            EditItemBtn.TabIndex = 3;
            EditItemBtn.Text = "Edit The Highlighted Item";
            EditItemBtn.UseVisualStyleBackColor = true;
            EditItemBtn.Click += EditItemBtn_Click;
            // 
            // ItemSearchTextBox
            // 
            ItemSearchTextBox.Location = new Point(7, 855);
            ItemSearchTextBox.Margin = new Padding(3, 4, 3, 4);
            ItemSearchTextBox.Name = "ItemSearchTextBox";
            ItemSearchTextBox.Size = new Size(356, 27);
            ItemSearchTextBox.TabIndex = 2;
            // 
            // SearchBtn
            // 
            SearchBtn.Location = new Point(370, 853);
            SearchBtn.Margin = new Padding(3, 4, 3, 4);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(86, 31);
            SearchBtn.TabIndex = 1;
            SearchBtn.Text = "Search";
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // ItemsListBox
            // 
            ItemsListBox.FormattingEnabled = true;
            ItemsListBox.Location = new Point(7, 59);
            ItemsListBox.Margin = new Padding(3, 4, 3, 4);
            ItemsListBox.Name = "ItemsListBox";
            ItemsListBox.Size = new Size(449, 784);
            ItemsListBox.TabIndex = 0;
            // 
            // PendingOrdersGroupBox
            // 
            PendingOrdersGroupBox.Controls.Add(DeletePendingOrderBtn);
            PendingOrdersGroupBox.Controls.Add(PendingOrderListBox);
            PendingOrdersGroupBox.Location = new Point(953, 16);
            PendingOrdersGroupBox.Margin = new Padding(3, 4, 3, 4);
            PendingOrdersGroupBox.Name = "PendingOrdersGroupBox";
            PendingOrdersGroupBox.Padding = new Padding(3, 4, 3, 4);
            PendingOrdersGroupBox.Size = new Size(463, 185);
            PendingOrdersGroupBox.TabIndex = 4;
            PendingOrdersGroupBox.TabStop = false;
            PendingOrdersGroupBox.Text = "Pending Orders";
            // 
            // DeletePendingOrderBtn
            // 
            DeletePendingOrderBtn.Location = new Point(7, 143);
            DeletePendingOrderBtn.Margin = new Padding(3, 4, 3, 4);
            DeletePendingOrderBtn.Name = "DeletePendingOrderBtn";
            DeletePendingOrderBtn.Size = new Size(449, 31);
            DeletePendingOrderBtn.TabIndex = 4;
            DeletePendingOrderBtn.Text = "Delete Selected Pending Order";
            DeletePendingOrderBtn.UseVisualStyleBackColor = true;
            DeletePendingOrderBtn.Click += DeletePendingOrderBtn_Click;
            // 
            // PendingOrderListBox
            // 
            PendingOrderListBox.FormattingEnabled = true;
            PendingOrderListBox.Location = new Point(7, 29);
            PendingOrderListBox.Margin = new Padding(3, 4, 3, 4);
            PendingOrderListBox.Name = "PendingOrderListBox";
            PendingOrderListBox.Size = new Size(449, 104);
            PendingOrderListBox.TabIndex = 0;
            // 
            // CurrentOrdersGroupBox
            // 
            CurrentOrdersGroupBox.Controls.Add(CurrentOrdersListBox);
            CurrentOrdersGroupBox.Location = new Point(953, 209);
            CurrentOrdersGroupBox.Margin = new Padding(3, 4, 3, 4);
            CurrentOrdersGroupBox.Name = "CurrentOrdersGroupBox";
            CurrentOrdersGroupBox.Padding = new Padding(3, 4, 3, 4);
            CurrentOrdersGroupBox.Size = new Size(463, 492);
            CurrentOrdersGroupBox.TabIndex = 5;
            CurrentOrdersGroupBox.TabStop = false;
            CurrentOrdersGroupBox.Text = "Currently Active Orders";
            // 
            // CurrentOrdersListBox
            // 
            CurrentOrdersListBox.FormattingEnabled = true;
            CurrentOrdersListBox.Location = new Point(7, 29);
            CurrentOrdersListBox.Margin = new Padding(3, 4, 3, 4);
            CurrentOrdersListBox.Name = "CurrentOrdersListBox";
            CurrentOrdersListBox.Size = new Size(435, 444);
            CurrentOrdersListBox.TabIndex = 0;
            // 
            // OrderItemsGroupBox
            // 
            OrderItemsGroupBox.Controls.Add(OrderItemsListBox);
            OrderItemsGroupBox.Location = new Point(953, 709);
            OrderItemsGroupBox.Margin = new Padding(3, 4, 3, 4);
            OrderItemsGroupBox.Name = "OrderItemsGroupBox";
            OrderItemsGroupBox.Padding = new Padding(3, 4, 3, 4);
            OrderItemsGroupBox.Size = new Size(463, 247);
            OrderItemsGroupBox.TabIndex = 1;
            OrderItemsGroupBox.TabStop = false;
            OrderItemsGroupBox.Text = "Items In Selected Order";
            // 
            // OrderItemsListBox
            // 
            OrderItemsListBox.FormattingEnabled = true;
            OrderItemsListBox.Location = new Point(7, 29);
            OrderItemsListBox.Margin = new Padding(3, 4, 3, 4);
            OrderItemsListBox.Name = "OrderItemsListBox";
            OrderItemsListBox.Size = new Size(435, 204);
            OrderItemsListBox.TabIndex = 0;
            // 
            // EditOrderAmtTextBox
            // 
            EditOrderAmtTextBox.Enabled = false;
            EditOrderAmtTextBox.Location = new Point(1010, 963);
            EditOrderAmtTextBox.Margin = new Padding(3, 4, 3, 4);
            EditOrderAmtTextBox.Name = "EditOrderAmtTextBox";
            EditOrderAmtTextBox.Size = new Size(89, 27);
            EditOrderAmtTextBox.TabIndex = 2;
            // 
            // EditOrderAmtBtn
            // 
            EditOrderAmtBtn.Enabled = false;
            EditOrderAmtBtn.Location = new Point(1151, 961);
            EditOrderAmtBtn.Margin = new Padding(3, 4, 3, 4);
            EditOrderAmtBtn.Name = "EditOrderAmtBtn";
            EditOrderAmtBtn.Size = new Size(198, 31);
            EditOrderAmtBtn.TabIndex = 3;
            EditOrderAmtBtn.Text = "Update Item's Order Quantity";
            EditOrderAmtBtn.UseVisualStyleBackColor = true;
            EditOrderAmtBtn.Click += EditOrderAmtBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1445, 1015);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ItemInfoGroupBox.ResumeLayout(false);
            ItemInfoGroupBox.PerformLayout();
            ItemDescriptionGroupBox.ResumeLayout(false);
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
    }
}

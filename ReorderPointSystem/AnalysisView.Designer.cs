namespace ReorderPointSystem
{
    partial class AnalysisView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            historyGrid = new DataGridView();
            groupBox1 = new GroupBox();
            label5 = new Label();
            historyRecentGainsGrid = new DataGridView();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label4 = new Label();
            predictionExponentialGrid = new DataGridView();
            label3 = new Label();
            predictionParabolicGrid = new DataGridView();
            label2 = new Label();
            predictionLinearGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)historyGrid).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)historyRecentGainsGrid).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)predictionExponentialGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)predictionParabolicGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)predictionLinearGrid).BeginInit();
            SuspendLayout();
            // 
            // historyGrid
            // 
            historyGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            historyGrid.Location = new Point(6, 37);
            historyGrid.Name = "historyGrid";
            historyGrid.Size = new Size(602, 280);
            historyGrid.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(historyRecentGainsGrid);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(historyGrid);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(614, 532);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "History";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 320);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 7;
            label5.Text = "Gains";
            // 
            // historyRecentGainsGrid
            // 
            historyRecentGainsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            historyRecentGainsGrid.Location = new Point(6, 338);
            historyRecentGainsGrid.Name = "historyRecentGainsGrid";
            historyRecentGainsGrid.Size = new Size(602, 141);
            historyRecentGainsGrid.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 19);
            label1.Name = "label1";
            label1.Size = new Size(242, 15);
            label1.TabIndex = 1;
            label1.Text = "Full log, including start state and current day";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(predictionExponentialGrid);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(predictionParabolicGrid);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(predictionLinearGrid);
            groupBox2.Location = new Point(632, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(614, 509);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Projected growth for tomorrow";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 343);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 5;
            label4.Text = "Exponential";
            // 
            // predictionExponentialGrid
            // 
            predictionExponentialGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            predictionExponentialGrid.Location = new Point(6, 361);
            predictionExponentialGrid.Name = "predictionExponentialGrid";
            predictionExponentialGrid.Size = new Size(602, 141);
            predictionExponentialGrid.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 181);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 3;
            label3.Text = "Parabolic";
            // 
            // predictionParabolicGrid
            // 
            predictionParabolicGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            predictionParabolicGrid.Location = new Point(6, 199);
            predictionParabolicGrid.Name = "predictionParabolicGrid";
            predictionParabolicGrid.Size = new Size(602, 141);
            predictionParabolicGrid.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 19);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Linear";
            // 
            // predictionLinearGrid
            // 
            predictionLinearGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            predictionLinearGrid.Location = new Point(6, 37);
            predictionLinearGrid.Name = "predictionLinearGrid";
            predictionLinearGrid.Size = new Size(602, 141);
            predictionLinearGrid.TabIndex = 0;
            // 
            // AnalysisView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 605);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "AnalysisView";
            Text = "AnalysisView";
            ((System.ComponentModel.ISupportInitialize)historyGrid).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)historyRecentGainsGrid).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)predictionExponentialGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)predictionParabolicGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)predictionLinearGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView historyGrid;
        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox2;
        private Label label4;
        private DataGridView predictionExponentialGrid;
        private Label label3;
        private DataGridView predictionParabolicGrid;
        private Label label2;
        private DataGridView predictionLinearGrid;
        private Label label5;
        private DataGridView historyRecentGainsGrid;
    }
}
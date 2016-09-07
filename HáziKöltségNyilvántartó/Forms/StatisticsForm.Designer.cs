namespace HáziKöltségNyilvántartó
{
    partial class StatisticsForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statisticsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthlySpendingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthlyIncomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthlyDifferenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.monthDataGridViewTextBoxColumn,
            this.monthlySpendingDataGridViewTextBoxColumn,
            this.monthlyIncomeDataGridViewTextBoxColumn,
            this.monthlyDifferenceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.statisticsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(23, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(886, 194);
            this.dataGridView1.TabIndex = 0;
            // 
            // statisticsBindingSource
            // 
            this.statisticsBindingSource.DataSource = typeof(HáziKöltségNyilvántartó.Statistics);
            // 
            // monthDataGridViewTextBoxColumn
            // 
            this.monthDataGridViewTextBoxColumn.DataPropertyName = "Month";
            this.monthDataGridViewTextBoxColumn.HeaderText = "Month";
            this.monthDataGridViewTextBoxColumn.Name = "monthDataGridViewTextBoxColumn";
            // 
            // monthlySpendingDataGridViewTextBoxColumn
            // 
            this.monthlySpendingDataGridViewTextBoxColumn.DataPropertyName = "MonthlySpending";
            this.monthlySpendingDataGridViewTextBoxColumn.HeaderText = "MonthlySpending";
            this.monthlySpendingDataGridViewTextBoxColumn.Name = "monthlySpendingDataGridViewTextBoxColumn";
            // 
            // monthlyIncomeDataGridViewTextBoxColumn
            // 
            this.monthlyIncomeDataGridViewTextBoxColumn.DataPropertyName = "MonthlyIncome";
            this.monthlyIncomeDataGridViewTextBoxColumn.HeaderText = "MonthlyIncome";
            this.monthlyIncomeDataGridViewTextBoxColumn.Name = "monthlyIncomeDataGridViewTextBoxColumn";
            // 
            // monthlyDifferenceDataGridViewTextBoxColumn
            // 
            this.monthlyDifferenceDataGridViewTextBoxColumn.DataPropertyName = "MonthlyDifference";
            this.monthlyDifferenceDataGridViewTextBoxColumn.HeaderText = "MonthlyDifference";
            this.monthlyDifferenceDataGridViewTextBoxColumn.Name = "monthlyDifferenceDataGridViewTextBoxColumn";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 402);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StatisticsForm";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthlySpendingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthlyIncomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthlyDifferenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource statisticsBindingSource;
    }
}
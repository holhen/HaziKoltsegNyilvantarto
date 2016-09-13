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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.categoryNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalByCategoryDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryPercentageDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryStatisticsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.categoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalByCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryPercentageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryStatisticsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthlySpendingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthlyIncomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthlyDifferenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statisticsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryStatisticsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryStatisticsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.monthDataGridViewTextBoxColumn,
            this.monthlySpendingDataGridViewTextBoxColumn,
            this.monthlyIncomeDataGridViewTextBoxColumn,
            this.monthlyDifferenceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.statisticsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(23, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1131, 194);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryNameDataGridViewTextBoxColumn,
            this.totalByCategoryDataGridViewTextBoxColumn,
            this.categoryPercentageDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.categoryStatisticsBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(23, 299);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(432, 206);
            this.dataGridView2.TabIndex = 1;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryNameDataGridViewTextBoxColumn1,
            this.totalByCategoryDataGridViewTextBoxColumn1,
            this.categoryPercentageDataGridViewTextBoxColumn1});
            this.dataGridView3.DataSource = this.categoryStatisticsBindingSource2;
            this.dataGridView3.Location = new System.Drawing.Point(688, 301);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(466, 204);
            this.dataGridView3.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(32, 558);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // categoryNameDataGridViewTextBoxColumn1
            // 
            this.categoryNameDataGridViewTextBoxColumn1.DataPropertyName = "CategoryName";
            this.categoryNameDataGridViewTextBoxColumn1.HeaderText = "CategoryName";
            this.categoryNameDataGridViewTextBoxColumn1.Name = "categoryNameDataGridViewTextBoxColumn1";
            // 
            // totalByCategoryDataGridViewTextBoxColumn1
            // 
            this.totalByCategoryDataGridViewTextBoxColumn1.DataPropertyName = "TotalByCategory";
            this.totalByCategoryDataGridViewTextBoxColumn1.HeaderText = "TotalByCategory";
            this.totalByCategoryDataGridViewTextBoxColumn1.Name = "totalByCategoryDataGridViewTextBoxColumn1";
            // 
            // categoryPercentageDataGridViewTextBoxColumn1
            // 
            this.categoryPercentageDataGridViewTextBoxColumn1.DataPropertyName = "CategoryPercentage";
            this.categoryPercentageDataGridViewTextBoxColumn1.HeaderText = "CategoryPercentage";
            this.categoryPercentageDataGridViewTextBoxColumn1.Name = "categoryPercentageDataGridViewTextBoxColumn1";
            // 
            // categoryStatisticsBindingSource2
            // 
            this.categoryStatisticsBindingSource2.DataSource = typeof(HáziKöltségNyilvántartó.CategoryStatistics);
            // 
            // categoryNameDataGridViewTextBoxColumn
            // 
            this.categoryNameDataGridViewTextBoxColumn.DataPropertyName = "CategoryName";
            this.categoryNameDataGridViewTextBoxColumn.HeaderText = "CategoryName";
            this.categoryNameDataGridViewTextBoxColumn.Name = "categoryNameDataGridViewTextBoxColumn";
            // 
            // totalByCategoryDataGridViewTextBoxColumn
            // 
            this.totalByCategoryDataGridViewTextBoxColumn.DataPropertyName = "TotalByCategory";
            this.totalByCategoryDataGridViewTextBoxColumn.HeaderText = "TotalByCategory";
            this.totalByCategoryDataGridViewTextBoxColumn.Name = "totalByCategoryDataGridViewTextBoxColumn";
            // 
            // categoryPercentageDataGridViewTextBoxColumn
            // 
            this.categoryPercentageDataGridViewTextBoxColumn.DataPropertyName = "CategoryPercentage";
            this.categoryPercentageDataGridViewTextBoxColumn.HeaderText = "CategoryPercentage";
            this.categoryPercentageDataGridViewTextBoxColumn.Name = "categoryPercentageDataGridViewTextBoxColumn";
            // 
            // categoryStatisticsBindingSource
            // 
            this.categoryStatisticsBindingSource.DataSource = typeof(HáziKöltségNyilvántartó.CategoryStatistics);
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
            // statisticsBindingSource
            // 
            this.statisticsBindingSource.DataSource = typeof(HáziKöltségNyilvántartó.Statistics);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Havi költségvetés";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Havi költségvetés kategóriánként";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(737, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Éves költségvetés kategóriánként";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1166, 694);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StatisticsForm";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryStatisticsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryStatisticsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthlySpendingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthlyIncomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthlyDifferenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource statisticsBindingSource;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalByCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryPercentageDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource categoryStatisticsBindingSource;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalByCategoryDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryPercentageDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource categoryStatisticsBindingSource2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
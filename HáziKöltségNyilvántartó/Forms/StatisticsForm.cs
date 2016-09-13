﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HáziKöltségNyilvántartó.ViewModels;

namespace HáziKöltségNyilvántartó
{
    public partial class StatisticsForm : Form
    {
        private StatisticsViewModel _viewModel;
        public StatisticsForm(StatisticsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            statisticsBindingSource.DataSource = _viewModel.GetStatisticsForYear(dateTimePicker1.Value.Year);
            categoryStatisticsBindingSource2.DataSource = _viewModel.GetCategoryStatistics(dateTimePicker1.Value.Year);
            dataGridView3.Columns[2].DefaultCellStyle.Format = "#0.000\\%";
            dataGridView2.Columns[2].DefaultCellStyle.Format = "#0.000\\%";

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            categoryStatisticsBindingSource.DataSource = _viewModel.GetCategoryStatistics(dateTimePicker1.Value.Year,e.RowIndex + 1);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            statisticsBindingSource.DataSource = _viewModel.GetStatisticsForYear(dateTimePicker1.Value.Year);
            categoryStatisticsBindingSource.DataSource = _viewModel.GetCategoryStatistics(dateTimePicker1.Value.Year, dataGridView1.CurrentRow.Index + 1);
            categoryStatisticsBindingSource2.DataSource = _viewModel.GetCategoryStatistics(dateTimePicker1.Value.Year);
        }
    }
}

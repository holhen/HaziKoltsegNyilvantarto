using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HáziKöltségNyilvántartó.ViewModels;

namespace HáziKöltségNyilvántartó.Forms
{
    public partial class KoltsegvetesFelvitele : Form
    {
        private AutoCompleteStringCollection nameCollection = new AutoCompleteStringCollection();
        private KoltsegvetesFelviteleViewModel _viewModel;

        public KoltsegvetesFelvitele (KoltsegvetesFelviteleViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void nameBox_Validated(object sender, EventArgs e)
        {
            int LastValue = _viewModel.GetLastValueOfItem(nameBox.Text);
            if (LastValue != 0)
                priceNumber.Value = LastValue;
            else
            {
                priceNumber.Value = 0;
            }
            priceNumber.Select(0, priceNumber.Text.Length);
            priceNumber.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _viewModel.AddOrEditItem(nameBox.Text, (int)priceNumber.Value, income.Checked);
            if (!nameCollection.Contains(nameBox.Text))
            {
                nameCollection.Add(nameBox.Text);
            }
            _viewModel.AddNewTransaction(nameBox.Text, (int)priceNumber.Value, income.Checked, DateTime.Today);
            nameBox.Text = string.Empty;
            nameBox.Focus();
            priceNumber.Value = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            nameCollection.AddRange(_viewModel.GetNamesFromDatabase());
            nameBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            nameBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            nameBox.AutoCompleteCustomSource = nameCollection;
        }

        public List<Transaction> GetTransactionList()
        {
            return _viewModel.newlyAddedTransactions;
        }
    }
}

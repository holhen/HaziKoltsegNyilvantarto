using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using HáziKöltségNyilvántartó.ViewModels;

namespace HáziKöltségNyilvántartó.Forms
{
    public partial class KoltsegvetesMegjelenitese : Form
    {
        private BindingList<Transaction> _monthlyTransactionsBindingList;
        private List<Transaction> _monthlyTransactionsList;
        private KoltsegvetesMegjeleniteseViewModel _viewModel;
        public KoltsegvetesMegjelenitese(KoltsegvetesMegjeleniteseViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void KoltsegvetesMegjelenites_Load(object sender, EventArgs e)
        {
            _monthlyTransactionsList = _viewModel.GetMonthlyTransactionsList(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);
            _monthlyTransactionsBindingList = new BindingList<Transaction>(_monthlyTransactionsList);
            transactionBindingSource.DataSource = _monthlyTransactionsBindingList;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _monthlyTransactionsList = _viewModel.GetMonthlyTransactionsList(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);
            _monthlyTransactionsBindingList.Clear();
            foreach (var item in _monthlyTransactionsList)
                _monthlyTransactionsBindingList.Add(item);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lifetimescope = Program.Container.BeginLifetimeScope();
            KoltsegvetesFelvitele kf = lifetimescope.Resolve<KoltsegvetesFelvitele>();
            if (kf.ShowDialog() == DialogResult.Cancel)
            {
                foreach (var item in kf.GetTransactionList())
                    _monthlyTransactionsBindingList.Add(item);
            }
            kf.FormClosed += delegate
            {
                lifetimescope.Dispose();
            };
        }
    }
}

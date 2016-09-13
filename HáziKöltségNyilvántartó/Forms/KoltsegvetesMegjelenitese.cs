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
using HáziKöltségNyilvántartó.HelperClasses;

namespace HáziKöltségNyilvántartó.Forms
{
    public partial class KoltsegvetesMegjelenitese : Form
    {
        private BindingList<ItemTransaction> _monthlyTransactionsBindingList;
        private List<ItemTransaction> _monthlyTransactionsList;
        private KoltsegvetesMegjeleniteseViewModel _viewModel;
        public KoltsegvetesMegjelenitese(KoltsegvetesMegjeleniteseViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void KoltsegvetesMegjelenites_Load(object sender, EventArgs e)
        {
            _monthlyTransactionsList = _viewModel.GetMonthlyTransactionsList(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);
            _monthlyTransactionsBindingList = new BindingList<ItemTransaction>(_monthlyTransactionsList);
            itemTransactionBindingSource.DataSource = _monthlyTransactionsBindingList;
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
                foreach (var transaction in kf.GetTransactionList())
                    _monthlyTransactionsBindingList.Add(transaction);
            }
            kf.FormClosed += delegate
            {
                lifetimescope.Dispose();
            };
        }
    }
}

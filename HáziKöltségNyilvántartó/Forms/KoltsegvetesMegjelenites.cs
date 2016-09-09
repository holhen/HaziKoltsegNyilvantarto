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

namespace HáziKöltségNyilvántartó
{
    public partial class KoltsegvetesMegjelenites : Form
    {
        private BindingList<Transaction> _transactionsList;
        private ISampleContext _context;
        public KoltsegvetesMegjelenites(ISampleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void KoltsegvetesMegjelenites_Load(object sender, EventArgs e)
        {
            _transactionsList = new BindingList<Transaction>(_context.Transactions.Where(entry => entry.CreatedTime.Month == dateTimePicker1.Value.Month).ToList());
            transactionBindingSource.DataSource = _transactionsList;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _transactionsList = new BindingList<Transaction>(_context.Transactions.Where(entry => entry.CreatedTime.Month == dateTimePicker1.Value.Month).ToList());
            transactionBindingSource.DataSource = _transactionsList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lifetimescope = Program.Container.BeginLifetimeScope();
            KoltsegvetesFelvitele kf = lifetimescope.Resolve<KoltsegvetesFelvitele>();
            if (kf.ShowDialog() == DialogResult.Cancel)
            {
                foreach (var item in kf.transactionList)
                    _transactionsList.Add(item);
            }
            kf.FormClosed += delegate
            {
                lifetimescope.Dispose();
            };
        }
    }
}

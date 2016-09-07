using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HáziKöltségNyilvántartó
{
    public partial class StatisticsForm : Form
    {
        private ISampleContext _context;
        public StatisticsForm(ISampleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            List<Statistics> stats = new List<Statistics>();
            for (int i = 1; i <= 12; i++)
            {
                var stat = new Statistics();
                stat.Month = i;
                stat.MonthlyIncome = _context.Transactions.Where(entry => entry.IsIncome == true && entry.CreatedTime.Month == i).Select(entry => entry.Value).DefaultIfEmpty(0).Sum();
                stat.MonthlySpending = _context.Transactions.Where(entry => entry.IsIncome == false && entry.CreatedTime.Month == i).Select(entry => entry.Value).DefaultIfEmpty(0).Sum();
                stat.MonthlyDifference = stat.MonthlyIncome - stat.MonthlySpending;
                stats.Add(stat);
            }
            statisticsBindingSource.DataSource = stats;
        }
    }
}

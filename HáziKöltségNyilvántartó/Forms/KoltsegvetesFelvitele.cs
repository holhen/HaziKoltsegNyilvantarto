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
    public partial class KoltsegvetesFelvitele : Form
    {
        private ISampleContext _context;
        private List<Item> items;
        private List<Category> categories;
        private AutoCompleteStringCollection nameCollection = new AutoCompleteStringCollection();
        public List<Transaction> transactionList;

        public KoltsegvetesFelvitele(ISampleContext context)
        {
            InitializeComponent();
            _context = context;
            items = _context.Items.ToList();
            categories = _context.Categories.ToList();
        }

        private void nameBox_Validated(object sender, EventArgs e)
        {
            var query = items.Where(entry => entry.Name == nameBox.Text).Select(entry => entry.LastValue);
            if (query.Any() && priceNumber.Value == 0)
                priceNumber.Value = query.First();
            else
            {
                priceNumber.Value = 0;
            }
            priceNumber.Select(0, priceNumber.Text.Length);
            priceNumber.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction();
            transaction.ItemId = items.Where(entry => entry.Name == nameBox.Text).Select(entry => entry.Id).FirstOrDefault();
            transaction.IsIncome = income.Checked;
            transaction.Value = (int)priceNumber.Value;
            transaction.CreatedTime = DateTime.Now;
            transaction.UserId = 1;
            transactionList.Add(transaction);
            nameCollection.Add(nameBox.Text);
            _context.Transactions.Add(transaction);
            if (!items.Any(entry => entry.Name == nameBox.Text))
            {
                Item item = new Item()
                {
                    Name = nameBox.Text,
                    LastValue = (int)priceNumber.Value,
                    IsIncome = income.Checked,
                    CategoryId = categories.Where(entry => entry.Name == "Default").Select(entry => entry.Id).First(),
                };
                _context.Items.Add(item);
            }
            else
            {
                Item item = _context.Items.Where(entry => entry.Name == nameBox.Name).First();
                item.LastValue = (int)priceNumber.Value;
                item.IsIncome = income.Checked;                
            }
            _context.SaveChanges();
            nameBox.Text = string.Empty;
            nameBox.Focus();
            priceNumber.Value = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            nameCollection.AddRange(items.Select(entry => entry.Name).ToArray());
            nameBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            nameBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            nameBox.AutoCompleteCustomSource = nameCollection;
        }
    }
}

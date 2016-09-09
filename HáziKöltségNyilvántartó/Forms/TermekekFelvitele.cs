using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.IO;

namespace HáziKöltségNyilvántartó
{
    public partial class TermekekFelvitele : Form
    {
        private ISampleContext _context;
        private BindingList<ItemCategory> _itemCategoryList = new BindingList<ItemCategory>();
        public TermekekFelvitele(ISampleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void TermekekFelvitele_Load(object sender, EventArgs e)
        {
            itemCategoryBindingSource.DataSource = _itemCategoryList;
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            itemCategoryBindingSource.CancelEdit();
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.CheckFileExists = true;
                open.Multiselect = false;
                open.Filter = "Csv fájlok (*.csv)|*.csv|Minden fájl (*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker1.RunWorkerAsync(open.FileName);
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _itemCategoryList.Clear();
            foreach (var item in LoadDataFromDatabase())
            {
                _itemCategoryList.Add(item);
            }

            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "Csv fájlok (*.csv)| *.csv|Minden fájl (*.*)|*.*";
                save.OverwritePrompt = true;
                save.AddExtension = true;
                save.DefaultExt = ".csv";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker2.RunWorkerAsync(save.FileName);
                }
            }           
        }

        private void adatbázisbaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveDataToDatabase();
        }

        private void SaveDataToDatabase()
        {
            DateTime createdDate = new DateTime(2014, 1, 1);
            int i = 0;
            foreach (var listitem in _itemCategoryList)
            {
                Item item = _context.Items.Where(entry => entry.Name == listitem.Name).FirstOrDefault();
                if (item == null)
                {
                    if (!_context.Categories.Any(entry => entry.Name == listitem.CategoryName))
                    {
                        Category category = new Category() { Name = listitem.CategoryName };
                        _context.Categories.Add(category);
                        _context.SaveChanges();
                    }
                    item = new Item();
                    item.Name = listitem.Name;
                    item.LastValue = listitem.Value;
                    item.IsIncome = false;
                    item.CategoryId = _context.Categories.Where(entry => entry.Name == listitem.CategoryName).Select(entry => entry.Id).First();
                    _context.Items.Add(item);
                    _context.SaveChanges();

                    Transaction transaction = new Transaction();
                    transaction.CreatedTime = createdDate.AddDays(i);
                    i++;
                    transaction.IsIncome = false;
                    transaction.ItemId = _context.Items.Where(entry => entry.Name == listitem.Name).Select(entry => entry.Id).First();
                    transaction.Value = listitem.Value;
                    transaction.UserId = 1;
                    _context.Transactions.Add(transaction);
                    _context.SaveChanges();
                }
                else if(!item.Equals(listitem))
                {
                    if (!_context.Categories.Any(entry => entry.Name == listitem.CategoryName))
                    {
                        Category category = new Category() { Name = listitem.CategoryName };
                        _context.Categories.Add(category);
                        _context.SaveChanges();
                    }
                    item.LastValue = listitem.Value;
                    item.IsIncome = false;
                    item.CategoryId = _context.Categories.Where(entry => entry.Name == listitem.CategoryName).Select(entry => entry.Id).First();
                    _context.SaveChanges();
                }
            }
            MessageBox.Show("Az adatokat sikeresen elmentettük.");
        }

        private List<ItemCategory> LoadDataFromDatabase()
        {
            List<ItemCategory> warehouse = new List<ItemCategory>();
            List<Item> itemList = _context.Items.ToList();
            List<Category> categoryList = _context.Categories.ToList();
            List<Transaction> transactionList = _context.Transactions.ToList();
            int counter = _context.Items.Count();
            for (int i = 0; i < counter; i++)
            {
                ItemCategory itemCategory = new ItemCategory();
                itemCategory.Id = itemList[i].Id;
                itemCategory.Name = itemList[i].Name;
                itemCategory.Value = itemList[i].LastValue;
                itemCategory.CategoryName = categoryList.Where(entry => entry.Id == itemList[i].CategoryId).Select(entry => entry.Name).First();
                itemCategory.CreatedDate = transactionList[i].CreatedTime;
                warehouse.Add(itemCategory);
                itemCategory = null;
            }
            return warehouse;
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            using (var fileReader = new StreamReader((string)e.Argument, Encoding.Default, true))
            using (var csvReader = new CsvReader(fileReader))
            {

                csvReader.Configuration.Delimiter = ";";
                csvReader.Configuration.TrimFields = true;
                DateTime date = new DateTime(2014, 1, 1);
                int i = 0;
                while (csvReader.Read())
                {
                    ItemCategory ic = new ItemCategory();
                    ic.Id = csvReader.GetField<int>(0);
                    ic.Name = csvReader.GetField<string>(1);
                    ic.CategoryName = csvReader.GetField<string>(2);
                    ic.Value = csvReader.GetField<int>(3);
                    ic.CreatedDate = date.AddDays(i);
                    i++;
                    Invoke(new Action(() =>
                    {
                        _itemCategoryList.Add(ic);
                    }));
                }
                SaveDataToDatabase();
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            using (StreamWriter textwriter = new StreamWriter((string)e.Argument, false))
            using (CsvWriter writer = new CsvWriter(textwriter))
            {
                writer.Configuration.Delimiter = ";";
                writer.Configuration.QuoteAllFields = true;
                writer.WriteHeader<ItemCategory>();
                foreach (ItemCategory itemCategory in _itemCategoryList)
                {
                    writer.WriteRecord(itemCategory);
                }
            }
        }

        private void cSVFájlbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "Csv fájlok (*.csv)| *.csv|Minden fájl (*.*)|*.*";
                save.OverwritePrompt = true;
                save.AddExtension = true;
                save.DefaultExt = ".csv";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker2.RunWorkerAsync(save.FileName);
                }
            }
        }
    }
}


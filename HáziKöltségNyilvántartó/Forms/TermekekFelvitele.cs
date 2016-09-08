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
        private BindingList<ItemCategory> _itemCategoryList;
        public TermekekFelvitele(ISampleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void TermekekFelvitele_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DeleteDataFromGrid(e.Row.Index);
        }

        private void DeleteDataFromGrid(int rowNumber)
        {
            Item item = _context.Items.ToList().ElementAt(rowNumber);
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        private void mentésToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void SaveDataToDatabase(List<ItemCategory> list)
        {
            int counter = list.Count();
            SampleContext context = _context as SampleContext;
            context.Database.ExecuteSqlCommand("DELETE FROM Items");
            context.Database.ExecuteSqlCommand("DELETE FROM Categories WHERE Id != 1");
            context.Database.ExecuteSqlCommand("DELETE FROM Transactions");
            _context.SaveChanges();
            DateTime createdDate = new DateTime(2014, 1, 1);
            for (int i = 0; i < counter; i++)
            {
                var listitem = list[i];
                if (!_context.Categories.Any(entry => entry.Name == listitem.CategoryName))
                {
                    Category category = new Category() { Name = listitem.CategoryName };
                    _context.Categories.Add(category);
                    _context.SaveChanges();
                }
                Item item = new Item();
                item.Name = listitem.Name;
                item.LastValue = listitem.Value;
                item.IsIncome = false;
                item.CategoryId = _context.Categories.Where(entry => entry.Name == listitem.CategoryName).Select(entry => entry.Id).First();
                _context.Items.Add(item);
                _context.SaveChanges();

                Transaction transaction = new Transaction();
                transaction.CreatedTime = createdDate.AddDays(i);
                transaction.IsIncome = false;
                transaction.ItemId = _context.Items.Where(entry => entry.Name == listitem.Name).Select(entry => entry.Id).First();
                transaction.Value = listitem.Value;
                transaction.UserId = 1;
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
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

        private void adatbázisbólToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _itemCategoryList = new BindingList<ItemCategory>(LoadDataFromDatabase());
            itemCategoryBindingSource.DataSource = _itemCategoryList;
        }

        private void cSVFájlbólToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.CheckFileExists = true;
                open.Multiselect = false;
                open.Filter = "Csv fájlok (*.csv)|*.csv|Minden fájl (*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    List<ItemCategory> warehouse = new List<ItemCategory>();

                    using (var fileReader = new StreamReader(open.FileName, Encoding.Default, true))
                    using (var csvReader = new CsvReader(fileReader))
                    {
                        _itemCategoryList = new BindingList<ItemCategory>();
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
                            warehouse.Add(ic);
                        }
                        foreach (ItemCategory ic in warehouse)
                        {
                            _itemCategoryList.Add(ic);
                        }
                        itemCategoryBindingSource.DataSource = _itemCategoryList;
                        SaveDataToDatabase(warehouse);
                    }
                    
                }
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            /*using (var reader = new StreamReader((string)e.Argument, Encoding.Default, true))
            {
                string line;
                line = reader.ReadLine();
                List<Category> categoryList = _context.Categories.ToList();
                List<Item> itemList = _context.Items.ToList();
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    string[] elements = line.Split(';');
                    for (int i = 0; i < elements.Length; i++)
                        elements[i] = elements[i].Trim('"').Trim(' ');
                    ItemCategory itemCategory = new ItemCategory();
                    itemCategory.Id = int.Parse(elements[0]);
                    itemCategory.Name = elements[1];
                    itemCategory.CategoryName = elements[2];
                    itemCategory.Value = int.Parse(elements[3]);
                    //itemCategory.CategoryId = categoryList.Where(entry => entry.Name == itemCategory.CategoryName).Select(entry => entry.Id).FirstOrDefault();
                    Invoke(new Action(() =>
                    {
                        _itemCategoryList.Add(itemCategory);
                    }));
                }
            }*/
            List<ItemCategory> warehouse = new List<ItemCategory>();

            using (var fileReader = new StreamReader((string)e.Argument, Encoding.Default, true))
            using (var csvReader = new CsvReader(fileReader))
            {
                csvReader.Configuration.Delimiter = ";";
                csvReader.Configuration.TrimFields = true;
                while (csvReader.Read())
                {
                    Invoke(new Action(() =>
                    {
                        warehouse.Add(csvReader.GetRecord<ItemCategory>());
                    }));
                }
                SaveDataToDatabase(warehouse);

            }

        }

        private void adatbázisbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDataToDatabase(_itemCategoryList.ToList());
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
    }
}


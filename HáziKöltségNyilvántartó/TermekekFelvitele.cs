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
            SaveDataFromGrid();
        }

        private void SaveDataFromGrid()
        {
            int counter = _itemCategoryList.Count();
            while (counter > _context.Items.Count())
            {
                _context.Items.Add(new Item());
                _context.SaveChanges();
            }      
            for (int i = 0; i < counter; i++)
            {
                var listitem = _itemCategoryList[i];
                if (_context.Items.Any(entry => entry.Id == listitem.Id))
                {
                    _context.Items.ToList()[i].Name = listitem.Name;
                    _context.Items.ToList()[i].LastValue = listitem.LastValue;
                    _context.Items.ToList()[i].IsIncome = listitem.IsIncome;
                    _context.Items.ToList()[i].CategoryId = listitem.CategoryId;
                }
                else
                {
                    Item item = new Item();
                    item.Name = listitem.Name;
                    item.LastValue = listitem.LastValue;
                    item.IsIncome = listitem.IsIncome;
                    item.CategoryId = listitem.CategoryId;
                    _context.Items.Add(item);
                }
                if (!_context.Categories.Any(entry => entry.Name == listitem.CategoryName))
                {
                    Category category = new Category() { Id = listitem.CategoryId, Name = listitem.CategoryName };
                    _context.Categories.Add(category);
                }
            }
            var list = _context.Items.Where(entry => string.IsNullOrEmpty(entry.Name));
            _context.Items.RemoveRange(list);
            _context.SaveChanges();
            MessageBox.Show("Az adatokat sikeresen elmentettük.");
        }

        private void adatbázisbólToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _itemCategoryList = new BindingList<ItemCategory>();
            List<Item> itemList = _context.Items.ToList();
            List<Category> categoryList = _context.Categories.ToList();
            int counter = _context.Items.Count();

            for (int i = 0; i < counter; i++)
            {
                ItemCategory itemCategory = new ItemCategory();
                itemCategory.Id = itemList[i].Id;
                itemCategory.Name = itemList[i].Name;
                itemCategory.LastValue = itemList[i].LastValue;
                itemCategory.IsIncome = itemList[i].IsIncome;
                itemCategory.CategoryId = itemList[i].CategoryId;
                itemCategory.CategoryName = categoryList.Where(entry => entry.Id == itemList[i].CategoryId).Select(entry => entry.Name).First();
                _itemCategoryList.Add(itemCategory);
                itemCategory = null;
            }
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
                    _itemCategoryList = new BindingList<ItemCategory>();
                    backgroundWorker1.RunWorkerAsync(open.FileName);
                    itemCategoryBindingSource.DataSource = _itemCategoryList;
                }
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var reader = new StreamReader((string)e.Argument, Encoding.Default, true))
            {
                string line;
                int result;
                line = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    string[] elements = line.Split(';');
                    for (int i = 0; i < elements.Length; i++)
                        elements[i] = elements[i].Trim('"').Trim(' ');
                    ItemCategory itemCategory = new ItemCategory();
                    if (int.TryParse(elements[0], out result))
                    {
                        itemCategory.Id = result;
                    }
                    else itemCategory.Id = null;
                    itemCategory.Name = elements[1];
                    itemCategory.CategoryName = elements[2];
                    itemCategory.LastValue = int.Parse(elements[3]);
                    itemCategory.CategoryId = _context.Categories.Where(entry => entry.Name == itemCategory.CategoryName).Select(entry => entry.Id).FirstOrDefault();
                    itemCategory.IsIncome = _context.Items.Where(entry => entry.Name == itemCategory.Name).Select(entry => entry.IsIncome).FirstOrDefault();
                    Invoke(new Action(() =>
                    {
                        _itemCategoryList.Add(itemCategory);
                    }));
                }
            }
           
        }
    }
}


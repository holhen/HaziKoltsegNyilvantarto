using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CsvHelper;

namespace HáziKöltségNyilvántartó.ViewModels
{
    public class TermekekFelviteleViewModel
    {
        ISampleContext _context;
        public TermekekFelviteleViewModel(ISampleContext context)
        {
            _context = context;
        }

        public void SaveDataToDatabase(List<ItemCategory> itemCategoryList)
        {
            DateTime createdDate = new DateTime(2014, 1, 1);
            int i = 0;
            foreach (var listitem in itemCategoryList)
            {
                Item item = _context.Items.Where(entry => entry.csvId == listitem.Id).FirstOrDefault();
                if (item == null)
                {
                    if (!_context.Categories.Any(entry => entry.Name == listitem.CategoryName))
                    {
                        Category category = new Category() { Name = listitem.CategoryName };
                        _context.Categories.Add(category);
                        _context.SaveChanges();
                    }
                    item = new Item();
                    item.csvId = listitem.Id;
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
                    transaction.ItemId = (int)_context.Items.Where(entry => entry.Name == listitem.Name).Select(entry => entry.Id).FirstOrDefault();
                    transaction.Value = listitem.Value;
                    transaction.UserId = 1;
                    _context.Transactions.Add(transaction);
                    _context.SaveChanges();
                }
                else if (!item.Equals(listitem))
                {
                    if (!_context.Categories.Any(entry => entry.Name == listitem.CategoryName))
                    {
                        Category category = new Category() { Name = listitem.CategoryName };
                        _context.Categories.Add(category);
                        _context.SaveChanges();
                    }
                    item.Name = listitem.Name;
                    item.LastValue = listitem.Value;
                    item.IsIncome = false;
                    item.CategoryId = _context.Categories.Where(entry => entry.Name == listitem.CategoryName).Select(entry => entry.Id).First();
                    _context.SaveChanges();
                }
            }
            MessageBox.Show("Az adatokat sikeresen elmentettük.");
        }

        public List<ItemCategory> LoadDataFromDatabase()
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

        public List<ItemCategory> ReadCsvFile()
        {
            using (var fileReader = new StreamReader((string)e.Argument, Encoding.Default, true))
            using (var csvReader = new CsvReader(fileReader))
            {
                List<ItemCategory> itemCategoryList = new List<ItemCategory>();
                csvReader.Configuration.Delimiter = ";";
                csvReader.Configuration.TrimFields = true;
                DateTime date = new DateTime(2014, 1, 1);
                int i = 0;
                while (csvReader.Read())
                {
                    ItemCategory ic = new ItemCategory();
                    ic.Id = csvReader.GetField<int?>(0);
                    ic.Name = csvReader.GetField<string>(1);
                    ic.CategoryName = csvReader.GetField<string>(2);
                    ic.Value = csvReader.GetField<int>(3);
                    ic.CreatedDate = date.AddDays(i);
                    i++;
                    itemCategoryList.Add(ic);
                }
                return itemCategoryList;
            }
        }


        public void SaveCsvFile(List<ItemCategory> itemCategoryList)
        {
            using (StreamWriter textwriter = new StreamWriter((string)e.Argument, false))
            using (CsvWriter writer = new CsvWriter(textwriter))
            {
                writer.Configuration.Delimiter = ";";
                writer.Configuration.QuoteAllFields = true;
                writer.WriteHeader<ItemCategory>();
                foreach (ItemCategory itemCategory in itemCategoryList)
                {
                    writer.WriteRecord(itemCategory);
                }
            }
        }
    }
}

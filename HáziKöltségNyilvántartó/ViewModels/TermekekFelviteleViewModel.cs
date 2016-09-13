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
    public class TermekekFelviteleViewModel: BaseViewModel
    {
        public TermekekFelviteleViewModel(ISampleContext context): base(context)
        {
        }

        public void SaveDataToDatabase(List<ItemCategory> itemCategoryList)
        {
           
            foreach (var listitem in itemCategoryList)
            {
                AddNonExistingCategory(listitem.CategoryName);

                Item item = _context.Items.Where(entry => entry.csvId == listitem.Id).FirstOrDefault();
                if (item == null)
                {
                    AddNewItem(listitem.Name, listitem.Value, listitem.CategoryName, false, listitem.Id);
                    AddNewTransaction(listitem.Name, listitem.Value, false, listitem.CreatedDate);
                }
                else if (!item.Equals(listitem))
                {
                    int CategoryId = _context.Categories.Where(entry => entry.Name == listitem.CategoryName).Select(entry => entry.Id).First();
                    EditItem(item, listitem.Name, listitem.Value, false, CategoryId, listitem.Id);
                }
            }
            MessageBox.Show("Az adatokat sikeresen elmentettük.");
        }

        public List<ItemCategory> LoadDataFromDatabase()
        {
            List<ItemCategory> warehouse = new List<ItemCategory>();
            int counter = _context.Items.Count();
            for (int i = 0; i < counter; i++)
            {
                ItemCategory itemCategory = new ItemCategory();
                itemCategory.Id = items[i].Id;
                itemCategory.Name = items[i].Name;
                itemCategory.Value = items[i].LastValue;
                itemCategory.CategoryName = categories.Where(entry => entry.Id == items[i].CategoryId).Select(entry => entry.Name).First();
                itemCategory.CreatedDate = transactions[i].CreatedTime;
                warehouse.Add(itemCategory);
                itemCategory = null;
            }
            return warehouse;
        }

        public List<ItemCategory> ReadCsvFile(string fileName)
        {
            using (var fileReader = new StreamReader(fileName, Encoding.Default, true))
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


        public void SaveCsvFile(List<ItemCategory> itemCategoryList, string fileName)
        {
            using (StreamWriter textwriter = new StreamWriter(fileName, false))
            using (CsvWriter writer = new CsvWriter(textwriter))
            {
                writer.Configuration.Delimiter = ";";
                writer.Configuration.QuoteAllFields = true;
                writer.WriteHeader<ItemCategory>();
                foreach (ItemCategory itemCategory in itemCategoryList)
                {
                    writer.WriteRecord(itemCategory);
                }
                MessageBox.Show("Az adatokat sikeresen mentettük.");
            }
        }
    }
}

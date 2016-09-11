using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HáziKöltségNyilvántartó.ViewModels
{
    public class KoltsegvetesFelviteleViewModel
    {
        private ISampleContext _context;
        private List<Item> items;
        private List<Category> categories;
        public List<Transaction> transactionList;

        public KoltsegvetesFelviteleViewModel(ISampleContext context)
        {
            _context = context;
            items = _context.Items.ToList();
            categories = _context.Categories.ToList();
            transactionList = new List<Transaction>();
        }

        public int GetLastValueOfItem(string itemName)
        {
            return items.Where(entry => entry.Name == itemName).Select(entry => entry.LastValue).FirstOrDefault();
        }

        public string[] GetNamesFromDatabase()
        {
           return items.Select(entry => entry.Name).ToArray();
        }

        public void CreateNewTransaction(string nameOfItem, int priceOfItem, bool isIncome)
        {
            Transaction transaction = new Transaction();
            transaction.ItemId = items.Where(entry => entry.Name == nameOfItem).Select(entry => entry.Id).FirstOrDefault();
            transaction.IsIncome = isIncome;
            transaction.Value = priceOfItem;
            transaction.CreatedTime = DateTime.Now;
            transaction.UserId = 1;
            transactionList.Add(transaction);
            _context.Transactions.Add(transaction);
        }

        public void AddOrEditItem(string nameOfItem, int priceOfItem, bool isIncome)
        {
            if (!items.Any(entry => entry.Name == nameOfItem))
            {
                Item item = new Item()
                {
                    Name = nameOfItem,
                    LastValue = priceOfItem,
                    IsIncome = isIncome,
                    CategoryId = categories.Where(entry => entry.Name == "Default").Select(entry => entry.Id).First(),
                };
                _context.Items.Add(item);
            }
            else
            {
                Item item = _context.Items.Where(entry => entry.Name == nameOfItem).First();
                item.LastValue = priceOfItem;
                item.IsIncome = isIncome;
            }
            _context.SaveChanges();
        }
    }
}

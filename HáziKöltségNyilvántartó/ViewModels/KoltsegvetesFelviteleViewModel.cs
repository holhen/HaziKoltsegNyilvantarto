using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HáziKöltségNyilvántartó.HelperClasses;

namespace HáziKöltségNyilvántartó.ViewModels
{
    public class KoltsegvetesFelviteleViewModel: BaseViewModel
    {
        
        public List<ItemTransaction> newlyAddedTransactions;

        public KoltsegvetesFelviteleViewModel(ISampleContext context): base(context)
        {
            newlyAddedTransactions = new List<ItemTransaction>();
        }

        public int GetLastValueOfItem(string itemName)
        {
            return items.Where(entry => entry.Name == itemName).Select(entry => entry.LastValue).FirstOrDefault();
        }

        public string[] GetNamesFromDatabase()
        {
           return items.Select(entry => entry.Name).ToArray();
        }

        public override void AddNewTransaction(string nameOfItem, int priceOfItem, bool isIncome, DateTime createdTime)
        {
            if (string.IsNullOrWhiteSpace(nameOfItem))
                throw new ArgumentNullException("A termék neve nem lehet üres!!");
            base.AddNewTransaction(nameOfItem,priceOfItem,isIncome, createdTime);
            var query = from item in items
                        join trans in transactions on item.Id equals trans.ItemId
                        join cat in categories on item.CategoryId equals cat.Id
                        where trans.CreatedTime == createdTime && trans.Value == priceOfItem && item.Name == nameOfItem
                        select new ItemTransaction
                        {
                            Id = item.Id,
                            csvId = item.csvId,
                            Name = item.Name,
                            CategoryId = item.CategoryId,
                            LastValue = item.LastValue,
                            IsIncome = item.IsIncome,
                            CategoryName = cat.Name,
                            CreatedTime = trans.CreatedTime,
                            UserId = trans.UserId
                        };
            newlyAddedTransactions.Add(query.First());
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void AddOrEditItem(string nameOfItem, int priceOfItem, bool isIncome)
        {
            if (string.IsNullOrWhiteSpace(nameOfItem))
                throw new ArgumentNullException("A termék neve nem lehet üres!!");
            Item item = _context.Items.Where(entry => entry.Name == nameOfItem).FirstOrDefault();
            if (item == null)
            {
                AddNewItem(nameOfItem, priceOfItem, "Default", isIncome);
            }
            else
            {
                EditItem(item, nameOfItem, priceOfItem, isIncome, item.CategoryId);
            }
            _context.SaveChanges();
        }
    }
}

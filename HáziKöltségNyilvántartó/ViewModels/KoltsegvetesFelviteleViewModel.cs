using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HáziKöltségNyilvántartó.ViewModels
{
    public class KoltsegvetesFelviteleViewModel: BaseViewModel
    {
        
        public List<Transaction> newlyAddedTransactions;

        public KoltsegvetesFelviteleViewModel(ISampleContext context): base(context)
        {
            newlyAddedTransactions = new List<Transaction>();
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
            base.AddNewTransaction(nameOfItem,priceOfItem,isIncome, createdTime);
            newlyAddedTransactions.Add(transaction);
        }

        public void AddOrEditItem(string nameOfItem, int priceOfItem, bool isIncome)
        {
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

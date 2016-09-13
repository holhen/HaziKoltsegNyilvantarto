using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HáziKöltségNyilvántartó.HelperClasses;

namespace HáziKöltségNyilvántartó.ViewModels
{
    public class BaseViewModel
    {
        protected ISampleContext _context;
        protected List<Item> items;
        protected List<Category> categories;
        protected List<Transaction> transactions;
        protected List<User> users;
        protected Transaction transaction;
        protected Item _item;

        public BaseViewModel(ISampleContext context)
        {
            _context = context;
            items = _context.Items.ToList();
            categories = _context.Categories.ToList();
            transactions = _context.Transactions.ToList();
        }

        public virtual void AddNewTransaction(string nameOfItem, int priceOfItem, bool isIncome, DateTime createdTime)
        {
            transaction = new Transaction()
            {
                ItemId = _context.Items.Where(entry => entry.Name == nameOfItem).Select(entry => entry.Id).FirstOrDefault(),
                IsIncome = isIncome,
                Value = priceOfItem,
                CreatedTime = createdTime,
                UserId = LoggedInUser.UserID
        };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public virtual void AddNewItem(string nameOfItem, int priceOfItem, string categoryName, bool isIncome, int? Id = 0)
        {
            _item = new Item()
            {
                csvId = Id,
                Name = nameOfItem,
                LastValue = priceOfItem,
                IsIncome = isIncome,
                CategoryId = _context.Categories.Where(entry => entry.Name == categoryName).Select(entry => entry.Id).First(),
            };
            _context.Items.Add(_item);
            _context.SaveChanges();
        }

        public virtual void EditItem(Item item, string nameOfItem, int valueOfItem, bool isIncome, int categoryId, int? Id = 0)
        {
            _item = item;
            _item.Name = nameOfItem;
            _item.LastValue = valueOfItem;
            _item.IsIncome = isIncome;
            _item.CategoryId = categoryId;
            _item.csvId = Id;
            _context.SaveChanges();
        }

        public void AddNonExistingCategory(string categoryName)
        {
            if (!_context.Categories.Any(entry => entry.Name == categoryName))
            {
                Category category = new Category() { Name = categoryName };
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
        }
}
}

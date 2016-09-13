using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HáziKöltségNyilvántartó.HelperClasses;

namespace HáziKöltségNyilvántartó.ViewModels
{
    public class KoltsegvetesMegjeleniteseViewModel: BaseViewModel
    {
        public KoltsegvetesMegjeleniteseViewModel(ISampleContext context): base(context)
        {
        }

        public List<ItemTransaction> GetMonthlyTransactionsList(int year, int month)
        {
            var query = from item in items
                        join trans in transactions on item.Id equals trans.ItemId
                        join cat in categories on item.CategoryId equals cat.Id
                        where trans.CreatedTime.Year == year && trans.CreatedTime.Month == month && trans.UserId == LoggedInUser.UserID
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
            return query.ToList();
        }

    }
}

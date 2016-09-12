using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HáziKöltségNyilvántartó.ViewModels
{
    public class KoltsegvetesMegjeleniteseViewModel: BaseViewModel
    {
        public KoltsegvetesMegjeleniteseViewModel(ISampleContext context): base(context)
        {
        }

        public List<Transaction> GetMonthlyTransactionsList(int year, int month)
        {
            return transactions.Where(entry => entry.CreatedTime.Year == year && entry.CreatedTime.Month == month).ToList();
        }
    }
}

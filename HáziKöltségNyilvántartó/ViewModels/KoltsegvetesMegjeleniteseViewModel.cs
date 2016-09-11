using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HáziKöltségNyilvántartó.ViewModels
{
    public class KoltsegvetesMegjeleniteseViewModel
    {
        private ISampleContext _context;
        public KoltsegvetesMegjeleniteseViewModel(ISampleContext context)
        {
            _context = context;
        }

        public List<Transaction> GetMonthlyTransactionsList(int year, int month)
        {
            return _context.Transactions.Where(entry => entry.CreatedTime.Year == year && entry.CreatedTime.Month == month).ToList();
        }
    }
}

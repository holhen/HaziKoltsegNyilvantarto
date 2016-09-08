using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HáziKöltségNyilvántartó.ViewModels
{
    public class StatisticsViewModel
    {
        private ISampleContext _context;
        public StatisticsViewModel (ISampleContext context)
        {
            _context = context;
        }


        public List<Statistics> GetStatisticsForYear(int year)
        {
            List<Statistics> stats = new List<Statistics>();
            for (int i = 1; i <= 12; i++)
            {
                var stat = new Statistics();
                stat.Month = i;
                stat.MonthlyIncome = GetSumOfMonthlyTransactions(true, year, i);
                stat.MonthlySpending = GetSumOfMonthlyTransactions(false, year, i);
                stat.MonthlyDifference = stat.MonthlyIncome - stat.MonthlySpending;
                stats.Add(stat);
            }
            return stats;
        }

        public int GetSumOfMonthlyTransactions(bool isIncome, int year, int month)
        {
            return  GetTransactions(year, month).Where(entry => entry.IsIncome == isIncome).
                    Select(entry => entry.Value).
                    DefaultIfEmpty(0).
                    Sum();
        }

        public List<CategoryStatistics> GetCategoryStatistics(int year, int month = 0)
        {
            List<CategoryStatistics> catstats = new List<CategoryStatistics>();
            IQueryable<Transaction> transactions = GetTransactions(year, month);

            var query = FindStatistics(transactions);

            foreach (var item in query)
            {
                CategoryStatistics catstat = new CategoryStatistics();
                catstat.CategoryName = item.CategoryName;
                catstat.CategoryPercentage = item.CategoryPercentage;
                catstat.TotalByCategory = item.TotalByCategory;
                catstats.Add(catstat);
            }
            return catstats;
        }

        public IQueryable<Transaction> GetTransactions(int year, int month)
        {
            var yearly = _context.Transactions.Where(entry => entry.CreatedTime.Year == year);
            if (month == 0)
                return yearly;
            else
                return yearly.Where(entry => entry.CreatedTime.Month == month);
        }

        public IQueryable<CategoryStatistics> FindStatistics(IQueryable<Transaction> transactions)
        {
            var query = from cat in _context.Categories
                        join item in _context.Items on cat.Id equals item.CategoryId
                        join trans in _context.Transactions on item.Id equals trans.ItemId
                        where transactions.Contains(trans)
                        group new { cat.Name, trans.Value } by cat.Name into g
                        let sum = g.Sum(entry => entry.Value)
                        select new CategoryStatistics
                        {
                            CategoryName = g.Key,
                            TotalByCategory = g.Sum(entry => entry.Value),
                            CategoryPercentage = ((double)sum / transactions.Select(entry => entry.Value).Sum()) * 100
                        };
            return query;
        }
    }
}

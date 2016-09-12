using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HáziKöltségNyilvántartó.ViewModels
{
    public class StatisticsViewModel: BaseViewModel
    {
        public StatisticsViewModel (ISampleContext context): base(context)
        {
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
            IEnumerable<Transaction> transactions = GetTransactions(year, month);

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

        public IEnumerable<Transaction> GetTransactions(int year, int month)
        {
            var yearly = transactions.Where(entry => entry.CreatedTime.Year == year);
            if (month == 0)
                return yearly;
            else
                return yearly.Where(entry => entry.CreatedTime.Month == month);
        }

        public IEnumerable<CategoryStatistics> FindStatistics(IEnumerable<Transaction> transactions)
        {
            var query = from cat in this.categories
                        join item in this.items on cat.Id equals item.CategoryId
                        join trans in transactions on item.Id equals trans.ItemId
                        group new { cat.Name, trans.Value } by cat.Name into g
                        let sum = g.Sum(entry => entry.Value)
                        orderby sum descending
                        select new CategoryStatistics
                        {
                            CategoryName = g.Key,
                            TotalByCategory = sum,
                            CategoryPercentage = ((double)sum / transactions.Sum(entry => entry.Value)) * 100
                        };
            return query;
        }
    }
}

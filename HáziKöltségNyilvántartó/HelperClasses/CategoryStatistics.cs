using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HáziKöltségNyilvántartó
{
    public class CategoryStatistics
    {
        public string CategoryName { get; set; }
        public int TotalByCategory { get; set; }
        public double CategoryPercentage { get; set; }
    }
}

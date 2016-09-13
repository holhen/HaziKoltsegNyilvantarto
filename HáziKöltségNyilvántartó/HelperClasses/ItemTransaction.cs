using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HáziKöltségNyilvántartó.HelperClasses
{
    public class ItemTransaction
    {
        public int Id { get; set; }
        public int? csvId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int LastValue { get; set; }
        public bool IsIncome { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedTime { get; set; }
        public int UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HáziKöltségNyilvántartó
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Value { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsIncome { get; set; }

        public Item Item { get; set; }
        public User User {get; set; }
    }
}

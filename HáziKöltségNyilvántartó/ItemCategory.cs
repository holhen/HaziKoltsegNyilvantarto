using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HáziKöltségNyilvántartó
{
    class ItemCategory
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int LastValue { get; set; }
        public bool IsIncome { get; set; }
        public string CategoryName { get; set; }
    }
}


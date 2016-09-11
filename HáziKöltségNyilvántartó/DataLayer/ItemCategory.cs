using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HáziKöltségNyilvántartó
{
    public class ItemCategory
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int Value { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}


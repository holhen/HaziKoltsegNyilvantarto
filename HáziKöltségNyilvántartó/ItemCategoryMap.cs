using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace HáziKöltségNyilvántartó
{
    class ItemCategoryMap: CsvClassMap<ItemCategory>
    {
        public ItemCategoryMap()
        {
            Map(m => m.Id);
            Map(m => m.Name);
            Map(m => m.CategoryName);
            Map(m => m.LastValue).Name("Value");
        }
    }
}

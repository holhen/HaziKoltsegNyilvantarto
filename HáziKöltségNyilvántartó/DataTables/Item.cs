using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HáziKöltségNyilvántartó
{
    public class Item
    {
       public int Id { get; set; }
       public int? csvId { get; set; }
       public string Name { get; set; }
       public int CategoryId { get; set; }
       public int LastValue { get; set; }
       public bool IsIncome { get; set; }
       public List<Category> Category { get; set; }

        public override bool Equals(object obj)
        {
            Item item;
            if (obj is Item)
                item = obj as Item;
            else return false;
            if (item.Id == this.Id && item.Name == this.Name && item.LastValue == this.LastValue && item.IsIncome == this.IsIncome && item.CategoryId == this.CategoryId)
                return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

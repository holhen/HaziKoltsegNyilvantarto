using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HáziKöltségNyilvántartó
{
    public interface ISampleContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcTest.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Eats> Eats { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

    }
    public class BookContext2 : DbContext
    {
        public DbSet<Eats> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

    }

}
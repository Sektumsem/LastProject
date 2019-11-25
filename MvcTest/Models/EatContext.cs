using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcTest.Models
{
    public class EatContext : DbContext
    {
        public DbSet<Eats> Eats { get; set; }
        public DbSet<Kokkale> Kokkale { get; set; }

    }
    public class BookContext2 : DbContext
    {
        public DbSet<Eats> Books { get; set; }
        public DbSet<Kokkale> Kokkale { get; set; }

    }

}
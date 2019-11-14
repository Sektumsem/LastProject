using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcTest.Models
{
    public class BookDbInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Eats.Add(new Eats { Nimetus = "Картошка", Hind = "5€",});
            base.Seed(db);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
    public class UserDbInitializer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            db.Roles.Add( new Role { Id = 1, Name = "admin"});
            db.Roles.Add( new Role { Id = 2, Name = "kokk"});
            db.Roles.Add(new Role { Id = 3, Name = "tenindaja" });
            db.Users.Add(new User
            {
                Id = 1,
                Email = "admin",
                Password = "admin",
                Age = 20,
                RoleId = 1

            });
            db.Users.Add(new User
            {
                Id = 2,
                Email = "kokk",
                Password = "kokk",
                Age = 20,
                RoleId = 2

            });
            db.Users.Add(new User
            {
                Id = 3,
                Email = "tenindaja",
                Password = "tenindaja",
                Age = 20,
                RoleId = 3

            });

            base.Seed(db);
        }
    }
}
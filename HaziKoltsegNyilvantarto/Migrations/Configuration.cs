namespace HáziKöltségNyilvántartó.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SampleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (!context.Categories.Any(entry => entry.Name == "Default"))
            {
                context.Categories.Add(new Category
                {
                    Id = 1,
                    Name = "Default"
                });
            }

            if (!context.Users.Any(entry => entry.UserName == "admin"))
            {
                context.Users.Add(new User
                {
                    Id = 1,
                    UserName = "admin",
                    Password = PasswordHelper.EncryptPassword("admin")
                });
            }
        }
    }
}

using Mooshak2.Models;

namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

<<<<<<< HEAD
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
=======
    internal sealed class Configuration : DbMigrationsConfiguration<Mooshak2.Models.ApplicationDbContext>
>>>>>>> origin/master
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

<<<<<<< HEAD
        protected override void Seed(ApplicationDbContext context)
=======
        protected override void Seed(Mooshak2.Models.ApplicationDbContext context)
>>>>>>> origin/master
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
        }
    }
}

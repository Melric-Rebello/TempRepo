namespace DemoPrj.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DemoPrj.Models.ContactContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DemoPrj.Models.ContactContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Contacts.AddOrUpdate(new Contact[] {
              new Contact {ID=0, FirstName = "Andrew", LastName="Peters" },
              new Contact {ID=1, FirstName = "Brice", LastName="Lambson" },
              new Contact {ID=2, FirstName = "Rowan", LastName="Miller" }
            }
            );

        }
    }
}

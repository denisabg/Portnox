namespace Portnox.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Portnox.Data.PortnoxContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //Database.SetInitializer<PortnoxContext>(new NullDatabaseInitializer<PortnoxContext>());
            //Database.SetInitializer<PortnoxContext>(new CreateDatabaseIfNotExists<PortnoxContext>());
            Database.SetInitializer<PortnoxContext>(new DropCreateDatabaseAlways<PortnoxContext>());
            //Database.SetInitializer<PortnoxContext>(new DropCreateDatabaseIfModelChanges<PortnoxContext>());




        }

        protected override void Seed(Portnox.Data.PortnoxContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

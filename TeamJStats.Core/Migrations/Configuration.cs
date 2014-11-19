using System;
using System.Data.Entity.Migrations;
using TeamJStats.DataAccess.DataAccess;
using TeamJStats.Domain;

namespace TeamJStats.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            context.CreateSet<Player>().AddOrUpdate<Player>(
                new Player
                {
                    DateCreatedUtc = DateTime.UtcNow,
                    DateUpdatedUtc = DateTime.UtcNow,
                    FirstName = "Michael",
                    LastName = "Jordan"
                },
                new Player
                {
                    DateCreatedUtc = DateTime.UtcNow,
                    DateUpdatedUtc = DateTime.UtcNow,
                    FirstName = "Kobe",
                    LastName = "Bryant"
                },
                new Player
                {
                    DateCreatedUtc = DateTime.UtcNow,
                    DateUpdatedUtc = DateTime.UtcNow,
                    FirstName = "Lebron",
                    LastName = "James"
                });
        }
    }
}
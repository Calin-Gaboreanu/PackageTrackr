namespace PackageTrackr.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PackageTrackr.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PackageTrackr.PackageTrackrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PackageTrackr.PackageTrackrContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(u => u.UserName, 
                new User { UserName = "admin", Password= "admin1"}    
            );

            context.Packages.AddOrUpdate( p => p.AWB,
                new Package { AWB = "12345678901" , PackageStatusId = 1},
                new Package { AWB = "92920029912" , PackageStatusId = 1},
                new Package { AWB = "87237138412" , PackageStatusId = 1},
                new Package { AWB = "12312312223" , PackageStatusId = 1},
                new Package { AWB = "12341523431" , PackageStatusId = 1},
                new Package { AWB = "14322341312" , PackageStatusId = 1},
                new Package { AWB = "12312412342" , PackageStatusId = 1},
                new Package { AWB = "56563753474" , PackageStatusId = 1},
                new Package { AWB = "56342435232" , PackageStatusId = 1},
                new Package { AWB = "62453341232" , PackageStatusId = 1},
                new Package { AWB = "86434322123" , PackageStatusId = 1},
                new Package { AWB = "07664321212" , PackageStatusId = 1},
                new Package { AWB = "00000000001" , PackageStatusId = 1},
                new Package { AWB = "00000000002" , PackageStatusId = 1},
                new Package { AWB = "00000000003" , PackageStatusId = 1},
                new Package { AWB = "93454382293" , PackageStatusId = 1},
                new Package { AWB = "35243524522" , PackageStatusId = 1},
                new Package { AWB = "45654745543" , PackageStatusId = 1},
                new Package { AWB = "67895745432" , PackageStatusId = 1},
                new Package { AWB = "90989876545" , PackageStatusId = 1},
                new Package { AWB = "45746764532" , PackageStatusId = 1},
                new Package { AWB = "54343456789" , PackageStatusId = 1},
                new Package { AWB = "00000000040" , PackageStatusId = 1},
                new Package { AWB = "00000023020" , PackageStatusId = 1},
                new Package { AWB = "34352433422" , PackageStatusId = 1},
                new Package { AWB = "75432131262" , PackageStatusId = 5},
                new Package { AWB = "89653232132" , PackageStatusId = 4},
                new Package { AWB = "98789054323" , PackageStatusId = 4},
                new Package { AWB = "45764573122" , PackageStatusId = 3},
                new Package { AWB = "97867544322" , PackageStatusId = 3},
                new Package { AWB = "65756453422" , PackageStatusId = 2},
                new Package { AWB = "12354332235" , PackageStatusId = 2}
                
            );
        }
    }
}

namespace PackageTrackr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePackageStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PackageStatus(Id, Name) VALUES (1, 'Delivered')");
            Sql("INSERT INTO PackageStatus(Id, Name) VALUES (2, 'Undelivered')");
            Sql("INSERT INTO PackageStatus(Id, Name) VALUES (3, 'Processing')");
            Sql("INSERT INTO PackageStatus(Id, Name) VALUES (4, 'In Transit')");
            Sql("INSERT INTO PackageStatus(Id, Name) VALUES (5, 'Pick Up')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM PackageStatus WHERE Id = 1");
            Sql("DELETE FROM PackageStatus WHERE Id = 2");
            Sql("DELETE FROM PackageStatus WHERE Id = 3");
            Sql("DELETE FROM PackageStatus WHERE Id = 4");
            Sql("DELETE FROM PackageStatus WHERE Id = 5");
        }
    }
}

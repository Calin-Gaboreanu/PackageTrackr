namespace PackageTrackr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPackageAndPackageStatusModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AWB = c.String(nullable: false, maxLength: 11),
                        EnteredDate = c.DateTime(nullable: false),
                        PackageStatusId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PackageStatus", t => t.PackageStatusId, cascadeDelete: true)
                .Index(t => t.AWB, unique: true, name: "AWBIndex")
                .Index(t => t.PackageStatusId);
            
            CreateTable(
                "dbo.PackageStatus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "PackageStatusId", "dbo.PackageStatus");
            DropIndex("dbo.Packages", new[] { "PackageStatusId" });
            DropIndex("dbo.Packages", "AWBIndex");
            DropTable("dbo.PackageStatus");
            DropTable("dbo.Packages");
        }
    }
}

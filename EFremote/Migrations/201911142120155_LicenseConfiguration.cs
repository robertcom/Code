namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LicenseConfiguration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Licenses", "User_Id", "dbo.PUsers");
            DropIndex("dbo.Licenses", new[] { "User_Id" });
            AlterColumn("dbo.Licenses", "LicenseString", c => c.String(maxLength: 255));
            AlterColumn("dbo.Licenses", "HKeyString", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Licenses", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Licenses", "User_Id");
            AddForeignKey("dbo.Licenses", "User_Id", "dbo.PUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Licenses", "User_Id", "dbo.PUsers");
            DropIndex("dbo.Licenses", new[] { "User_Id" });
            AlterColumn("dbo.Licenses", "User_Id", c => c.Int());
            AlterColumn("dbo.Licenses", "HKeyString", c => c.String());
            AlterColumn("dbo.Licenses", "LicenseString", c => c.String());
            CreateIndex("dbo.Licenses", "User_Id");
            AddForeignKey("dbo.Licenses", "User_Id", "dbo.PUsers", "Id");
        }
    }
}

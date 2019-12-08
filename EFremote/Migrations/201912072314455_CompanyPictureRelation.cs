namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyPictureRelation : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Companies", new[] { "Logo_Id" });
            RenameColumn(table: "dbo.Pictures", name: "Logo_Id", newName: "Company_Id");
            CreateIndex("dbo.Pictures", "Company_Id");
            DropColumn("dbo.Companies", "Logo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Logo_Id", c => c.Int());
            DropIndex("dbo.Pictures", new[] { "Company_Id" });
            RenameColumn(table: "dbo.Pictures", name: "Company_Id", newName: "Logo_Id");
            CreateIndex("dbo.Companies", "Logo_Id");
        }
    }
}

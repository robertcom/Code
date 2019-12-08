namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoRelationCompanyPicture : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "Logo_Id", "dbo.Pictures");
            DropIndex("dbo.Companies", new[] { "Logo_Id" });
            DropColumn("dbo.Companies", "Logo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Logo_Id", c => c.Int());
            CreateIndex("dbo.Companies", "Logo_Id");
            AddForeignKey("dbo.Companies", "Logo_Id", "dbo.Pictures", "Id");
        }
    }
}

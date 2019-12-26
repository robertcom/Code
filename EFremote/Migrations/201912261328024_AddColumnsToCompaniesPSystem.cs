namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToCompaniesPSystem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "IsVisible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Companies", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Companies", "IsProducer", c => c.Boolean(nullable: false));
            AddColumn("dbo.PSystems", "Company_Id", c => c.Int());
            CreateIndex("dbo.PSystems", "Company_Id");
            AddForeignKey("dbo.PSystems", "Company_Id", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PSystems", "Company_Id", "dbo.Companies");
            DropIndex("dbo.PSystems", new[] { "Company_Id" });
            DropColumn("dbo.PSystems", "Company_Id");
            DropColumn("dbo.Companies", "IsProducer");
            DropColumn("dbo.Companies", "IsDeleted");
            DropColumn("dbo.Companies", "IsVisible");
        }
    }
}

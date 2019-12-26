namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKCompanyNotNullInPSystem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PSystems", "Company_Id", "dbo.Companies");
            DropIndex("dbo.PSystems", new[] { "Company_Id" });
            AlterColumn("dbo.PSystems", "Company_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.PSystems", "Company_Id");
            AddForeignKey("dbo.PSystems", "Company_Id", "dbo.Companies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PSystems", "Company_Id", "dbo.Companies");
            DropIndex("dbo.PSystems", new[] { "Company_Id" });
            AlterColumn("dbo.PSystems", "Company_Id", c => c.Int());
            CreateIndex("dbo.PSystems", "Company_Id");
            AddForeignKey("dbo.PSystems", "Company_Id", "dbo.Companies", "Id");
        }
    }
}

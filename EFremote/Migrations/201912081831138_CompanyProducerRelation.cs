namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyProducerRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PSystems", "Producer_Id", "dbo.Producers");
            DropPrimaryKey("dbo.Producers");
            DropPrimaryKey("dbo.PSystemUsers");
            AlterColumn("dbo.Producers", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Producers", "Id");
            AddPrimaryKey("dbo.PSystemUsers", new[] { "User_Id", "PSystem_Id" });
            CreateIndex("dbo.Producers", "Id");
            AddForeignKey("dbo.Producers", "Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.PSystems", "Producer_Id", "dbo.Producers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PSystems", "Producer_Id", "dbo.Producers");
            DropForeignKey("dbo.Producers", "Id", "dbo.Companies");
            DropIndex("dbo.Producers", new[] { "Id" });
            DropPrimaryKey("dbo.PSystemUsers");
            DropPrimaryKey("dbo.Producers");
            AlterColumn("dbo.Producers", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PSystemUsers", new[] { "PSystem_Id", "User_Id" });
            AddPrimaryKey("dbo.Producers", "Id");
            AddForeignKey("dbo.PSystems", "Producer_Id", "dbo.Producers", "Id");
        }
    }
}

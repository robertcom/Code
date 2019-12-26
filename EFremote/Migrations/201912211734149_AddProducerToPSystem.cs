namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProducerToPSystem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PSystems", "Producer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.PSystems", "Producer_Id");
            AddForeignKey("dbo.PSystems", "Producer_Id", "dbo.Producers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PSystems", "Producer_Id", "dbo.Producers");
            DropIndex("dbo.PSystems", new[] { "Producer_Id" });
            DropColumn("dbo.PSystems", "Producer_Id");
        }
    }
}

namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProducerFromPSystem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PSystems", "Producer_Id", "dbo.Producers");
            DropIndex("dbo.PSystems", new[] { "Producer_Id" });
            DropColumn("dbo.PSystems", "Producer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PSystems", "Producer_Id", c => c.Int());
            CreateIndex("dbo.PSystems", "Producer_Id");
            AddForeignKey("dbo.PSystems", "Producer_Id", "dbo.Producers", "Id");
        }
    }
}

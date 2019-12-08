namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfilePictureRelation : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Pictures");
            AlterColumn("dbo.Pictures", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Pictures", "Id");
            CreateIndex("dbo.Pictures", "Id");
            AddForeignKey("dbo.Pictures", "Id", "dbo.Profiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "Id", "dbo.Profiles");
            DropIndex("dbo.Pictures", new[] { "Id" });
            DropPrimaryKey("dbo.Pictures");
            AlterColumn("dbo.Pictures", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Pictures", "Id");
        }
    }
}

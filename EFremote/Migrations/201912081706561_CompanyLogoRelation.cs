namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyLogoRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logos",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FileName = c.String(),
                        Description = c.String(),
                        Path = c.String(),
                        Width = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logos", "Id", "dbo.Companies");
            DropIndex("dbo.Logos", new[] { "Id" });
            DropTable("dbo.Logos");
        }
    }
}

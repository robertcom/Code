namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProducerTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PSystems", "Producer_Id", "dbo.Producers");
            DropForeignKey("dbo.Producers", "Id", "dbo.Companies");
            DropIndex("dbo.Producers", new[] { "Id" });
            DropIndex("dbo.Producers", "Index_indeks");
            DropIndex("dbo.PSystems", new[] { "Producer_Id" });
            DropColumn("dbo.PSystems", "Producer_Id");
            DropTable("dbo.Producers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Indeks = c.String(nullable: false, maxLength: 80),
                        Name = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PSystems", "Producer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.PSystems", "Producer_Id");
            CreateIndex("dbo.Producers", "Indeks", unique: true, name: "Index_indeks");
            CreateIndex("dbo.Producers", "Id");
            AddForeignKey("dbo.Producers", "Id", "dbo.Companies", "Id");
            AddForeignKey("dbo.PSystems", "Producer_Id", "dbo.Producers", "Id", cascadeDelete: true);
        }
    }
}

namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaterialConfiguration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Materials", "Indeks", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Materials", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Materials", "Description", c => c.String(maxLength: 80));
            CreateIndex("dbo.Materials", "Indeks", unique: true, name: "Index_Indeks");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Materials", "Index_Indeks");
            AlterColumn("dbo.Materials", "Description", c => c.String());
            AlterColumn("dbo.Materials", "Name", c => c.String());
            AlterColumn("dbo.Materials", "Indeks", c => c.String());
        }
    }
}

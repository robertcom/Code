namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureAndProducerConfiguration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pictures", "FileName", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Pictures", "Description", c => c.String(maxLength: 255));
            AlterColumn("dbo.Pictures", "Path", c => c.String(nullable: false));
            AlterColumn("dbo.Producers", "Indeks", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Producers", "Name", c => c.String(maxLength: 80));
            CreateIndex("dbo.Pictures", "FileName", unique: true, name: "Index_FileName");
            CreateIndex("dbo.Producers", "Indeks", unique: true, name: "Index_indeks");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Producers", "Index_indeks");
            DropIndex("dbo.Pictures", "Index_FileName");
            AlterColumn("dbo.Producers", "Name", c => c.String());
            AlterColumn("dbo.Producers", "Indeks", c => c.String());
            AlterColumn("dbo.Pictures", "Path", c => c.String());
            AlterColumn("dbo.Pictures", "Description", c => c.String());
            AlterColumn("dbo.Pictures", "FileName", c => c.String());
        }
    }
}

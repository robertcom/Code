namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigureCompanies : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "Indeks", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Companies", "Name", c => c.String(maxLength: 80));
            AlterColumn("dbo.Companies", "Street", c => c.String(maxLength: 80));
            AlterColumn("dbo.Companies", "No", c => c.String(maxLength: 10));
            AlterColumn("dbo.Companies", "Code", c => c.String(maxLength: 10));
            AlterColumn("dbo.Companies", "City", c => c.String(maxLength: 80));
            AlterColumn("dbo.Companies", "Country", c => c.String(maxLength: 80));
            CreateIndex("dbo.Companies", "Indeks", name: "Index_Indeks");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Companies", "Index_Indeks");
            AlterColumn("dbo.Companies", "Country", c => c.String());
            AlterColumn("dbo.Companies", "City", c => c.String());
            AlterColumn("dbo.Companies", "Code", c => c.String());
            AlterColumn("dbo.Companies", "No", c => c.String());
            AlterColumn("dbo.Companies", "Street", c => c.String());
            AlterColumn("dbo.Companies", "Name", c => c.String());
            AlterColumn("dbo.Companies", "Indeks", c => c.String());
        }
    }
}

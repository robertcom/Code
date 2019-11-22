namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigureCompanies_UniqueIndeks : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Companies", "Index_Indeks");
            CreateIndex("dbo.Companies", "Indeks", unique: true, name: "Index_Indeks");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Companies", "Index_Indeks");
            CreateIndex("dbo.Companies", "Indeks", name: "Index_Indeks");
        }
    }
}

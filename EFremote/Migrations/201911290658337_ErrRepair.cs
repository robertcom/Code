namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrRepair : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "Picture_Id", "dbo.Pictures");
            DropIndex("dbo.Profiles", new[] { "Picture_Id" });
            AlterColumn("dbo.Profiles", "Indeks", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Profiles", "Name", c => c.String(maxLength: 80));
            AlterColumn("dbo.Profiles", "Ixmm4", c => c.Double());
            AlterColumn("dbo.Profiles", "Iymm4", c => c.Double());
            AlterColumn("dbo.Profiles", "Wxmm3", c => c.Double());
            AlterColumn("dbo.Profiles", "Wymm3", c => c.Double());
            AlterColumn("dbo.Profiles", "Scmm", c => c.Double());
            AlterColumn("dbo.Profiles", "Stmm", c => c.Double());
            AlterColumn("dbo.Profiles", "Symm", c => c.Double());
            AlterColumn("dbo.Profiles", "Amm2", c => c.Double());
            AlterColumn("dbo.Profiles", "Ix", c => c.Double());
            AlterColumn("dbo.Profiles", "Iy", c => c.Double());
            AlterColumn("dbo.Profiles", "Wx", c => c.Double());
            AlterColumn("dbo.Profiles", "Wy", c => c.Double());
            AlterColumn("dbo.Profiles", "A", c => c.Double());
            AlterColumn("dbo.Profiles", "Weight", c => c.Double());
            AlterColumn("dbo.Profiles", "Ixeff", c => c.Double());
            AlterColumn("dbo.Profiles", "Aeff", c => c.Double());
            AlterColumn("dbo.Profiles", "IsMullion", c => c.Boolean());
            AlterColumn("dbo.Profiles", "IsTransom", c => c.Boolean());
            AlterColumn("dbo.Profiles", "Sort", c => c.Int());
            CreateIndex("dbo.Profiles", "Indeks", unique: true, name: "Index_indeks");
            DropColumn("dbo.Profiles", "Picture_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Picture_Id", c => c.Int());
            DropIndex("dbo.Profiles", "Index_indeks");
            AlterColumn("dbo.Profiles", "Sort", c => c.Int(nullable: false));
            AlterColumn("dbo.Profiles", "IsTransom", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Profiles", "IsMullion", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Profiles", "Aeff", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Ixeff", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Weight", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "A", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Wy", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Wx", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Iy", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Ix", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Amm2", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Symm", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Stmm", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Scmm", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Wymm3", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Wxmm3", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Iymm4", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Ixmm4", c => c.Double(nullable: false));
            AlterColumn("dbo.Profiles", "Name", c => c.String());
            AlterColumn("dbo.Profiles", "Indeks", c => c.String());
            CreateIndex("dbo.Profiles", "Picture_Id");
            AddForeignKey("dbo.Profiles", "Picture_Id", "dbo.Pictures", "Id");
        }
    }
}

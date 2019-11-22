namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfilePictureConfiguration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PSystemUsers", newName: "UserPSystems");
            DropIndex("dbo.Profiles", new[] { "Picture_Id" });
            RenameColumn(table: "dbo.Pictures", name: "Picture_Id", newName: "Profile_Id");
            DropPrimaryKey("dbo.UserPSystems");
            AddColumn("dbo.Pictures", "Producer_Id", c => c.Int());
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
            AddPrimaryKey("dbo.UserPSystems", new[] { "User_Id", "PSystem_Id" });
            CreateIndex("dbo.Pictures", "Producer_Id");
            CreateIndex("dbo.Pictures", "Profile_Id");
            CreateIndex("dbo.Profiles", "Indeks", unique: true, name: "Index_indeks");
            AddForeignKey("dbo.Pictures", "Producer_Id", "dbo.Producers", "Id");
            DropColumn("dbo.Profiles", "Picture_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Picture_Id", c => c.Int());
            DropForeignKey("dbo.Pictures", "Producer_Id", "dbo.Producers");
            DropIndex("dbo.Profiles", "Index_indeks");
            DropIndex("dbo.Pictures", new[] { "Profile_Id" });
            DropIndex("dbo.Pictures", new[] { "Producer_Id" });
            DropPrimaryKey("dbo.UserPSystems");
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
            DropColumn("dbo.Pictures", "Producer_Id");
            AddPrimaryKey("dbo.UserPSystems", new[] { "PSystem_Id", "User_Id" });
            RenameColumn(table: "dbo.Pictures", name: "Profile_Id", newName: "Picture_Id");
            CreateIndex("dbo.Profiles", "Picture_Id");
            RenameTable(name: "dbo.UserPSystems", newName: "PSystemUsers");
        }
    }
}

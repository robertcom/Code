namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Indeks = c.String(),
                        Name = c.String(),
                        Street = c.String(),
                        No = c.String(),
                        Code = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Logo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pictures", t => t.Logo_Id)
                .Index(t => t.Logo_Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Description = c.String(),
                        Path = c.String(),
                        Width = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LicenseString = c.String(),
                        UsedHKeysCounter = c.Int(nullable: false),
                        HKeysValidAmount = c.Int(nullable: false),
                        CheckLicenseFreq = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        TempCompany = c.String(),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Licenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicenseString = c.String(),
                        HKeyString = c.String(),
                        IsHKeyValid = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.PSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Indeks = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Producer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producers", t => t.Producer_Id)
                .Index(t => t.Producer_Id);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Indeks = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Indeks = c.String(),
                        Name = c.String(),
                        Ixmm4 = c.Double(nullable: false),
                        Iymm4 = c.Double(nullable: false),
                        Wxmm3 = c.Double(nullable: false),
                        Wymm3 = c.Double(nullable: false),
                        Scmm = c.Double(nullable: false),
                        Stmm = c.Double(nullable: false),
                        Symm = c.Double(nullable: false),
                        Amm2 = c.Double(nullable: false),
                        Ix = c.Double(nullable: false),
                        Iy = c.Double(nullable: false),
                        Wx = c.Double(nullable: false),
                        Wy = c.Double(nullable: false),
                        A = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Ixeff = c.Double(nullable: false),
                        Aeff = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsInsulated = c.Boolean(nullable: false),
                        IsMullion = c.Boolean(nullable: false),
                        IsTransom = c.Boolean(nullable: false),
                        Sort = c.Int(nullable: false),
                        Material_Id = c.Int(),
                        Picture_Id = c.Int(),
                        System_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.Material_Id)
                .ForeignKey("dbo.Pictures", t => t.Picture_Id)
                .ForeignKey("dbo.PSystems", t => t.System_Id)
                .Index(t => t.Material_Id)
                .Index(t => t.Picture_Id)
                .Index(t => t.System_Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Indeks = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        fo = c.Double(nullable: false),
                        fu = c.Double(nullable: false),
                        E = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PL_Phrase = c.String(),
                        Eng_Phrase = c.String(),
                        Ger_Phrase = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PSystemPUsers",
                c => new
                    {
                        PSystem_Id = c.Int(nullable: false),
                        PUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PSystem_Id, t.PUser_Id })
                .ForeignKey("dbo.PSystems", t => t.PSystem_Id, cascadeDelete: true)
                .ForeignKey("dbo.PUsers", t => t.PUser_Id, cascadeDelete: true)
                .Index(t => t.PSystem_Id)
                .Index(t => t.PUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PSystemPUsers", "PUser_Id", "dbo.PUsers");
            DropForeignKey("dbo.PSystemPUsers", "PSystem_Id", "dbo.PSystems");
            DropForeignKey("dbo.Profiles", "System_Id", "dbo.PSystems");
            DropForeignKey("dbo.Profiles", "Picture_Id", "dbo.Pictures");
            DropForeignKey("dbo.Profiles", "Material_Id", "dbo.Materials");
            DropForeignKey("dbo.PSystems", "Producer_Id", "dbo.Producers");
            DropForeignKey("dbo.Licenses", "User_Id", "dbo.PUsers");
            DropForeignKey("dbo.PConfigurations", "Id", "dbo.PUsers");
            DropForeignKey("dbo.PUsers", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Companies", "Logo_Id", "dbo.Pictures");
            DropIndex("dbo.PSystemPUsers", new[] { "PUser_Id" });
            DropIndex("dbo.PSystemPUsers", new[] { "PSystem_Id" });
            DropIndex("dbo.Profiles", new[] { "System_Id" });
            DropIndex("dbo.Profiles", new[] { "Picture_Id" });
            DropIndex("dbo.Profiles", new[] { "Material_Id" });
            DropIndex("dbo.PSystems", new[] { "Producer_Id" });
            DropIndex("dbo.Licenses", new[] { "User_Id" });
            DropIndex("dbo.PUsers", new[] { "Company_Id" });
            DropIndex("dbo.PConfigurations", new[] { "Id" });
            DropIndex("dbo.Companies", new[] { "Logo_Id" });
            DropTable("dbo.PSystemPUsers");
            DropTable("dbo.Translations");
            DropTable("dbo.Materials");
            DropTable("dbo.Profiles");
            DropTable("dbo.Producers");
            DropTable("dbo.PSystems");
            DropTable("dbo.Licenses");
            DropTable("dbo.PUsers");
            DropTable("dbo.PConfigurations");
            DropTable("dbo.Pictures");
            DropTable("dbo.Companies");
        }
    }
}

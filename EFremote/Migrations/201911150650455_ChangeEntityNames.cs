namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEntityNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PConfigurations", newName: "Configs");
            RenameTable(name: "dbo.PUsers", newName: "Users");
            RenameTable(name: "dbo.PSystemPUsers", newName: "PSystemUsers");
            RenameColumn(table: "dbo.PSystemUsers", name: "PUser_Id", newName: "User_Id");
            RenameIndex(table: "dbo.PSystemUsers", name: "IX_PUser_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PSystemUsers", name: "IX_User_Id", newName: "IX_PUser_Id");
            RenameColumn(table: "dbo.PSystemUsers", name: "User_Id", newName: "PUser_Id");
            RenameTable(name: "dbo.PSystemUsers", newName: "PSystemPUsers");
            RenameTable(name: "dbo.Users", newName: "PUsers");
            RenameTable(name: "dbo.Configs", newName: "PConfigurations");
        }
    }
}

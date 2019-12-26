namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyAliplastRecord : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Companies SET IsVisible=1, IsDeleted=0, IsProducer=1" +
                " WHERE Id=1");
        }
        
        public override void Down()
        {
            Sql("UPDATE Companies SET IsVisible=0, IsDeleted=0, IsProducer=0" +
                " WHERE Id=1");
        }
    }
}

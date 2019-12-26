namespace EFremote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillCompaniesTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Statyka01.dbo.Companies ON");
            Sql("INSERT INTO Companies(Id, Indeks, Name, Street, No, Code, City, Country)" +
                " VALUES(1, 'ALIPLAST', 'Aliplast Sp. z o.o.', 'Wacława Moritza', '3', '20-276', 'Lublin', 'Polska')");
            Sql("SET IDENTITY_INSERT Statyka01.dbo.Companies OFF");
        }
        
        public override void Down()
        {
            Sql("SET IDENTITY_INSERT Statyka01.dbo.Companies OFF");
            Sql("DELETE FROM Companies WHERE Id=1;");
        }
    }
}

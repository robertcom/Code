namespace EFremote
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using DAModel.Core.Domain;
    using EFremote.EntityConfigurations;

    public class StatykaModel : DbContext
    {
        // Your context has been configured to use a 'StatykaModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EFremote.StatykaModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StatykaModel' 
        // connection string in the application configuration file.
        public StatykaModel()
            : base("name=efMsSql01")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Company> Companies { get; set; } // uw
        public DbSet<License> Licenses { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<PSystem> Systems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Translation> Translations { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<User>(new UserConfiguration());
            modelBuilder.Configurations.Add<Company>(new CompanyConfiguration());
            modelBuilder.Configurations.Add<License>(new LicenseConfiguration());
            modelBuilder.Configurations.Add<Material>(new MaterialConfiguration());
            modelBuilder.Configurations.Add<Picture>(new PictureConfiguration());
            modelBuilder.Configurations.Add<Producer>(new ProducerConfiguration());
            modelBuilder.Configurations.Add<Profile>(new ProfileConfiguration());
            modelBuilder.Configurations.Add<Logo>(new LogoConfiguration());
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
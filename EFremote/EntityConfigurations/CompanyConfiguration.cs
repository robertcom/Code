
using System.Data.Entity.ModelConfiguration;
using DAModel.Core.Domain;

namespace EFremote.EntityConfigurations
{
    public class CompanyConfiguration:EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            this.ToTable("Companies");
            this.HasIndex(p => p.Indeks).IsUnique().HasName("Index_Indeks");

            HasOptional(c => c.Logo)
                .WithRequired(l => l.Company);

            Property(p => p.Indeks)
                .IsRequired()
                .HasMaxLength(80);
            Property(p => p.Name)
                .HasMaxLength(80);
            Property(p => p.Street)
               .HasMaxLength(80);
            Property(p => p.No)
              .HasMaxLength(10);
            Property(p => p.Code)
             .HasMaxLength(10);
            Property(p => p.City)
               .HasMaxLength(80);
            Property(p => p.Country)
               .HasMaxLength(80);
        }
    }
}

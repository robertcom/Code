using System.Data.Entity.ModelConfiguration;
using DAModel.Core.Domain;

namespace EFremote.EntityConfigurations
{
    public class MaterialConfiguration:EntityTypeConfiguration<Material>
    {
        public MaterialConfiguration()
        {
            this.HasIndex(p => p.Indeks).IsUnique().HasName("Index_Indeks");

            Property(p => p.Indeks)
                .IsRequired()
                .HasMaxLength(10);
            Property(p => p.Name)
                .HasMaxLength(50);
            Property(p => p.Description)
                .HasMaxLength(80);
        }
    }
}

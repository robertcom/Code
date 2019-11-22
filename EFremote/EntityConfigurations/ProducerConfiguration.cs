using System.Data.Entity.ModelConfiguration;
using DAModel.Core.Domain;

namespace EFremote.EntityConfigurations
{
    public class ProducerConfiguration:EntityTypeConfiguration<Producer>
    {
        public ProducerConfiguration()
        {
            HasOptional(p => p.Picture)
                .WithOptionalPrincipal(p => p.Producer);

            HasIndex(p => p.Indeks)
                .HasName("Index_indeks")
                .IsUnique();

            Property(p => p.Indeks)
                .IsRequired()
                .HasMaxLength(80);

            Property(p => p.Name)
                .HasMaxLength(80);
        }
    }
}

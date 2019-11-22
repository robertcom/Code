using System.Data.Entity.ModelConfiguration;
using DAModel.Core.Domain;

namespace EFremote.EntityConfigurations
{
    public class PictureConfiguration:EntityTypeConfiguration<Picture>
    {
        public PictureConfiguration()
        {
            HasIndex(p => p.FileName)
                .HasName("Index_FileName")
                .IsUnique();

            Property(p => p.FileName)
                .HasMaxLength(80)
                .IsRequired();
            Property(p => p.Path)
                .IsRequired();
            Property(p => p.Description)
                .HasMaxLength(255);
        }
    }
}

using System.Data.Entity.ModelConfiguration;
using DAModel.Core.Domain;

namespace EFremote.EntityConfigurations
{
    public class ProfileConfiguration: EntityTypeConfiguration<Profile>
    {
        public ProfileConfiguration()
        {
            //HasOptional(p => p.Picture)
            //    .WithOptionalPrincipal(p => p.Profile);
            HasIndex(p => p.Indeks)
                .HasName("Index_indeks")
                .IsUnique();

            Property(p => p.Indeks)
               .IsRequired()
               .HasMaxLength(80);

            Property(p => p.Name)
                .HasMaxLength(80);

            Property(p => p.Ix)
                .IsOptional();
            Property(p => p.Ixmm4)
                .IsOptional();
            Property(p => p.Ixeff)
                .IsOptional();
            Property(p => p.Iy)
                .IsOptional();
            Property(p => p.Iymm4)
                .IsOptional();
            Property(p => p.Wx)
                .IsOptional();
            Property(p => p.Wxmm3)
                .IsOptional();
            Property(p => p.Wy)
                .IsOptional();
            Property(p => p.Wymm3)
                .IsOptional();
            Property(p => p.Scmm)
                .IsOptional();
            Property(p => p.Stmm)
                .IsOptional();
            Property(p => p.Symm)
                .IsOptional();
            Property(p => p.Amm2)
                .IsOptional();
            Property(p => p.A)
                .IsOptional();
            Property(p => p.Aeff)
                .IsOptional();
            Property(p => p.Weight)
                .IsOptional();
            Property(p => p.IsMullion)
                .IsOptional();
            Property(p => p.IsTransom)
                .IsOptional();
            Property(p => p.Sort)
                .IsOptional();
        }
    }
}

using System.Data.Entity.ModelConfiguration;
using DAModel.Core.Domain;

namespace EFremote.EntityConfigurations
{
    public class PSystemConfiguration:EntityTypeConfiguration<PSystem>
    {
        public PSystemConfiguration()
        {
            //HasRequired(p => p.Producer);
        }
    }
}

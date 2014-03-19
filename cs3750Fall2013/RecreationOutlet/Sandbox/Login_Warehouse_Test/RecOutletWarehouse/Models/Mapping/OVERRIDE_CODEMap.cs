using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class OVERRIDE_CODEMap : EntityTypeConfiguration<OVERRIDE_CODE>
    {
        public OVERRIDE_CODEMap()
        {
            // Primary Key
            this.HasKey(t => t.OverrideCode);

            // Properties
            this.Property(t => t.OverrideReason)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OVERRIDE_CODE");
            this.Property(t => t.OverrideCode).HasColumnName("OverrideCode");
            this.Property(t => t.OverrideReason).HasColumnName("OverrideReason");
        }
    }
}

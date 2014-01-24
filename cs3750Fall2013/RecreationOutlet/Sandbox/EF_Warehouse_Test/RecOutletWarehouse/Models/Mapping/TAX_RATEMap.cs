using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class TAX_RATEMap : EntityTypeConfiguration<TAX_RATE>
    {
        public TAX_RATEMap()
        {
            // Primary Key
            this.HasKey(t => t.TaxRateID);

            // Properties
            this.Property(t => t.TaxRateType)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TAX_RATE");
            this.Property(t => t.TaxRateID).HasColumnName("TaxRateID");
            this.Property(t => t.TaxRateType).HasColumnName("TaxRateType");
            this.Property(t => t.TaxRate).HasColumnName("TaxRate");
        }
    }
}

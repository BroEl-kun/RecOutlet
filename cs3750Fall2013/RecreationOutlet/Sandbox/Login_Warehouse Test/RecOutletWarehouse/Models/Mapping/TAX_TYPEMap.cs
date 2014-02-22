using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class TAX_TYPEMap : EntityTypeConfiguration<TAX_TYPE>
    {
        public TAX_TYPEMap()
        {
            // Primary Key
            this.HasKey(t => t.TaxTypeID);

            // Properties
            this.Property(t => t.TaxTypeName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TAX_TYPE");
            this.Property(t => t.TaxTypeID).HasColumnName("TaxTypeID");
            this.Property(t => t.TaxTypeName).HasColumnName("TaxTypeName");
        }
    }
}

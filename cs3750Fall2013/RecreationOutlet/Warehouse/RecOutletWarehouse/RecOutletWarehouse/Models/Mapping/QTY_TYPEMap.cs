using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class QTY_TYPEMap : EntityTypeConfiguration<QTY_TYPE>
    {
        public QTY_TYPEMap()
        {
            // Primary Key
            this.HasKey(t => t.QtyTypeID);

            // Properties
            this.Property(t => t.QtyTypeDescription)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("QTY_TYPE");
            this.Property(t => t.QtyTypeID).HasColumnName("QtyTypeID");
            this.Property(t => t.QtyTypeDescription).HasColumnName("QtyTypeDescription");
        }
    }
}

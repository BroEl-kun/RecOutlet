using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class REFUND_CODEMap : EntityTypeConfiguration<REFUND_CODE>
    {
        public REFUND_CODEMap()
        {
            // Primary Key
            this.HasKey(t => t.RefundCode);

            // Properties
            this.Property(t => t.RefundReason)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("REFUND_CODE");
            this.Property(t => t.RefundCode).HasColumnName("RefundCode");
            this.Property(t => t.RefundReason).HasColumnName("RefundReason");
        }
    }
}

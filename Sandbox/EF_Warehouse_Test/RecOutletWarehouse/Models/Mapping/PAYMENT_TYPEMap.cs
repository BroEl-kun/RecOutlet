using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class PAYMENT_TYPEMap : EntityTypeConfiguration<PAYMENT_TYPE>
    {
        public PAYMENT_TYPEMap()
        {
            // Primary Key
            this.HasKey(t => t.PaymentTypeID);

            // Properties
            this.Property(t => t.PaymentTypeName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PAYMENT_TYPE");
            this.Property(t => t.PaymentTypeID).HasColumnName("PaymentTypeID");
            this.Property(t => t.PaymentTypeName).HasColumnName("PaymentTypeName");
        }
    }
}

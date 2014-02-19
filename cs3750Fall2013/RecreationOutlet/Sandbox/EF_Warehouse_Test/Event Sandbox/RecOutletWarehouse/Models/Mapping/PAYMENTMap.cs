using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class PAYMENTMap : EntityTypeConfiguration<PAYMENT>
    {
        public PAYMENTMap()
        {
            // Primary Key
            this.HasKey(t => t.PaymentID);

            // Properties
            // Table & Column Mappings
            this.ToTable("PAYMENT");
            this.Property(t => t.PaymentID).HasColumnName("PaymentID");
            this.Property(t => t.PaymentTypeID).HasColumnName("PaymentTypeID");
            this.Property(t => t.TransactionID).HasColumnName("TransactionID");
            this.Property(t => t.PaymentAmount).HasColumnName("PaymentAmount");

            // Relationships
            this.HasRequired(t => t.PAYMENT_TYPE)
                .WithMany(t => t.PAYMENTs)
                .HasForeignKey(d => d.PaymentTypeID);
            this.HasRequired(t => t.STORE_TRANSACTION)
                .WithMany(t => t.PAYMENTs)
                .HasForeignKey(d => d.TransactionID);

        }
    }
}

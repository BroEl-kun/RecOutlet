using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class PAYMENTMap : EntityTypeConfiguration<PAYMENT>
    {
        public PAYMENTMap()
        {
            // Primary Key
            this.HasKey(t => new { t.PaymentID, t.PaymentTypeID, t.StoreID });

            // Properties
            this.Property(t => t.PaymentID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("PAYMENT");
            this.Property(t => t.PaymentID).HasColumnName("PaymentID");
            this.Property(t => t.PaymentTypeID).HasColumnName("PaymentTypeID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.PaymentAmount).HasColumnName("PaymentAmount");

            // Relationships
            this.HasRequired(t => t.LOCATION)
                .WithMany(t => t.PAYMENTs)
                .HasForeignKey(d => d.StoreID);
            this.HasRequired(t => t.PAYMENT_TYPE)
                .WithMany(t => t.PAYMENTs)
                .HasForeignKey(d => d.PaymentTypeID);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class SHIPPING_LOGMap : EntityTypeConfiguration<SHIPPING_LOG>
    {
        public SHIPPING_LOGMap()
        {
            // Primary Key
            this.HasKey(t => t.ShippingID);

            // Properties
            this.Property(t => t.ShippingID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Attention)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShipSource)
                .HasMaxLength(50);

            this.Property(t => t.TrackingNum)
                .HasMaxLength(50);

            this.Property(t => t.FreightProvider)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SHIPPING_LOG");
            this.Property(t => t.ShippingID).HasColumnName("ShippingID");
            this.Property(t => t.InvoiceID).HasColumnName("InvoiceID");
            this.Property(t => t.ShippingNotes).HasColumnName("ShippingNotes");
            this.Property(t => t.ShippingFrieghtCost).HasColumnName("ShippingFrieghtCost");
            this.Property(t => t.Attention).HasColumnName("Attention");
            this.Property(t => t.EstimatedShipDate).HasColumnName("EstimatedShipDate");
            this.Property(t => t.ShipDate).HasColumnName("ShipDate");
            this.Property(t => t.ShipSource).HasColumnName("ShipSource");
            this.Property(t => t.TrackingNum).HasColumnName("TrackingNum");
            this.Property(t => t.FreightProvider).HasColumnName("FreightProvider");

            // Relationships
            this.HasRequired(t => t.INVOICE)
                .WithMany(t => t.SHIPPING_LOG)
                .HasForeignKey(d => d.InvoiceID);

        }
    }
}

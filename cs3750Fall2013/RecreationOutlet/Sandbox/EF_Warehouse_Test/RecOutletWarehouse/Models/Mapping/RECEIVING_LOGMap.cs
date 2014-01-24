using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class RECEIVING_LOGMap : EntityTypeConfiguration<RECEIVING_LOG>
    {
        public RECEIVING_LOGMap()
        {
            // Primary Key
            this.HasKey(t => t.ReceivingID);

            // Properties
            // Table & Column Mappings
            this.ToTable("RECEIVING_LOG");
            this.Property(t => t.ReceivingID).HasColumnName("ReceivingID");
            this.Property(t => t.POLineItemID).HasColumnName("POLineItemID");
            this.Property(t => t.BackorderID).HasColumnName("BackorderID");
            this.Property(t => t.QtyTypeID).HasColumnName("QtyTypeID");
            this.Property(t => t.ReceiveDate).HasColumnName("ReceiveDate");
            this.Property(t => t.ReceivingNotes).HasColumnName("ReceivingNotes");
            this.Property(t => t.ReceivedQty).HasColumnName("ReceivedQty");

            // Relationships
            this.HasOptional(t => t.BACKORDER)
                .WithMany(t => t.RECEIVING_LOG)
                .HasForeignKey(d => d.BackorderID);
            this.HasOptional(t => t.PO_LINEITEM)
                .WithMany(t => t.RECEIVING_LOG)
                .HasForeignKey(d => d.POLineItemID);
            this.HasOptional(t => t.QTY_TYPE)
                .WithMany(t => t.RECEIVING_LOG)
                .HasForeignKey(d => d.QtyTypeID);

        }
    }
}

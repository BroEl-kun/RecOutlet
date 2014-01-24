using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class PO_LINEITEMMap : EntityTypeConfiguration<PO_LINEITEM>
    {
        public PO_LINEITEMMap()
        {
            // Primary Key
            this.HasKey(t => t.POLineItemID);

            // Properties
            // Table & Column Mappings
            this.ToTable("PO_LINEITEM");
            this.Property(t => t.POLineItemID).HasColumnName("POLineItemID");
            this.Property(t => t.POID).HasColumnName("POID");
            this.Property(t => t.RecRPC).HasColumnName("RecRPC");
            this.Property(t => t.WholesaleCost).HasColumnName("WholesaleCost");
            this.Property(t => t.QtyOrdered).HasColumnName("QtyOrdered");
            this.Property(t => t.QtyTypeID).HasColumnName("QtyTypeID");

            // Relationships
            this.HasRequired(t => t.ITEM)
                .WithMany(t => t.PO_LINEITEM)
                .HasForeignKey(d => d.RecRPC);
            this.HasRequired(t => t.PURCHASE_ORDER)
                .WithMany(t => t.PO_LINEITEM)
                .HasForeignKey(d => d.POID);
            this.HasRequired(t => t.QTY_TYPE)
                .WithMany(t => t.PO_LINEITEM)
                .HasForeignKey(d => d.QtyTypeID);

        }
    }
}

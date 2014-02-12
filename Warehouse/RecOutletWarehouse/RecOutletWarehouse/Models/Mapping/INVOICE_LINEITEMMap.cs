using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class INVOICE_LINEITEMMap : EntityTypeConfiguration<INVOICE_LINEITEM>
    {
        public INVOICE_LINEITEMMap()
        {
            // Primary Key
            this.HasKey(t => t.InvoiceLineItemID);

            // Properties
            this.Property(t => t.InvoiceLineItemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("INVOICE_LINEITEM");
            this.Property(t => t.InvoiceLineItemID).HasColumnName("InvoiceLineItemID");
            this.Property(t => t.InvoiceID).HasColumnName("InvoiceID");
            this.Property(t => t.RecRPC).HasColumnName("RecRPC");
            this.Property(t => t.QtyTypeID).HasColumnName("QtyTypeID");
            this.Property(t => t.ItemQty).HasColumnName("ItemQty");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.UnitCost).HasColumnName("UnitCost");

            // Relationships
            this.HasRequired(t => t.INVOICE)
                .WithMany(t => t.INVOICE_LINEITEM)
                .HasForeignKey(d => d.InvoiceID);
            this.HasRequired(t => t.ITEM)
                .WithMany(t => t.INVOICE_LINEITEM)
                .HasForeignKey(d => d.RecRPC);
            this.HasRequired(t => t.QTY_TYPE)
                .WithMany(t => t.INVOICE_LINEITEM)
                .HasForeignKey(d => d.QtyTypeID);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class TRANSACTION_LINEITEMMap : EntityTypeConfiguration<TRANSACTION_LINEITEM>
    {
        public TRANSACTION_LINEITEMMap()
        {
            // Primary Key
            this.HasKey(t => t.TransactionLineItemID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TRANSACTION_LINEITEM");
            this.Property(t => t.TransactionLineItemID).HasColumnName("TransactionLineItemID");
            this.Property(t => t.TransactionID).HasColumnName("TransactionID");
            this.Property(t => t.RecRPC).HasColumnName("RecRPC");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.UnitCost).HasColumnName("UnitCost");
            this.Property(t => t.CommissionEmployeeID).HasColumnName("CommissionEmployeeID");
            this.Property(t => t.ItemTaxTotal).HasColumnName("ItemTaxTotal");
            this.Property(t => t.ItemTotal).HasColumnName("ItemTotal");

            // Relationships
            this.HasRequired(t => t.ITEM)
                .WithMany(t => t.TRANSACTION_LINEITEM)
                .HasForeignKey(d => d.RecRPC);
            this.HasRequired(t => t.STORE_TRANSACTION)
                .WithMany(t => t.TRANSACTION_LINEITEM)
                .HasForeignKey(d => d.TransactionID);

        }
    }
}

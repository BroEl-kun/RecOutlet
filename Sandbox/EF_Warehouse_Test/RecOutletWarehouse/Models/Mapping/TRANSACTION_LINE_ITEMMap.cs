using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class TRANSACTION_LINE_ITEMMap : EntityTypeConfiguration<TRANSACTION_LINE_ITEM>
    {
        public TRANSACTION_LINE_ITEMMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TransactionLineItemID, t.TransactionID, t.StoreID });

            // Properties
            this.Property(t => t.TransactionLineItemID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.TransactionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("TRANSACTION_LINE_ITEM");
            this.Property(t => t.TransactionLineItemID).HasColumnName("TransactionLineItemID");
            this.Property(t => t.TransactionID).HasColumnName("TransactionID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.RecID).HasColumnName("RecID");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.SaleEach).HasColumnName("SaleEach");
            this.Property(t => t.CommissionEmployeeID).HasColumnName("CommissionEmployeeID");
            this.Property(t => t.OverrideCode).HasColumnName("OverrideCode");
            this.Property(t => t.RefundCode).HasColumnName("RefundCode");

            // Relationships
            this.HasRequired(t => t.STORE_TRANSACTION)
                .WithMany(t => t.TRANSACTION_LINE_ITEM)
                .HasForeignKey(d => new { d.TransactionID, d.StoreID });

        }
    }
}

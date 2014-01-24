using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class STORE_TRANSACTIONMap : EntityTypeConfiguration<STORE_TRANSACTION>
    {
        public STORE_TRANSACTIONMap()
        {
            // Primary Key
            this.HasKey(t => new { t.TransactionID, t.StoreID });

            // Properties
            this.Property(t => t.TransactionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.TerminalID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PaymentType)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("STORE_TRANSACTION");
            this.Property(t => t.TransactionID).HasColumnName("TransactionID");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");
            this.Property(t => t.TransactionDate).HasColumnName("TransactionDate");
            this.Property(t => t.TerminalID).HasColumnName("TerminalID");
            this.Property(t => t.TransTotal).HasColumnName("TransTotal");
            this.Property(t => t.TransTax).HasColumnName("TransTax");
            this.Property(t => t.ManagerID).HasColumnName("ManagerID");
            this.Property(t => t.PaymentType).HasColumnName("PaymentType");
            this.Property(t => t.PreviousTransactionID).HasColumnName("PreviousTransactionID");
        }
    }
}

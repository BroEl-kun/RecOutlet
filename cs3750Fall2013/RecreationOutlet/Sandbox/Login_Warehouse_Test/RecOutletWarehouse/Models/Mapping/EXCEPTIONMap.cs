using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class EXCEPTIONMap : EntityTypeConfiguration<EXCEPTION>
    {
        public EXCEPTIONMap()
        {
            // Primary Key
            this.HasKey(t => t.ExceptionsID);

            // Properties
            this.Property(t => t.ExceptionsID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("EXCEPTIONS");
            this.Property(t => t.ExceptionsID).HasColumnName("ExceptionsID");
            this.Property(t => t.ManagerID).HasColumnName("ManagerID");
            this.Property(t => t.TransactionLineItemID).HasColumnName("TransactionLineItemID");
            this.Property(t => t.PreviousTransactionLineItemID).HasColumnName("PreviousTransactionLineItemID");
            this.Property(t => t.OverrideCode).HasColumnName("OverrideCode");
            this.Property(t => t.RefundCode).HasColumnName("RefundCode");

            // Relationships
            this.HasOptional(t => t.OVERRIDE_CODE)
                .WithMany(t => t.EXCEPTIONS)
                .HasForeignKey(d => d.OverrideCode);
            this.HasOptional(t => t.REFUND_CODE)
                .WithMany(t => t.EXCEPTIONS)
                .HasForeignKey(d => d.RefundCode);
            this.HasRequired(t => t.TRANSACTION_LINEITEM)
                .WithMany(t => t.EXCEPTIONS)
                .HasForeignKey(d => d.TransactionLineItemID);

        }
    }
}

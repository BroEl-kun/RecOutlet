using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class INVOICEMap : EntityTypeConfiguration<INVOICE>
    {
        public INVOICEMap()
        {
            // Primary Key
            this.HasKey(t => t.InvoiceID);

            // Properties
            this.Property(t => t.InvoiceID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Attention)
                .HasMaxLength(50);

            this.Property(t => t.InvoiceNotes)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("INVOICE");
            this.Property(t => t.InvoiceID).HasColumnName("InvoiceID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.InvoiceCreatedBy).HasColumnName("InvoiceCreatedBy");
            this.Property(t => t.InvoiceCreatedDate).HasColumnName("InvoiceCreatedDate");
            this.Property(t => t.Attention).HasColumnName("Attention");
            this.Property(t => t.TotalSalesTax).HasColumnName("TotalSalesTax");
            this.Property(t => t.TotalAmount).HasColumnName("TotalAmount");
            this.Property(t => t.TotalAmountPaid).HasColumnName("TotalAmountPaid");
            this.Property(t => t.LastPaymentReceived).HasColumnName("LastPaymentReceived");
            this.Property(t => t.InvoiceNotes).HasColumnName("InvoiceNotes");

            // Relationships
            this.HasRequired(t => t.EMPLOYEE)
                .WithMany(t => t.INVOICEs)
                .HasForeignKey(d => d.InvoiceCreatedBy);
            this.HasRequired(t => t.INVOICE_CUSTOMER)
                .WithMany(t => t.INVOICEs)
                .HasForeignKey(d => d.CustomerID);

        }
    }
}

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

            this.Property(t => t.CustomerID)
                .IsRequired();

            this.Property(t => t.Attention)
                .IsRequired();

            this.Property(t => t.InvoiceNotes)
                .HasMaxLength(50);

            this.Property(t => t.InvoiceCreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("INVOICE");
            this.Property(t => t.InvoiceID).HasColumnName("InvoiceID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.ShippingID).HasColumnName("ShippingID");
            this.Property(t => t.Attention).HasColumnName("Attention");
            this.Property(t => t.PaymentDue).HasColumnName("PaymentDue");
            this.Property(t => t.SalesTaxDue).HasColumnName("SalesTaxDue");
            this.Property(t => t.DatePaid).HasColumnName("DatePaid");
            this.Property(t => t.AmountPaid).HasColumnName("AmountPaid");
            this.Property(t => t.InvoiceNotes).HasColumnName("InvoiceNotes");
            this.Property(t => t.InvoiceCreatedBy).HasColumnName("InvoiceCreatedBy");
            this.Property(t => t.InvoiceCreatedDate).HasColumnName("InvoiceCreatedDate");

            // Relationships
            this.HasRequired(t => t.SHIPPING_LOG)
                .WithMany(t => t.INVOICEs)
                .HasForeignKey(d => d.ShippingID);

        }
    }
}

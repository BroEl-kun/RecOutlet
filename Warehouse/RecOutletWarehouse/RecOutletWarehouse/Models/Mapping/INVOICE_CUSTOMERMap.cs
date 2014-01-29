using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class INVOICE_CUSTOMERMap : EntityTypeConfiguration<INVOICE_CUSTOMER>
    {
        public INVOICE_CUSTOMERMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerID);

            // Properties
            this.Property(t => t.CustomerID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CustomerName)
                .IsRequired();

            this.Property(t => t.CustomerPaymentTerms)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("INVOICE_CUSTOMER");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.CustomerName).HasColumnName("CustomerName");
            this.Property(t => t.CustomerPhoneNumber).HasColumnName("CustomerPhoneNumber");
            this.Property(t => t.TaxExemptID).HasColumnName("TaxExemptID");
            this.Property(t => t.CustomerPaymentTerms).HasColumnName("CustomerPaymentTerms");
            this.Property(t => t.CustomerAddress).HasColumnName("CustomerAddress");
        }
    }
}

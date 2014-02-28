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
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CustomerPaymentTerms)
                .HasMaxLength(50);

            this.Property(t => t.CustomerAddress)
                .HasMaxLength(50);

            this.Property(t => t.CustomerAddress2)
                .HasMaxLength(50);

            this.Property(t => t.CustomerCity)
                .HasMaxLength(25);

            this.Property(t => t.CustomerState)
                .HasMaxLength(2);

            this.Property(t => t.CustomerZip)
                .HasMaxLength(10);

            this.Property(t => t.CustomerCountry)
                .HasMaxLength(50);

            this.Property(t => t.CustomerPhone)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("INVOICE_CUSTOMER");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.CustomerName).HasColumnName("CustomerName");
            this.Property(t => t.TaxExemptID).HasColumnName("TaxExemptID");
            this.Property(t => t.CustomerPaymentTerms).HasColumnName("CustomerPaymentTerms");
            this.Property(t => t.CustomerAddress).HasColumnName("CustomerAddress");
            this.Property(t => t.CustomerAddress2).HasColumnName("CustomerAddress2");
            this.Property(t => t.CustomerCity).HasColumnName("CustomerCity");
            this.Property(t => t.CustomerState).HasColumnName("CustomerState");
            this.Property(t => t.CustomerZip).HasColumnName("CustomerZip");
            this.Property(t => t.CustomerCountry).HasColumnName("CustomerCountry");
            this.Property(t => t.CustomerPhone).HasColumnName("CustomerPhone");
        }
    }
}

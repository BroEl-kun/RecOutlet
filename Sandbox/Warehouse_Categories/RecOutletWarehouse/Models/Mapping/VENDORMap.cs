using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class VENDORMap : EntityTypeConfiguration<VENDOR>
    {
        public VENDORMap()
        {
            // Primary Key
            this.HasKey(t => t.VendorID);

            // Properties
            this.Property(t => t.VendorName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ContactName)
                .HasMaxLength(100);

            this.Property(t => t.ContactPhone)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.ContactFax)
                .HasMaxLength(12);

            this.Property(t => t.AltPhone)
                .HasMaxLength(12);

            this.Property(t => t.VendorAddress)
                .HasMaxLength(50);

            this.Property(t => t.VendorState)
                .HasMaxLength(2);

            this.Property(t => t.VendorZip)
                .HasMaxLength(10);

            this.Property(t => t.VendorWebsite)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("VENDOR");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.VendorName).HasColumnName("VendorName");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
            this.Property(t => t.ContactPhone).HasColumnName("ContactPhone");
            this.Property(t => t.ContactFax).HasColumnName("ContactFax");
            this.Property(t => t.AltPhone).HasColumnName("AltPhone");
            this.Property(t => t.VendorAddress).HasColumnName("VendorAddress");
            this.Property(t => t.VendorState).HasColumnName("VendorState");
            this.Property(t => t.VendorZip).HasColumnName("VendorZip");
            this.Property(t => t.VendorWebsite).HasColumnName("VendorWebsite");
        }
    }
}

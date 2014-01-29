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
                .IsRequired();

            this.Property(t => t.ContactPhone)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ContactFax)
                .HasMaxLength(50);

            this.Property(t => t.AltPhone)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("VENDOR");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.VendorName).HasColumnName("VendorName");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
            this.Property(t => t.ContactPhone).HasColumnName("ContactPhone");
            this.Property(t => t.ContactFax).HasColumnName("ContactFax");
            this.Property(t => t.AltPhone).HasColumnName("AltPhone");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Website).HasColumnName("Website");
        }
    }
}

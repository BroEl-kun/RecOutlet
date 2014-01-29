using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class PRODUCT_LINEMap : EntityTypeConfiguration<PRODUCT_LINE>
    {
        public PRODUCT_LINEMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductLineID);

            // Properties
            this.Property(t => t.ProductLineName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PRODUCT_LINE");
            this.Property(t => t.ProductLineID).HasColumnName("ProductLineID");
            this.Property(t => t.ProductLineName).HasColumnName("ProductLineName");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.RepID).HasColumnName("RepID");

            // Relationships
            this.HasRequired(t => t.SALES_REP)
                .WithMany(t => t.PRODUCT_LINE)
                .HasForeignKey(d => d.RepID);
            this.HasRequired(t => t.VENDOR)
                .WithMany(t => t.PRODUCT_LINE)
                .HasForeignKey(d => d.VendorID);

        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class ITEMMap : EntityTypeConfiguration<ITEM>
    {
        public ITEMMap()
        {
            // Primary Key
            this.HasKey(t => t.RecRPC);

            // Properties
            this.Property(t => t.RecRPC)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.SeasonCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ITEM");
            this.Property(t => t.RecRPC).HasColumnName("RecRPC");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.DepartmentID).HasColumnName("DepartmentID");
            this.Property(t => t.SubcategoryID).HasColumnName("SubcategoryID");
            this.Property(t => t.ProductLineID).HasColumnName("ProductLineID");
            this.Property(t => t.TaxTypeID).HasColumnName("TaxTypeID");
            this.Property(t => t.LegacyID).HasColumnName("LegacyID");
            this.Property(t => t.ItemUPC).HasColumnName("ItemUPC");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.VendorItemID).HasColumnName("VendorItemID");
            this.Property(t => t.SeasonCode).HasColumnName("SeasonCode");
            this.Property(t => t.ItemID).HasColumnName("ItemID");
            this.Property(t => t.MSRP).HasColumnName("MSRP");
            this.Property(t => t.SellPrice).HasColumnName("SellPrice");
            this.Property(t => t.RestrictedAge).HasColumnName("RestrictedAge");
            this.Property(t => t.ItemCreatedBy).HasColumnName("ItemCreatedBy");
            this.Property(t => t.ItemCreatedDate).HasColumnName("ItemCreatedDate");

            // Relationships
            this.HasRequired(t => t.ITEM_CATEGORY)
                .WithMany(t => t.ITEMs)
                .HasForeignKey(d => d.CategoryID);
            this.HasRequired(t => t.ITEM_DEPARTMENT)
                .WithMany(t => t.ITEMs)
                .HasForeignKey(d => d.DepartmentID);
            this.HasRequired(t => t.ITEM_SUBCATEGORY)
                .WithMany(t => t.ITEMs)
                .HasForeignKey(d => d.SubcategoryID);
            this.HasRequired(t => t.PRODUCT_LINE)
                .WithMany(t => t.ITEMs)
                .HasForeignKey(d => d.ProductLineID);
            this.HasRequired(t => t.TAX_TYPE)
                .WithMany(t => t.ITEMs)
                .HasForeignKey(d => d.TaxTypeID);

        }
    }
}

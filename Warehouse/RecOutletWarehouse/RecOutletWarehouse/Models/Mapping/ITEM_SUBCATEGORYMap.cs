using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class ITEM_SUBCATEGORYMap : EntityTypeConfiguration<ITEM_SUBCATEGORY>
    {
        public ITEM_SUBCATEGORYMap()
        {
            // Primary Key
            this.HasKey(t => t.SubcategoryID);

            // Properties
            this.Property(t => t.SubcategoryName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ITEM_SUBCATEGORY");
            this.Property(t => t.SubcategoryID).HasColumnName("SubcategoryID");
            this.Property(t => t.SubcategoryName).HasColumnName("SubcategoryName");
        }
    }
}

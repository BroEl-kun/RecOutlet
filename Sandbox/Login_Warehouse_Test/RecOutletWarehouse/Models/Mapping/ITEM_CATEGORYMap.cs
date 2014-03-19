using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class ITEM_CATEGORYMap : EntityTypeConfiguration<ITEM_CATEGORY>
    {
        public ITEM_CATEGORYMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryID);

            // Properties
            this.Property(t => t.CategoryName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ITEM_CATEGORY");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.CategoryName).HasColumnName("CategoryName");
            this.Property(t => t.CategoryDescription).HasColumnName("CategoryDescription");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class ITEM_IMAGEMap : EntityTypeConfiguration<ITEM_IMAGE>
    {
        public ITEM_IMAGEMap()
        {
            // Primary Key
            this.HasKey(t => t.ItemImageID);

            // Properties
            this.Property(t => t.ItemImagePath)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("ITEM_IMAGE");
            this.Property(t => t.ItemImageID).HasColumnName("ItemImageID");
            this.Property(t => t.RecRPC).HasColumnName("RecRPC");
            this.Property(t => t.ItemImagePath).HasColumnName("ItemImagePath");
            this.Property(t => t.ItemImageDescription).HasColumnName("ItemImageDescription");

            // Relationships
            this.HasRequired(t => t.ITEM)
                .WithMany(t => t.ITEM_IMAGE)
                .HasForeignKey(d => d.RecRPC);

        }
    }
}

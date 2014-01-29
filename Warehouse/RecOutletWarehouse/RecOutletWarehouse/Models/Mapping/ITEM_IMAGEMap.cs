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
            this.Property(t => t.ItemImageID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ItemPath)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("ITEM_IMAGE");
            this.Property(t => t.ItemImageID).HasColumnName("ItemImageID");
            this.Property(t => t.RecRPC).HasColumnName("RecRPC");
            this.Property(t => t.ItemPath).HasColumnName("ItemPath");

            // Relationships
            this.HasRequired(t => t.ITEM)
                .WithMany(t => t.ITEM_IMAGE)
                .HasForeignKey(d => d.RecRPC);

        }
    }
}

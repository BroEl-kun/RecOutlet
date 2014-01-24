using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class INVENTORYMap : EntityTypeConfiguration<INVENTORY>
    {
        public INVENTORYMap()
        {
            // Primary Key
            this.HasKey(t => new { t.StoreID, t.RecID });

            // Properties
            this.Property(t => t.RecID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("INVENTORY");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.RecID).HasColumnName("RecID");
            this.Property(t => t.QtyOnHand).HasColumnName("QtyOnHand");
            this.Property(t => t.QtyThreshold).HasColumnName("QtyThreshold");

            // Relationships
            this.HasRequired(t => t.LOCATION)
                .WithMany(t => t.INVENTORies)
                .HasForeignKey(d => d.StoreID);

        }
    }
}

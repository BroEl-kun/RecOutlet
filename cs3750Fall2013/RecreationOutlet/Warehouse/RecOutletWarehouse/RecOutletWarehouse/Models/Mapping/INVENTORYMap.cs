using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class INVENTORYMap : EntityTypeConfiguration<INVENTORY>
    {
        public INVENTORYMap()
        {
            // Primary Key
            this.HasKey(t => new { t.StoreID, t.RecRPC });

            // Properties
            this.Property(t => t.RecRPC)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("INVENTORY");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.RecRPC).HasColumnName("RecRPC");
            this.Property(t => t.QtyOnHand).HasColumnName("QtyOnHand");
            this.Property(t => t.QtyThreshold).HasColumnName("QtyThreshold");

            // Relationships
            this.HasRequired(t => t.ITEM)
                .WithMany(t => t.INVENTORies)
                .HasForeignKey(d => d.RecRPC);
            this.HasRequired(t => t.LOCATION)
                .WithMany(t => t.INVENTORies)
                .HasForeignKey(d => d.StoreID);

        }
    }
}

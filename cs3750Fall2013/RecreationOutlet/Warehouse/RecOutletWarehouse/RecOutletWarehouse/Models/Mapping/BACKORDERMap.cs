using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class BACKORDERMap : EntityTypeConfiguration<BACKORDER>
    {
        public BACKORDERMap()
        {
            // Primary Key
            this.HasKey(t => t.BackorderID);

            // Properties
            this.Property(t => t.BackorderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("BACKORDER");
            this.Property(t => t.BackorderID).HasColumnName("BackorderID");
            this.Property(t => t.ReceivingID).HasColumnName("ReceivingID");
            this.Property(t => t.BackorderQty).HasColumnName("BackorderQty");

            // Relationships
            this.HasRequired(t => t.RECEIVING_LOG)
                .WithMany(t => t.BACKORDERs)
                .HasForeignKey(d => d.ReceivingID);

        }
    }
}

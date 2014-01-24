using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class LOCATIONMap : EntityTypeConfiguration<LOCATION>
    {
        public LOCATIONMap()
        {
            // Primary Key
            this.HasKey(t => t.StoreID);

            // Properties
            this.Property(t => t.StoreName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("LOCATION");
            this.Property(t => t.StoreID).HasColumnName("StoreID");
            this.Property(t => t.StoreName).HasColumnName("StoreName");
            this.Property(t => t.ManagerId).HasColumnName("ManagerId");

            // Relationships
            this.HasRequired(t => t.EMPLOYEE)
                .WithMany(t => t.LOCATIONs)
                .HasForeignKey(d => d.ManagerId);

        }
    }
}

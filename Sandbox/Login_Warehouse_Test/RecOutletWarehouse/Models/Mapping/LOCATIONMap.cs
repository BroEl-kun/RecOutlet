using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class LOCATIONMap : EntityTypeConfiguration<LOCATION>
    {
        public LOCATIONMap()
        {
            // Primary Key
            this.HasKey(t => t.LocationID);

            // Properties
            this.Property(t => t.StoreName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.Address2)
                .HasMaxLength(50);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.Zip)
                .HasMaxLength(10);

            this.Property(t => t.Country)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("LOCATION");
            this.Property(t => t.LocationID).HasColumnName("LocationID");
            this.Property(t => t.ManagerId).HasColumnName("ManagerId");
            this.Property(t => t.StoreName).HasColumnName("StoreName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.Phone).HasColumnName("Phone");

            // Relationships
            this.HasRequired(t => t.EMPLOYEE)
                .WithMany(t => t.LOCATIONs)
                .HasForeignKey(d => d.ManagerId);

        }
    }
}

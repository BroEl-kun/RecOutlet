using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class TAX_RATEMap : EntityTypeConfiguration<TAX_RATE>
    {
        public TAX_RATEMap()
        {
            // Primary Key
            this.HasKey(t => t.TaxRateID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TAX_RATE");
            this.Property(t => t.TaxRateID).HasColumnName("TaxRateID");
            this.Property(t => t.TaxTypeID).HasColumnName("TaxTypeID");
            this.Property(t => t.LocationID).HasColumnName("LocationID");
            this.Property(t => t.TaxRate).HasColumnName("TaxRate");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");

            // Relationships
            this.HasOptional(t => t.LOCATION)
                .WithMany(t => t.TAX_RATE)
                .HasForeignKey(d => d.LocationID);
            this.HasRequired(t => t.TAX_TYPE)
                .WithMany(t => t.TAX_RATE)
                .HasForeignKey(d => d.TaxTypeID);

        }
    }
}

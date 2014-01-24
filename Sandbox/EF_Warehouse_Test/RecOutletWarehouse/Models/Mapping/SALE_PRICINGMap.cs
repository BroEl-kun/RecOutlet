using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class SALE_PRICINGMap : EntityTypeConfiguration<SALE_PRICING>
    {
        public SALE_PRICINGMap()
        {
            // Primary Key
            this.HasKey(t => new { t.EventTypeCode, t.RecRPC });

            // Properties
            this.Property(t => t.RecRPC)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Comments)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SALE_PRICING");
            this.Property(t => t.EventTypeCode).HasColumnName("EventTypeCode");
            this.Property(t => t.RecRPC).HasColumnName("RecRPC");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.BeginDate).HasColumnName("BeginDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Comments).HasColumnName("Comments");

            // Relationships
            this.HasRequired(t => t.SALE_PRICING2)
                .WithOptional(t => t.SALE_PRICING1);

        }
    }
}

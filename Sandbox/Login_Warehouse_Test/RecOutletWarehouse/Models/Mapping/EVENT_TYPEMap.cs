using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class EVENT_TYPEMap : EntityTypeConfiguration<EVENT_TYPE>
    {
        public EVENT_TYPEMap()
        {
            // Primary Key
            this.HasKey(t => t.EventTypeCode);

            // Properties
            this.Property(t => t.EventDescription)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EVENT_TYPE");
            this.Property(t => t.EventTypeCode).HasColumnName("EventTypeCode");
            this.Property(t => t.EventDescription).HasColumnName("EventDescription");
        }
    }
}

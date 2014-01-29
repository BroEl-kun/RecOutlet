using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class SALES_REPMap : EntityTypeConfiguration<SALES_REP>
    {
        public SALES_REPMap()
        {
            // Primary Key
            this.HasKey(t => t.RepID);

            // Properties
            this.Property(t => t.SalesRepName)
                .IsRequired();

            this.Property(t => t.SalesRepPhone)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("SALES_REP");
            this.Property(t => t.RepID).HasColumnName("RepID");
            this.Property(t => t.SalesRepName).HasColumnName("SalesRepName");
            this.Property(t => t.SalesRepPhone).HasColumnName("SalesRepPhone");
            this.Property(t => t.SalesRepEmail).HasColumnName("SalesRepEmail");
        }
    }
}

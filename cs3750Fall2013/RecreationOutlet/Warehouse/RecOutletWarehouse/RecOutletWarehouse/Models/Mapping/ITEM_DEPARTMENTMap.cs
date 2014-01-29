using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class ITEM_DEPARTMENTMap : EntityTypeConfiguration<ITEM_DEPARTMENT>
    {
        public ITEM_DEPARTMENTMap()
        {
            // Primary Key
            this.HasKey(t => t.DepartmentID);

            // Properties
            this.Property(t => t.DepartmentName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ITEM_DEPARTMENT");
            this.Property(t => t.DepartmentID).HasColumnName("DepartmentID");
            this.Property(t => t.DepartmentName).HasColumnName("DepartmentName");
        }
    }
}

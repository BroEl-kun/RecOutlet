using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class EMPLOYEEMap : EntityTypeConfiguration<EMPLOYEE>
    {
        public EMPLOYEEMap()
        {
            // Primary Key
            this.HasKey(t => t.EmployeeId);

            // Properties
            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Position)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PasswordSalt)
                .IsRequired()
                .HasMaxLength(16);
            // Table & Column Mappings
            this.ToTable("EMPLOYEE");
            this.Property(t => t.EmployeeId).HasColumnName("EmployeeId");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Position).HasColumnName("Position");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.PasswordSalt).HasColumnName("PasswordSalt");
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class PURCHASE_ORDERMap : EntityTypeConfiguration<PURCHASE_ORDER>
    {
        public PURCHASE_ORDERMap()
        {
            // Primary Key
            this.HasKey(t => t.POID);

            // Properties
            this.Property(t => t.POID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.POFreightCost)
                .HasMaxLength(50);

            this.Property(t => t.POTerms)
                .HasMaxLength(50);

            this.Property(t => t.POComments)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PURCHASE_ORDER");
            this.Property(t => t.POID).HasColumnName("POID");
            this.Property(t => t.VendorID).HasColumnName("VendorID");
            this.Property(t => t.POCreatedBy).HasColumnName("POCreatedBy");
            this.Property(t => t.POOrderDate).HasColumnName("POOrderDate");
            this.Property(t => t.POEstimatedShipDate).HasColumnName("POEstimatedShipDate");
            this.Property(t => t.POCreatedDate).HasColumnName("POCreatedDate");
            this.Property(t => t.POFreightCost).HasColumnName("POFreightCost");
            this.Property(t => t.POTerms).HasColumnName("POTerms");
            this.Property(t => t.POComments).HasColumnName("POComments");
            this.Property(t => t.ShippingID).HasColumnName("ShippingID");
            this.Property(t => t.POCancelIfNotReceivedBy).HasColumnName("POCancelIfNotReceivedBy");

            // Relationships
            this.HasRequired(t => t.EMPLOYEE)
                .WithMany(t => t.PURCHASE_ORDER)
                .HasForeignKey(d => d.POCreatedBy);
            this.HasRequired(t => t.VENDOR)
                .WithMany(t => t.PURCHASE_ORDER)
                .HasForeignKey(d => d.VendorID);

        }
    }
}

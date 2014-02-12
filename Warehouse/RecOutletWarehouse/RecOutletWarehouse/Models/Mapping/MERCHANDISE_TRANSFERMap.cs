using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecOutletWarehouse.Models.Mapping
{
    public class MERCHANDISE_TRANSFERMap : EntityTypeConfiguration<MERCHANDISE_TRANSFER>
    {
        public MERCHANDISE_TRANSFERMap()
        {
            // Primary Key
            this.HasKey(t => t.TransferID);

            // Properties
            // Table & Column Mappings
            this.ToTable("MERCHANDISE_TRANSFER");
            this.Property(t => t.TransferID).HasColumnName("TransferID");
            this.Property(t => t.RecRPC).HasColumnName("RecRPC");
            this.Property(t => t.ToLocationID).HasColumnName("ToLocationID");
            this.Property(t => t.FromLocationID).HasColumnName("FromLocationID");
            this.Property(t => t.TansferDate).HasColumnName("TansferDate");
            this.Property(t => t.TansferComments).HasColumnName("TansferComments");
            this.Property(t => t.TransferCreatedBy).HasColumnName("TransferCreatedBy");
            this.Property(t => t.TransferCreatedDate).HasColumnName("TransferCreatedDate");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.QtyTypeID).HasColumnName("QtyTypeID");

            // Relationships
            this.HasRequired(t => t.ITEM)
                .WithMany(t => t.MERCHANDISE_TRANSFER)
                .HasForeignKey(d => d.RecRPC);
            this.HasRequired(t => t.QTY_TYPE)
                .WithMany(t => t.MERCHANDISE_TRANSFER)
                .HasForeignKey(d => d.QtyTypeID);

        }
    }
}

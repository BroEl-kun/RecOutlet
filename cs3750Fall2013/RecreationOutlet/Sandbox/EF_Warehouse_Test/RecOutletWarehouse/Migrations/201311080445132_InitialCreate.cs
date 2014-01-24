namespace RecOutletWarehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        PurchaseOrderId = c.String(nullable: false, maxLength: 128),
                        Vendor = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        EstShipDate = c.DateTime(nullable: false),
                        FreightCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Terms = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseOrderId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        VendorName = c.String(),
                        ContactName = c.String(),
                        ContactPhone = c.String(),
                        ContactFax = c.String(),
                        AltPhone = c.String(),
                        Address = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendors");
            DropTable("dbo.PurchaseOrders");
        }
    }
}

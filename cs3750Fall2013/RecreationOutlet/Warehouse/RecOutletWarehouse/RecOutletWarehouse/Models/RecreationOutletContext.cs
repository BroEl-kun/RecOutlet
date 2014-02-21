using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using RecOutletWarehouse.Models.Mapping;
using System.Data.SqlTypes;
using System;

namespace RecOutletWarehouse.Models
{
    public partial class RecreationOutletContext : DbContext
    {
        static RecreationOutletContext()
        {
            Database.SetInitializer<RecreationOutletContext>(null);
        }

        public RecreationOutletContext()
            : base("Name=RecreationOutletContext")
        {
        }

        /// <summary>
        /// This is overridden so we can update the dates and convert them
        /// from DateTimes to SmallDateTimes
        /// </summary>
        /// <returns></returns>
        //public override int SaveChanges()
        //{
        //    UpdateDates();
        //    return base.SaveChanges();
        //}

        /// <summary>
        /// This method is to convert all DateTimes to SmallDateTimes
        /// before posting data to the database.
        /// </summary>
        private void UpdateDates()
        {
            foreach (var change in ChangeTracker.Entries<PURCHASE_ORDER>())
            {
                var values = change.CurrentValues;
                foreach (var name in values.PropertyNames)
                {
                    var value = values[name];
                    if (value is DateTime)
                    {
                        var date = (DateTime)value;
                        if (date < SqlDateTime.MinValue.Value)
                        {
                            values[name] = SqlDateTime.MinValue.Value;
                        }
                        else if (date > SqlDateTime.MaxValue.Value)
                        {
                            values[name] = SqlDateTime.MaxValue.Value;
                        }
                    }
                }
            }
        }

        public DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public DbSet<EVENT_TYPE> EVENT_TYPE { get; set; }
        public DbSet<EXCEPTION> EXCEPTIONS { get; set; }
        public DbSet<INVENTORY> INVENTORies { get; set; }
        public DbSet<INVOICE> INVOICEs { get; set; }
        public DbSet<INVOICE_CUSTOMER> INVOICE_CUSTOMER { get; set; }
        public DbSet<INVOICE_LINEITEM> INVOICE_LINEITEM { get; set; }
        public DbSet<ITEM> ITEMs { get; set; }
        public DbSet<ITEM_CATEGORY> ITEM_CATEGORY { get; set; }
        public DbSet<ITEM_DEPARTMENT> ITEM_DEPARTMENT { get; set; }
        public DbSet<ITEM_IMAGE> ITEM_IMAGE { get; set; }
        public DbSet<ITEM_SUBCATEGORY> ITEM_SUBCATEGORY { get; set; }
        public DbSet<LOCATION> LOCATIONs { get; set; }
        public DbSet<MERCHANDISE_TRANSFER> MERCHANDISE_TRANSFER { get; set; }
        public DbSet<OVERRIDE_CODE> OVERRIDE_CODE { get; set; }
        public DbSet<PAYMENT> PAYMENTs { get; set; }
        public DbSet<PAYMENT_TYPE> PAYMENT_TYPE { get; set; }
        public DbSet<PO_LINEITEM> PO_LINEITEM { get; set; }
        public DbSet<PRODUCT_LINE> PRODUCT_LINE { get; set; }
        public DbSet<PURCHASE_ORDER> PURCHASE_ORDER { get; set; }
        public DbSet<QTY_TYPE> QTY_TYPE { get; set; }
        public DbSet<RECEIVING_LOG> RECEIVING_LOG { get; set; }
        public DbSet<REFUND_CODE> REFUND_CODE { get; set; }
        public DbSet<SALE_PRICING> SALE_PRICING { get; set; }
        public DbSet<SALES_REP> SALES_REPs { get; set; }
        public DbSet<SHIPPING_LOG> SHIPPING_LOG { get; set; }
        public DbSet<STORE_TRANSACTION> STORE_TRANSACTION { get; set; }
        public DbSet<TAX_RATE> TAX_RATE { get; set; }
        public DbSet<TAX_TYPE> TAX_TYPE { get; set; }
        public DbSet<TRANSACTION_LINEITEM> TRANSACTION_LINEITEM { get; set; }
        public DbSet<VENDOR> VENDORs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EMPLOYEEMap());
            modelBuilder.Configurations.Add(new EVENT_TYPEMap());
            modelBuilder.Configurations.Add(new EXCEPTIONMap());
            modelBuilder.Configurations.Add(new INVENTORYMap());
            modelBuilder.Configurations.Add(new INVOICEMap());
            modelBuilder.Configurations.Add(new INVOICE_CUSTOMERMap());
            modelBuilder.Configurations.Add(new INVOICE_LINEITEMMap());
            modelBuilder.Configurations.Add(new ITEMMap());
            modelBuilder.Configurations.Add(new ITEM_CATEGORYMap());
            modelBuilder.Configurations.Add(new ITEM_DEPARTMENTMap());
            modelBuilder.Configurations.Add(new ITEM_IMAGEMap());
            modelBuilder.Configurations.Add(new ITEM_SUBCATEGORYMap());
            modelBuilder.Configurations.Add(new LOCATIONMap());
            modelBuilder.Configurations.Add(new MERCHANDISE_TRANSFERMap());
            modelBuilder.Configurations.Add(new OVERRIDE_CODEMap());
            modelBuilder.Configurations.Add(new PAYMENTMap());
            modelBuilder.Configurations.Add(new PAYMENT_TYPEMap());
            modelBuilder.Configurations.Add(new PO_LINEITEMMap());
            modelBuilder.Configurations.Add(new PRODUCT_LINEMap());
            modelBuilder.Configurations.Add(new PURCHASE_ORDERMap());
            modelBuilder.Configurations.Add(new QTY_TYPEMap());
            modelBuilder.Configurations.Add(new RECEIVING_LOGMap());
            modelBuilder.Configurations.Add(new REFUND_CODEMap());
            modelBuilder.Configurations.Add(new SALE_PRICINGMap());
            modelBuilder.Configurations.Add(new SALES_REPMap());
            modelBuilder.Configurations.Add(new SHIPPING_LOGMap());
            modelBuilder.Configurations.Add(new STORE_TRANSACTIONMap());
            modelBuilder.Configurations.Add(new TAX_RATEMap());
            modelBuilder.Configurations.Add(new TAX_TYPEMap());
            modelBuilder.Configurations.Add(new TRANSACTION_LINEITEMMap());
            modelBuilder.Configurations.Add(new VENDORMap());

            var po = modelBuilder.Entity<PURCHASE_ORDER>();
            po.Property(x => x.POOrderDate).HasColumnType("smalldatetime");
            po.Property(x => x.POEstimatedShipDate).HasColumnType("smalldatetime");
            po.Property(x => x.POCreatedDate).HasColumnType("smalldatetime");

            base.OnModelCreating(modelBuilder);
        }
    }
}

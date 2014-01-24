using System;
using System.Collections.Generic;

namespace RecOutletWarehouse.Models
{
    public partial class ITEM
    {
        public ITEM()
        {
            this.ITEM_IMAGE = new List<ITEM_IMAGE>();
            this.PO_LINEITEM = new List<PO_LINEITEM>();
        }

        public long RecRPC { get; set; }
        public Nullable<long> ItemUPC { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int VendorItemID { get; set; }
        public int ProductLineID { get; set; }
        public string SeasonCode { get; set; }
        public int ItemID { get; set; }
        public byte CategoryID { get; set; }
        public byte DepartmentID { get; set; }
        public byte SubcategoryID { get; set; }
        public Nullable<decimal> MSRP { get; set; }
        public decimal SellPrice { get; set; }
        public byte TaxRateID { get; set; }
        public Nullable<byte> RestrictedAge { get; set; }
        public Nullable<short> LegacyID { get; set; }
        public short ItemCreatedBy { get; set; }
        public System.DateTime ItemCreatedDate { get; set; }
        public virtual ICollection<ITEM_IMAGE> ITEM_IMAGE { get; set; }
        public virtual ITEM_CATEGORY ITEM_CATEGORY { get; set; }
        public virtual ITEM_DEPARTMENT ITEM_DEPARTMENT { get; set; }
        public virtual ITEM_SUBCATEGORY ITEM_SUBCATEGORY { get; set; }
        public virtual PRODUCT_LINE PRODUCT_LINE { get; set; }
        public virtual TAX_RATE TAX_RATE { get; set; }
        public virtual ICollection<PO_LINEITEM> PO_LINEITEM { get; set; }
    }
}

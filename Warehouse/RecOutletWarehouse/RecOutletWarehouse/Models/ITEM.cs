using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Models
{
    public partial class ITEM
    {
        public ITEM()
        {
            this.INVENTORies = new List<INVENTORY>();
            this.INVOICE_LINEITEM = new List<INVOICE_LINEITEM>();
            this.ITEM_IMAGE = new List<ITEM_IMAGE>();
            this.MERCHANDISE_TRANSFER = new List<MERCHANDISE_TRANSFER>();
            this.PO_LINEITEM = new List<PO_LINEITEM>();
            this.SALE_PRICING = new List<SALE_PRICING>();
            this.TRANSACTION_LINEITEM = new List<TRANSACTION_LINEITEM>();
        }

        public long RecRPC { get; set; }
        public byte CategoryID { get; set; }
        public byte DepartmentID { get; set; }
        public short SubcategoryID { get; set; }
        public int ProductLineID { get; set; }
        public byte TaxTypeID { get; set; }
        public Nullable<short> LegacyID { get; set; }
        public Nullable<long> ItemUPC { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VendorItemID { get; set; }
        public string SeasonCode { get; set; }
        public int ItemID { get; set; }
        public Nullable<decimal> MSRP { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal SellPrice { get; set; }

        public Nullable<byte> RestrictedAge { get; set; }
        public short ItemCreatedBy { get; set; }
        public System.DateTime ItemCreatedDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<INVENTORY> INVENTORies { get; set; }

        [JsonIgnore]
        public virtual ICollection<INVOICE_LINEITEM> INVOICE_LINEITEM { get; set; }

        [JsonIgnore]
        public virtual ICollection<ITEM_IMAGE> ITEM_IMAGE { get; set; }

        [JsonIgnore]
        public virtual ITEM_CATEGORY ITEM_CATEGORY { get; set; }

        [JsonIgnore]
        public virtual ITEM_DEPARTMENT ITEM_DEPARTMENT { get; set; }

        [JsonIgnore]
        public virtual ITEM_SUBCATEGORY ITEM_SUBCATEGORY { get; set; }

        [JsonIgnore]
        public virtual PRODUCT_LINE PRODUCT_LINE { get; set; }

        [JsonIgnore]
        public virtual TAX_TYPE TAX_TYPE { get; set; }

        [JsonIgnore]
        public virtual ICollection<MERCHANDISE_TRANSFER> MERCHANDISE_TRANSFER { get; set; }

        [JsonIgnore]
        public virtual ICollection<PO_LINEITEM> PO_LINEITEM { get; set; }

        [JsonIgnore]
        public virtual ICollection<SALE_PRICING> SALE_PRICING { get; set; }

        [JsonIgnore]
        public virtual ICollection<TRANSACTION_LINEITEM> TRANSACTION_LINEITEM { get; set; }
    }
}

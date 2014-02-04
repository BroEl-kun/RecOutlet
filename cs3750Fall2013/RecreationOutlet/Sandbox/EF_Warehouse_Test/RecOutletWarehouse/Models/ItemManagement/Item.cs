﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace RecOutletWarehouse.Models.ItemManagement {
    public class Item {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RecRPC { get; set; }

        public long? UPC { get; set; }

        [Required]
        public string Vendor { get; set; }

        [Required]
        public int VendorItemID { get; set; }

        [Required]
        public string ProductLine { get; set; }

        [Required]
        public string ItemName { get; set; }

        public int? Legacy { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Subcategory { get; set; }

        [HiddenInput]
        public int ItemId { get; set; } //autogenerated identity

        public byte? restrictedAge { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal SellPrice { get; set; }

        [DataType(DataType.Currency)]
        public decimal MSRP { get; set; }

        [Required]
        public string SeasonCode { get; set; }

        [HiddenInput]
        public decimal TaxRate { get; set; }

        [HiddenInput]
        public short CreatedBy { get; set; }

        [HiddenInput]
        public DateTime CreatedDate { get; set; }

        //TODO: SalePricing?

    }
}
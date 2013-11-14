using RecOutletWarehouse.Models.ItemManagement;
using RecOutletWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecOutletWarehouse.Utilities {
    public class WarehouseUtilities {

        public static long GenerateRPC(Item item) {
            DataFetcherSetter db = new DataFetcherSetter();
            //Item convertedItem = db.ConvertNamesToIDs(item); //Convert dept, cat, subcat
            string RPC = Convert.ToByte(item.Department).ToString("D2"); //better way to do this?
            RPC += Convert.ToByte(item.Category).ToString("D2");
            RPC += item.ItemId.ToString("D6");
            RPC += Convert.ToInt16(item.Subcategory).ToString("D3");

            return Convert.ToInt64(RPC);
        }



    }
}
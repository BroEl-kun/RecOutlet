using RecOutletWarehouse.Models;
using RecOutletWarehouse.Models.AddVendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecOutletWarehouse.Controllers {
    public class WarehouseApiController : ApiController {

        [HttpGet]
        public IEnumerable<AddVendor> GetVendors(string query = "") {
            DataFetcherSetter db = new DataFetcherSetter();
            List<AddVendor> vendors = db.SearchVendorByName(query);
            return vendors;

        }
    }
}
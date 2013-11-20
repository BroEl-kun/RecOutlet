using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models.VendorManagement;
using RecOutletWarehouse.Models;

namespace RecOutletWarehouse.Controllers
{
    public class VendorController : Controller
    {
        public class ProductLineSalesRepViewModel {
            public ProductLine productLine { get; set; }
            public SalesRep rep { get; set; }
        }
        //
        // GET: /Vendor/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddVendor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddVendor(Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                //TODO: replace this view with the correct submit view.
                return View(vendor);
            }
            else
            {
                DataFetcherSetter db = new DataFetcherSetter();

                db.AddNewVendor(vendor.VendorName, vendor.ContactName,
                    vendor.ContactPhone, vendor.ContactFax,
                    vendor.AltPhone, vendor.Address,
                    vendor.Website);

                //TODO: change this to the actual view i need to return like Success! or something.
                return View("Index");
            }
        }

        public ActionResult CreateNewPL() {

            return View();
        }

        [HttpPost]
        public ActionResult CreateNewPL(ProductLineSalesRepViewModel pl) {
            DataFetcherSetter db = new DataFetcherSetter();

            if (!ModelState.IsValid) {

                return View(pl);
            }
            pl.productLine.SalesRep = pl.rep.SalesRepName; //TODO: See if there's a better way to do this
            pl.productLine = db.convertPLNameFieldsToIDs(pl.productLine);
            int insertSuccessCode = db.AddNewProductLine(pl.productLine);
            if (insertSuccessCode == 0)
                return View(); //TODO: confirmation

            return View();
        }

    }
}


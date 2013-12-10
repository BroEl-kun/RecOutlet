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
        public ActionResult AddVendor(Vendor vendor, string labelRedirect = "")
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
                vendor.VendorId = db.GetVendorIdForVendorName(vendor.VendorName);

                //TODO: change this to the actual view i need to return like Success! or something.
                ViewBag.Success = "Vendor successfully created.";
                if (labelRedirect == "Add Vendor, Create Product Line")
                {
                    return RedirectToAction("CreateNewPL", new { id = vendor.VendorId });
                }
                return View();
            }
        }

     

        public ActionResult CreateNewPL(short? id)
        {
            DataFetcherSetter db = new DataFetcherSetter();

          
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewPL(ProductLineSalesRepViewModel pl) {
            DataFetcherSetter db = new DataFetcherSetter();
            int insertSuccessCode;

            if (pl.productLine.SalesRep == null && (pl.rep.SalesRepName == null && pl.rep.SalesRepPhone == null)) {
                ModelState.AddModelError("rep.SalesRepID", "Please specify a sales rep for this product.");
            }

            if (!ModelState.IsValid) {

                return View(pl);
            }

            //if the user chose to create a new rep...
            if (pl.productLine.SalesRep == null) {
                pl.productLine.SalesRep = pl.rep.SalesRepName; //TODO: See if there's a better way to do this
                insertSuccessCode = db.AddNewSalesRep(pl.rep);
                if (insertSuccessCode != 0) { //TODO: Check for exceptions
                }
                else {
                    ViewBag.RepSuccess = "Sales Rep " + pl.rep.SalesRepName + " successfully assigned to " + pl.productLine.ProductLineName + ".";
                }
            }
            string tempProductLine = pl.productLine.ProductLineName;
            string tempVendorName = pl.productLine.Vendor;

            pl.productLine = db.convertPLNameFieldsToIDs(pl.productLine);
            insertSuccessCode = db.AddNewProductLine(pl.productLine);
            if (insertSuccessCode == 0) {
                ViewBag.ProductLineSuccess = "Product Line " + tempProductLine + " successfully created and assigned to vendor " + tempVendorName + ".";
                return View(); //TODO: confirmation
            }

            return View();
        }

    }
}


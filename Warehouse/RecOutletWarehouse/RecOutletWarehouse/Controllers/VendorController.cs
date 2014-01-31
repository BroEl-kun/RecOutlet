using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models.VendorManagement;
using RecOutletWarehouse.Models;
using System.Data.Entity.Validation;

namespace RecOutletWarehouse.Controllers
{

    public class VendorController : Controller
    {
        private RecreationOutletContext db = new RecreationOutletContext();
        private DataFetcherSetter dfs = new DataFetcherSetter();
        
        public class ProductLineSalesRepViewModel {
            public PRODUCT_LINE productLine { get; set; }
            public SALES_REP rep { get; set; }
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
        public ActionResult AddVendor(VENDOR vendor, string labelRedirect = "")
        {
            if (!ModelState.IsValid)
            {
                //TODO: replace this view with the correct submit view.
                return View(vendor);
            }
            else
            {
                //EF deprecates the following function call
                //dfs.AddNewVendor(vendor.VendorName, vendor.ContactName,
                //    vendor.ContactPhone, vendor.ContactFax,
                //    vendor.AltPhone, vendor.Address,
                //    vendor.Website);

                db.VENDORs.Add(vendor);
                db.SaveChanges();

                //EF deprecates the following line
                //vendor.VendorId = dfs.GetVendorIdForVendorName(vendor.VendorName);

                //TODO: change this to the actual view i need to return like Success! or something.
                ViewBag.Success = "Vendor successfully created.";
                if (labelRedirect == "Add Vendor, Create Product Line")
                {
                    return RedirectToAction("CreateNewPL", new { id = vendor.VendorID });
                }
                return View();
            }
        }

     

        public ActionResult CreateNewPL(short? id = 0)
        {
            if (id != 0)
                //{ ViewBag.VendorName = dfs.GetVendorNameForVendorId((Int16)id); }

                // EF version of deprecated DFS method follows
                ViewBag.VendorName = db.VENDORs.Find(id).VendorName;
            return View();
        }

     

        [HttpPost]
        public ActionResult CreateNewPL(ProductLineSalesRepViewModel pl) {
            int insertSuccessCode;

            if (pl.productLine.SALES_REP.SalesRepName == null && (pl.rep.SalesRepName == null && pl.rep.SalesRepPhone == null)) {
                ModelState.AddModelError("rep.SalesRepID", "Please specify a sales rep for this product.");
            }

            if (!ModelState.IsValid) {

                return View(pl);
            }

            //if the user chose to create a new rep...
            if (pl.productLine.SALES_REP.SalesRepName == null) {
                pl.productLine.SALES_REP.SalesRepName = pl.rep.SalesRepName; //TODO: See if there's a better way to do this

                db.SALES_REP.Add(pl.rep);
                db.SaveChanges();

                // TODO: Check for duplications and only set success message when db is successfully updated
                //insertSuccessCode = dfs.AddNewSalesRep(pl.rep);
                //if (insertSuccessCode != 0) { //TODO: Check for exceptions
                //}
                //else {
                ViewBag.RepSuccess = "Sales Rep " + pl.rep.SalesRepName + " successfully assigned to " + pl.productLine.ProductLineName + ".";
                //}
            }
            string tempProductLine = pl.productLine.ProductLineName;
            string tempVendorName = pl.productLine.VENDOR.VendorName;

            // The following two lines are deprecated by EF
            //pl.productLine = dfs.convertPLNameFieldsToIDs(pl.productLine);
            //insertSuccessCode = dfs.AddNewProductLine(pl.productLine);

            db.PRODUCT_LINE.Add(pl.productLine);

            try {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e) {
                foreach (var eve in e.EntityValidationErrors) {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors) {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            //if (insertSuccessCode == 0) {
                ViewBag.ProductLineSuccess = "Product Line " + tempProductLine + " successfully created and assigned to vendor " + tempVendorName + ".";
                //return View();
            //}

            return View();
        }

    }
}


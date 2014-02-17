﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models.VendorManagement;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Utilities;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace RecOutletWarehouse.Controllers
{

    public class VendorController : Controller
    {
        private RecreationOutletContext db = new RecreationOutletContext();
        private DataFetcherSetter dfs = new DataFetcherSetter();
        public int BrowsePageSize = 25; // The number of results we want to show on each BrowseVendor page

        public class ProductLineSalesRepViewModel
        {
            public PRODUCT_LINE productLine { get; set; }
            public SALES_REP rep { get; set; }
        }

        public class PagingInfo {
            public int TotalItems { get; set; }
            public int ItemsPerPage { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages {
                get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
            }
        }

        public class BrowseVendorViewModel {
            public IEnumerable<VENDOR> Vendors { get; set; }
            public PagingInfo PagingInfo { get; set; }
            public string search { get; set; }
            public string startLetter { get; set; }
        }

        //
        // GET: /Vendor/
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult AddVendor()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// The POST method for AddVendor, the function for adding vendors to the database.
        /// </summary>
        /// <param name="vendor">The Entity Framework VENDOR model</param>
        /// <param name="labelRedirect">
        /// A parameter indicating whether the user wants to add product lines to the vendor following creation
        /// </param>
        /// <returns>The AddVendor View</returns>
        /// Changelog:
        ///     Version 1.0 (M.S.)
        ///         - Initial creation
        ///     Version 1.1: 11-14-13 (T.M.)
        ///         - Validations and database interaction (via DataFetcherSetter) implemented
        ///     Version 1.5: 1-31-14 (T.M.)
        ///         - Entity Framework implemented; DataFetcherSetter no longer referenced
        ///         - Code refactored for EF implementation
        [HttpPost]
        public ActionResult AddVendor(VENDOR vendor, string labelRedirect = "")
        {
            try
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
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }


        /// <summary>
        /// GET method for CreateNewPL
        /// </summary>
        /// <param name="id">Optional ID parameter that is passed when the user is redirected from vendor creation.</param>
        /// <returns>The CreateNewPL View; clear if id is not supplied, and with VendorName filled if id is supplied.</returns>
        /// Changelog:
        ///     Version 1.0 (T.M.)
        ///         - Initial creation
        ///     Version 1.5 (T.M.)
        ///         - Entity Framework implemented; DataFetcherSetter no longer referenced
        ///         - Code refactored for EF implementation
        public ActionResult CreateNewPL(short? id = 0)
        {
            try
            {
                if (id != 0)
                    //{ ViewBag.VendorName = dfs.GetVendorNameForVendorId((Int16)id); }

                    // EF version of deprecated DFS method follows
                    ViewBag.VendorName = db.VENDORs.Find(id).VendorName;
                return View();
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// POST for CreateNewPL. Adds new product lines, associates them with vendors, and either creates a new sales rep
        /// for the product line or associates an existing sales rep with the product line.
        /// </summary>
        /// <param name="pl">The ViewModel containing information about the product line and sales rep.</param>
        /// <param name="existingrep">A parameter passed from the CreateNewPL View indicating whether the user wanted to
        /// create a new rep or assign an existing rep.</param>
        /// <returns>The CreateNewPL view.</returns>
        /// Changelog:
        ///     Version 1.0: 10-25-13 (T.M.)
        ///         - Initial creation
        ///     Version 1.1: 11-16-13 (T.M.)
        ///         - Validations added
        ///         - View form enhancements
        ///         - DataFetcherSetter methods added; existing methods enhanced
        ///         - jQuery enhancement for the View
        ///     Version 1.5: 1-31-14 (T.M.)
        ///         - Entity Framework implemented; DataFetcherSetter no longer referenced
        ///         - Code refactored for EF implementation
        ///         - Validations removed; will need to be re-implemented
        ///         - View form enhancements
        [HttpPost]
        public ActionResult CreateNewPL(ProductLineSalesRepViewModel pl, string existingrep)
        {
            try
            {
                if (pl.productLine.SALES_REP.SalesRepName == null && (pl.rep.SalesRepName == null && pl.rep.SalesRepPhone == null))
                {
                    ModelState.AddModelError("rep.SalesRepID", "Please specify a sales rep for this product.");
                }

                if (!ModelState.IsValid)
                {

                    return View(pl);
                }

                // if the user chose to create a new rep...
                if (existingrep == "No")
                {
                    db.SALES_REPs.Add(pl.rep);
                    db.SaveChanges();

                    // TODO: Check for duplications and only set success message when db is successfully updated
                    //insertSuccessCode = dfs.AddNewSalesRep(pl.rep);
                    //if (insertSuccessCode != 0) { //TODO: Check for exceptions
                    //}
                    //else {
                    pl.productLine.SALES_REP = db.SALES_REPs.Single(sr => sr.RepID == pl.rep.RepID); // A new rep establishes PRODUCT_LINE --> SALES_REP FK relationship based on new rep's ID
                    ViewBag.RepSuccess = "New Sales Rep " + pl.rep.SalesRepName + " successfully assigned to " + pl.productLine.ProductLineName + ".";
                    //}
                }
                else
                {
                    pl.productLine.SALES_REP = db.SALES_REPs.Single(sr => sr.SalesRepName == pl.productLine.SALES_REP.SalesRepName); // An existing rep establishes PRODUCT_LINE --> SALES_REP FK relationship based on a search by rep name
                    ViewBag.RepSuccess = "Existing Sales Rep " + pl.rep.SalesRepName + " successfully assigned to " + pl.productLine.ProductLineName + ".";
                }

                // The following two lines are deprecated by EF
                //pl.productLine = dfs.convertPLNameFieldsToIDs(pl.productLine);
                //insertSuccessCode = dfs.AddNewProductLine(pl.productLine);

                pl.productLine.VENDOR = db.VENDORs.Single(v => v.VendorName == pl.productLine.VENDOR.VendorName); //Establish VENDOR FK relationship
                db.PRODUCT_LINE.Add(pl.productLine);

                db.SaveChanges();

                ViewBag.ProductLineSuccess = "Product Line " + pl.productLine.ProductLineName + " successfully created and assigned to vendor " + pl.productLine.VENDOR.VendorName + ".";

                return View();

            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }


        public ActionResult BrowseVendors(string venNameSearch, string firstLetter, int page = 1) {
            try {
                BrowseVendorViewModel model;
                var vendors = from v in db.VENDORs
                              select v;

                if (!String.IsNullOrEmpty(firstLetter)) {
                    vendors = vendors.Where(v => v.VendorName.ToUpper().StartsWith(firstLetter));
                }

                if (String.IsNullOrEmpty(venNameSearch)) {
                    model = new BrowseVendorViewModel {
                        Vendors = vendors
                                  .OrderBy(v => v.VendorName)
                                  .Skip((page - 1) * BrowsePageSize)
                                  .Take(BrowsePageSize),
                        PagingInfo = new PagingInfo {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = vendors.Count()
                        },
                        startLetter = firstLetter
                    };
                }
                else {
                    model = new BrowseVendorViewModel {
                        Vendors = vendors
                                  .Where(ve => ve.VendorName.ToUpper().Contains(venNameSearch.ToUpper()))
                                  .OrderBy(v => v.VendorName)
                                  .Skip((page - 1) * BrowsePageSize)
                                  .Take(BrowsePageSize),
                        PagingInfo = new PagingInfo {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = vendors.Where(ve => ve.VendorName.ToUpper().Contains(venNameSearch.ToUpper())).Count()
                        },
                        search = venNameSearch
                        //startLetter = firstLetter // leaving out -- it gives results the user might not expect
                    };
                }
                return View(model);
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// GET method for Vendor Details
        /// </summary>
        /// <param name="id">The VendorID of the Vendor we want the details for.</param>
        /// <returns></returns>
        public ActionResult VendorDetail(int id = 0) {
            try {
                VENDOR vendor = db.VENDORs.Find(id);
                if (vendor == null) {
                    return HttpNotFound();
                }

                return View(vendor);
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// GET Method for editing a vendor
        /// </summary>
        /// <param name="id">The VendorID of the vendor to edit</param>
        /// <returns>The EditVendor View, prefilled with the vendor information.</returns>
        public ActionResult EditVendor(int id = 0) {
            VENDOR vendor = db.VENDORs.Find(id);
            if (vendor == null) {
                return HttpNotFound();
            }
            return View(vendor);
        }

        /// <summary>
        /// POST method for editing a vendor
        /// </summary>
        /// <param name="vendor">The vendor object that is modified</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditVendor(VENDOR vendor) {
            if (ModelState.IsValid) {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BrowseVendors");
            }

            return View(vendor);
        }
    }
}


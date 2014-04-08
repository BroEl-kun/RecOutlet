using RecOutletWarehouse.Models;
using RecOutletWarehouse.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace RecOutletWarehouse.Controllers
{
    /// <summary>
    /// Herein are the controller methods used to process requests made to Views in the directory ~/Views/Vendor/
    /// This Controller class uses Entity Framework exclusively to interact with the database; no direct SQL is used.
    /// </summary>
    public class VendorController : Controller
    {
        private RecreationOutletContext db = new RecreationOutletContext(); // Entity Framework database context
        public int BrowsePageSize = 25; // The number of results we want to show on each BrowseVendor and BrowseSalesReps page

        /// <summary>
        /// The ViewModel used in Product Line CRUD functions
        /// </summary>
        public class ProductLineSalesRepViewModel
        {
            public PRODUCT_LINE productLine { get; set; }
            public SALES_REP rep { get; set; }

            [Required(ErrorMessage="Please select the vendor of this product line.")]
            public string vendorName { get; set; } // Ajax helper variable; also used to look up vendors for db interaction
            public string existingRepFirst { get; set; } // Ajax helper variable
            public string existingRepLast { get; set; } // Ajax helper variable
            public string newRepFirst { get; set; }
            public string newRepLast { get; set; }
            public string newRepPhone { get; set; }
            public string newRepEmail { get; set; }
        }

        /// <summary>
        /// This ViewModel contains a generic list for holding VENDOR objects,
        /// as well as a PagingInfo object to help with pagination and two simple
        /// strings for search and rolodex capabilities.
        /// </summary>
        public class BrowseVendorViewModel {
            public IEnumerable<VENDOR> Vendors { get; set; }
            public PagingInfo PagingInfo { get; set; }
            public string search { get; set; }
            public string startLetter { get; set; }
        }
        
        /// <summary>
        /// This ViewModel contains a generic list of SALES_REPs,
        /// as well as a PagingInfo object to help with pagination
        /// and two simple strings for search and rolodex functionality.
        /// </summary>
        public class BrowseRepsViewModel {
            public IEnumerable<SALES_REP> Reps { get; set; }
            public PagingInfo PagingInfo { get; set; }
            public string search { get; set; }
            public string lastNameStartLetter { get; set; }
        }

        /// <summary>
        /// (UNUSED) HTTP GET for ~/Vendors/Index.cshtml
        /// </summary>
        /// <returns>The Index View, which is currently empty</returns>
        /// TODO: Either implement BrowseVendors logic here or modify URL Routing to redirect to BrowseVendors when this is requested
        public ActionResult Index()
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
        /// This method renders a browsing and searching View for the list of VENDORs.
        /// It can take a number of parameters to filter this list.
        /// </summary>
        /// <param name="venNameSearch">If provided, this filters the list to items that contain it.</param>
        /// <param name="firstLetter">If provided, this filters the list to items that start with it.</param>
        /// <param name="page">Navigates to a specific page; works in tandem with filtering variables.</param>
        /// <returns>The View containing the list.</returns>
        /// TODO: (low priority) Filtering logic can be optimized.
        public ActionResult BrowseVendors(string venNameSearch, string firstLetter, string successRedirectMessage, int page = 1) {
            try {
                // Set redirect message (if there is one)
                if (successRedirectMessage != null) {
                    ViewBag.SuccessMessage = successRedirectMessage;
                }

                // Declare model
                BrowseVendorViewModel model;

                // Create master list
                var vendors = from v in db.VENDORs
                              select v;

                // Filter master list to only those members that start with a certain letter
                // First letter is defined by rolodex selection in View
                // For now, we want it to only filter if there is no search query
                if (!String.IsNullOrEmpty(firstLetter) && String.IsNullOrEmpty(venNameSearch)) {
                    vendors = vendors.Where(v => v.VendorName.ToUpper().StartsWith(firstLetter));
                }

                // IF the user doesn't provide a search query...
                if (String.IsNullOrEmpty(venNameSearch)) {
                    model = new BrowseVendorViewModel {
                        Vendors = vendors
                                  .OrderBy(v => v.VendorName)
                                  .Skip((page - 1) * BrowsePageSize)
                                  .Take(BrowsePageSize),
                        PagingInfo = new PagingInfo {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = vendors.Count() // Get the count of the FILTERED list
                        },
                        startLetter = firstLetter // The starting letter needs to be passed to the View
                                                  // so the View can pass it back to the Controller.
                                                  // If not included, pagination will not work correctly.
                    };
                }
                // ELSE (the user did provide a vendor name search query)
                else {
                    model = new BrowseVendorViewModel {
                        Vendors = vendors
                                  .Where(ve => ve.VendorName.ToUpper().Contains(venNameSearch.ToUpper())) // Further filter the list to items that contain the search
                                  .OrderBy(v => v.VendorName) // This is likely unnecessary (vendors is already sorted), but I'm leaving it here for now
                                  .Skip((page - 1) * BrowsePageSize)
                                  .Take(BrowsePageSize),
                        PagingInfo = new PagingInfo {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = vendors.Where(ve => ve.VendorName.ToUpper().Contains(venNameSearch.ToUpper())).Count() // Again, we want the count to take our filters into account
                        },
                        search = venNameSearch
                        //startLetter = firstLetter // Leaving out -- it gives results the user might not expect
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
        /// Simple HTTP GET method for AddVendor View
        /// </summary>
        /// <returns>An empty AddVendor View</returns>
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
        [HttpPost]
        public ActionResult AddVendor(VENDOR vendor, string labelRedirect = "")
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(vendor);
                }
                else
                {
                    db.VENDORs.Add(vendor);
                    db.SaveChanges();

                    ViewBag.Success = "Vendor successfully created.";
                    if (labelRedirect == "Add Vendor, Create Product Line")
                    {
                        return RedirectToAction("CreateNewPL", new { vendorId = vendor.VendorID });
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
        /// GET Method for editing a vendor
        /// </summary>
        /// <param name="id">The VendorID of the VENDOR object to be edited</param>
        /// <returns>The EditVendor View, prefilled with the vendor information.</returns>
        public ActionResult EditVendor(int id = 0) {
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
        /// POST method for editing a VENDOR object
        /// </summary>
        /// <param name="vendor">The VENDOR object that is modified</param>
        /// <returns>
        /// SUCCESS: A redirect to the BrowseVendors View with a success message
        /// FAIL-VALIDATION: The EditVendor View with field validation annotations
        /// FAIL-OTHER: A redirect to the error page (error logged in ~/Logs/ERRORLOG.txt)
        /// </returns>
        /// TODO: (low priority) Ideal candidate for using a partial View (within a jQuery modal) instead of a new page
        [HttpPost]
        public ActionResult EditVendor(VENDOR vendor) {
            try {
                if (ModelState.IsValid) {
                    db.Entry(vendor).State = EntityState.Modified; // Tell EF what "entity" is going to be modified
                    db.SaveChanges();
                    return RedirectToAction("BrowseVendors", new {
                        firstletter = vendor.VendorName.Substring(0, 1),
                        successRedirectMessage = String.Format("Vendor \"{0}\" successfully modified.", vendor.VendorName)
                    });
                }

                return View(vendor);
            }
            catch (Exception ex){
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

                return PartialView(vendor);
            }
            catch (Exception ex) {
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
        public ActionResult CreateNewPL(short? vendorId = 0)
        {
            try
            {
                if (vendorId != 0)
                    ViewBag.VendorName = db.VENDORs.Find(vendorId).VendorName;
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
        [HttpPost]
        public ActionResult CreateNewPL(ProductLineSalesRepViewModel pl, string existingrep)
        {
            try
            {
                ViewBag.VendorName = pl.vendorName; // Sustains vendor name field when validation fails & when product line is successfully created
                pl.productLine.VENDOR = db.VENDORs.SingleOrDefault(v => v.VendorName == pl.vendorName);
                if (pl.existingRepFirst== null && pl.existingRepLast == null && (pl.newRepFirst == null && pl.newRepLast == null && pl.newRepPhone == null && pl.newRepEmail == null))
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
                    pl.rep = new SALES_REP {
                        SalesRepFirstName = pl.newRepFirst,
                        SalesRepLastName = pl.newRepLast,
                        SalesRepPhone = pl.newRepPhone,
                        SalesRepEmail = pl.newRepEmail
                    };
                    db.SALES_REPs.Add(pl.rep);
                    db.SaveChanges();

                    // TODO: Check for duplications and only set success message when db is successfully updated

                    pl.productLine.SALES_REP = db.SALES_REPs.Single(sr => sr.RepID == pl.rep.RepID); // A new rep establishes PRODUCT_LINE --> SALES_REP FK relationship based on new rep's ID
                    ViewBag.RepSuccess = "New Sales Rep " + pl.rep.SalesRepFirstName + " " + pl.rep.SalesRepLastName + " successfully assigned to " + pl.productLine.ProductLineName + ".";
                }
                else
                {
                    pl.productLine.SALES_REP = db.SALES_REPs.Single(sr => sr.SalesRepFirstName == pl.existingRepFirst && sr.SalesRepLastName == pl.existingRepLast); // An existing rep establishes PRODUCT_LINE --> SALES_REP FK relationship based on a search by rep name
                    ViewBag.RepSuccess = "Existing Sales Rep " + pl.productLine.SALES_REP.SalesRepFirstName + " " + pl.productLine.SALES_REP.SalesRepLastName + " successfully assigned to " + pl.productLine.ProductLineName + ".";
                }

                pl.productLine.VENDOR = db.VENDORs.Single(v => v.VendorName == pl.productLine.VENDOR.VendorName); //Establish VENDOR FK relationship
                db.PRODUCT_LINE.Add(pl.productLine);

                db.SaveChanges();

                ViewBag.ProductLineSuccess = "Product Line " + pl.productLine.ProductLineName + " successfully created and assigned to vendor " + pl.productLine.VENDOR.VendorName + ".";

                return View(); //clear all fields on success
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// HTTP GET for a View that allows the user to edit a PRODUCT_LINE's attributes
        /// </summary>
        /// <param name="id">The ProductLineID of the PRODUCT_LINE object to be edited</param>
        /// <returns>The EditProductLine View, pre-filled with data retrieved for the specified PRODUCT_LINE</returns>
        /// TODO: (low priority) This is an ideal candidate for conversion to a partial View displayed in a jQuery modal (rather than displaying a new page).
        public ActionResult EditProductLine(int id = 0) {
            try {
                ProductLineSalesRepViewModel model = new ProductLineSalesRepViewModel();
                model.productLine = db.PRODUCT_LINE.Find(id);
                model.vendorName = model.productLine.VENDOR.VendorName; //ViewModel needs to be set based on PL information
                if (model.productLine == null) {
                    return HttpNotFound();
                }
                return View(model);
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// POST: Submits changes (requested by the user) to a certain Product Line to the database
        /// </summary>
        /// <param name="pl">An instance of the ProductLineSalesRepViewModel ViewModel class</param>
        /// <param name="changerep">
        /// A switch variable, set by radio buttons in the View, that 
        /// indicates whether the user chose to change the sales rep</param>
        /// <returns>A redirect back to the BrowseVendors View</returns>
        [HttpPost]
        public ActionResult EditProductLine(ProductLineSalesRepViewModel pl, string changerep) {
            try {
                if (ModelState.IsValid) {
                    db.Entry(pl.productLine).State = EntityState.Modified; // Signal to EF that any of pl.productLine's entities could change
                    switch (changerep) {
                        case "no":
                            pl.productLine.SALES_REP = db.SALES_REPs.Single(rep => rep.RepID == pl.productLine.SALES_REP.RepID);
                            break;
                        case "existing":
                            pl.productLine.SALES_REP = db.SALES_REPs.Single(rep => rep.SalesRepFirstName == pl.existingRepFirst && rep.SalesRepLastName == pl.existingRepLast);
                            break;
                        case "new":
                            //add the sales rep
                            pl.rep.SalesRepFirstName = pl.newRepFirst;
                            pl.rep.SalesRepLastName = pl.newRepLast;
                            db.SALES_REPs.Add(pl.rep);
                            db.SaveChanges();
                            pl.productLine.SALES_REP = db.SALES_REPs.Single(rep => rep.RepID == pl.rep.RepID);
                            break;
                    }

                    pl.productLine.VENDOR = db.VENDORs.Single(ven => ven.VendorName == pl.vendorName);

                    db.SaveChanges();

                    
                    return RedirectToAction("BrowseVendors", new {
                                firstletter = pl.productLine.ProductLineName.Substring(0, 1),
                                successRedirectMessage = String.Format("Product Line \"{0}\" successfully modified.", pl.productLine.ProductLineName) });
                }
                return View(pl);
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// HTTP GET for a partial View that displays a Product Line's details.
        /// </summary>
        /// <param name="id">The ProductLineID associated with the PRODUCT_LINE object we wish to retrieve details about</param>
        /// <returns>A partial View (currently rendered as a jQuery modal in the BrowseVendors View) with the PRODUCT_LINE object's details</returns>
        public ActionResult ProductLineDetail(int id = 0) {
            try {
                PRODUCT_LINE pl = db.PRODUCT_LINE.Find(id);
                if (pl == null) {
                    return HttpNotFound();
                }
                return PartialView(pl);
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// HTTP GET for a View displaying a list of SALES_REPs, which can be filtered using parameters passed to this function
        /// </summary>
        /// <param name="repNameSearch">Filters the list of SALES_REPs based on whether they contain this string</param>
        /// <param name="lastNameBeginsWith">Filters the list of SALES_REPs based on whether SalesRepLastName starts with this string</param>
        /// <param name="page">Filters the list of SALES_REPs based on whether they belong to this "page"</param>
        /// <returns>A View with a list of SALES_REP objects that meet the filtering criteria</returns>
        /// TODO: (low priority) The filtering logic of this function could be optimized.
        public ActionResult BrowseSalesReps(string repNameSearch, string lastNameBeginsWith, int page = 1) {
            try {
                BrowseRepsViewModel model;
                var reps = from v in db.SALES_REPs
                           select v;

                // Filter master list to only those members that start with a certain letter
                // First letter is defined by rolodex selection in View
                if (!String.IsNullOrEmpty(lastNameBeginsWith) && String.IsNullOrEmpty(repNameSearch)) {
                    reps = reps.Where(sr => sr.SalesRepLastName.ToUpper().StartsWith(lastNameBeginsWith));
                }

                // IF the user doesn't provide a search query...
                if (String.IsNullOrEmpty(repNameSearch)) {
                    model = new BrowseRepsViewModel {
                        Reps = reps
                                  .OrderBy(sr => sr.SalesRepLastName)
                                  .Skip((page - 1) * BrowsePageSize)
                                  .Take(BrowsePageSize),
                        PagingInfo = new PagingInfo {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = reps.Count() // Get the count of the FILTERED list
                        },
                        lastNameStartLetter = lastNameBeginsWith // The starting letter needs to be passed to the View
                        // so the View can pass it back to the Controller.
                        // If not included, pagination will not work correctly.
                    };
                }
                // ELSE (the user did provide a search query)
                else {
                    model = new BrowseRepsViewModel {
                        Reps = reps
                                  .Where(sr => sr.SalesRepLastName.ToUpper().Contains(repNameSearch.ToUpper()) || sr.SalesRepFirstName.ToUpper().Contains(repNameSearch.ToUpper()))
                                  .OrderBy(v => v.SalesRepLastName) // possibly unnecessary
                                  .Skip((page - 1) * BrowsePageSize)
                                  .Take(BrowsePageSize),
                        PagingInfo = new PagingInfo {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = reps.Where(sr => sr.SalesRepLastName.ToUpper().Contains(repNameSearch.ToUpper()) || sr.SalesRepFirstName.ToUpper().Contains(repNameSearch.ToUpper())).Count()
                        },
                        search = repNameSearch
                        //startLetter = firstLetter // Leaving out -- it gives results the user might not expect
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
        /// HTTP GET for the View that allows the user to insert a new SALES_REP into the database
        /// </summary>
        /// <returns>An empty AddRep View</returns>
        public ActionResult AddRep() {
            try {
                return View();
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// HTTP POST that sends a new SALES_REP object to Entity Framework for insertion into the database.
        /// This View also allows a SALES_REP to be associated with a PRODUCT_LINE upon creation.
        /// </summary>
        /// <param name="rep">The SALES_REP to be added to the database</param>
        /// <param name="productLineName">The ProductLineName of a PRODUCT_LINE object to which the SALES_REP is to be associated</param>
        /// <returns>
        /// SUCCESS: A blank AddRep View
        /// FAIL-VALIDATION: The AddRep View with invalid form fields indicated
        /// FAIL-OTHER: A redirect to the Error page
        /// </returns>
        [HttpPost]
        public ActionResult AddRep(SALES_REP rep, string productLineName) {
            try {
                if (!ModelState.IsValid)
                    return View(rep);

                if (!String.IsNullOrEmpty(productLineName)) {
                    PRODUCT_LINE pl = db.PRODUCT_LINE.SingleOrDefault(p => p.ProductLineName == productLineName);
                    if (pl != null) {
                        db.Entry(pl).State = EntityState.Modified;
                        pl.SALES_REP = rep;
                    }
                    else {
                        ViewBag.ProductLineDNE = string.Format("The product line \"{0}\" does not exist. Enter an existing product "
                            + "line or leave the field empty and use the \"Add Sales Rep, Create Product Line\" button "
                            + "to assign this sales rep to a new product line.", productLineName);
                        return View(rep);
                    }
                }

                db.SALES_REPs.Add(rep);
                db.SaveChanges();

                return View();
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }
        /// <summary>
        /// HTTP GET for the EditRep View, which allows the user to modify a SALES_REP's attributes
        /// </summary>
        /// <param name="id">The RepID of the SALES_REP to be modified</param>
        /// <returns>The EditRep View, pre-filled with data for the specified SALES_REP</returns>
        /// TODO: (low priority) Ideal candidate for conversion to a partial View (inside a jQuery modal; like RepDetail) 
        public ActionResult EditRep(int id = 0) {
            try {
                SALES_REP rep = new SALES_REP();
                rep = db.SALES_REPs.Find(id);

                if (rep == null) {
                    return HttpNotFound();
                }
                return View(rep);
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// HTTP POST for EditRep submits supplied form data to Entity Framework to update the database
        /// </summary>
        /// <param name="rep">The SALES_REP object to be updated</param>
        /// <returns>
        /// If form validation and database update succeed, a redirect to BrowseSalesReps.
        /// If form validation fails, the View is returned with Model errors.
        /// If database insertion fails, a redirect to the "error" page.
        /// </returns>
        [HttpPost]
        public ActionResult EditRep(SALES_REP rep) {
            try {
                if (ModelState.IsValid) {
                    db.Entry(rep).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("BrowseSalesReps");
                }

                return View(rep);
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// HTTP GET for a partial View giving details on a specified SALES_REP
        /// </summary>
        /// <param name="id">The RepID of the SALES_REP object for which details are requested</param>
        /// <returns>A partial View within a jQuery modal (defined in BrowseSalesReps View) with details about the specified SALES_REP</returns>
        public ActionResult RepDetail(int id = 0) {
            try {
                SALES_REP rep = db.SALES_REPs.Find(id);

                return PartialView(rep);
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
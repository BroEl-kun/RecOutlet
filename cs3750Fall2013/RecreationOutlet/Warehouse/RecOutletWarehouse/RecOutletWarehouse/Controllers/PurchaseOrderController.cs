using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Utilities;
using System.Data.Entity;

namespace RecOutletWarehouse.Controllers
{
    public class PurchaseOrderController : Controller
    {
        RecreationOutletContext entityDb = new RecreationOutletContext();
        public int BrowsePageSize = 25; // The number of results we want to show on each BrowseVendor page

        //ViewModel: PurchaseOrderAndLineItem
        //A ViewModel allows you to access data from different models 
        //(often database tables) in a single view

        /// <summary>
        /// The ViewModel that allows retrieval and insertion of data from and into
        /// the PurchaseOrder and POLineItem models within a single form
        /// </summary>
        public class PurchaseOrderCreationViewModel
        {
            public PurchaseOrderCreationViewModel()
            {
                VendorItems = new List<VendorItemsViewModel>();
            }
            public PURCHASE_ORDER PO { get; set; }
            public List<PO_LINEITEM> AddedLineItems { get; set; }
            public List<VendorItemsViewModel> VendorItems { get; set; }
            //public  ItemToAdd { get; set; }
            public List<string> ItemNames { get; set; }
            public List<int> VendorIds { get; set; }
            public String tempPOID { get; set; }
        }

        /// <summary>
        /// ViewModel for creating items to a purchase order
        /// </summary>
        public class VendorItemsViewModel
        {
            public ITEM VendorItem { get; set; }
            public short QtyToOrder { get; set; }
            public decimal ItemCostEach { get; set; }
        }

        /// <summary>
        /// ViewModel for Browsing/Searching/Paging Purchase Orders
        /// </summary>
        public class PurchaseOrderSearchViewModel
        {
            public List<PURCHASE_ORDER> POs { get; set; }
            public PagingInfo PagingInfo { get; set; }
            public string search { get; set; }
        }

        //public class PO_LineItemList {
        //    public PURCHASE_ORDER PO { get; set; }
        //    public List<PO_LINEITEM> LineItems { get; set; }
        //}

        //
        // GET: /PurchaseOrder/

        /// <summary>
        /// Index of the Purchase Order Controller
        /// </summary>
        /// <returns>ActionResult Index</returns>
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
        /// Form for creating a new Purchase Order
        /// </summary>
        /// <param name="vendorId">Id of the Vendor the Purchase Order is for</param>
        /// <returns>ActionResult CreateNewPO</returns>
        [HttpGet]
        public ActionResult CreateNewPO(int vendorId = 0)
        {
            try
            {

                //DataFetcherSetter db = new DataFetcherSetter();
                //int nextPO = db.getLastPONumForDate(DateTime.Now.Date);

                int nextPO = Utilities.WarehouseUtilities.getPODateCount();

                ViewBag.PO = createPOForForm(nextPO);
                if(vendorId != 0){
                    ViewBag.VendorName = entityDb.VENDORs.SingleOrDefault(v => v.VendorID == vendorId).VendorName;
                }

                return View();
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Creates a purchase order with basic information
        /// </summary>
        /// <param name="POVM">The ViewModel to store PO information</param>
        /// <returns>A redirect to AddPOLineItem</returns>
        [HttpPost]
        public ActionResult CreateNewPO(PurchaseOrderCreationViewModel POVM)
        {
            try
            {
                if(!ModelState.IsValid){
                    return View(POVM);
                }

                ViewBag.PO = POVM.PO.POID;

                //TODO: Move the character replacement logic to a
                //tools class and enhance its functionality
                string POtoInt = POVM.tempPOID;
                POtoInt = POtoInt.Replace("-", string.Empty);

                int convertedPO = Convert.ToInt32(POtoInt);

                POVM.PO.POID = convertedPO;

                POVM.PO.VENDOR = entityDb.VENDORs.Single(x => x.VendorName == POVM.PO.VENDOR.VendorName);

                POVM.PO.POCreatedDate = DateTime.Now;

                POVM.PO.EMPLOYEE = entityDb.EMPLOYEEs.SingleOrDefault(x => x.EmployeeId == 1);
                    entityDb.PURCHASE_ORDER.Add(POVM.PO);
                    entityDb.SaveChanges();

                    return RedirectToAction("AddPOLineItem", new { id = convertedPO });
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Provides the form into which LineItems are entered for a particular PO
        /// (indicated by the id variable)
        /// </summary>
        /// <param name="id">The PO ID for which information is displayed and entered</param>
        /// <returns>The AddPOLineItem View, supplemented with general PO information</returns>
        public ActionResult AddPOLineItem(int id = 0)
        {
            try
            {
                // List<Item> items = db.SearchItemsByName("AS Laptop 17 B3250");
                PurchaseOrderCreationViewModel POVM = new PurchaseOrderCreationViewModel();
                POVM.PO = entityDb.PURCHASE_ORDER.Find(id);
                POVM.AddedLineItems = entityDb.PO_LINEITEM.Where(p => p.PURCHASE_ORDER.POID == POVM.PO.POID).ToList();
                List<VendorItemsViewModel> VIVMList = new List<VendorItemsViewModel>();
                List<ITEM> items = entityDb.ITEMs.Where(i => i.PRODUCT_LINE.VendorID == POVM.PO.VENDOR.VendorID).ToList();
                foreach (var item in items) {
                    VIVMList.Add(new VendorItemsViewModel{
                        VendorItem = item
                    });
                }

                ViewBag.TotalPOCost = String.Format("{0:$0.00}", POVM.AddedLineItems.Sum(x => x.WholesaleCost * x.QtyOrdered));

                POVM.VendorItems = VIVMList;

                return View(POVM);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Commits the POLineItems to the database with the provided POID
        /// </summary>
        /// <param name="POVM">The ViewModel that will store the POLineItems</param>
        /// <param name="id">The Purchase Order ID that these line items are associated with</param>
        /// <returns>A redirect to POSummary</returns>
        /// POST: PurchaseOrder/AddPOLineItem
        [HttpPost]
        public ActionResult AddPOLineItem(PurchaseOrderCreationViewModel POVM)
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
        /// Add item to line items
        /// </summary>
        /// <param name="cost">Cost of product</param>
        /// <param name="qty">Number of product</param>
        /// <param name="num"></param>
        /// <param name="rpc">RecRPC</param>
        /// <param name="poid">Purchase Order ID</param>
        /// <returns>PartialView POLineItemsListPart</returns>
        public ActionResult addItemToLineItems(decimal cost = 0, short qty = 0, int num = 0, long rpc = 0, long poid = 0 )
        {
            try
            {
                // TODO: Find a more "maintainable" way to do this (i.e. pass a ViewModel instead of a bunch of parameters)
                ITEM item = entityDb.ITEMs.Single(i => i.RecRPC == rpc);
                PURCHASE_ORDER PO = entityDb.PURCHASE_ORDER.Single(p => p.POID == poid);
                entityDb.PO_LINEITEM.Add(new PO_LINEITEM
                {
                    PURCHASE_ORDER = PO,
                    ITEM = item,
                    QtyOrdered = qty,
                    WholesaleCost = cost,
                    QtyTypeID = 1 // Need to re-evaluate the purpose of QtyType - esp. does it need to be here? 
                });
                if (!ModelState.IsValid)
                {
                    return PartialView("POLineItemListPart");
                }

                entityDb.SaveChanges();
                List<PO_LINEITEM> listToReturn = entityDb.PO_LINEITEM.Where(li => li.POID == PO.POID).ToList();

                ViewBag.TotalPOCost = String.Format("{0:$0.00}", listToReturn.Sum(x => x.WholesaleCost * x.QtyOrdered));

                return PartialView("POLineItemListPart", listToReturn);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Removes an item for the the line items
        /// </summary>
        /// <param name="lineItemID">Line item ID</param>
        /// <returns>PartialView POLineItemsListPart</returns>
        public ActionResult removeItemFromLineItems(int lineItemID = 0)
        {
            try
            {
                // TODO: Find a more "maintainable" way to do this (i.e. pass a ViewModel instead of a bunch of parameters)
                PO_LINEITEM lineItem = entityDb.PO_LINEITEM.Single(poli => poli.POLineItemID == lineItemID);
                long POID = lineItem.POID;

                entityDb.PO_LINEITEM.Remove(lineItem);

                entityDb.SaveChanges();
                List<PO_LINEITEM> listToReturn = entityDb.PO_LINEITEM.Where(li => li.POID == POID).ToList();

                ViewBag.TotalPOCost = String.Format("{0:$0.00}", listToReturn.Sum(x => x.WholesaleCost * x.QtyOrdered));

                return PartialView("POLineItemListPart", listToReturn);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Utility for searching PO by orderdate. Also paging is included
        /// for lists greater than 25 POs
        /// </summary>
        /// <param name="orderDate"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult SearchPO(DateTime? orderDate, int page = 1)
        {
            try
            {
                //Master List of PO's
                var poMList = from v in entityDb.PURCHASE_ORDER
                              select v;

                PurchaseOrderSearchViewModel model;

                // IF the user doesn't provide a search query...
                if (String.IsNullOrEmpty(orderDate.ToString()))
                {
                    model = new PurchaseOrderSearchViewModel
                    {
                        POs = poMList
                                  .OrderBy(v => v.POOrderDate)
                                  .Skip((page - 1) * BrowsePageSize)
                                  .Take(BrowsePageSize).ToList(),
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = poMList.Count() // Get the count of the FILTERED list
                        },
                        //startLetter = firstLetter // The starting letter needs to be passed to the View
                        // so the View can pass it back to the Controller.
                        // If not included, pagination will not work correctly.
                    };
                }
                // ELSE (the user did provide a vendor name search query)
                else
                {
                    model = new PurchaseOrderSearchViewModel
                    {
                        POs = poMList
                                  .Where(ve => ve.POOrderDate == orderDate) // Further filter the list to items that contain the search
                                  .OrderBy(v => v.POOrderDate) // This is likely unnecessary (vendors is already sorted), but I'm leaving it here for now
                                  .Skip((page - 1) * BrowsePageSize)
                                  .Take(BrowsePageSize).ToList(),
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = poMList.Where(ve => ve.POOrderDate == orderDate).Count() // Again, we want the count to take our filters into account
                        },
                        search = orderDate.ToString()
                        //startLetter = firstLetter // Leaving out -- it gives results the user might not expect
                    };
                }

                //List<PURCHASE_ORDER> po = entityDb.PURCHASE_ORDER.ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Edit an existing Purchase Order's data
        /// </summary>
        /// <param name="id">Purchase Order ID</param>
        /// <returns>ActionResult EditPO</returns>
        public ActionResult EditPO(int id)
        {
            try
            {
                //byte newId = Convert.ToByte(id);
                //PURCHASE_ORDER po = entityDb.PURCHASE_ORDER.Find(id);
                PURCHASE_ORDER po = entityDb.PURCHASE_ORDER.SingleOrDefault(x => x.POID == id);

                return View(po);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// POST method for editing and existing PO's data
        /// </summary>
        /// <param name="po">PURCHASE_ORDER model</param>
        /// <returns>ActionResult SearchPO</returns>
        [HttpPost]
        public ActionResult EditPO(PURCHASE_ORDER po)
        {
            try
            {
                entityDb.Entry(po).State = EntityState.Modified;
                entityDb.SaveChanges();
                return RedirectToAction("SearchPO");
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// View Purchase Order in PDF format
        /// </summary>
        /// <param name="id">Purchase Order ID</param>
        /// <returns>View of PDF version of Purchase Order</returns>
        public ActionResult PODocumentView(int id=0)
        {
            try
            {
                Response.Redirect(@"~/WebForms/POReport.aspx?id=" + id.ToString());
                return new EmptyResult();
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        //PURCHASE ORDER UTILITY METHODS FOLLOW
        /// <summary>
        /// Creates a PO form
        /// </summary>
        /// <param name="PO">Int Purchase Order ID</param>
        /// <returns>String Purchase Order for form</returns>
        public static string createPOForForm(int PO)
        {
            // TODO: This class returns an incorrectly-formatted PO Number when the PO number
            // for "today's" date ends in 10 (produces "010" instead of "10")
            // Easy fix, low priority
            string POforForm;
            bool lessThan10 = false;

            if (PO < 10)
            {
                lessThan10 = true;
            }

            if (PO != 0)
            {

                PO++; //increment the last number of the PO

                POforForm = DateTime.Now.Date.ToString("MM-dd-yyyy");
                if (lessThan10)
                {
                    POforForm = POforForm + "-0" + PO.ToString();
                }
                else
                {
                    POforForm = POforForm + "-" + PO.ToString();
                }
            }
            else
            {
                POforForm = DateTime.Now.Date.ToString("MM-dd-yyyy");
                POforForm = POforForm + "-01";
            }

            return POforForm;
        }
    }
}

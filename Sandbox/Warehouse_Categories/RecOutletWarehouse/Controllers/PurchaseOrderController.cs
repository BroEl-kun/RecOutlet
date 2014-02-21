using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Models.PurchaseOrder;
using RecOutletWarehouse.Models.VendorManagement;
using RecOutletWarehouse.Models.ItemManagement;
using RecOutletWarehouse.Utilities;

namespace RecOutletWarehouse.Controllers
{
    public class PurchaseOrderController : Controller
    {
        RecreationOutletContext entityDb = new RecreationOutletContext();

        //ViewModel: PurchaseOrderAndLineItem
        //A ViewModel allows you to access data from different models 
        //(often database tables) in a single view

        /// <summary>
        /// The ViewModel that allows retrieval and insertion of data from and into
        /// the PurchaseOrder and POLineItem models within a single form
        /// </summary>
        /// <author>Tyler M.</author>
        public class PurchaseOrderCreationViewModel
        {
            public PURCHASE_ORDER PO { get; set; }
            public List<PurchaseOrderLineItem> LineItems { get; set; }
            public List<string> ItemNames { get; set; }
            public List<int> VendorIds { get; set; }
            public String tempPOID { get; set; }
        }

        //
        // GET: /PurchaseOrder/

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

        [HttpGet]
        public ActionResult CreateNewPO()
        {
            try
            {

                //DataFetcherSetter db = new DataFetcherSetter();
                //int nextPO = db.getLastPONumForDate(DateTime.Now.Date);

                int nextPO = Utilities.WarehouseUtilities.getPODateCount();

                ViewBag.PO = createPOForForm(nextPO);

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Creates a purchase order with basic information
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="POVM">The ViewModel to store PO information</param>
        /// <returns>A redirect to AddPOLineItem</returns>
        [HttpPost]
        public ActionResult CreateNewPO(PurchaseOrderCreationViewModel POVM)
        {
            try
            {
                DataFetcherSetter db = new DataFetcherSetter();

                ViewBag.PO = POVM.PO.POID;

                //TODO: Move the character replacement logic to a
                //tools class and enhance its functionality
                string POtoInt = POVM.tempPOID;
                POtoInt = POtoInt.Replace("-", string.Empty);

                int convertedPO = Convert.ToInt32(POtoInt);

                POVM.PO.POID = convertedPO;

                //find the vendor ID for the provided vendor name
                short vendorId = Convert.ToInt16(db.GetVendorIdForVendorName(POVM.PO.VENDOR.VendorName));

                POVM.PO.VENDOR = entityDb.VENDORs.Single(x => x.VendorName == POVM.PO.VENDOR.VendorName);

                //CUSTOM VALIDATION FOLLOWS
                //if (db.RetrievePObyPOID(Convert.ToInt64(convertedPO)).PurchaseOrderId != null)
                //{
                //    ModelState.AddModelError("PO.PurchaseOrderId", "That PO Number already exists.");
                //}
                //if (vendorId == 0)
                //{
                //    ModelState.AddModelError("PO.Vendor", "That Vendor isn't in the database. Please add vendor information.");
                //}
                //else if (vendorId == -1)
                //{
                //    ModelState.AddModelError("PO.Vendor", "Please be more specific. TODO: better error message");
                //}

                //if (POVM.PO.OrderDate < DateTime.Now.Date)
                //{
                //    ModelState.AddModelError("PO.OrderDate", "That date has passed");
                //}
                //if (POVM.PO.EstShipDate < POVM.PO.OrderDate)
                //{
                //    ModelState.AddModelError("PO.EstShipDate", "The estimated ship date cannot occur before the order date");
                //}

                //CUSTOM VALIDATION ENDS

                //Test section for converting Datetime to smalldatetime
                //-------------------------------------------------------
                

                //-------------------------------------------------------

                if (!ModelState.IsValid)
                {
                    return View(POVM);
                }
                else
                {
                    //db.CreateNewPurchaseOrder(convertedPO,
                    //    vendorId, POVM.PO.CreatedBy,
                    //    POVM.PO.OrderDate, POVM.PO.EstShipDate,
                    //    POVM.PO.FreightCost, POVM.PO.Terms,
                    //    POVM.PO.Comments); //TODO: Associate the employeeID with this

                    entityDb.PURCHASE_ORDER.Add(POVM.PO);
                    entityDb.SaveChanges();

                    return RedirectToAction("AddPOLineItem", new { id = convertedPO });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Provides the form into which LineItems are entered for a particular PO
        /// (indicated by the id variable)
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="id">The PO ID for which information is displayed and entered</param>
        /// <returns>The AddPOLineItem View, supplemented with general PO information</returns>
        public ActionResult AddPOLineItem(int id = 0)
        {
            try
            {
                DataFetcherSetter db = new DataFetcherSetter();
                // List<Item> items = db.SearchItemsByName("AS Laptop 17 B3250");
                PurchaseOrderCreationViewModel POVM = new PurchaseOrderCreationViewModel();
                //POVM.PO = db.RetrievePObyPOID(id);

                return View(POVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Commits the POLineItems to the database with the provided POID
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="POVM">The ViewModel that will store the POLineItems</param>
        /// <param name="id">The Purchase Order ID that these line items are associated with</param>
        /// <returns>A redirect to POSummary</returns>
        /// POST: PurchaseOrder/AddPOLineItem
        [HttpPost]
        public ActionResult AddPOLineItem(PurchaseOrderCreationViewModel POVM, string id)
        {
            try
            {
                DataFetcherSetter db = new DataFetcherSetter();

                //POVM.PO = db.RetrievePObyPOID(Convert.ToInt64(id));
                string POtoInt = id;
                POtoInt = POtoInt.Replace("-", string.Empty);

                int convertedPO = Convert.ToInt32(POtoInt);
                decimal totalCost = Convert.ToDecimal(POVM.PO.POFreightCost);

                //TODO: Move the character replacement logic to a
                //tools class and enhance its functionality

                foreach (var item in POVM.LineItems)
                {
                    if (item.RecRPC != 0 && item.WholesaleCost != 0 && item.QtyOrdered != 0)
                    { //do not attempt to add empty list items
                        db.NewPOLineItemForPO(convertedPO, item.RecRPC, item.WholesaleCost,
                        item.QtyOrdered, 1); //TODO: figure out how "Qty Type" fits in here
                        totalCost += (item.WholesaleCost * item.QtyOrdered);
                    }
                }

                ViewBag.POTotal = String.Format("P.O. Total Cost: ${0:C}", totalCost.ToString());

                return View("POSummary", POVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// POSummary is the View redirect result for completed purchase orders and the "details"
        /// of a searched PO
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="id">The ID of the Purchase order the summary is based on</param>
        /// <returns>HTTPGet: The base View of POSummary, which has PO information and a list 
        /// of POLineItems</returns>
        /// GET: PurchaseOrder/POSummary
        public ActionResult POSummary(PurchaseOrderCreationViewModel POVM)
        {
            try
            {
                //PurchaseOrderCreationViewModel POVM = new PurchaseOrderCreationViewModel();
                DataFetcherSetter db = new DataFetcherSetter();

                //POVM.PO = db.RetrievePObyPOID(id);
                //POVM.LineItems = db.ListLineItemsForPO(id);

                return View(POVM);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult SearchPO() 
        {
            try
            {
                DataFetcherSetter db = new DataFetcherSetter();

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public ActionResult SearchPO(string queryType, string query)
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

        //PURCHASE ORDER UTILITY METHODS FOLLOW

        public static string createPOForForm(int PO)
        {
            string POforForm;

            if (PO != 0)
            {
                //format for displaying in the form
                PO++; //increment the last number of the PO
                POforForm = PO.ToString();
                POforForm = POforForm.Insert(2, "-");
                POforForm = POforForm.Insert(5, "-");
                POforForm = POforForm.Insert(10, "-");
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

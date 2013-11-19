using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Models.PurchaseOrder;
using RecOutletWarehouse.Models.VendorManagement;

namespace RecOutletWarehouse.Controllers
{
    public class PurchaseOrderController : Controller
    {
        //ViewModel: PurchaseOrderAndLineItem
        //A ViewModel allows you to access data from different models 
        //(often database tables) in a single view

        /// <summary>
        /// The ViewModel that allows retrieval and insertion of data from and into
        /// the PurchaseOrder and POLineItem models within a single form
        /// </summary>
        /// <author>Tyler M.</author>
        public class PurchaseOrderCreationViewModel {
            public PurchaseOrder PO { get; set; }
            public List<PurchaseOrderLineItem> LineItems { get; set; }

        }

        //
        // GET: /PurchaseOrder/

        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult CreateNewPO() {
            DataFetcherSetter db = new DataFetcherSetter();
            int nextPO = db.getLastPONumForDate(DateTime.Now.Date); 

            ViewBag.PO = createPOForForm(nextPO);

            return View();
        }

        /// <summary>
        /// Creates a purchase order with basic information
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="POVM">The ViewModel to store PO information</param>
        /// <returns>A redirect to AddPOLineItem</returns>
        [HttpPost]
        public ActionResult CreateNewPO(PurchaseOrderCreationViewModel POVM) {
            DataFetcherSetter db = new DataFetcherSetter();
            
            ViewBag.PO = POVM.PO.PurchaseOrderId;

            string POtoInt = POVM.PO.PurchaseOrderId;
            POtoInt = POtoInt.Replace("-", string.Empty);

            int convertedPO = Convert.ToInt32(POtoInt);

            //find the vendor ID for the provided vendor name
            short vendorId = Convert.ToInt16(db.GetVendorIdForVendorName(POVM.PO.Vendor));
            
            //CUSTOM VALIDATION FOLLOWS
            if (vendorId == 0) {
                ModelState.AddModelError("PO.Vendor", "That Vendor isn't in the database. Please add vendor information.");
            }
            else if (vendorId == -1) {
                ModelState.AddModelError("PO.Vendor", "Please be more specific. TODO: better error message");
            }
            else {
                //if the vendorID is valid, check to see if the PO already exists
                Boolean validPO = db.NewPurchaseOrder(convertedPO,
                    vendorId, POVM.PO.CreatedBy,
                    POVM.PO.OrderDate, POVM.PO.EstShipDate,
                    POVM.PO.FreightCost, POVM.PO.Terms,
                    POVM.PO.Comments); //TODO: Associate the employeeID with this

                if (!validPO) {
                    ModelState.AddModelError("PO.PurchaseOrderId", "That PO already exists.");
                }
            }

            //CUSTOM VALIDATION ENDS

            if (!ModelState.IsValid) {
                return View(POVM);
            }
            else {
                
                //TODO: Move the character replacement logic to a
                //tools class and enhance its functionality

                return RedirectToAction("AddPOLineItem", new { id = convertedPO });
            }
        }

        /// <summary>
        /// Provides the form into which LineItems are entered for a particular PO
        /// (indicated by the id variable)
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="id">The PO ID for which information is displayed and entered</param>
        /// <returns>The AddPOLineItem View, supplemented with general PO information</returns>
        public ActionResult AddPOLineItem(int id = 0) {
            DataFetcherSetter db = new DataFetcherSetter();
            PurchaseOrderCreationViewModel POVM = new PurchaseOrderCreationViewModel();
            POVM.PO = db.RetrievePObyPOID(id);

            return View(POVM);
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
        public ActionResult AddPOLineItem(PurchaseOrderCreationViewModel POVM, string id) {
            DataFetcherSetter db = new DataFetcherSetter();

            //TODO: Move the character replacement logic to a
            //tools class and enhance its functionality
            string POtoInt = id;
            POtoInt = POtoInt.Replace("-", string.Empty);

            int convertedPO = Convert.ToInt32(POtoInt);

            foreach (var item in POVM.LineItems) {
                if(item.RecRPC != 0 && item.WholesaleCost != 0 && item.QtyOrdered != 0
                    && item.QtyTypeId != 0) //do not attempt to add empty list items
                        db.NewPOLineItemForPO(convertedPO, item.RecRPC, item.WholesaleCost,
                        item.QtyOrdered, item.QtyTypeId);
            }

            return RedirectToAction("POSummary", new { id = convertedPO });

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
        public ActionResult POSummary(int id = 0) {
            PurchaseOrderCreationViewModel POVM = new PurchaseOrderCreationViewModel();
            DataFetcherSetter db = new DataFetcherSetter();
            
            POVM.PO = db.RetrievePObyPOID(id);
            POVM.LineItems = db.ListLineItemsForPO(id);

            return View(POVM);
        }

        public ActionResult SearchPO() {
            DataFetcherSetter db = new DataFetcherSetter();


            return View();
        }

        [HttpPost]
        public ActionResult SearchPO(string queryType, string query) {


            return View();
        }



        //PURCHASE ORDER UTILITY METHODS FOLLOW

        public static string createPOForForm(int PO) {
            string POforForm;

            if (PO != 0) {
                //format for displaying in the form
                PO++; //increment the last number of the PO
                POforForm = PO.ToString();
                POforForm = POforForm.Insert(2, "-");
                POforForm = POforForm.Insert(5, "-");
                POforForm = POforForm.Insert(10, "-");

            }
            else {
                POforForm = DateTime.Now.Date.ToString("MM-dd-yyyy");
                POforForm = POforForm + "-01";
            }

            return POforForm;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Models.PurchaseOrder;

namespace RecOutletWarehouse.Controllers
{
    public class PurchaseOrderController : Controller
    {
        //
        // GET: /PurchaseOrder/

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult CreateNewPO() {

            return View();
        }

        [HttpPost]
        public ActionResult CreateNewPO(PurchaseOrder PO) {
            if (!ModelState.IsValid) {
                return View(PO);
            }
            else {
                DataFetcherSetter db = new DataFetcherSetter();
                
                //TODO: Move the character replacement logic to a
                //tools class and enhance its functionality
                string POtoInt = PO.PurchaseOrderId;
                POtoInt = POtoInt.Replace("-", string.Empty);

                int convertedPO = Convert.ToInt32(POtoInt);

                db.NewPurchaseOrder(convertedPO,
                    PO.VendorId, PO.CreatedBy,
                    PO.OrderDate, PO.EstShipDate,
                    PO.FreightCost, PO.Terms,
                    PO.Comments);


                return View("AddPOLineItem");
            }
        }

        public ActionResult AddPOLineItem() {

            return View();
        }

    }
}

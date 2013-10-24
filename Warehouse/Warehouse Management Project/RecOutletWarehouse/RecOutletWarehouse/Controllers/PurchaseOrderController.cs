using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult AddPOLineItem() {

            return View();
        }

    }
}

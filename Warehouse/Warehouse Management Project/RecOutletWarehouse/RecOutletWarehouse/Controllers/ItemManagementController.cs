using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Models.ItemManagement;


namespace RecOutletWarehouse.Controllers
{
    public class ItemManagementController : Controller
    {
        //
        // GET: /ItemMangement/

        public ActionResult CreateNewItem()
        {


            return View();
        }

        [HttpPost]
        public ActionResult CreateNewItem(AddItem item) {
            if (ModelState.IsValid) {

                RedirectToAction("Index", "Home");
            }

            return View(item);
        }

    }
}

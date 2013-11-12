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
           // DataFetcherSetter db = new DataFetcherSetter();
            //List<SubCategory> testList = db.SearchSubcategoriesByName("a");

            return View();
        }

        [HttpPost]
        public ActionResult CreateNewItem(Item item) {
            DataFetcherSetter db = new DataFetcherSetter();

            if (ModelState.IsValid) {
                string RPC = item.Department.ToString();
                RPC += item.Category.ToString();



                item.CreatedDate = DateTime.Now.Date;
                item.CreatedBy = 1; //TODO: Associate with logged-in user
                item.ItemId = 1; //TODO: Autogenerate
                item.TaxRate = 5; //TODO: A lot of things :)
                if (item.UPC == null)
                    item.UPC = 0; //TODO: Fix this
                if (item.restrictedAge == null)
                    item.restrictedAge = 0; //TODO: Fix this
                db.AddNewItem(item);
                RedirectToAction("Index", "Home");
            }

            return View(item);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Models.ItemManagement;
using RecOutletWarehouse.Utilities;


namespace RecOutletWarehouse.Controllers
{
    public class ItemManagementController : Controller
    {
        //
        // GET: /ItemMangement/

        public ActionResult CreateNewItem()
        {
            //DataFetcherSetter db = new DataFetcherSetter();
            //List<SubCategory> testList = db.SearchSubcategoriesByName("a");

            return View();
        }

        [HttpPost]
        public ActionResult CreateNewItem(Item item, string labelRedirect = "") {
            DataFetcherSetter db = new DataFetcherSetter();

            if (ModelState.IsValid) {

                item.CreatedDate = DateTime.Now.Date;
                item.CreatedBy = 1; //TODO: Associate with logged-in user   
                item.TaxRate = 5; //TODO: A lot of things :)
                if (item.UPC == null)
                    item.UPC = 0; //TODO: Fix this
                if (item.restrictedAge == null)
                    item.restrictedAge = 0; //TODO: Fix this
                item = db.ConvertNamesToIDs(item);
                item.ItemId = db.GetNextItemForDeptCatSubcat(Convert.ToByte(item.Department),
                                                            Convert.ToByte(item.Category),
                                                            Convert.ToInt16(item.Subcategory));
                item.RecRPC = WarehouseUtilities.GenerateRPC(item);
                db.AddNewItem(item);
                if (labelRedirect == "Create Item and Print Labels") {
                    return RedirectToAction("PrintLabels", new { id = item.RecRPC});
                }

                return RedirectToAction("Index", "Home");
            }

            return View(item);
        }

        public ActionResult PrintLabels(long? id) {
            ViewBag.RPC = id.ToString();
            return View();
        }

        [HttpPost]
        public ActionResult PrintLabels(LabelPrinting labelModel) {
            DataFetcherSetter db = new DataFetcherSetter();
            Item tempItem = new Item();
            if (!ModelState.IsValid) {
                return View(labelModel);
            }
            if (labelModel.RPC != "") {
                tempItem = db.GetItemForRPC(Convert.ToInt64(labelModel.RPC));
            }
            //TODO: add logic that will search for an item given a UPC or item info and NOT an RPC

            if (labelModel.LabelType == "RPC") {
                WarehouseUtilities.PrintRPCLabel(tempItem, labelModel.LabelQty);
            }

            if (labelModel.LabelType == "UPC") {
                //TODO: print a UPC label given labelModel's information
            }

            return View();
        }

    }
}

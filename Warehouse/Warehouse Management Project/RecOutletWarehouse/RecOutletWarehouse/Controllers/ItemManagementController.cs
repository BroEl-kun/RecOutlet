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

            item.CreatedDate = DateTime.Now.Date;
            item.CreatedBy = 1; //TODO: Associate with logged-in user   
            item.TaxRate = 5; //TODO: A lot of things :)
            if (item.UPC == null)
                item.UPC = 0; //TODO: Fix this
            if (item.restrictedAge == null)
                item.restrictedAge = 0; //TODO: Fix this
            item = db.ConvertNamesToIDs(item);

            //CUSTOM VALIDATION FOLLOWS
            //Check if Vendor exists or if too many vendors were returned
            if (item.Vendor == "0") {
                ModelState.AddModelError("Vendor", "That vendor doesn't exist.");
            }
            if (item.Vendor == "-1") {
                ModelState.AddModelError("Vendor", "Multiple vendors have that name.");
            }
            //Check if Product Line exists or if too many were returned
            if (item.ProductLine == "0") {
                ModelState.AddModelError("ProductLine", "That product line doesn't exist OR is not "
                                       + "associated with the specified vendor.");
            }
            if (item.ProductLine == "-1") {
                ModelState.AddModelError("ProductLine", "Multiple product lines have that name and vendor.");
            }

            //Check if Department exists or if too many were returned
            if (item.Department == "0") {
                ModelState.AddModelError("Department", "That department doesn't exist.");
            }
            if (item.Department == "-1") {
                ModelState.AddModelError("Department", "Multiple departments have that name.");
            }

            //Check if Category exists or if too many were returned
            if (item.Category == "0") {
                ModelState.AddModelError("Category", "That category doesn't exist.");
            }
            if (item.Category == "-1") {
                ModelState.AddModelError("Category", "Multiple categories have that name.");
            }

            //Check if Subcategory exists or if too many were returned
            if (item.Subcategory == "0") {
                ModelState.AddModelError("Subcategory", "That subcategory doesn't exist.");
            }
            if (item.Subcategory == "-1") {
                ModelState.AddModelError("Subcategory", "Multiple subcategories have that name.");
            }

            //CUSTOM VALIDATION ENDS

            item.ItemId = db.GetNextItemForDeptCatSubcat(Convert.ToByte(item.Department),
                                                        Convert.ToByte(item.Category),
                                                        Convert.ToInt16(item.Subcategory));
            item.RecRPC = WarehouseUtilities.GenerateRPC(item);

            if (ModelState.IsValid) {
                db.AddNewItem(item);
                ViewBag.ItemSuccessfulInsert = item.ItemName + "created with RPC " + item.RecRPC + ".";
                if (labelRedirect == "Create Item and Print Labels") {
                    return RedirectToAction("PrintLabels", new { id = item.RecRPC});
                }

                return View(new Item());
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

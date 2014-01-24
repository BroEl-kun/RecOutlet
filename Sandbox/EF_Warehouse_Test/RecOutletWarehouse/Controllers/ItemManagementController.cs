using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Models.ItemManagement;
using RecOutletWarehouse.Utilities;
using System.Data.Entity;


namespace RecOutletWarehouse.Controllers
{
    public class ItemManagementController : Controller
    {
        //
        // GET: /ItemMangement/

        private RecreationOutlet_Test1Context entityDb = new RecreationOutlet_Test1Context();

        public class ItemDeptCatSubcatViewModel {
            public ITEM_DEPARTMENT department { get; set; }
            public ITEM_CATEGORY category { get; set; }
            public ITEM_SUBCATEGORY subcat { get; set; }
        }

        public class ItemDeptCatSubcatCollectionViewModel
        {
            public List<ITEM_DEPARTMENT> department { get; set; }
            public List<ITEM_CATEGORY> category { get; set; }
            public List<ITEM_SUBCATEGORY> subcat { get; set; }
        }

        public ActionResult CreateNewItem()
        {
            //DataFetcherSetter db = new DataFetcherSetter();
            //List<SubCategory> testList = db.SearchSubcategoriesByName("a");

            return View();
        }

        [HttpPost]
        public ActionResult CreateNewItem(ITEM item, string labelRedirect = "") {
            DataFetcherSetter db = new DataFetcherSetter();

            item.ItemCreatedDate = DateTime.Now.Date;
            item.ItemCreatedBy = 1; //TODO: Associate with logged-in user   
            item.TAX_RATE.TaxRate = 5; //TODO: A lot of things :)

            if (item.ItemUPC == null)
                item.ItemUPC = 0; //TODO: Fix this
            if (item.RestrictedAge == null)
                item.RestrictedAge = 0; //TODO: Fix this

            //CUSTOM VALIDATION FOLLOWS
            //Check if Vendor exists or if too many vendors were returned
            if (item.PRODUCT_LINE.VendorID.ToString() == "0") {
                ModelState.AddModelError("Vendor", "That vendor doesn't exist.");
            }
            if (item.PRODUCT_LINE.VendorID.ToString() == "-1") {
                ModelState.AddModelError("Vendor", "Multiple vendors have that name.");
            }
            //Check if Product Line exists or if too many were returned
            if (item.PRODUCT_LINE.ProductLineID.ToString() == "0") {
                ModelState.AddModelError("ProductLine", "That product line doesn't exist OR is not "
                                       + "associated with the specified vendor.");
            }
            if (item.PRODUCT_LINE.ProductLineID.ToString() == "-1") {
                ModelState.AddModelError("ProductLine", "Multiple product lines have that name and vendor.");
            }

            //Check if Department exists or if too many were returned
            if (item.DepartmentID.ToString() == "0") {
                ModelState.AddModelError("Department", "That department doesn't exist.");
            }
            if (item.DepartmentID.ToString() == "-1") {
                ModelState.AddModelError("Department", "Multiple departments have that name.");
            }

            //Check if Category exists or if too many were returned
            if (item.CategoryID.ToString() == "0") {
                ModelState.AddModelError("Category", "That category doesn't exist.");
            }
            if (item.CategoryID.ToString() == "-1") {
                ModelState.AddModelError("Category", "Multiple categories have that name.");
            }

            //Check if Subcategory exists or if too many were returned
            if (item.SubcategoryID.ToString() == "0") {
                ModelState.AddModelError("Subcategory", "That subcategory doesn't exist.");
            }
            if (item.SubcategoryID.ToString() == "-1") {
                ModelState.AddModelError("Subcategory", "Multiple subcategories have that name.");
            }

            //CUSTOM VALIDATION ENDS

            //item.ItemId = db.GetNextItemForDeptCatSubcat(Convert.ToByte(item.Department),
            //                                            Convert.ToByte(item.Category),
            //                                            Convert.ToInt16(item.Subcategory));

            //item.RecRPC = WarehouseUtilities.GenerateRPC(item);

            item.RecRPC = 123456;

            if (ModelState.IsValid) {
                //db.AddNewItem(item);
                entityDb.ITEMs.Add(item);
                entityDb.SaveChanges();
                ViewBag.ItemSuccessfulInsert = item.Name + " " + item.RecRPC + ".";

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

        public ActionResult addNewDeptCatSubcat() {

            return View();
        }

        [HttpPost]
        public ActionResult addNewDeptCatSubcat(ItemDeptCatSubcatViewModel model, string submitButton) {
            //DataFetcherSetter db = new DataFetcherSetter();
            if (submitButton == "Department") {
                ViewBag.activeTab = "Department";
                //TODO: check for duplicates
                if (!ModelState.IsValid) {
                    return View(model);
                }
                //db.AddDepartment(model.department);
                entityDb.ITEM_DEPARTMENT.Add(model.department);
                entityDb.SaveChanges();

                ViewBag.deptSuccess = "Department \"" + model.department.DepartmentName + "\" successfully added.";

                return View(new ItemDeptCatSubcatViewModel());
            }

            if (submitButton == "Category") {
                ViewBag.activeTab = "Category";
                //TODO: check for duplicates
                if (!ModelState.IsValid) {
                    return View(model);
                }
                //db.AddCategory(model.category);
                entityDb.ITEM_CATEGORY.Add(model.category);
                entityDb.SaveChanges();

                ViewBag.catSuccess = "Category \"" + model.category.CategoryName + "\" successfully added.";

                return View(new ItemDeptCatSubcatViewModel());
            }

            if (submitButton == "Subcategory") {
                ViewBag.activeTab = "Subcategory";
                //TODO: check for duplicates
                if (!ModelState.IsValid) {
                    return View(model);
                }
                //db.AddSubcategory(model.subcat);
                entityDb.ITEM_SUBCATEGORY.Add(model.subcat);
                entityDb.SaveChanges();

                ViewBag.subcatSuccess = "Subcategory \"" + model.subcat.SubcategoryName + "\" successfully added.";

                return View(new ItemDeptCatSubcatViewModel());
            }

            else
                return View();
        }

        public ActionResult ViewItemDeptCatSubCat()
        {
            ItemDeptCatSubcatCollectionViewModel collection = new ItemDeptCatSubcatCollectionViewModel();
            collection.category = entityDb.ITEM_CATEGORY.ToList();
            collection.department = entityDb.ITEM_DEPARTMENT.ToList();
            collection.subcat = entityDb.ITEM_SUBCATEGORY.ToList();

            return View(collection);
        }

        public ActionResult ViewItems()
        {
            return View(entityDb.ITEMs.ToList());
        }
    }
}

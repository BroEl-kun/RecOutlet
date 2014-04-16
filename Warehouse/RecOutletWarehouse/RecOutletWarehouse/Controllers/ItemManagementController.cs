using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Utilities;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Controllers
{
    public class ItemManagementController : Controller
    {

        RecreationOutletContext entityDb = new RecreationOutletContext();
        public int BrowsePageSize = 25; // The number of results we want to show on each BrowseVendor page

        /// <summary>
        /// ViewModel that is used for creating a new department, category and/or subcategory
        /// </summary>
        public class newItemDeptCatSubcatViewModel
        {
            public ITEM_DEPARTMENT department { get; set; }
            public ITEM_CATEGORY category { get; set; }
            public ITEM_SUBCATEGORY subcat { get; set; }
        }

        /// <summary>
        /// ViewModel for Browsing/Editing all existing departments, categories and subcategories
        /// </summary>
        public class allItemDeptCatSubcatViewModel
        {
            public List<ITEM_DEPARTMENT> departments { get; set; }
            public List<ITEM_CATEGORY> categorys { get; set; }
            public List<ITEM_SUBCATEGORY> subcats { get; set; }
            public ITEM_CATEGORY cat { get; set; }
            public ITEM_SUBCATEGORY subcat { get; set; }
            public ITEM_DEPARTMENT dept { get; set; }
        }

        /// <summary>
        /// ViewModel for browsing/paging all existing Items
        /// </summary>
        public class BrowseItemViewModel
        {
            public IEnumerable<ITEM> Items { get; set; }
            public PagingInfo PagingInfo { get; set; }
            public string search { get; set; }
            public string startLetter { get; set; }
        }

        /// <summary>
        /// ViewModel for creation of a new item
        /// </summary>
        public class ItemCreationViewModel
        {
            [Required]
            public string VendorName { get; set; }
            public ITEM Item { get; set; }
        }

        /// <summary>
        /// Browse capabilites of all items. Gives the ability to search for and item. A rollodex
        /// is included. Also paging if item list is larger than 25.
        /// </summary>
        /// <param name="itemNameSearch">String for user to search by item's name</param>
        /// <param name="firstLetter">String one character for rollodex feature</param>
        /// <param name="page">Int page number</param>
        /// <returns>ActionResult BrowseItemManagement</returns>
        public ActionResult BrowseItemManagement(string itemNameSearch, string firstLetter, int page = 1)
        {
            try {
                // Declare model
                BrowseItemViewModel model;

                // Create master list
                var items = from i in entityDb.ITEMs
                            select i;

                // Filter master list to only those members that start with a certain letter
                // First letter is defined by rolodex selection in View
                // For now, we want it to only filter if there is no search query
                if (!String.IsNullOrEmpty(firstLetter) && String.IsNullOrEmpty(itemNameSearch)) {
                    items = items.Where(i => i.Name.ToUpper().StartsWith(firstLetter));
                }

                //IF the user doesn't provide a search query...
                if (String.IsNullOrEmpty(itemNameSearch)) {
                    model = new BrowseItemViewModel {
                        Items = items
                                  .OrderBy(i => i.Name)
                                  .Skip((page - 1) * BrowsePageSize)
                                  .Take(BrowsePageSize),
                        PagingInfo = new PagingInfo {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = items.Count() // Get the count of the FILTERED list
                        },
                        startLetter = firstLetter // The starting letter needs to be passed to the View
                        // so the View can pass it back to the Controller.
                        // If not included, pagination will not work correctly.
                    };
                }
                // ELSE (the user did provide a vendor name search query)
                else {
                    model = new BrowseItemViewModel {
                        Items = items
                                  .Where(ve => ve.Name.ToUpper().Contains(itemNameSearch.ToUpper())) // Further filter the list to items that contain the search
                                  .OrderBy(v => v.Name) // This is likely unnecessary (already sorted), but I'm leaving it here for now
                                  .Skip((page - 1) * BrowsePageSize)
                                  .Take(BrowsePageSize),
                        PagingInfo = new PagingInfo {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = items.Where(ve => ve.Name.ToUpper().Contains(itemNameSearch.ToUpper())).Count() // Again, we want the count to take our filters into account
                        },
                        search = itemNameSearch
                        //startLetter = firstLetter // Leaving out -- it gives results the user might not expect
                    };
                }
                return View(model);
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// GET Method for editing a vendor
        /// </summary>
        /// <param name="id">The VendorID of the vendor to edit</param>
        /// <returns>The EditVendor View, prefilled with the vendor information.</returns>
        public ActionResult EditItem(int id = 0)
        {
            try
            {
                ITEM item = entityDb.ITEMs.Find(id);

                if (item == null)
                {
                    return HttpNotFound();
                }

                return View(item);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// POST method for editing an Item
        /// </summary>
        /// <param name="vendor">The item model that has been modified</param>
        /// <returns>ActionResult EditItem</returns>
        [HttpPost]
        public ActionResult EditItem(ITEM item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entityDb.Entry(item).State = EntityState.Modified;
                    entityDb.SaveChanges();

                    return RedirectToAction("BrowseItemManagement");
                }

                return View(item);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Empty form to creating a new item
        /// </summary>
        /// <returns>ActionResult CreatenewItem</returns>
        public ActionResult CreateNewItem()
        {
            try
            {
                //DataFetcherSetter db = new DataFetcherSetter();
                //List<SubCategory> testList = db.SearchSubcategoriesByName("a");

                ViewBag.Array = entityDb.ITEMs.Select(x => x.RecRPC).ToList();

                return View();
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// POST method for creating a new item
        /// </summary>
        /// <param name="model">ItemCreationViewModel</param>
        /// <param name="labelRedirect">String to see if user wants to proceed to printing labels</param>
        /// <returns>ActionReslut CreateNewItem</returns>
        [HttpPost]
        public ActionResult CreateNewItem(ItemCreationViewModel model, string labelRedirect = "")
        {
            try
            {
                ITEM item = model.Item;
                item.TaxTypeID = 1; //TODO: A lot of things :)
                //item = db.ConvertNamesToIDs(item);

                item.PRODUCT_LINE = entityDb.PRODUCT_LINE.Single(x => x.ProductLineName == model.Item.PRODUCT_LINE.ProductLineName);
                item.ProductLineID = item.PRODUCT_LINE.ProductLineID;
                item.ITEM_DEPARTMENT = entityDb.ITEM_DEPARTMENT.Single(x => x.DepartmentName == model.Item.ITEM_DEPARTMENT.DepartmentName);
                item.DepartmentID = item.ITEM_DEPARTMENT.DepartmentID;
                item.ITEM_CATEGORY = entityDb.ITEM_CATEGORY.Single(x => x.CategoryName == model.Item.ITEM_CATEGORY.CategoryName);
                item.CategoryID = item.ITEM_CATEGORY.CategoryID;
                item.ITEM_SUBCATEGORY = entityDb.ITEM_SUBCATEGORY.Single(x => x.SubcategoryName == model.Item.ITEM_SUBCATEGORY.SubcategoryName);
                item.SubcategoryID = item.ITEM_SUBCATEGORY.SubcategoryID;

                item.ItemCreatedDate = DateTime.Now.Date;
                item.ItemCreatedBy = 1;

                if (item.ItemUPC == null) {
                    item.ItemUPC = 0; //TODO: Fix this
                }
                if (item.RestrictedAge == null) {
                    item.RestrictedAge = 0; //TODO: Fix this
                }

                //check if a product line exists if it does do nothing if it doesnt then let them enter a new product line.
                if (!entityDb.PRODUCT_LINE.Any(i => i.ProductLineID == item.ProductLineID)) {
                    // no match
                    ModelState.AddModelError("ProductLine", "That product line doesn't exist OR is not "
                                           + "associated with the specified vendor.");
                }

                //check if a department exists if it does do nothing if it doesnt then...
                if (!entityDb.ITEM_DEPARTMENT.Any(i => i.DepartmentID == item.DepartmentID)) {
                    // no match
                    ModelState.AddModelError("Department", "That department doesn't exist.");
                }

                //check if a catagory exists if it does do nothing if it doesnt then...
                if (!entityDb.ITEM_CATEGORY.Any(i => i.CategoryID == item.CategoryID)) {
                    // no match
                    ModelState.AddModelError("Category", "That category doesn't exist.");
                }

                //check if a subcatagory exists if it does do nothing if it doesnt then let them...
                if (!entityDb.ITEM_SUBCATEGORY.Any(i => i.SubcategoryID == item.SubcategoryID)) {
                    // no match
                    ModelState.AddModelError("Subcategory", "That subcategory doesn't exist.");
                }

                var query = (from e in entityDb.ITEMs
                             where e.DepartmentID == item.DepartmentID &&
                             e.CategoryID == item.CategoryID &&
                             e.SubcategoryID == item.SubcategoryID
                             select (int?)e.ItemID).Max();

                //add one to the item id so its not the same
                item.ItemID = Convert.ToInt32(query) + 1;


                item.RecRPC = WarehouseUtilities.GenerateRPC(item);

                if (ModelState.IsValid) {
                    entityDb.ITEMs.Add(item);
                    entityDb.SaveChanges();
                    ViewBag.ItemSuccessfulInsert = item.Name + " " + item.RecRPC + ".";
                    if (labelRedirect == "Create Item and Print Labels") {
                        return RedirectToAction("PrintLabels", new { id = item.RecRPC });
                    }

                    return View(new ItemCreationViewModel());
                }

                return View(model);
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Prints labels for an item
        /// </summary>
        /// <param name="id">Nullable long RecRPC</param>
        /// <returns>ActionResult PrintLabels</returns>
        public ActionResult PrintLabels(long? id)
        {
            try
            {
                ViewBag.RPC = id.ToString();
                return View();
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// POST method for printing labels
        /// </summary>
        /// <param name="labelModel">LabelPrinting model</param>
        /// <returns>ActionResult PrintLables</returns>
        [HttpPost]
        public ActionResult PrintLabels(LabelPrinting labelModel)
        {
            try
            {
                ITEM tempItem = new ITEM();
                if (!ModelState.IsValid)
                {
                    return View(labelModel);
                }
                if (labelModel.RPC != 0)
                {
                    tempItem = entityDb.ITEMs.Single(x => x.RecRPC == labelModel.RPC);
                }
                //TODO: add logic that will search for an item given a UPC or item info and NOT an RPC

                if (labelModel.LabelType == "RPC")
                {
                    WarehouseUtilities.PrintRPCLabel(tempItem, labelModel.LabelQty);
                }

                if (labelModel.LabelType == "UPC")
                {
                    //TODO: print a UPC label given labelModel's information
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
        /// Form for creating a new Deptartment, Category or Subcategory
        /// </summary>
        /// <returns>ActionResult addNewDeptCatSubcat</returns>
        public ActionResult addNewDeptCatSubcat()
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
        /// POST method for creating a new Deptartment, Category or Subcategory
        /// </summary>
        /// <param name="model">newItemDeptCatSubcatViewModel</param>
        /// <param name="submitButton">String to specify which item characteristic the user wants to create</param>
        /// <returns>ActionResult addNewDeptCatSubcat</returns>
        [HttpPost]
        public ActionResult addNewDeptCatSubcat(newItemDeptCatSubcatViewModel model, string submitButton)
        {
            try
            {
                if (submitButton == "Department")
                {
                    ViewBag.activeTab = "Department";
                    //TODO: check for duplicates
                    if (!ModelState.IsValid)
                    {
                        return View(model);
                    }
                    //db.AddDepartment(model.department);
                    entityDb.ITEM_DEPARTMENT.Add(model.department);
                    entityDb.SaveChanges();

                    ViewBag.deptSuccess = "Department \"" + model.department.DepartmentName + "\" successfully added.";

                    return View(new newItemDeptCatSubcatViewModel());
                }

                if (submitButton == "Category")
                {
                    ViewBag.activeTab = "Category";
                    //TODO: check for duplicates
                    if (!ModelState.IsValid)
                    {
                        return View(model);
                    }
                    //db.AddCategory(model.category);
                    entityDb.ITEM_CATEGORY.Add(model.category);
                    entityDb.SaveChanges();

                    ViewBag.catSuccess = "Category \"" + model.category.CategoryName + "\" successfully added.";

                    return View(new newItemDeptCatSubcatViewModel());
                }

                if (submitButton == "Subcategory")
                {
                    ViewBag.activeTab = "Subcategory";
                    //TODO: check for duplicates
                    if (!ModelState.IsValid)
                    {
                        return View(model);
                    }
                    //db.AddSubcategory(model.subcat);

                    entityDb.ITEM_SUBCATEGORY.Add(model.subcat);
                    entityDb.SaveChanges();

                    ViewBag.subcatSuccess = "Subcategory \"" + model.subcat.SubcategoryName + "\" successfully added.";

                    return View(new newItemDeptCatSubcatViewModel());
                }

                else
                    return View();
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// View/Browse/Edit all existing Deptartments, Categories or Subcategories
        /// </summary>
        /// <returns>ActionResult ItemCharacteristics</returns>
        public ActionResult ItemCharacteristics()
        {
            try
            {
                allItemDeptCatSubcatViewModel model = new allItemDeptCatSubcatViewModel();

                model.categorys = entityDb.ITEM_CATEGORY.ToList();
                model.departments = entityDb.ITEM_DEPARTMENT.ToList();
                model.subcats = entityDb.ITEM_SUBCATEGORY.ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Select an existing Deptartment, Category or Subcategory for editing
        /// </summary>
        /// <param name="idcsvm">allItemDeptCatSubcatViewModel</param>
        /// <param name="editButton">String for selecting specific characteristic</param>
        /// <returns>ActionResult ItemCharacteristics</returns>
        [HttpPost]
        public ActionResult ItemCharacteristics(allItemDeptCatSubcatViewModel idcsvm, string editButton)
        {
            try
            {
                //newItemDeptCatSubcatViewModel model = new newItemDeptCatSubcatViewModel();
                //ViewBag.editButton = editButton;

                int newID = 0;
                string newEditButton = editButton;

                if (editButton == "category")
                {
                    newID = idcsvm.cat.CategoryID;
                }
                else if (editButton == "subcategory")
                {
                    newID = idcsvm.subcat.SubcategoryID;
                }
                else if (editButton == "department")
                {
                    newID = idcsvm.dept.DepartmentID;
                }

                return RedirectToAction("EditItemCharacteristics", new { id = newID, editButton = newEditButton});

            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Edit an existing Deptartment, Category or Subcategory
        /// </summary>
        /// <param name="id">ID of the item characterisitc</param>
        /// <param name="editButton">String for selecting specific characteristic</param>
        /// <returns>ActionResult EditItemCharacteristics</returns>
        public ActionResult EditItemCharacteristics(int id, string editButton)
        {
            try
            {
                newItemDeptCatSubcatViewModel model = new newItemDeptCatSubcatViewModel();
                ViewBag.editButton = editButton;

                if (editButton == "category")
                {
                    model.category = entityDb.ITEM_CATEGORY.SingleOrDefault(x => x.CategoryID == id);
                }
                else if (editButton == "subcategory")
                {
                    model.subcat = entityDb.ITEM_SUBCATEGORY.SingleOrDefault(x => x.SubcategoryID == id);
                }
                else if (editButton == "department")
                {
                    model.department = entityDb.ITEM_DEPARTMENT.SingleOrDefault(x => x.DepartmentID == id);
                }

                return View(model);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// POST for modifing an existing Deptartment, Category or Subcategory
        /// </summary>
        /// <param name="model">newItemDeptCatSubcatViewModel</param>
        /// <param name="editButton">String for selecting specific characteristic</param>
        /// <returns>ActionResult ItemCharacteristics</returns>
        [HttpPost]
        public ActionResult EditItemCharacteristics(newItemDeptCatSubcatViewModel model, String editButton)
        {
            try
            {
                if (editButton == "category")
                {
                    entityDb.Entry(model.category).State = EntityState.Modified;
                    entityDb.SaveChanges();
                }
                else if (editButton == "subcategory")
                {
                    entityDb.Entry(model.subcat).State = EntityState.Modified;
                    entityDb.SaveChanges();
                }
                else if (editButton == "department")
                {
                    entityDb.Entry(model.department).State = EntityState.Modified;
                    entityDb.SaveChanges();
                }

                return RedirectToAction("ItemCharacteristics", "ItemManagement");
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Update an existing Deptartment, Category or Subcategory
        /// </summary>
        /// <param name="model">allItemDeptCatSubcatViewModel</param>
        /// <param name="editButton">String for selecting specific characteristic</param>
        /// <returns>ActionResult UpdateItemCharacteristics</returns>
        [HttpPost]
        public ActionResult UpdateItemCharacteristics(allItemDeptCatSubcatViewModel model, String editButton)
        {
            try
            {
                if (editButton == "category")
                {
                    entityDb.Entry(model.cat).State = EntityState.Modified;
                    entityDb.SaveChanges();
                }
                else if (editButton == "subcategory")
                {
                    entityDb.Entry(model.subcat).State = EntityState.Modified;
                    entityDb.SaveChanges();
                }
                else if (editButton == "department")
                {
                    entityDb.Entry(model.dept).State = EntityState.Modified;
                    entityDb.SaveChanges();
                }

                return RedirectToAction("ItemCharacteristics", "ItemManagement");
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Generates the next Item ID available
        /// </summary>
        /// <param name="dept">Deptartment ID</param>
        /// <param name="cat">Category</param>
        /// <param name="subcat">Subcategory ID</param>
        /// <returns>JsonResult of the next Item ID</returns>
        public JsonResult getNextItemID(byte dept, int cat, int subcat)
        {
            try {
                var maxItemID = (from e in entityDb.ITEMs
                                where e.DepartmentID == dept &&
                                e.CategoryID == cat &&
                                e.SubcategoryID == subcat
                                select (int?)e.ItemID).Max();

                var nextItemID = Convert.ToInt32(maxItemID) + 1;
                var jsonData = new { nextItemID };

                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

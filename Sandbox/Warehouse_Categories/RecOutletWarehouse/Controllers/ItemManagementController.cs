﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Models.ItemManagement;
using RecOutletWarehouse.Utilities;
using System.Data.Entity;
using System.Data.Entity.Validation;


namespace RecOutletWarehouse.Controllers
{
    public class ItemManagementController : Controller
    {
        //
        // GET: /ItemMangement/

        private RecreationOutletContext db = new RecreationOutletContext();
        private DataFetcherSetter dfs = new DataFetcherSetter();

        public class ItemDeptCatSubcatViewModel {
            public Department department { get; set; }
            public Category category { get; set; }
            public SubCategory subcat { get; set; }
        }

        public class ItemCategoryViewModel
        {
            //public Category category { get; set; }
            //public SubCategory subcat { get; set; }

            public IEnumerable<ITEM_CATEGORY> Categories { get; set; }
            public PagingInfo PagingInfo { get; set; }
            public string search { get; set; }
            public string startLetter { get; set; }
        }

        public ActionResult CreateNewItem()
        {
            try
            {
                //DataFetcherSetter db = new DataFetcherSetter();
                //List<SubCategory> testList = db.SearchSubcategoriesByName("a");

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public ActionResult CreateNewItem(Item item, string labelRedirect = "")
        {
            try
            {
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
                if (item.Vendor == "0")
                {
                    ModelState.AddModelError("Vendor", "That vendor doesn't exist.");
                }
                if (item.Vendor == "-1")
                {
                    ModelState.AddModelError("Vendor", "Multiple vendors have that name.");
                }
                //Check if Product Line exists or if too many were returned
                if (item.ProductLine == "0")
                {
                    ModelState.AddModelError("ProductLine", "That product line doesn't exist OR is not "
                                           + "associated with the specified vendor.");
                }
                if (item.ProductLine == "-1")
                {
                    ModelState.AddModelError("ProductLine", "Multiple product lines have that name and vendor.");
                }

                //Check if Department exists or if too many were returned
                if (item.Department == "0")
                {
                    ModelState.AddModelError("Department", "That department doesn't exist.");
                }
                if (item.Department == "-1")
                {
                    ModelState.AddModelError("Department", "Multiple departments have that name.");
                }

                //Check if Category exists or if too many were returned
                if (item.Category == "0")
                {
                    ModelState.AddModelError("Category", "That category doesn't exist.");
                }
                if (item.Category == "-1")
                {
                    ModelState.AddModelError("Category", "Multiple categories have that name.");
                }

                //Check if Subcategory exists or if too many were returned
                if (item.Subcategory == "0")
                {
                    ModelState.AddModelError("Subcategory", "That subcategory doesn't exist.");
                }
                if (item.Subcategory == "-1")
                {
                    ModelState.AddModelError("Subcategory", "Multiple subcategories have that name.");
                }

                //CUSTOM VALIDATION ENDS

                item.ItemId = db.GetNextItemForDeptCatSubcat(Convert.ToByte(item.Department),
                                                            Convert.ToByte(item.Category),
                                                            Convert.ToInt16(item.Subcategory));
                item.RecRPC = WarehouseUtilities.GenerateRPC(item);

                if (ModelState.IsValid)
                {
                    db.AddNewItem(item);
                    ViewBag.ItemSuccessfulInsert = item.ItemName + " " + item.RecRPC + ".";
                    if (labelRedirect == "Create Item and Print Labels")
                    {
                        return RedirectToAction("PrintLabels", new { id = item.RecRPC });
                    }

                    return View(new Item());
                }

                return View(item);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult PrintLabels(long? id)
        {
            try
            {
                ViewBag.RPC = id.ToString();
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public ActionResult PrintLabels(LabelPrinting labelModel)
        {
            try
            {
                DataFetcherSetter db = new DataFetcherSetter();
                Item tempItem = new Item();
                if (!ModelState.IsValid)
                {
                    return View(labelModel);
                }
                if (labelModel.RPC != "")
                {
                    tempItem = db.GetItemForRPC(Convert.ToInt64(labelModel.RPC));
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
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult addNewDeptCatSubcat()
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

        [HttpPost]
        public ActionResult addNewDeptCatSubcat(ItemDeptCatSubcatViewModel model, string submitButton)
        {
            try
            {
                DataFetcherSetter db = new DataFetcherSetter();
                if (submitButton == "Department")
                {
                    ViewBag.activeTab = "Department";
                    //TODO: check for duplicates
                    if (!ModelState.IsValid)
                    {
                        return View(model);
                    }
                    db.AddDepartment(model.department);
                    ViewBag.deptSuccess = "Department \"" + model.department.DepartmentName + "\" successfully added.";

                    return View(new ItemDeptCatSubcatViewModel());
                }

                if (submitButton == "Category")
                {
                    ViewBag.activeTab = "Category";
                    //TODO: check for duplicates
                    if (!ModelState.IsValid)
                    {
                        return View(model);
                    }
                    db.AddCategory(model.category);
                    ViewBag.catSuccess = "Category \"" + model.category.CategoryName + "\" successfully added.";

                    return View(new ItemDeptCatSubcatViewModel());
                }

                if (submitButton == "Subcategory")
                {
                    ViewBag.activeTab = "Subcategory";
                    //TODO: check for duplicates
                    if (!ModelState.IsValid)
                    {
                        return View(model);
                    }
                    db.AddSubcategory(model.subcat);
                    ViewBag.subcatSuccess = "Subcategory \"" + model.subcat.SubcategoryName + "\" successfully added.";

                    return View(new ItemDeptCatSubcatViewModel());
                }

                else
                    return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }


        public ActionResult BrowseEditCategory(long? id)
        {
            try
            {
                ItemCategoryViewModel model = new ItemCategoryViewModel();

                model.Categories = db.ITEM_CATEGORY.ToList();

                ViewBag.RPC = id.ToString();
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public ActionResult BrowseEditCategory()
        {
            try
            {
                //RecreationOutletContext db = new RecreationOutletContext();
                //DataFetcherSetter dfs = new DataFetcherSetter();

                // Declare model
                ItemCategoryViewModel model;

                // Create master list
                var categories = from c in db.ITEM_CATEGORY
                                 select c;

                model = new ItemCategoryViewModel
                {
                    Categories = categories
                              .OrderBy(c => c.CategoryID)
                              .Skip((1 - 1) * 100)
                              .Take(100),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = 0,
                        ItemsPerPage = 100,
                        TotalItems = categories.Count() // Get the count of the FILTERED list
                    },
                    //startLetter = ""
                };
                return View(model);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }


        public ActionResult EditCategory(int id = 0)
        {
            ITEM_CATEGORY category = db.ITEM_CATEGORY.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(ITEM_CATEGORY category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BrowseEditCategory");
            }

            return View(category);
        }
    }
}

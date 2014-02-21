using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Models.ItemManagement;
using RecOutletWarehouse.Utilities;


// TODO:
// When the page loads, pull in all category data.
// Give the option through means of a button that allows the user to dynamically edit the entry.
// To reduce clutter, make the button only appear if the user is hovering over it.
// DOABLE?


namespace RecOutletWarehouse.Controllers
{
    public class ItemCategoryController : Controller
    {
        //
        // GET: /CategoryMangement/

        public class ItemCategoryViewModel
        {
            public Category category { get; set; }
            public SubCategory subcat { get; set; }
        }


        public ActionResult RenameCategory()
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
        public ActionResult RenameCategory(ItemCategoryViewModel model, int categoryID, string newName)
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
        public ActionResult addNewDeptCatSubcat(ItemCategoryViewModel model, string submitButton)
        {
            try
            {
                DataFetcherSetter db = new DataFetcherSetter();

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

                    return View(new ItemCategoryViewModel());
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

                    return View(new ItemCategoryViewModel());
                }

                else
                    return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}

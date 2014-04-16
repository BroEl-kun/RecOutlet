using RecOutletWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RecOutletWarehouse.Controllers
{
    //***************************************************************************
    // All ApiControllers are for jQuery AutoComplete or other dynamic Ajax calls
    // made from the Views
    //***************************************************************************

    /// <summary>
    /// Autocomplete ApiController Class for the VENDOR model
    /// </summary>
    public class VendorApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<VENDOR> GetVendors(string query = "")
        {
            using (var db = new RecreationOutletContext()) {
                return String.IsNullOrEmpty(query) ? db.VENDORs.ToList() :
                db.VENDORs.Where(p => p.VendorName.Contains(query)).ToList();
            }
        }
    }

    /// <summary>
    /// Autocomplete ApiController Class for the PRODUCT_LINE model
    /// </summary>
    public class ProductLineApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<PRODUCT_LINE> GetProductLines(string query = "")
        {
            using (var db = new RecreationOutletContext()) {
                return String.IsNullOrEmpty(query) ? db.PRODUCT_LINE.ToList() :
                db.PRODUCT_LINE.Where(p => p.ProductLineName.Contains(query)).ToList();
            }
        }
    }

    /// <summary>
    /// Autocomplete ApiController Class for the ITEM_DEPARTMENT model
    /// </summary>
    public class DepartmentApiController : ApiController
    {

        [HttpGet]
        public IEnumerable<ITEM_DEPARTMENT> GetDepartments(string query = "")
        {
            using (var db = new RecreationOutletContext())
            {
                return String.IsNullOrEmpty(query) ? db.ITEM_DEPARTMENT.ToList() :
                db.ITEM_DEPARTMENT.Where(p => p.DepartmentName.Contains(query)).ToList();
            }
        }
    }

    /// <summary>
    /// Autocomplete ApiController Class for the ITEM_CATEGORY model
    /// </summary>
    public class CategoryApiController : ApiController
    {

        [HttpGet]
        public IEnumerable<ITEM_CATEGORY> GetCategories(string query = "")
        {
            using (var db = new RecreationOutletContext())
            {
                return String.IsNullOrEmpty(query) ? db.ITEM_CATEGORY.ToList() :
                db.ITEM_CATEGORY.Where(x => x.CategoryName.Contains(query)).ToList();
            }
        }
    }

    /// <summary>
    /// Autocomplete ApiController Class for the ITEM_SUBCATEGORY model
    /// </summary>
    public class SubcategoryApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<ITEM_SUBCATEGORY> GetSubcategories(string query = "")
        {
            using (var db = new RecreationOutletContext())
            {
                return String.IsNullOrEmpty(query) ? db.ITEM_SUBCATEGORY.ToList() :
                db.ITEM_SUBCATEGORY.Where(x => x.SubcategoryName.Contains(query)).ToList();
            }
        }
    }

    /// <summary>
    /// Autocomplete ApiController Class for the SALES_REP model
    /// </summary>
    public class SalesRepApiController : ApiController {
        [HttpGet]
        public IEnumerable<SALES_REP> GetSalesReps(string query = "") {
            using (var db = new RecreationOutletContext()) {
                return String.IsNullOrEmpty(query) ? db.SALES_REPs.ToList() :
                db.SALES_REPs.Where(p => p.SalesRepFirstName.Contains(query) ||
                    p.SalesRepLastName.Contains(query))
                .ToList();
            }
        }
    }

    /// <summary>
    /// Autocomplete ApiController Class for the ITEM model
    /// </summary>
    public class ItemApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<ITEM> GetItems(string query = "")
        {
            using (var db = new RecreationOutletContext()) {
                return String.IsNullOrEmpty(query) ? db.ITEMs.ToList() :
                    db.ITEMs.Where(i => i.Name.Contains(query)).ToList();
            }
        }
    }

    /// <summary>
    /// Autocomplete ApiController Class for the EVENT_TYPE model
    /// </summary>
    public class EventTypeApiController : ApiController {
        [HttpGet]
        public IEnumerable<EVENT_TYPE> GetEventType(string query = "") {
            using (var db = new RecreationOutletContext()) {
                return String.IsNullOrEmpty(query) ? db.EVENT_TYPE.ToList() :
                db.EVENT_TYPE.Where(p => p.EventDescription.Contains(query)).ToList();
            }
        }
    }

    /// <summary>
    /// Autocomplete ApiController Class for the ITEM_CATEGORY model (POTENTIAL DUPLICATE)
    /// </summary>
    public class SearchCategoryApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<ITEM_CATEGORY> GetCategories(string query = "")
        {
            using (var db = new RecreationOutletContext())
            {
                return String.IsNullOrEmpty(query) ? db.ITEM_CATEGORY.ToList() :
                db.ITEM_CATEGORY.Where(x => x.CategoryName.Contains(query)).ToList();
            }
        }
    }
}
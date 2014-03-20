using RecOutletWarehouse.Models;
using RecOutletWarehouse.Models.VendorManagement;
using RecOutletWarehouse.Models.ItemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecOutletWarehouse.Controllers
{
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

    public class ProductLineApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<ProductLine> GetProductLines(string query = "")
        {
            DataFetcherSetter db = new DataFetcherSetter();
            List<ProductLine> productLines = db.SearchProductLinesByName(query);
            return productLines;
        }
    }

    public class DepartmentApiController : ApiController
    {
        //[HttpGet]
        //public IEnumerable<Department> GetDepartments(string query = "")
        //{
        //    DataFetcherSetter db = new DataFetcherSetter();
        //    return db.SearchDepartmentsByName(query);
        //}
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

    public class CategoryApiController : ApiController
    {
        //[HttpGet]
        //public IEnumerable<Category> GetCategories(string query = "")
        //{
        //    DataFetcherSetter db = new DataFetcherSetter();
        //    return db.SearchCategoriesByName(query);
        //}
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

    public class SubcategoryApiController : ApiController
    {
        //[HttpGet]
        //public IEnumerable<SubCategory> GetSubcategories(string query = "")
        //{
        //    DataFetcherSetter db = new DataFetcherSetter();
        //    return db.SearchSubcategoriesByName(query);
        //}
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

    public class ItemApiController : ApiController
    {
        [HttpGet]
        public IEnumerable<Item> GetItems(string query = "")
        {
            DataFetcherSetter db = new DataFetcherSetter();
            return db.SearchItemsByName(query);
        }
    }

    public class EventTypeApiController : ApiController {
        [HttpGet]
        public IEnumerable<EVENT_TYPE> GetEventType(string query = "") {
            using (var db = new RecreationOutletContext()) {
                return String.IsNullOrEmpty(query) ? db.EVENT_TYPE.ToList() :
                db.EVENT_TYPE.Where(p => p.EventDescription.Contains(query)).ToList();
            }
        }
    }

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
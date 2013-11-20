﻿using RecOutletWarehouse.Models;
using RecOutletWarehouse.Models.VendorManagement;
using RecOutletWarehouse.Models.ItemManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecOutletWarehouse.Controllers {
    public class VendorApiController : ApiController {

        [HttpGet]
        public IEnumerable<Vendor> GetVendors(string query = "") {
            DataFetcherSetter db = new DataFetcherSetter();
            List<Vendor> vendors = db.SearchVendorByName(query);
            return vendors;
        }
    }

    public class ProductLineApiController : ApiController {

        [HttpGet]
        public IEnumerable<ProductLine> GetProductLines(string query = "") {
            DataFetcherSetter db = new DataFetcherSetter();
            List<ProductLine> productLines = db.SearchProductLinesByName(query);
            return productLines;
        }
    }

    public class DepartmentApiController : ApiController {
        [HttpGet]
        public IEnumerable<Department> GetDepartments(string query = "") {
            DataFetcherSetter db = new DataFetcherSetter();
            return db.SearchDepartmentsByName(query);
        }
    }

    public class CategoryApiController : ApiController {
        [HttpGet]
        public IEnumerable<Category> GetCategories(string query = "") {
            DataFetcherSetter db = new DataFetcherSetter();
            return db.SearchCategoriesByName(query);
        }
    }

    public class SubcategoryApiController : ApiController {
        [HttpGet]
        public IEnumerable<SubCategory> GetSubcategories(string query = "") {
            DataFetcherSetter db = new DataFetcherSetter();
            return db.SearchSubcategoriesByName(query);
        }
    }

    public class SalesRepApiController : ApiController {

        [HttpGet]
        public IEnumerable<SalesRep> GetSalesReps(string query = "") {
            DataFetcherSetter db = new DataFetcherSetter();
            return db.SearchRepsByName(query);
        }
    }
}
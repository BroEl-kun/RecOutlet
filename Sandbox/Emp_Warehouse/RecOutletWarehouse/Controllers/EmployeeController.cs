using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Utilities;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Controllers
{
    public class EmployeeController : Controller
    {
        private RecreationOutletContext db = new RecreationOutletContext();
        public int BrowsePageSize = 25; // The number of results we want to show on each BrowseVendor page


        public class BrowseEmployeeViewModel
        {
            public IEnumerable<EMPLOYEE> Employee { get; set; }
            public PagingInfo PagingInfo { get; set; }
            public string search { get; set; }
            public string startLetter { get; set; }
        }
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BrowseEmployee(string empNameSearch, string firstLetter, int page = 1) 
        {
            try
            {
                BrowseEmployeeViewModel model;
           
                var employee = from e in db.EMPLOYEEs
                               select e;

                if (!String.IsNullOrEmpty(firstLetter) && String.IsNullOrEmpty(empNameSearch))
                {
                    employee = employee.Where(e => e.LastName.ToUpper().StartsWith(firstLetter));
                }

                if (String.IsNullOrEmpty(empNameSearch))
                {

                    model = new BrowseEmployeeViewModel
                    {
                        Employee = employee
                            .OrderBy(e => e.LastName)
                            .Skip((page - 1) * BrowsePageSize)
                            .Take(BrowsePageSize),
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = employee.Count()
                        },
                        startLetter = firstLetter

                    };

                }
                else
                {
                    model = new BrowseEmployeeViewModel
                    {
                        Employee = employee
                            .Where(e => e.LastName.ToUpper().Contains(empNameSearch.ToUpper()) || e.FirstName.ToUpper().Contains(empNameSearch.ToUpper()))
                            .OrderBy(em => em.LastName)
                            .Skip((page - 1) * BrowsePageSize)
                            .Take(BrowsePageSize),
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = employee.Where(e => e.LastName.ToUpper().Contains(empNameSearch.ToUpper()) || e.FirstName.ToUpper().Contains(empNameSearch.ToUpper())).Count()
                        },
                        search = empNameSearch
                    };
                                    
                }

            
            
                    return View(model);
            }
            catch (Exception ex) {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult EditEmployee(int id = 0)
        {
            EMPLOYEE emp = new EMPLOYEE();
            emp = db.EMPLOYEEs.Find(id);

            if (emp == null) {
                return HttpNotFound();
            }
            return View(emp);
        }

         [HttpPost]
        public ActionResult EditEmployee(EMPLOYEE emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("BrowseEmployee");
                }

                return View(emp);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }

            
        }


    }
}

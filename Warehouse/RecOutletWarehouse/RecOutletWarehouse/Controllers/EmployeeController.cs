<<<<<<< .mine
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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

        //public class ConfirmPINViewModel
        //{
        //    public EMPLOYEE employee { get; set; }

        //    [DataType(DataType.Password)]
        //    [StringLength(4, MinimumLength = 4)]
        //    public string NewPIN { get; set; }

        //    [DataType(DataType.Password)]
        //    [StringLength(4, MinimumLength = 4)]
        //    public string ConfirmPIN { get; set; }
        //}

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
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult EditEmployee(int id = 0)
        {
            try
            {
                var crypto = new SimpleCrypto.PBKDF2();

                EMPLOYEE emp = new EMPLOYEE();
                emp = db.EMPLOYEEs.Find(id);



                if (emp == null)
                {
                    return HttpNotFound();
                }
                return View(emp);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public ActionResult EditEmployee(EMPLOYEE emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrpPass = crypto.Compute(emp.Password);

                    emp.Password = encrpPass;
                    emp.PasswordSalt = crypto.Salt;

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

        public ActionResult CreateEmployee()
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

        [HttpPost]
        public ActionResult CreateEmployee(EMPLOYEE emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrpPass = crypto.Compute(emp.Password);

                    emp.Password = encrpPass;
                    emp.PasswordSalt = crypto.Salt;


                    db.EMPLOYEEs.Add(emp);
                    db.SaveChanges();

                    ViewBag.Success = "Employee successfully created.";

                    return View();

                }
                else
                {
                    return View(emp);
                }
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult LogIn(RecOutletWarehouse.Models.EMPLOYEE employee)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(employee.Username, employee.Password))
                {
                    FormsAuthentication.SetAuthCookie(employee.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Data is incorrect.");
                }
            }

            return View(employee);

        }
        private bool IsValid(string username, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();

            bool isValid = false;

            using (var db = new RecreationOutletContext())
            {
                var user = db.EMPLOYEEs.FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }
    }
}=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            try
            {
                var crypto = new SimpleCrypto.PBKDF2();

                EMPLOYEE emp = new EMPLOYEE();
                emp = db.EMPLOYEEs.Find(id);

               

                if (emp == null)
                {
                    return HttpNotFound();
                }
                return View(emp);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

         [HttpPost]
        public ActionResult EditEmployee(EMPLOYEE emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrpPass = crypto.Compute(emp.Password);

                    emp.Password = encrpPass;
                    emp.PasswordSalt = crypto.Salt;

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

         public ActionResult CreateEmployee()
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
        
            [HttpPost]
         public ActionResult CreateEmployee(EMPLOYEE emp)
         {
             try
             {

               

                 if (ModelState.IsValid)
                 {
                    


                     var crypto = new SimpleCrypto.PBKDF2();

                     var encrpPass = crypto.Compute(emp.Password);

                     emp.Password = encrpPass;
                     emp.PasswordSalt = crypto.Salt;


                     db.EMPLOYEEs.Add(emp);
                     db.SaveChanges();

                     ViewBag.Success = "Employee successfully created.";

                     return View(new EMPLOYEE());

                 }
                 else
                 {
                     return View(emp);
                 }

                
             }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
         }


    }
}
>>>>>>> .r3112

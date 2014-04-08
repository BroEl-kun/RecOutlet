using System;
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

        /// <summary>
        /// View Model for browsing employees
        /// </summary>
        public class BrowseEmployeeViewModel
        {
            public IEnumerable<EMPLOYEE> Employee { get; set; }
            public PagingInfo PagingInfo { get; set; }
            public string search { get; set; }
            public string startLetter { get; set; }
        }

        /// <summary>
        /// View Model for confirming a new/existing user's password
        /// </summary>
        public class ConfirmPasswordViewModel
        {
            public EMPLOYEE employee { get; set; }

            [Required]
            [DataType(DataType.Password)]            
            public string NewPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]            
            public string ConfirmPassword { get; set; }
        }

        /// <summary>
        /// View Model for the user login page
        /// </summary>
        public class LoginViewModel
        {
            [Display(Name = "Username: ")]
            [Required(ErrorMessage="Please provide a username.")]
            [MaxLength(50, ErrorMessage = "Max Legth of 50 Characters")]
            public string Username { get; set; }

            [Required(ErrorMessage="Please provide a password.")]
            [Display(Name = "Password: ")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        //
        // GET: /Employee/

        /// <summary>
        /// There is no reason to have an index page, but we add it just incase
        /// the user types this url. This will redirect to Browse Employee action
        /// </summary>
        /// <returns>RedirectToAction "BrowseEmployees"</returns>
        public ActionResult Index()
        {
            return RedirectToAction("BrowseEmployees");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empNameSearch">Input String for searching an employee</param>
        /// <param name="firstLetter">Rollodex character selection for filtering</param>
        /// <param name="page">Page number selection for paging employees</param>
        /// <returns>Browse Employee view along with filtered/unfiltered BrowseEmployeeViewModel</returns>
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

        /// <summary>
        /// Edits an existing employee's information
        /// </summary>
        /// <param name="id">The employee id of the employee that is being edited</param>
        /// <returns>EditEmployee.cshtml along with a blank ConfirmPasswordViewModel class</returns>
        public ActionResult EditEmployee(int id = 0)
        {
            try
            {
                var crypto = new SimpleCrypto.PBKDF2();

                ConfirmPasswordViewModel emp = new ConfirmPasswordViewModel();
                emp.employee = db.EMPLOYEEs.Find(id);
                
                if (emp.employee == null)
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

        /// <summary>
        /// This is a POST method for editing an existing employee
        /// </summary>
        /// <param name="emp">ConrifmPasswordViewModel class</param>
        /// <returns>BrowseEmployees.cshtml</returns>
        [HttpPost]
        public ActionResult EditEmployee(ConfirmPasswordViewModel emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var crypto = new SimpleCrypto.PBKDF2();

                    if (emp.NewPassword.Equals(emp.ConfirmPassword))
                    {
                        var encrpPass = crypto.Compute(emp.NewPassword);

                        emp.employee.Password = encrpPass;
                        emp.employee.PasswordSalt = crypto.Salt;

                        db.Entry(emp.employee).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("BrowseEmployee");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Passwords do not match.");
                    }
                }

                return View(emp);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Form to create a new employee
        /// </summary>
        /// <returns>CreateEmployee.cshtml</returns>
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

        /// <summary>
        /// POST for creating a new employee from a form
        /// </summary>
        /// <param name="emp">EMLOYEE Model</param>
        /// <returns>CreateEmployee.cshtml</returns>
        [HttpPost]
        public ActionResult CreateEmployee(EMPLOYEE emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.EMPLOYEEs.Any(e => e.Username == emp.Username))
                    {
                        return View(emp);
                    }
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

        /// <summary>
        /// Login page
        /// </summary>
        /// <returns>LogIn.cshtml</returns>
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        /// <summary>
        /// Logs out the user that is currently logged in
        /// </summary>
        /// <returns>LogIn.cshtml</returns>
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("LogIn", "Employee");
        }

        /// <summary>
        /// POST to log in user with credentials that are in the LoginViewModel
        /// </summary>
        /// <param name="loginInfo">LoginViewModel that holds users credentials for validation</param>
        /// <returns>Index.cshtml if the credentials are correct</returns>
        [HttpPost]
        public ActionResult LogIn(LoginViewModel loginInfo)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(loginInfo.Username, loginInfo.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginInfo.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login failed. Please check your login details.");
                }
            }

            return View();

        }

        /// <summary>
        /// Tests the username and password for validity
        /// </summary>
        /// <param name="username">username from login form</param>
        /// <param name="password">password from login form</param>
        /// <returns>bool (true if username/password are correct; false otherwise)</returns>
        private bool IsValid(string username, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();

            bool isValid = false;

            var user = db.EMPLOYEEs.FirstOrDefault(u => u.Username == username);            
           
            if (user != null)
            {
                user.Password = user.Password.TrimEnd(' ');
                user.PasswordSalt = user.PasswordSalt.TrimEnd(' ');

                if (user.Password == crypto.Compute(password, user.PasswordSalt))
                {
                    isValid = true;
                }
            }

            return isValid; 
        }

        public JsonResult CheckForDuplicateEmployees(string username = "")
        {
            IEnumerable<EMPLOYEE> emp = db.EMPLOYEEs.ToList();
            var isDuplicate = false;
            if (emp.Any(e => e.Username == username))
            {
                isDuplicate = true;
            }

            var jsonData = new { isDuplicate };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}
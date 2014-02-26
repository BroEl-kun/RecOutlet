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

namespace RecOutletWarehouse.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RecOutletWarehouse.Models.EMPLOYEE user)
        {

            if (ModelState.IsValid)
            {
                using (var db = new RecreationOutletContext())
                {
                    //var crypto = new SimpleCrypto.PBKDF2();

                    //var encrpPass = crypto.Compute(user.PIN);

                    var sysUser = db.EMPLOYEEs.Create();

                    sysUser.FirstName = "Bob";
                    sysUser.LastName = "Smith";
                    sysUser.Position = "Manager";
                    sysUser.Username = user.Username;
                    sysUser.PIN = user.PIN;
                    //sysUser.PasswordSalt = crypto.Salt;
                    //sysUser.EmployeeId = Guid.NewGuid();

                    db.EMPLOYEEs.Add(sysUser);
                    db.SaveChanges();

                    ViewBag.UserName = user.Username;

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login Data is incorrect.");
            }

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
                if (IsValid(employee.Username, employee.PIN))
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
                    //if (user.PIN == crypto.Compute(password, user.PasswordSalt))
                    if (user.PIN == password)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }
    }
}

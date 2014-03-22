using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RecOutletWarehouse.Models;
using System.Data.Entity;
using RecOutletWarehouse.Utilities;

namespace RecOutletWarehouse.Controllers
{
    public class LogInController : Controller
    {
        RecreationOutletContext entityDb = new RecreationOutletContext();

        //
        // GET: /LogIn/

        public ActionResult Index()
        {
            return View();
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
                
        [HttpGet]
        public ActionResult ChangePIN(int id = 0)
        {
            //EMPLOYEE user = entityDb.EMPLOYEEs.Find(id);
            //if (user == null)
            //{
            //    return HttpNotFound();
            //}

            return View();
        }

        [HttpPost]
        public ActionResult ChangePIN(EMPLOYEE employee)
        {
            //var crypto = new SimpleCrypto.PBKDF2();

            if (ModelState.IsValid)
            {
                if (IsValid(employee.Username, employee.Password))
                {
                    //var encrpPIN = crypto.Compute(newPIN);
                    var user = new EMPLOYEE()
                    {
                        EmployeeId = employee.EmployeeId,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Username = employee.Username,
                        Position = employee.Position,
                        //PIN = employee.PIN
                        //PIN = encrpPIN,
                        //PINSalt = crypto.Salt
                    };

                    entityDb.EMPLOYEEs.Attach(user);
                    entityDb.Entry(user).Property(x => x.Password).IsModified = true;
                    entityDb.SaveChanges();

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "PIN is incorrect");
                }
                //entityDb.Entry(employee).State = EntityState.Modified;
                //entityDb.SaveChanges();
                //return RedirectToAction("Index", "Home");
            }

            return View();
        }

        private bool IsValid(string username, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();

            bool isValid = false;
           
            var user = entityDb.EMPLOYEEs.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                if (user.Password == crypto.Compute(password, user.PasswordSalt))                    
                    isValid = true;
            }

            return isValid;                
        }
    }
}

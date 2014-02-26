using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SimpleLoginSystem.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(SimpleLoginSystem.Models.UserModel user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.Username, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login Data is incorrect.");
                }
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Registration(SimpleLoginSystem.Models.UserModel user)
        {

            if (ModelState.IsValid)
            {
                using (var db = new MainDbEntities1())
                {
                    var crypto = new SimpleCrypto.PBKDF2();

                    var encrpPass = crypto.Compute(user.Password);

                    var sysUser = db.Tables.Create();

                    sysUser.Username = user.Username;
                    sysUser.Password = encrpPass;
                    sysUser.PasswordSalt = crypto.Salt;
                    sysUser.UserId = Guid.NewGuid();

                    db.Tables.Add(sysUser);
                    db.SaveChanges();

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


        private bool IsValid(string username, string password) 
        {
            var crypto = new SimpleCrypto.PBKDF2();

            bool isValid = false;

            using (var db = new MainDbEntities1())
            { 
                var user = db.Tables.FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    if(user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }
    }
}

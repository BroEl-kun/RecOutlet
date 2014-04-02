using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Utilities;

namespace RecOutletWarehouse.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
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
            else
            {
                try
                {
                    return RedirectToAction("LogIn", "Employee");
                }
                catch (Exception ex)
                {
                    WarehouseUtilities.LogError(ex);
                    return RedirectToAction("Error", "Home");
                }
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}

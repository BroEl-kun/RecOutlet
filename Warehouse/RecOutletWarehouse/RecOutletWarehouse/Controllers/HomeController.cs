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

        /// <summary>
        /// Index consists of a series of links to other parts of the application
        /// </summary>
        /// <returns>ActionResult Index</returns>
        public ActionResult Index()
        {
            try
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
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// A simple error page to prevent the user
        /// from seeing an ugly MVC error page
        /// </summary>
        /// <returns>ActionResult Error</returns>
        public ActionResult Error()
        {
            return View();
        }
    }
}

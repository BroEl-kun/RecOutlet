using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models.VendorManagement;
using RecOutletWarehouse.Models;

namespace RecOutletWarehouse.Controllers
{
    public class VendorController : Controller
    {
        //
        // GET: /Vendor/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddVendor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddVendor(Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                //TODO: replace this view with the correct submit view.
                return View(vendor);
            }
            else
            {
                DataFetcherSetter db = new DataFetcherSetter();

                db.AddNewVendor(vendor.VendorName, vendor.ContactName,
                    vendor.ContactPhone, vendor.ContactFax,
                    vendor.AltPhone, vendor.Address,
                    vendor.Website);

                //TODO: change this to the actual view i need to return like Success! or something.
                return View("Index");
            }
        }

    }
}


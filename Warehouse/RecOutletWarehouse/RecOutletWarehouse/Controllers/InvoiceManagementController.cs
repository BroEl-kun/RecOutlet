using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Models.InvoiceManagement;
using RecOutletWarehouse.Utilities;


namespace RecOutletWarehouse.Controllers
{
    public class InvoiceManagementController : Controller
    {

        RecreationOutletContext entityDb = new RecreationOutletContext();
        //
        // GET: /Invoice/

        //New view model that incorporates the Entity Framework models
        public class InvoiceViewModel
        {
            public INVOICE invoice { get; set; }
            public INVOICE_CUSTOMER customer { get; set; }
            public INVOICE_LINEITEM lineitem { get; set; }
        }

        public ActionResult Index()
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
        public ActionResult Index(Invoice invoice, string labelRedirect = "")
        {
            try
            {
                DataFetcherSetter db = new DataFetcherSetter();

                invoice.InvoiceCreatedDate = DateTime.Now.Date;
                invoice.InvoiceCreatedBy = 1; //TODO: Associate with logged-in user   
                
                //invoice.CustomerID
               

                if (ModelState.IsValid)
                {
                    //db.AddNewInvoice(invoice);
                    //ViewBag.ItemSuccessfulInsert = invoice.InvoiceID;

                    return View(new Invoice());
                }

                //return View(invoice);
                return View(new Invoice());
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }


        public ActionResult CreateNewInvoice()
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
        public ActionResult CreateNewInvoice(Invoice invoice, string labelRedirect = "")
        {
            try
            {
                DataFetcherSetter db = new DataFetcherSetter();

                invoice.InvoiceCreatedDate = DateTime.Now.Date;
                invoice.InvoiceCreatedBy = 1; //TODO: Associate with logged-in user   

                //invoice.CustomerID


                if (ModelState.IsValid)
                {
                    //db.AddNewInvoice(invoice);
                    //ViewBag.ItemSuccessfulInsert = invoice.InvoiceID;

                    return View(new Invoice());
                }

                //return View(invoice);
                return View(new Invoice());
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }


        public ActionResult CreateInvoiceRecipient()
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
        public ActionResult CreateInvoiceRecipient(Customer customer, string labelRedirect = "")
        {
            try
            {
                DataFetcherSetter db = new DataFetcherSetter();


                if (ModelState.IsValid)
                {

                    return View(new Customer());
                }

                //return View(customer);
                return View(new Customer());
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }
    }
}

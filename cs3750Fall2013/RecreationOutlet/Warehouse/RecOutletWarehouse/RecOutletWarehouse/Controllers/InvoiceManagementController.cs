using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int BrowsePageSize = 25;
        //
        // GET: /Invoice/

        //New view model that incorporates the Entity Framework models
        public class InvoiceViewModel
        {
            public INVOICE invoice { get; set; }
            public INVOICE_CUSTOMER customer { get; set; }
            public INVOICE_LINEITEM lineitem { get; set; }
        }

        public class SearchInvoiceViewModel
        {
            public IEnumerable<INVOICE> invoices { get; set; }
            public DateTime? fromDate { get; set; }
            public DateTime? toDate { get; set; }
            public PagingInfo PagingInfo { get; set; }
            public String customerName { get; set; }
            public long? invoiceID { get; set; }
        }

        public ActionResult Index(SearchInvoiceViewModel model, string searchButton, int page = 1)
        {
            try
            {
                model.invoices = entityDb.INVOICEs.ToList();

                if (model.toDate != null)
                {
                    model.invoices = model.invoices.Where(x => x.InvoiceCreatedDate <= model.toDate);
                }
                if (model.fromDate != null)
                {
                    model.invoices = model.invoices.Where(x => x.InvoiceCreatedDate >= model.fromDate);
                }
                if (model.customerName != null)
                {
                    model.invoices = model.invoices.Where(x => x.INVOICE_CUSTOMER.CustomerName.Contains(model.customerName));
                }
                if (model.invoiceID != null)
                {
                    model.invoices = model.invoices.Where(x => x.InvoiceID == model.invoiceID);
                }

                model.PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = BrowsePageSize,
                    TotalItems = model.invoices.Count()
                };

                return View(model);
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

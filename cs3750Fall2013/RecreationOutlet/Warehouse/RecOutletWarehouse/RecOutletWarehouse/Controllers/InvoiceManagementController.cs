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
                model.invoices = entityDb.INVOICEs.ToList().OrderBy(x => x.InvoiceCreatedDate);

                if (searchButton == null)
                {
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
                }
                else
                {
                    if (searchButton == "Today")
                    {
                        model.invoices = model.invoices.Where(x => x.InvoiceCreatedDate == DateTime.Today);
                    }
                    else if (searchButton == "Past Week")
                    {
                        model.invoices = model.invoices.Where(x => x.InvoiceCreatedDate > DateTime.Today.AddDays(-7));
                    }
                    else if (searchButton == "This Month")
                    {
                        model.invoices = model.invoices.Where(x => x.InvoiceCreatedDate.Month == DateTime.Now.Month);
                    }
                    else if (searchButton == "This Year")
                    {
                        model.invoices = model.invoices.Where(x => x.InvoiceCreatedDate.Year == DateTime.Now.Year);
                    }
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
                if (ModelState.IsValid)
                {
                    //db.AddNewInvoice(invoice);
                    //ViewBag.ItemSuccessfulInsert = invoice.InvoiceID;

                    return View(invoice);
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
        public ActionResult CreateInvoiceRecipient(INVOICE_CUSTOMER customer, string labelRedirect = "")
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //TODO: replace this view with the correct submit view.
                    return View(customer);
                }
                else
                {
                    entityDb.INVOICE_CUSTOMER.Add(customer);
                    entityDb.SaveChanges();
                    ViewBag.Success = "Recipient successfully created.";
                    if (labelRedirect == "Create Recipient, Create New Invoice")
                    {
                        return RedirectToAction("CreateNewInvoice", new { customerID = customer.CustomerID });
                    }
                    return View();
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

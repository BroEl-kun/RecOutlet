using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using RecOutletWarehouse.Utilities;

namespace RecOutletWarehouse.Controllers
{
    public class EventController : Controller
    {
        public RecreationOutletContext db = new RecreationOutletContext();

        /// <summary>
        /// View Model for a new sales price to a current event
        /// </summary>
        public class AddSalePriceViewModel 
        {
            public SALE_PRICING saleprice { get; set; }
            [Required(ErrorMessage = "Please provide the event.")]
            public string Event { get; set; }
            public long OldRPC { get; set; }
            public byte OldEvent { get; set; }
        }

        /// <summary>
        /// Need to add comments here
        /// </summary>
        public class ItemEventViewModel
        {
            //public EVENT_TYPE Event { get; set; }
            public IEnumerable<SelectListItem> Events { get; set; }
            //public string Event { get; set; }
            public List<ITEM> Items { get; set; }
            public List<SALE_PRICING> SalePrices { get; set; }
            public byte EventToAddTo { get; set; }
            public string ItemName { get; set; }
            public decimal OrigPriceOfItem { get; set; }
            public decimal SalePriceOfItem { get; set; }
        }

        //
        // GET: /Event/

        /// <summary>
        /// Page to view all existing events
        /// </summary>
        /// <returns>ViewEvents.cshtml</returns>
        public ActionResult ViewEvents()
        {
            try
            {
                var eventTypes = from et in db.EVENT_TYPE
                                 select et;

                return View(eventTypes.ToList());
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Edit an existing event's data
        /// </summary>
        /// <param name="id">Event id</param>
        /// <returns>EditEvent.cshtml</returns>
        public ActionResult EditEvent(int id = 0)
        {
            try
            {
                EVENT_TYPE et = db.EVENT_TYPE.Find(id);
                if (et == null)
                {
                    return HttpNotFound();
                }
                return View(et);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// POST for updating existing event's data
        /// </summary>
        /// <param name="et">EVENT_TYPE Model with modified data</param>
        /// <returns>EditEvent.cshtml</returns>
        [HttpPost]
        public ActionResult EditEvent(EVENT_TYPE et)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(et).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ViewEvents");
                }

                return View(et);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Empty form to create a new event
        /// </summary>
        /// <returns>CreateEvent.cshtml</returns>
        public ActionResult CreateEvent()
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
        /// POST for form data to create a new event
        /// </summary>
        /// <param name="et">EVENT_TYPE model</param>
        /// <returns>ActionResult ViewEvents</returns>
        [HttpPost]
        public ActionResult CreateEvent(EVENT_TYPE et)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.EVENT_TYPE.Add(et);
                    db.SaveChanges();
                    return RedirectToAction("ViewEvents");
                }

                return View(et);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// View all sales prices
        /// </summary>
        /// <returns>ActionResult ViewSalesPrice</returns>
        public ActionResult ViewSalesPrice()
        {
            try
            {
                var salesPrice = from sp in db.SALE_PRICING
                                 select sp;

                return View(salesPrice.ToList());
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Edit an existing sale's price
        /// </summary>
        /// <param name="etc">Event Type Code</param>
        /// <param name="rpc">Item RPC</param>
        /// <returns>ActionResult EditSalesPrice</returns>
        public ActionResult EditSalesPrice(byte etc = 0, long rpc = 0)
        {
            try
            {
                AddSalePriceViewModel model = new AddSalePriceViewModel();
                model.saleprice = db.SALE_PRICING.Find(etc, rpc);
                model.Event = model.saleprice.EVENT_TYPE.EventDescription;
                model.OldRPC = model.saleprice.RecRPC;
                model.OldEvent = model.saleprice.EventTypeCode;

                if (model.saleprice == null)
                {
                    return HttpNotFound();
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
        /// POST for modified data in an existing sale's price
        /// </summary>
        /// <param name="sp">AddSalesPriceViewModel</param>
        /// <returns>ActionResult ViewSalesPrice</returns>
        [HttpPost]
        public ActionResult EditSalesPrice(AddSalePriceViewModel sp)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    SALE_PRICING oldSalePrice = db.SALE_PRICING.Single(
                        p => p.RecRPC == sp.OldRPC && p.EventTypeCode == sp.OldEvent);

                    db.SALE_PRICING.Remove(oldSalePrice);

                    sp.saleprice.EVENT_TYPE = db.EVENT_TYPE.Single(et => et.EventDescription == sp.Event);
                    sp.saleprice.ITEM = db.ITEMs.Single(i => i.RecRPC == sp.saleprice.RecRPC);
                    db.SALE_PRICING.Add(sp.saleprice);
                    db.SaveChanges();
                    return RedirectToAction("ViewSalesPrice");
                }

                return View(sp);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Empty form for creating a new sale's price
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult CreateSalesPrice</returns>
        public ActionResult CreateSalesPrice(int id = 0)
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
        /// POST for form data to create a new sale's price
        /// </summary>
        /// <param name="sp">AddSalePriceViewModel</param>
        /// <returns>ActionResult CreateSalesPrice</returns>
        [HttpPost]
        public ActionResult CreateSalesPrice(AddSalePriceViewModel sp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sp.saleprice.EVENT_TYPE = db.EVENT_TYPE.Single(et => et.EventDescription == sp.Event);
                    db.SALE_PRICING.Add(sp.saleprice);
                    db.SaveChanges();
                    return RedirectToAction("ViewSalesPrice");
                }
                return View();
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Method for adding items to an existing event.
        /// Pulls a list of all existing items in in that event
        /// </summary>
        /// <param name="id">Event id</param>
        /// <returns>ActionResult AddItemsToEvent</returns>
        public ActionResult AddItemsToEvent(byte id = 0)
        {
            try
            {
                ItemEventViewModel ievm = new ItemEventViewModel
                {
                    Events = EventsToSelectListItems(db.EVENT_TYPE, id),
                    SalePrices = db.SALE_PRICING.Where(x => x.EventTypeCode == id).ToList()
                };

                return View(ievm);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// POST new items to add to an existing event
        /// </summary>
        /// <param name="ievm">ItemEventViewModel</param>
        /// <returns>ActionResult AddItemsToEvent</returns>
        [HttpPost]
        public ActionResult AddItemsToEvent(ItemEventViewModel ievm)
        {
            try
            {
                ievm.Events = EventsToSelectListItems(db.EVENT_TYPE, ievm.EventToAddTo);
                ievm.SalePrices = db.SALE_PRICING.Where(x => x.EventTypeCode == ievm.EventToAddTo).ToList();

                return View(ievm);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        //*************************NOTE:******************************
        //I don't believe we are using this method anymore, but I'm not
        //going to comment it out just something is dependent on this.
        public ActionResult ItemToEvent(ItemEventViewModel model)
        {
            try {
                // The following "if" control is bad code. Essentially it only prevents
                // attempted insertion of duplicate data into the database. It does not
                // set any error message. That is done by a jQuery function in
                // AddItemsToEvent.cshtml. If anyone wants to try finding a better way,
                // I wish you luck!
                if (db.SALE_PRICING.Any(x => x.ITEM.Name == model.ItemName && x.EventTypeCode == model.EventToAddTo)){
                    //ViewBag.ErrorMessage = String.Format("The item \"{0}\" is already on this event. Please edit the existing entry.", model.ItemName);
                    return PartialView("ItemToEvent", model.SalePrices);
                }

                if (!ModelState.IsValid) {
                    return PartialView("ItemToEvent", model.SalePrices);
                }

                SALE_PRICING priceToAdd = new SALE_PRICING {
                    RecRPC = db.ITEMs.Single(x => x.Name == model.ItemName).RecRPC,
                    SalePrice = model.SalePriceOfItem,
                    EventTypeCode = model.EventToAddTo
                };

                db.SALE_PRICING.Add(priceToAdd);

                db.SaveChanges();
                List<SALE_PRICING> listToReturn = db.SALE_PRICING.Where(li => li.EventTypeCode == model.EventToAddTo).ToList();

                //ViewBag.TotalPOCost = String.Format("{0:$0.00}", listToReturn.Sum(x => x.WholesaleCost * x.QtyOrdered));

                return PartialView("ItemToEvent", listToReturn);
            }
            catch(Exception ex)
            {
                return PartialView("ItemToEvent");
            }
        }

        /// <summary>
        /// Pulls a list of all sales prices so the user can choose which ones to remove
        /// </summary>
        /// <param name="etc">Event Type Code</param>
        /// <param name="rpc">RecRPC</param>
        /// <returns>ActionResult RemoveSalesPriceFromEvent</returns>
        public ActionResult RemoveSalesPriceFromEvent(byte etc = 0, long rpc = 0 )
        {
            try
            {
                SALE_PRICING lineItem = db.SALE_PRICING.Single(sp => sp.RecRPC == rpc && sp.EventTypeCode == etc);

                db.SALE_PRICING.Remove(lineItem);

                db.SaveChanges();
                List<SALE_PRICING> listToReturn = db.SALE_PRICING.Where(sp => sp.EventTypeCode == etc).ToList();

                return PartialView("ItemToEvent", listToReturn);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Pulls a list of all sales prices for a specified event
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <returns>ActionResult getAllSalePricesForEvent</returns>
        [HttpPost]
        public ActionResult getAllSalePricesForEvent(byte id = 0)
        {
            try
            {
                List<SALE_PRICING> listToReturn = db.SALE_PRICING.Where(sp => sp.EventTypeCode == id).ToList();
                return PartialView("ItemToEvent", listToReturn);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        // Extension methods follow

        public static IEnumerable<SelectListItem> EventsToSelectListItems(IEnumerable<EVENT_TYPE> events, int selectedId) {
            return events.OrderBy(ev => ev.EventDescription)
                         .Select(ev =>
                             new SelectListItem {
                                 Selected = (ev.EventTypeCode == selectedId),
                                 Text = ev.EventDescription,
                                 Value = ev.EventTypeCode.ToString()
                             });
        }

        /// <summary>
        /// This is a method that queries the database to see if a given
        /// ITEM.Name/EventTypeCode combo already exists and returns true 
        /// or false as JSON data.
        /// </summary>
        /// <param name="etc">The EventTypeCode to check</param>
        /// <param name="item">The ITEM name property to check</param>
        /// <returns>JSON data representing true or false</returns>
        public JsonResult CheckForDuplicateSalePrice(byte etc = 0, string item ="") {
            IEnumerable<SALE_PRICING> salePrices = db.SALE_PRICING.ToList();
            var isDuplicate = false;
            if (salePrices.Any(sp => sp.ITEM.Name == item && sp.EventTypeCode == etc)) {
                isDuplicate = true;
            }

            var jsonData = new { isDuplicate };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}

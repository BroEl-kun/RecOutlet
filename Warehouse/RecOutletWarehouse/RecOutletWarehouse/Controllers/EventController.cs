﻿using System;
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
        public class AddSalePriceViewModel {

            public SALE_PRICING saleprice { get; set; }
            [Required(ErrorMessage = "Please provide the event.")]
            public string Event { get; set; }
            public long OldRPC { get; set; }
            public byte OldEvent { get; set; }

        }

        public RecreationOutletContext db = new RecreationOutletContext();
        //
        // GET: /Event/

        public ActionResult ViewEvents()
        {
            var eventTypes = from et in db.EVENT_TYPE
                             select et;


            return View(eventTypes.ToList());
        }

        public ActionResult EditEvent(int id = 0) {
            EVENT_TYPE et = db.EVENT_TYPE.Find(id);
            if (et == null) {
                return HttpNotFound();
            }
            return View(et);
        }

        [HttpPost]
        public ActionResult EditEvent(EVENT_TYPE et) {

            if (ModelState.IsValid) {
                db.Entry(et).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewEvents");
            }

            return View(et);
        }

        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(EVENT_TYPE et)
        {

            if (ModelState.IsValid)
            {
                db.EVENT_TYPE.Add(et);
                db.SaveChanges();
                return RedirectToAction("ViewEvents");
            }

            return View(et);
        }

        public ActionResult ViewSalesPrice() {
            var salesPrice = from sp in db.SALE_PRICING
                             select sp;


            return View(salesPrice.ToList());
        }

        public ActionResult EditSalesPrice(byte etc = 0, long rpc = 0) {
            AddSalePriceViewModel model = new AddSalePriceViewModel();
            model.saleprice = db.SALE_PRICING.Find(etc, rpc);
            model.Event = model.saleprice.EVENT_TYPE.EventDescription;
            model.OldRPC = model.saleprice.RecRPC;
            model.OldEvent = model.saleprice.EventTypeCode;
            if (model.saleprice == null) {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult EditSalesPrice(AddSalePriceViewModel sp) {

            if (ModelState.IsValid) {

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

        public ActionResult CreateSalesPrice(int id = 0) {

            return View();
        }

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
    }
}

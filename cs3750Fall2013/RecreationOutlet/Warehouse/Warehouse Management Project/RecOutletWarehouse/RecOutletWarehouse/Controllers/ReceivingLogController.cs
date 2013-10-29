using RecOutletWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecOutletWarehouse.Controllers
{
    public class ReceivingLogController : Controller
    {
        //
        // GET: /ReceivingLog/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /ReceivingLog/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ReceivingLog/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ReceivingLog/Create

        [HttpPost]
        //public ActionResult Create(ReceivingLog RL)
        public ActionResult CreateNewRL(ReceivingLog RL)
        {
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            if (!ModelState.IsValid)
            {
                return View(RL);
            }
            else
            {
                //DataFetcherSetter db = new DataFetcherSetter();

                //db.NewReceivingLog(RL.ReceivingID,
                //    RL.POLineItemID, RL.BackorderID,
                //    RL.QtyTypeID, RL.ReceiveDate,
                //    RL.ReceivingNotes, RL.ReceivedQty);

                //return View("Create");
                return View(RL);
            }
        }

        //
        // GET: /ReceivingLog/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ReceivingLog/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ReceivingLog/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ReceivingLog/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using System.Data.Entity;

namespace RecOutletWarehouse.Controllers
{
    public class EventController : Controller
    {
        public RecreationOutletContext db = new RecreationOutletContext();
        //
        // GET: /Event/

        public ActionResult Index()
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
                return RedirectToAction("Index");
            }

            return View(et);
        }
    }
}

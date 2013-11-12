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

        //public ActionResult Create()
        public ActionResult CreateNewRL()
        {
            //return View();
            return View("Index");
        }

        //
        // POST: /ReceivingLog/Create

        [HttpPost]
        //public ActionResult Create(ReceivingLog RL)
        public ActionResult CreateNewRL(ReceivingLog RL)
        //public ActionResult Index(ReceivingLog RL)
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
                //return View(RL);
                //return View("Index", RL);
                return View("Index");
            }
            else
            {
                DataFetcherSetter db = new DataFetcherSetter();

                db.NewReceivingLog(//RL.ReceivingID,
                    RL.POLineItemID, RL.BackorderID,
                    RL.QtyTypeID, RL.ReceiveDate,
                    RL.ReceivingNotes, RL.ReceivedQty);

                //return View("CreateNewRL");
                return View("Index");
                //return View(RL);
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

        [HttpPost]
        public ActionResult findPO(string po)
        //public void findPO(string po)
        {
            //need to find the PO from the db
            //then populate with the line items
            //then be able to add values for each line item

            //return View("CreateNewRL");
            //return RedirectToAction("CreateNewRL")
            //return View("POSummary");

            //1108201301
            DataFetcherSetter db = new DataFetcherSetter();

            List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem;

            //objItem = ListLineItemsForPO(int.Parse(po));
            objItem = db.ListLineItemsForPO(int.Parse(po));

           // return new PurchaseOrderController().POSummary(int.Parse(po));
            return View("Index", objItem);
           // return View("Index");
        }

        //[HttpPost]
        //public ActionResult MarkedReceived(int QtyReceived)
        //{
        //    return View();
        //}

        [HttpPost]
        //public ActionResult Index(List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem, int QtyReceived)
        //public ActionResult Index(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem, DateTime ReceivedDate, ushort QtyReceived, string Notes)
        //public ActionResult MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem, string ReceivedDate, ushort QtyReceived, string Notes)
        //public void MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem, string ReceivedDate, ushort QtyReceived, string Notes)
       
            //public void MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem, string ReceivedDate, short QtyReceived, string Notes)
        public void MarkedReceived(FormCollection form, string ReceivedDate, short QtyReceived, string Notes)
        
            //public void MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem item, string ReceivedDate, short QtyReceived, string Notes)
        //public void MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem itemName, string ReceivedDate, short QtyReceived, string Notes)
        //public void MarkedReceived(string itemName, string ReceivedDate, short QtyReceived, string Notes)  //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem>
        //public void MarkedReceived(List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem, int cindex, string ReceivedDate, short QtyReceived, string Notes)
        {
            //if (QtyReceived != null)  //do test on the page!
            //{
                //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> item = objItem;
            //RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem = item;

           // RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem itemr = objItem[1];

            //RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem = Model[cindex];
           // RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem itemName = objItem[cindex];

                ReceivingLog RL = new ReceivingLog();

                //NewReceivingLog(RL.ReceivingID,
                //    RL.POLineItemID, RL.BackorderID,
                //    RL.QtyTypeID, RL.ReceiveDate,
                //    RL.ReceivingNotes, RL.ReceivedQty);

               // RL.POLineItemID = int.Parse(objItem.POLineItem.ToString());
                //RL.POLineItemID = objItem.POLineItem;
                //RL.POLineItemID = Convert.ToInt32(form.GetValue("POLineItem"));
            //RL.POLineItemID = form.
                //RL.POLineItemID = Convert.ToInt32(form.GetValue("POLineItem").ToString());
                RL.POLineItemID = Convert.ToInt32(form["POLineItem"].ToString());
                
            //RL.POLineItemID = itemName.POLineItem;
                //RL.BackorderID

            //if(

                //RL.QtyTypeID = objItem.QtyTypeId;
            //RL.QtyTypeID = Convert.ToInt16(form.GetValue("QtyTypeID").ToString());
                RL.QtyTypeID = Convert.ToInt16(form["QtyTypeID"].ToString());

                //RL.QtyTypeID = itemName.QtyTypeId;
                RL.ReceiveDate = Convert.ToDateTime(ReceivedDate);
                RL.ReceivingNotes = Notes;
                RL.ReceivedQty = QtyReceived;   //sooo have to make sure they don't put in something funky
                
            //}

            //return View("Index", RL);
            //    return View("Index");
            //return View("CreateNewRL", RL);

                DataFetcherSetter db = new DataFetcherSetter();

                //db.NewReceivingLog(//RL.ReceivingID,
                //    RL.POLineItemID, RL.BackorderID,
                //    RL.QtyTypeID, RL.ReceiveDate,
                //    RL.ReceivingNotes, RL.ReceivedQty);

            //Will need to handle backorder stuff
                db.NewReceivingLog(//RL.ReceivingID,
                    RL.POLineItemID, 
                    RL.QtyTypeID, RL.ReceiveDate,
                    RL.ReceivingNotes, RL.ReceivedQty);

        }
    }
}

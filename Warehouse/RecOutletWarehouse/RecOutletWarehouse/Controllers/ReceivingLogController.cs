﻿using RecOutletWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Utilities;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;

namespace RecOutletWarehouse.Controllers
{
    public class ReceivingLogController : Controller
    {
        public RecreationOutletContext db = new RecreationOutletContext();
        public int BrowsePageSize = 25; // The number of results we want to show on each BrowseVendor page

        /// <summary>
        /// ViewModel for creating a new Receivng Log
        /// </summary>
        public class ReceivingLogCreationViewModel
        {
            //public List<RecOutletWarehouse.Models.RECEIVING_LOG> RL { get; set; }
            public List<RECEIVING_LOG> RL { get; set; }
            public string[] ItemDescription { get; set; }
            //public List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> LineItems { get; set; }
            public List<PO_LINEITEM> LineItems { get; set; }
        }

        /// <summary>
        /// ViewModel for Browsing Receiving Log
        /// </summary>
        public class BrowseReceivingLogViewModel
        {
            public IEnumerable<RECEIVING_LOG> RLs { get; set; }
            public PagingInfo PagingInfo { get; set; }
            public string search { get; set; }
            public string startLetter { get; set; }
            public string[] qtytype { get; set; }
            public long[] POIDs { get; set; }
            public short[] CreatorIDs { get; set; }
            public long[] RPCs { get; set; }
        }

        //
        // GET: /ReceivingLog/
        public ActionResult Index()
        {
            try
            {
                //DataFetcherSetter dbfs = new DataFetcherSetter();

                //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrder> objItem = new List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrder>();

                return GetNonReceivedPOs();
                //return View();
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Generates a list of non-received Purchase Orders
        /// </summary>
        /// <returns>ActionResult GetNonReceivedPOs</returns>
        public ActionResult GetNonReceivedPOs()
        {
            List<PURCHASE_ORDER> objItem = new List<PURCHASE_ORDER>();

            //Why does the LineItem portion come back null?
            //objItem = dbfs.GetNonReceivedPOs();

            //from s in db.Services
            //join sa in db.ServiceAssignments on s.Id equals sa.ServiceId
            //where sa.LocationId == 1
            //select s

            //var pre = (from P in db.PURCHASE_ORDER
            //           join PL in db.PO_LINEITEM on P.POID equals PL.POID
            //           join RL in db.RECEIVING_LOG on PL.POLineItemID equals RL.POLineItemID
            //           where PL.QtyOrdered == RL.ReceivedQty
            //           select P).Distinct();

            var cte = (from P in db.PURCHASE_ORDER
                       //List<PURCHASE_ORDER> cte = (from P in db.PURCHASE_ORDER
                       join PL in db.PO_LINEITEM on P.POID equals PL.POID
                       //join RL in db.RECEIVING_LOG on PL.POLineItemID equals RL.POLineItemID
                       //join RL in db.RECEIVING_LOG.DefaultIfEmpty() on PL.POLineItemID equals RL.POLineItemID
                       join RL in db.RECEIVING_LOG on PL.POLineItemID equals RL.POLineItemID
                       where PL.QtyOrdered == RL.ReceivedQty
                       //where RL.ReceivingID.Equals(null)
                       //where RL.ReceivingID == null
                       //where P.POID not in pre(x=> x.
                       select P).Distinct();//.ToList().OrderBy(P=>P.POOrderDate);
            //.ToList<PURCHASE_ORDER>();

            //Shouldn't be necessary as all POs should have at least 1 line item.
            var temp = (from P in db.PURCHASE_ORDER
                        join PL in db.PO_LINEITEM on P.POID equals PL.POID
                        select P).Distinct();

            //.Where(e => !hasFacilities.Any(m => m.FacilityId == e.FacilityId))
            //objItem = db.PURCHASE_ORDER.Where(x => !cte.Any(m => m.POID == x.POID)).Take(50).ToList();
            //COMPLETE THIS QUERY
            //objItem = db.PURCHASE_ORDER.Take(50).ToList();
            //objItem = cte;
            // objItem = db.PURCHASE_ORDER.Where(x => x.POID == cte.All(m => m.POID));
            //objItem = db.PURCHASE_ORDER.Where(x => 
            //objItem = cte.OrderBy(P => P.POOrderDate).Take(50).ToList<PURCHASE_ORDER>();//.OrderBy(P => P.POOrderDate).Take(50);
            objItem = db.PURCHASE_ORDER.Where(x => !cte.Any(m => m.POID == x.POID) && temp.Any(n => n.POID == x.POID)).OrderBy(p => p.POOrderDate).Take(50).ToList();

            ViewBag.NonReceivedPOs = objItem;

            return View("Index");
        }

        //
        // GET: /ReceivingLog/Details/5

        /// <summary>
        /// Shows details of a specific Receiving Log
        /// </summary>
        /// <param name="id">Receiving Log ID</param>
        /// <returns>ActionResult Details</returns>
        public ActionResult Details(int id)
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

        //
        // GET: /ReceivingLog/Create
        //IS THIS EVEN USED? ------------------------------------------------
        //public ActionResult Create()
        //public ActionResult CreateNewRL()
        //{
        //    try
        //    {
        //        DataFetcherSetter dbfs = new DataFetcherSetter();

        //        //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrder> objItem = new List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrder>();
        //        List<PURCHASE_ORDER> objItem = new List<PURCHASE_ORDER>();

        //        //Why does the LineItem portion come back null?
        //        //objItem = dbfs.GetNonReceivedPOs();

        //        var cte = (from P in db.PURCHASE_ORDER
        //                   join PL in db.PO_LINEITEM on P.POID equals PL.POID
        //                   join RL in db.RECEIVING_LOG on PL.POLineItemID equals RL.POLineItemID
        //                   where PL.QtyOrdered == RL.ReceivedQty
        //                   select P).ToList();
        //        //.Where(e => !hasFacilities.Any(m => m.FacilityId == e.FacilityId))
        //        //objItem = db.PURCHASE_ORDER.Where(x => !cte.Any(m => m.POID == x.POID)).Take(50).ToList();
        //        //COMPLETE THIS QUERY
        //        objItem = db.PURCHASE_ORDER.Take(50).ToList();

        //        ViewBag.NonReceivedPOs = objItem;

        //        //return View();
        //        return View("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        WarehouseUtilities.LogError(ex);
        //        return RedirectToAction("Error", "Home");
        //    }
        //}

        //
        // POST: /ReceivingLog/Create

        //[HttpPost]
        ////public ActionResult Create(ReceivingLog RL)
        //public ActionResult CreateNewRL(RECEIVING_LOG RL)
        ////public ActionResult Index(ReceivingLog RL)
        //{
        //    //try
        //    //{
        //    //    // TODO: Add insert logic here

        //    //    return RedirectToAction("Index");
        //    //}
        //    //catch
        //    //{
        //    //    return View();
        //    //}
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            //return View(RL);
        //            //return View("Index", RL);
        //            return View("Index");
        //        }
        //        else
        //        {
        //            //DataFetcherSetter db = new DataFetcherSetter();

        //            //db.NewReceivingLog(//RL.ReceivingID,
        //            //    RL.POLineItemID, RL.BackorderID,
        //            //    RL.QtyTypeID, RL.ReceiveDate,
        //            //    RL.ReceivingNotes, RL.ReceivedQty);

        //            db.RECEIVING_LOG.Add(RL);
        //            db.SaveChanges();

        //            //return View("CreateNewRL");
        //            return View("Index");
        //            //return View(RL);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        WarehouseUtilities.LogError(ex);
        //        return RedirectToAction("Error", "Home");
        //    }
        //}

        //
        // GET: /ReceivingLog/Edit/5
        /// <summary>
        /// Edit an existing Receiving Log
        /// </summary>
        /// <param name="id">Receiving Log ID</param>
        /// <returns>ActionResult EditRL</returns>
        public ActionResult EditRL(int id)
        {
            try
            {
                RECEIVING_LOG rl = db.RECEIVING_LOG.Where(x => x.ReceivingID == id).First();

                ViewBag.editRL = rl;

                return View();
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        //
        // POST: /ReceivingLog/Edit/5

        [HttpPost]
        //public ActionResult EditRL(int id, FormCollection collection)
        //public ActionResult EditRL(RECEIVING_LOG LOG)
            //apparently whatever model is chosen is passed back and forth between associated view
            //and controller call. so on post it passed back edited model. BUT THE MODEL HAS TO BE
            //IN THE CONTROLLER ORIGINALLY FOR IT TO SEE IT.
        public ActionResult EditRL(ReceivingLogCreationViewModel log)
        {
            try
            {
                // TODO: Add update logic here

                //enum error?
                //foreach (RECEIVING_LOG uprlog in log)
                //{
                //    db.RECEIVING_LOG.Attach(log.RL[0]);
                //    var entry = db.Entry(log.RL[0]);
                //    entry.Property(e => e.ReceivingID).IsModified = false;
                //    entry.Property(e => e.POLineItemID).IsModified = false;
                //if(
                //    entry.Property(e => e.QtyTypeID).IsModified = false;
                //} else {
                //    entry.Property(e => e.QtyTypeID).IsModified = true;
                //}
                //    entry.Property(e => e.ReceiveDate).IsModified = true;
                //    entry.Property(e => e.ReceivingNotes).IsModified = true;
                //    entry.Property(e => e.ReceivedQty).IsModified = true;
                //    db.SaveChanges();
                //}

                RECEIVING_LOG updtrlog = log.RL[0];

                db.Entry(updtrlog).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index"); 
            }
            catch(Exception ex)
            {
                //return View();
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        //TODO
        // GET: /ReceivingLog/Delete/5
        /// <summary>
        /// Select a specific Receiving Log to remove
        /// </summary>
        /// <param name="id">Receiving Log ID</param>
        /// <returns>ActionResult Delete</returns>
        public ActionResult Delete(int id)
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

        //TODO
        // POST: /ReceivingLog/Delete/5
        /// <summary>
        /// POST Deletion of specified Receiving Log
        /// </summary>
        /// <param name="id">Receiving Log ID</param>
        /// <param name="collection">FormCollection</param>
        /// <returns>ActionResult Index</returns>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //return View();
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        //TODO
        [HttpPost]
        public ActionResult findPO(string po)   //Validation. Also perhaps on success populate a box saying so upon return to index?
        //public void findPO(string po)
        {
            try
            {
                //need to find the PO from the db
                //then populate with the line items
                //then be able to add values for each line item

                //return View("CreateNewRL");
                //return RedirectToAction("CreateNewRL")
                //return View("POSummary");

                ViewBag.CurrentPO = po;

                //1108201301
                DataFetcherSetter dbfs = new DataFetcherSetter();

                //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem;
                ReceivingLogCreationViewModel objItem = new ReceivingLogCreationViewModel();

                //objItem = ListLineItemsForPO(int.Parse(po));
                //objItem = db.ListLineItemsForPO(int.Parse(po));
                //objItem.LineItems = dbfs.ListLineItemsForPO(int.Parse(po));
                //objItem.LineItems = db.PO_LINEITEM.Where(x => x.POID == Convert.ToInt64(po)).ToList();

                //var cte = (from P in db.PO_LINEITEM
                //           where P.POID == 1121201301
                //           select P.QtyOrdered).ToList();

                //context.SomeTable.Where(c => c.ParentId == null)
                // .Where(c => c.Name.Contains("F"))
                // .Select(c => c.Name);

                long test = Convert.ToInt64(po);
                objItem.LineItems = db.PO_LINEITEM.Where(x => x.POID == test).ToList();

                //model.qtytype = new string[model.RLs.Count()];

                //for (int i = 0; i < model.RLs.Count(); i++)
                //{
                //    byte temp = model.RLs.ElementAt(i).QtyTypeID.Value;
                //    //model.qtytype[i] = db.QTY_TYPE.Where(ve => ve.QtyTypeID == model.RLs.ElementAt(i).QtyTypeID).Select(v => v.QtyTypeDescription).ToString();
                //    //model.qtytype[i] = db.QTY_TYPE.Where(ve => ve.QtyTypeID == model.RLs.ToList().ElementAt(i).QtyTypeID).Select(v => v.QtyTypeDescription).ToString();
                //    //model.qtytype[i] = db.QTY_TYPE.Select(v => v.QtyTypeDescription).Where(v => v.QtyTypeID == temp);
                //    var temp2 = from qt in db.QTY_TYPE where qt.QtyTypeID == temp select qt.QtyTypeDescription;
                //    model.qtytype[i] = temp2.First();
                //}

                objItem.ItemDescription = new string[objItem.LineItems.Count()];

                for (int i = 0; i < objItem.LineItems.Count(); i++)
                {
                    long temp = objItem.LineItems.ElementAt(i).RecRPC;
                    var temp2 = from it in db.ITEMs where it.RecRPC == temp select it.Description;
                    objItem.ItemDescription[i] = temp2.First();
                }

                // return new PurchaseOrderController().POSummary(int.Parse(po));
                return View("Index", objItem);
                // return View("Index");
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Update a non-received receiving log as received
        /// </summary>
        /// <param name="objItem">ReceivingLogCreationViewModel</param>
        /// <param name="POID">Purchase Order ID</param>
        /// <returns>ActionResult CreateReceived</returns>
        [HttpPost]
        public ActionResult CreateReceived(ReceivingLogCreationViewModel objItem, string POID)
        {
            try
            {
                //DataFetcherSetter dbfs = new DataFetcherSetter();

                //Why does the LineItem portion come back null?
                //objItem.LineItems = dbfs.ListLineItemsForPO(int.Parse(POID));
                //objItem.LineItems = db.PO_LINEITEM.Where(x => x.POID == Convert.ToInt64(POID)).ToList();

                long test = Convert.ToInt64(POID);
                //long test = Convert.ToInt64(ViewBag.CurrentPO);
                objItem.LineItems = db.PO_LINEITEM.Where(x => x.POID == test).ToList();

                List<int> tracker = new List<int>();

                foreach (RECEIVING_LOG RLog in objItem.RL)
                {
                    RECEIVING_LOG NewRL = new RECEIVING_LOG();

                    NewRL.POLineItemID = RLog.POLineItemID;
                    //NewRL.QtyTypeID = Convert.ToInt16(RLog.QtyTypeID.ToString());
                    NewRL.QtyTypeID = Convert.ToByte(RLog.QtyTypeID.ToString());

                    if (RLog.ReceiveDate.ToString() != "")
                    {
                        if (RLog.ReceiveDate > DateTime.Now.Date)
                        {
                            //ModelState.AddModelError("RL.ReceiveDate", "Cannot enter a future date.");
                            //ModelState.AddModelError(objItem.RL[objItem.RL.IndexOf(RLog)].ReceiveDate, "Cannot enter a future date.");
                        }
                        else
                        {
                            //NewRL.ReceiveDate = RLog.ReceiveDate;
                            Convert.ToDateTime(NewRL.ReceiveDate = RLog.ReceiveDate);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("RL.ReceiveDate", "Please enter a date");
                    }

                    if (RLog.ReceivedQty.ToString() != "")
                    {
                        if (RLog.ReceivedQty < 0)
                        {
                            ModelState.AddModelError("RL.ReceivedQty", "Cannot enter a negative amount.");
                        }
                        else
                        {
                            NewRL.ReceivedQty = Convert.ToInt16(RLog.ReceivedQty.ToString());
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("RL.ReceivedQty", "Please enter an amount.");
                    }

                    NewRL.ReceivingNotes = RLog.ReceivingNotes + "";

                    if (ModelState.IsValid)
                    {
                        //db.NewReceivingLog(NewRL.POLineItemID,
                        //    NewRL.QtyTypeID, NewRL.ReceiveDate,
                        //    NewRL.ReceivingNotes, NewRL.ReceivedQty);

                        db.RECEIVING_LOG.Add(NewRL);
                        db.SaveChanges();

                        //objItem.LineItems.RemoveAt(objItem.RL.IndexOf(RLog));
                        //int tester = objItem.RL.IndexOf(RLog);
                        //objItem.RL.Remove(RLog);
                        tracker.Add(objItem.RL.IndexOf(RLog));
                    }

                }

                for (int j = tracker.Count - 1; j >= 0; j--)
                //for (int j = 0; j < tracker.Count; j++)
                {
                    //objItem.LineItems.RemoveAt(tracker.ElementAt(j));
                    objItem.LineItems.RemoveAt(tracker[j]);
                    //objItem.RL.RemoveAt(tracker.ElementAt(j));
                    objItem.RL.RemoveAt(tracker[j]);
                }

                if (objItem.RL.Count < 1)
                {
                    //return View("Index");
                    //return View();
                    //return View(Index());
                    //return View("Index", objItem);
                    //return View("Index", null);
                    //objItem = null;
                    //return View("Index");
                    //return this.Index();
                    return GetNonReceivedPOs();
                }
                else
                    return View("Index", objItem);
                //return View(objItem);

                //return View("Index");
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        //[HttpPost]
        //public ActionResult MarkedReceived(int QtyReceived)
        //{
        //    return View();
        //}

        //[HttpPost]
        ////public ActionResult Index(List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem, int QtyReceived)
        ////public ActionResult Index(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem, DateTime ReceivedDate, ushort QtyReceived, string Notes)
        ////public ActionResult MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem, string ReceivedDate, ushort QtyReceived, string Notes)
        ////public void MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem, string ReceivedDate, ushort QtyReceived, string Notes)
       
        //    //public void MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem, string ReceivedDate, short QtyReceived, string Notes)
        ////public void MarkedReceived(FormCollection form, string ReceivedDate, short QtyReceived, string Notes)
        ////public void MarkedReceived(FormCollection form)
        
        //public ActionResult MarkedReceived(FormCollection form)
        ////public void MarkedReceived(FormCollection form)
        ////public ActionResult MarkedReceived(FormCollection form, List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem)
        ////public ActionResult MarkedReceived(List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem, FormCollection form)
        
        //    // public ActionResult MarkedReceived(FormCollection form, string ReceivedDate, short QtyReceived, string Notes)
        
        //    //public void MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem item, string ReceivedDate, short QtyReceived, string Notes)
        ////public void MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem itemName, string ReceivedDate, short QtyReceived, string Notes)
        ////public void MarkedReceived(string itemName, string ReceivedDate, short QtyReceived, string Notes)  //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem>
        ////public void MarkedReceived(List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem, int cindex, string ReceivedDate, short QtyReceived, string Notes)
        //{
        //    try
        //    {
        //        List<RecOutletWarehouse.Models.RECEIVING_LOG> Errored = new List<RecOutletWarehouse.Models.RECEIVING_LOG>();
        //        //FormCollection EForms = new FormCollection();

        //        //create local copy of objItem, if it has value pass it instead
        //        //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> tester = objItem; //keeps returning null
        //        DataFetcherSetter dbfs = new DataFetcherSetter();

        //        //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem;
        //        List<PO_LINEITEM> objItem;

        //        //objItem = ListLineItemsForPO(int.Parse(po));
        //        //objItem = dbfs.ListLineItemsForPO(int.Parse(form["POID" + 1].ToString()));
        //        objItem = db.PO_LINEITEM.Where(x => x.POID == Convert.ToInt64(form["POID" + 1].ToString())).ToList();

        //        //int tester = ModelState.Count;  //0

        //        //if (QtyReceived != null)  //do test on the page!
        //        //{
        //        //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> item = objItem;
        //        //RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem = item;

        //        // RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem itemr = objItem[1];

        //        //RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem = Model[cindex];
        //        // RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem itemName = objItem[cindex];

        //        //Console.Out.WriteLine(form["count"].ToString());
        //        //String test1 = form["count"].ToString();

        //        for (int i = 1; i < Convert.ToInt16(form["count"].ToString()); i++) //count is already incremented 1 to many times
        //        {
        //            //Console.Out.WriteLine("attempting form " + i);
        //            //String test2 = form["count"].ToString();

        //            RECEIVING_LOG RL = new RECEIVING_LOG();

        //            //NewReceivingLog(RL.ReceivingID,
        //            //    RL.POLineItemID, RL.BackorderID,
        //            //    RL.QtyTypeID, RL.ReceiveDate,
        //            //    RL.ReceivingNotes, RL.ReceivedQty);

        //            // RL.POLineItemID = int.Parse(objItem.POLineItem.ToString());
        //            //RL.POLineItemID = objItem.POLineItem;
        //            //RL.POLineItemID = Convert.ToInt32(form.GetValue("POLineItem"));
        //            //RL.POLineItemID = form.
        //            //RL.POLineItemID = Convert.ToInt32(form.GetValue("POLineItem").ToString());
        //            //String test3 = form["POLineItem" + i].ToString();
        //            //if(form["POLineItem" + i].ToString() 
        //            RL.POLineItemID = Convert.ToInt32(form["POLineItem" + i].ToString());

        //            //RL.POLineItemID = itemName.POLineItem;
        //            //RL.BackorderID

        //            //if(
        //            int tester = ModelState.Count;

        //            //RL.QtyTypeID = objItem.QtyTypeId;
        //            //RL.QtyTypeID = Convert.ToInt16(form.GetValue("QtyTypeID").ToString());

        //            //RL.QtyTypeID = Convert.ToInt16(form["QtyTypeID" + i].ToString());

        //            //RL.QtyTypeID = itemName.QtyTypeId;
        //            //RL.ReceiveDate = Convert.ToDateTime(ReceivedDate);
        //            if (form["ReceivedDate" + i].ToString() != "")
        //            {
        //                if (Convert.ToDateTime(form["ReceivedDate" + i].ToString()) > DateTime.Now.Date)
        //                {
        //                    ModelState.AddModelError("RL.ReceivedDate" + (Errored.Count + 1), "Cannot enter furture date");
        //                    //objItem[i].POID.
        //                    //ModelState.AddModelError(ModelState.ElementAt(i).ToString(), "bladsfasdf");

        //                }
        //                else
        //                {
        //                    RL.ReceiveDate = Convert.ToDateTime(form["ReceivedDate" + i].ToString());
        //                }
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("RL.ReceivedDate" + (Errored.Count + 1), "Please enter a date");
        //            }

        //            //RL.ReceivingNotes = Notes;
        //            RL.ReceivingNotes = form["Notes" + i].ToString();
        //            //RL.ReceivedQty = QtyReceived;   //sooo have to make sure they don't put in something funky

        //            if (form["QtyReceived" + i].ToString() != "")
        //            {
        //                if (Convert.ToInt16(form["QtyReceived" + i].ToString()) < 0)
        //                {
        //                    ModelState.AddModelError("RL.QtyReceived" + (Errored.Count + 1), "Cannot enter a negative amount.");
        //                }
        //                else
        //                {
        //                    RL.ReceivedQty = Convert.ToInt16(form["QtyReceived" + i].ToString());
        //                }
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("RL.QtyReceived" + (Errored.Count + 1), "Please enter an amount. Enter 0 if none received.");
        //            }



        //            //}

        //            //return View("Index", RL);
        //            //    return View("Index");
        //            //return View("CreateNewRL", RL);

        //            //if (!ModelState.IsValid)
        //            //{
        //            //    //return View("Index", objItem);
        //            //    return View("Index", form);
        //            //}
        //            //else
        //            if (ModelState.IsValid)
        //            {

        //                //DataFetcherSetter db = new DataFetcherSetter();

        //                //db.NewReceivingLog(//RL.ReceivingID,
        //                //    RL.POLineItemID, RL.BackorderID,
        //                //    RL.QtyTypeID, RL.ReceiveDate,
        //                //    RL.ReceivingNotes, RL.ReceivedQty);

        //                //Will need to handle backorder stuff
        //                //db.NewReceivingLog(//RL.ReceivingID,
        //                //    RL.POLineItemID,
        //                //    RL.QtyTypeID, RL.ReceiveDate,
        //                //    RL.ReceivingNotes, RL.ReceivedQty);

        //                db.RECEIVING_LOG.Add(RL);
        //                db.SaveChanges();

        //                //EForms.Add("POID", form["POID"].ToString());
        //                //EForms.Add("RecRPC" + EForms.Count, form["RecRPC" + i].ToString());
        //                //EForms.Add("QtyOrdered" + EForms.Count, form["QtyOrdered" + i].ToString());
        //                //EForms.Add("QtyTypeId" + EForms.Count, form["QtyTypeId" + i].ToString());
        //                //ViewBag.POID = form["POID"].ToString();
        //                //ViewBag.["RecRPC" + Errored.Count] = form["RecRPC" + i].ToString();

        //                form[i].Remove(i);
        //                Errored.Add(RL);

        //                objItem.RemoveAt(i);
        //            }

        //        }

        //        // return View("Index");
        //        //return View("Index", , ReturnErrored)
        //        //ReturnErrored(Errored);
        //        ViewBag.Errored = Errored;
        //        //ViewBag.EForms = EForms;
        //        //return View("Index", Errored);
        //        //return View("Index", form["POID"].ToString());
        //        //return findPO(form["POID" + 1].ToString());
        //        return View("Index", objItem);
        //    }
        //    catch (Exception ex)
        //    {
        //        WarehouseUtilities.LogError(ex);
        //        return RedirectToAction("Error", "Home");
        //    }
        //}

        //public ActionResult ReturnErrored(FormCollection form)
        //public ActionResult ReturnErrored(List<RecOutletWarehouse.Models.ReceivingLog> Errored)
        //{
        //    List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem;

        //    //for (int i = 0; i < form.Count; i++)
        //    //{
        //    //    objItem[i].POID = form[i].
        //    //}



        //    return View("Index");
        //}

        //public ActionResult BrowseReceivingLogs(int page = 1)
        ////public ActionResult BrowseReceivingLogs()
        //{
        //    try
        //    {
        //        // Declare model
        //        BrowseReceivingLogViewModel model;

        //        // Create master list
        //        var logs = from v in db.RECEIVING_LOG
        //                   select v;

        //        // Filter master list to only those members that start with a certain letter
        //        // First letter is defined by rolodex selection in View
        //        // For now, we want it to only filter if there is no search query

        //        //if (!String.IsNullOrEmpty(firstLetter) && String.IsNullOrEmpty(venNameSearch))
        //        //{
        //        //    logs = logs.Where(v => v.VendorName.ToUpper().StartsWith(firstLetter));
        //        //}

        //        // IF the user doesn't provide a search query...
                
        //        model = new BrowseReceivingLogViewModel
        //        {
        //            RLs = logs
        //                        .OrderBy(v => v.ReceiveDate),
        //            //.Skip((page - 1) * BrowsePageSize)
        //            //.Take(BrowsePageSize),
        //            PagingInfo = new PagingInfo
        //            {
        //                CurrentPage = page,
        //                ItemsPerPage = BrowsePageSize,
        //                TotalItems = logs.Count() // Get the count of the FILTERED list
        //            },
        //            //startLetter = firstLetter // The starting letter needs to be passed to the View
        //            // so the View can pass it back to the Controller.
        //            // If not included, pagination will not work correctly.
        //        };
               
        //        return View(model);
        //    }
        //    catch (Exception ex)
        //    {
        //        WarehouseUtilities.LogError(ex);
        //        return RedirectToAction("Error", "Home");
        //    }
        //}

        //public ActionResult BrowseVendors(string venNameSearch, string firstLetter, int page = 1)
        //public ActionResult BrowseReceivingLogs(int page = 1)
        //? means nullable. Can't do it to a string though...
        public ActionResult BrowseReceivingLogs(DateTime? receiveDate, String receivingLogID, int page = 1)
        //public ActionResult BrowseReceivingLogs()
        {
            try
            {
                // Declare model
                BrowseReceivingLogViewModel model;

                // Create master list
                var logs = from v in db.RECEIVING_LOG
                              select v;

                //model.qtytype = new string[logs.Count()];
                // Filter master list to only those members that start with a certain letter
                // First letter is defined by rolodex selection in View
                // For now, we want it to only filter if there is no search query
                
                //if (!String.IsNullOrEmpty(firstLetter) && String.IsNullOrEmpty(venNameSearch))
                //{
                //    logs = logs.Where(v => v.VendorName.ToUpper().StartsWith(firstLetter));
                //}

                // IF the user doesn't provide a search query...
                //as first instantiation doesn't make receivingLogID an object
                //if ( receivingLogID == null || (String.IsNullOrEmpty(receiveDate.ToString()) && String.IsNullOrEmpty(receivingLogID.ToString())))
                if( receivingLogID == null && String.IsNullOrEmpty(receiveDate.ToString()) )
                {
                    model = new BrowseReceivingLogViewModel
                    {
                        RLs = logs
                                  .OrderBy(v => v.ReceiveDate),
                                  //.Skip((page - 1) * BrowsePageSize)
                                  //.Take(BrowsePageSize),
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = BrowsePageSize,
                            TotalItems = logs.Count() // Get the count of the FILTERED list
                        },
                        //startLetter = firstLetter // The starting letter needs to be passed to the View
                        // so the View can pass it back to the Controller.
                        // If not included, pagination will not work correctly.

                        //qtytype[0] = db.QTY_TYPE.Where(ve => ve.QtyTypeID == model.RLs.ElementAt(1).QtyTypeID).Select(v => v.QtyTypeDescription).ToString(),

                    };

                    //model.qtytype[0] = db.QTY_TYPE.Where(ve => ve.QtyTypeID == model.RLs.ElementAt(1).QtyTypeID).Select(v => v.QtyTypeDescription).ToString();
                    //model.qtytype = db.QTY_TYPE.Where(ve => ve.QtyTypeID == model.RLs.All().QtyTypeID).Select(v => v.QtyTypeDescription).ToList();
                    model.qtytype = new string[model.RLs.Count()];

                    for (int i = 0; i < model.RLs.Count(); i++)
                    {
                        byte temp = model.RLs.ElementAt(i).QtyTypeID.Value;
                        //model.qtytype[i] = db.QTY_TYPE.Where(ve => ve.QtyTypeID == model.RLs.ElementAt(i).QtyTypeID).Select(v => v.QtyTypeDescription).ToString();
                        //model.qtytype[i] = db.QTY_TYPE.Where(ve => ve.QtyTypeID == model.RLs.ToList().ElementAt(i).QtyTypeID).Select(v => v.QtyTypeDescription).ToString();
                        //model.qtytype[i] = db.QTY_TYPE.Select(v => v.QtyTypeDescription).Where(v => v.QtyTypeID == temp);
                        var temp2 = from qt in db.QTY_TYPE where qt.QtyTypeID == temp select qt.QtyTypeDescription;
                        model.qtytype[i] = temp2.First();
                    }

                    //Better way to do this?
                    model.CreatorIDs = new short[model.RLs.Count()];

                    for (int i = 0; i < model.RLs.Count(); i++)
                    {
                        //short temp = model.RLs.ElementAt(i).PO_LINEITEM.PURCHASE_ORDER.POCreatedBy;
                        int temppl = model.RLs.ElementAt(i).POLineItemID.Value;
                        var temp2 = (from pl in db.PO_LINEITEM
                                     join p in db.PURCHASE_ORDER on pl.POID equals p.POID
                                     where pl.POLineItemID == temppl
                                        select p.POCreatedBy).ToList();
                        model.CreatorIDs[i] = temp2.First();
                    }

                    model.POIDs = new long[model.RLs.Count()];

                    for (int i = 0; i < model.RLs.Count(); i++)
                    {
                        int temppl = model.RLs.ElementAt(i).POLineItemID.Value;
                        var temp2 = (from pl in db.PO_LINEITEM
                                     join p in db.PURCHASE_ORDER on pl.POID equals p.POID
                                     where pl.POLineItemID == temppl
                                     select p.POID).ToList();
                        model.POIDs[i] = temp2.First();
                    }

                    model.RPCs = new long[model.RLs.Count()];

                    for (int i = 0; i < model.RLs.Count(); i++)
                    {
                        //short temp = model.RLs.ElementAt(i).PO_LINEITEM.PURCHASE_ORDER.POCreatedBy;
                        
                        model.RPCs[i] = model.RLs.ElementAt(i).PO_LINEITEM.RecRPC;
                    }

                }
                //// ELSE (the user did provide a vendor name search query)
                else
                {
                    if (!String.IsNullOrEmpty(receivingLogID.ToString()))
                    //if (receivingLogID != null)
                    {
                        int temp = Convert.ToInt32(receivingLogID);

                        model = new BrowseReceivingLogViewModel
                        {

                            RLs = logs
                                      //.Where(ve => ve.ReceivingID.Equals(receivingLogID)) // Further filter the list to items that contain the search
                                      //.Where(ve => ve.ReceivingID == Convert.ToInt32(receivingLogID.ToString()))
                                      .Where(ve => ve.ReceivingID == temp)
                                      .ToList(),
                            PagingInfo = new PagingInfo
                            {
                                CurrentPage = page,
                                ItemsPerPage = BrowsePageSize,
                                //TotalItems = logs.Where(ve => ve.VendorName.ToUpper().Contains(venNameSearch.ToUpper())).Count() // Again, we want the count to take our filters into account
                                TotalItems = 1
                            },
                            search = receivingLogID
                            //startLetter = firstLetter // Leaving out -- it gives results the user might not expect

                        };

                        model.qtytype = new string[model.RLs.Count()];

                        for (int i = 0; i < model.RLs.Count(); i++)
                        {
                            model.qtytype[i] = db.QTY_TYPE.Where(ve => ve.QtyTypeID == model.RLs.ElementAt(i).QtyTypeID).Select(v => v.QtyTypeDescription).ToString();
                        }

                        model.CreatorIDs = new short[model.RLs.Count()];

                        for (int i = 0; i < model.RLs.Count(); i++)
                        {
                            //short temp = model.RLs.ElementAt(i).PO_LINEITEM.PURCHASE_ORDER.POCreatedBy;
                            int temppl = model.RLs.ElementAt(i).POLineItemID.Value;
                            var temp2 = (from pl in db.PO_LINEITEM
                                         join p in db.PURCHASE_ORDER on pl.POID equals p.POID
                                         where pl.POLineItemID == temppl
                                         select p.POCreatedBy).ToList();
                            model.CreatorIDs[i] = temp2.First();
                        }

                        model.POIDs = new long[model.RLs.Count()];

                        for (int i = 0; i < model.RLs.Count(); i++)
                        {
                            int temppl = model.RLs.ElementAt(i).POLineItemID.Value;
                            var temp2 = (from pl in db.PO_LINEITEM
                                         join p in db.PURCHASE_ORDER on pl.POID equals p.POID
                                         where pl.POLineItemID == temppl
                                         select p.POID).ToList();
                            model.POIDs[i] = temp2.First();
                        }

                        model.RPCs = new long[model.RLs.Count()];

                        for (int i = 0; i < model.RLs.Count(); i++)
                        {
                            //short temp = model.RLs.ElementAt(i).PO_LINEITEM.PURCHASE_ORDER.POCreatedBy;

                            model.RPCs[i] = model.RLs.ElementAt(i).PO_LINEITEM.RecRPC;
                        }
                    }
                    else
                    {
                        model = new BrowseReceivingLogViewModel
                        {

                            RLs = logs
                                      .Where(ve => ve.ReceiveDate == receiveDate) // Further filter the list to items that contain the search
                                      .OrderBy(ve => ve.ReceivingID)
                                      //.Skip((page - 1) * BrowsePageSize)
                                      .ToList(),
                            PagingInfo = new PagingInfo
                            {
                                CurrentPage = page,
                                ItemsPerPage = BrowsePageSize,
                                //TotalItems = logs.Where(ve => ve.VendorName.ToUpper().Contains(venNameSearch.ToUpper())).Count() // Again, we want the count to take our filters into account
                                TotalItems = logs.Where(ve => ve.ReceiveDate == receiveDate).Count()
                            },
                            search = receiveDate.ToString()
                            //startLetter = firstLetter // Leaving out -- it gives results the user might not expect

                        };

                        model.qtytype = new string[model.RLs.Count()];

                        for (int i = 0; i < model.RLs.Count(); i++)
                        {
                            model.qtytype[i] = db.QTY_TYPE.Where(ve => ve.QtyTypeID == model.RLs.ElementAt(i).QtyTypeID).Select(v => v.QtyTypeDescription).ToString();
                        }

                        model.CreatorIDs = new short[model.RLs.Count()];

                        for (int i = 0; i < model.RLs.Count(); i++)
                        {
                            //short temp = model.RLs.ElementAt(i).PO_LINEITEM.PURCHASE_ORDER.POCreatedBy;
                            int temppl = model.RLs.ElementAt(i).POLineItemID.Value;
                            var temp2 = (from pl in db.PO_LINEITEM
                                         join p in db.PURCHASE_ORDER on pl.POID equals p.POID
                                         where pl.POLineItemID == temppl
                                         select p.POCreatedBy).ToList();
                            model.CreatorIDs[i] = temp2.First();
                        }

                        model.POIDs = new long[model.RLs.Count()];

                        for (int i = 0; i < model.RLs.Count(); i++)
                        {
                            int temppl = model.RLs.ElementAt(i).POLineItemID.Value;
                            var temp2 = (from pl in db.PO_LINEITEM
                                         join p in db.PURCHASE_ORDER on pl.POID equals p.POID
                                         where pl.POLineItemID == temppl
                                         select p.POID).ToList();
                            model.POIDs[i] = temp2.First();
                        }

                        model.RPCs = new long[model.RLs.Count()];

                        for (int i = 0; i < model.RLs.Count(); i++)
                        {
                            //short temp = model.RLs.ElementAt(i).PO_LINEITEM.PURCHASE_ORDER.POCreatedBy;

                            model.RPCs[i] = model.RLs.ElementAt(i).PO_LINEITEM.RecRPC;
                        }
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }
    }
}

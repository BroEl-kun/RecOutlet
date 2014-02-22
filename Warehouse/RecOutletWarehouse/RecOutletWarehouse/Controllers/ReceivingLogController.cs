using RecOutletWarehouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecOutletWarehouse.Models;
using RecOutletWarehouse.Utilities;

namespace RecOutletWarehouse.Controllers
{
    public class ReceivingLogController : Controller
    {
        public RecreationOutletContext db = new RecreationOutletContext();

        public class ReceivingLogCreationViewModel
        {
            public List<RecOutletWarehouse.Models.RECEIVING_LOG> RL { get; set; }
            public List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> LineItems { get; set; }
        }

        //
        // GET: /ReceivingLog/

        public ActionResult Index()
        {
            try
            {
                DataFetcherSetter dbfs = new DataFetcherSetter();

                List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrder> objItem = new List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrder>();

                //Why does the LineItem portion come back null?
                objItem = dbfs.GetNonReceivedPOs();

                ViewBag.NonReceivedPOs = objItem;

                return View();
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        //
        // GET: /ReceivingLog/Details/5

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

        //public ActionResult Create()
        public ActionResult CreateNewRL()
        {
            try
            {
                DataFetcherSetter dbfs = new DataFetcherSetter();

                List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrder> objItem = new List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrder>();

                //Why does the LineItem portion come back null?
                objItem = dbfs.GetNonReceivedPOs();

                ViewBag.NonReceivedPOs = objItem;

                //return View();
                return View("Index");
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        //
        // POST: /ReceivingLog/Create

        [HttpPost]
        //public ActionResult Create(ReceivingLog RL)
        public ActionResult CreateNewRL(RECEIVING_LOG RL)
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
            try
            {
                if (!ModelState.IsValid)
                {
                    //return View(RL);
                    //return View("Index", RL);
                    return View("Index");
                }
                else
                {
                    //DataFetcherSetter db = new DataFetcherSetter();

                    //db.NewReceivingLog(//RL.ReceivingID,
                    //    RL.POLineItemID, RL.BackorderID,
                    //    RL.QtyTypeID, RL.ReceiveDate,
                    //    RL.ReceivingNotes, RL.ReceivedQty);

                    db.RECEIVING_LOG.Add(RL);
                    db.SaveChanges();

                    //return View("CreateNewRL");
                    return View("Index");
                    //return View(RL);
                }
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        //
        // GET: /ReceivingLog/Edit/5

        public ActionResult Edit(int id)
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
        // POST: /ReceivingLog/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                //return View();
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        //
        // GET: /ReceivingLog/Delete/5

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
            catch (Exception ex)
            {
                //return View();
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

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
                DataFetcherSetter db = new DataFetcherSetter();

                //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem;
                ReceivingLogCreationViewModel objItem = new ReceivingLogCreationViewModel();

                //objItem = ListLineItemsForPO(int.Parse(po));
                //objItem = db.ListLineItemsForPO(int.Parse(po));
                objItem.LineItems = db.ListLineItemsForPO(int.Parse(po));

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

        [HttpPost]
        public ActionResult CreateReceived(ReceivingLogCreationViewModel objItem, string POID)
        {
            try
            {
                DataFetcherSetter dbfs = new DataFetcherSetter();

                //Why does the LineItem portion come back null?
                objItem.LineItems = dbfs.ListLineItemsForPO(int.Parse(POID));

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
                            NewRL.ReceiveDate = RLog.ReceiveDate;
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
                    return View("Index");
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

        [HttpPost]
        //public ActionResult Index(List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem, int QtyReceived)
        //public ActionResult Index(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem, DateTime ReceivedDate, ushort QtyReceived, string Notes)
        //public ActionResult MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem, string ReceivedDate, ushort QtyReceived, string Notes)
        //public void MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem, string ReceivedDate, ushort QtyReceived, string Notes)
       
            //public void MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem, string ReceivedDate, short QtyReceived, string Notes)
        //public void MarkedReceived(FormCollection form, string ReceivedDate, short QtyReceived, string Notes)
        //public void MarkedReceived(FormCollection form)
        
        public ActionResult MarkedReceived(FormCollection form)
        //public void MarkedReceived(FormCollection form)
        //public ActionResult MarkedReceived(FormCollection form, List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem)
        //public ActionResult MarkedReceived(List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem, FormCollection form)
        
            // public ActionResult MarkedReceived(FormCollection form, string ReceivedDate, short QtyReceived, string Notes)
        
            //public void MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem item, string ReceivedDate, short QtyReceived, string Notes)
        //public void MarkedReceived(RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem itemName, string ReceivedDate, short QtyReceived, string Notes)
        //public void MarkedReceived(string itemName, string ReceivedDate, short QtyReceived, string Notes)  //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem>
        //public void MarkedReceived(List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem, int cindex, string ReceivedDate, short QtyReceived, string Notes)
        {
            try
            {
                List<RecOutletWarehouse.Models.RECEIVING_LOG> Errored = new List<RecOutletWarehouse.Models.RECEIVING_LOG>();
                //FormCollection EForms = new FormCollection();

                //create local copy of objItem, if it has value pass it instead
                //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> tester = objItem; //keeps returning null
                DataFetcherSetter dbfs = new DataFetcherSetter();

                List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> objItem;

                //objItem = ListLineItemsForPO(int.Parse(po));
                objItem = dbfs.ListLineItemsForPO(int.Parse(form["POID" + 1].ToString()));

                //int tester = ModelState.Count;  //0

                //if (QtyReceived != null)  //do test on the page!
                //{
                //List<RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem> item = objItem;
                //RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem = item;

                // RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem itemr = objItem[1];

                //RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem objItem = Model[cindex];
                // RecOutletWarehouse.Models.PurchaseOrder.PurchaseOrderLineItem itemName = objItem[cindex];

                //Console.Out.WriteLine(form["count"].ToString());
                //String test1 = form["count"].ToString();

                for (int i = 1; i < Convert.ToInt16(form["count"].ToString()); i++) //count is already incremented 1 to many times
                {
                    //Console.Out.WriteLine("attempting form " + i);
                    //String test2 = form["count"].ToString();

                    RECEIVING_LOG RL = new RECEIVING_LOG();

                    //NewReceivingLog(RL.ReceivingID,
                    //    RL.POLineItemID, RL.BackorderID,
                    //    RL.QtyTypeID, RL.ReceiveDate,
                    //    RL.ReceivingNotes, RL.ReceivedQty);

                    // RL.POLineItemID = int.Parse(objItem.POLineItem.ToString());
                    //RL.POLineItemID = objItem.POLineItem;
                    //RL.POLineItemID = Convert.ToInt32(form.GetValue("POLineItem"));
                    //RL.POLineItemID = form.
                    //RL.POLineItemID = Convert.ToInt32(form.GetValue("POLineItem").ToString());
                    //String test3 = form["POLineItem" + i].ToString();
                    //if(form["POLineItem" + i].ToString() 
                    RL.POLineItemID = Convert.ToInt32(form["POLineItem" + i].ToString());

                    //RL.POLineItemID = itemName.POLineItem;
                    //RL.BackorderID

                    //if(
                    int tester = ModelState.Count;

                    //RL.QtyTypeID = objItem.QtyTypeId;
                    //RL.QtyTypeID = Convert.ToInt16(form.GetValue("QtyTypeID").ToString());

                    //RL.QtyTypeID = Convert.ToInt16(form["QtyTypeID" + i].ToString());

                    //RL.QtyTypeID = itemName.QtyTypeId;
                    //RL.ReceiveDate = Convert.ToDateTime(ReceivedDate);
                    if (form["ReceivedDate" + i].ToString() != "")
                    {
                        if (Convert.ToDateTime(form["ReceivedDate" + i].ToString()) > DateTime.Now.Date)
                        {
                            ModelState.AddModelError("RL.ReceivedDate" + (Errored.Count + 1), "Cannot enter furture date");
                            //objItem[i].POID.
                            //ModelState.AddModelError(ModelState.ElementAt(i).ToString(), "bladsfasdf");

                        }
                        else
                        {
                            RL.ReceiveDate = Convert.ToDateTime(form["ReceivedDate" + i].ToString());
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("RL.ReceivedDate" + (Errored.Count + 1), "Please enter a date");
                    }

                    //RL.ReceivingNotes = Notes;
                    RL.ReceivingNotes = form["Notes" + i].ToString();
                    //RL.ReceivedQty = QtyReceived;   //sooo have to make sure they don't put in something funky

                    if (form["QtyReceived" + i].ToString() != "")
                    {
                        if (Convert.ToInt16(form["QtyReceived" + i].ToString()) < 0)
                        {
                            ModelState.AddModelError("RL.QtyReceived" + (Errored.Count + 1), "Cannot enter a negative amount.");
                        }
                        else
                        {
                            RL.ReceivedQty = Convert.ToInt16(form["QtyReceived" + i].ToString());
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("RL.QtyReceived" + (Errored.Count + 1), "Please enter an amount. Enter 0 if none received.");
                    }



                    //}

                    //return View("Index", RL);
                    //    return View("Index");
                    //return View("CreateNewRL", RL);

                    //if (!ModelState.IsValid)
                    //{
                    //    //return View("Index", objItem);
                    //    return View("Index", form);
                    //}
                    //else
                    if (ModelState.IsValid)
                    {

                        //DataFetcherSetter db = new DataFetcherSetter();

                        //db.NewReceivingLog(//RL.ReceivingID,
                        //    RL.POLineItemID, RL.BackorderID,
                        //    RL.QtyTypeID, RL.ReceiveDate,
                        //    RL.ReceivingNotes, RL.ReceivedQty);

                        //Will need to handle backorder stuff
                        //db.NewReceivingLog(//RL.ReceivingID,
                        //    RL.POLineItemID,
                        //    RL.QtyTypeID, RL.ReceiveDate,
                        //    RL.ReceivingNotes, RL.ReceivedQty);

                        db.RECEIVING_LOG.Add(RL);
                        db.SaveChanges();

                        //EForms.Add("POID", form["POID"].ToString());
                        //EForms.Add("RecRPC" + EForms.Count, form["RecRPC" + i].ToString());
                        //EForms.Add("QtyOrdered" + EForms.Count, form["QtyOrdered" + i].ToString());
                        //EForms.Add("QtyTypeId" + EForms.Count, form["QtyTypeId" + i].ToString());
                        //ViewBag.POID = form["POID"].ToString();
                        //ViewBag.["RecRPC" + Errored.Count] = form["RecRPC" + i].ToString();

                        form[i].Remove(i);
                        Errored.Add(RL);

                        objItem.RemoveAt(i);
                    }

                }

                // return View("Index");
                //return View("Index", , ReturnErrored)
                //ReturnErrored(Errored);
                ViewBag.Errored = Errored;
                //ViewBag.EForms = EForms;
                //return View("Index", Errored);
                //return View("Index", form["POID"].ToString());
                //return findPO(form["POID" + 1].ToString());
                return View("Index", objItem);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

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
    }
}

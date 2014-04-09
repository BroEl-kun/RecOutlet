using RecOutletWarehouse.Models;
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
        /// This composite model is used primarily with any view
        /// regarding the creation process of a Receiving Log
        /// </summary>
        public class ReceivingLogCreationViewModel
        {
            //List of Receiving Log Models
            public List<RECEIVING_LOG> RL { get; set; }
            //Used to help carry over item descriptions as not stored in the model
            public string[] ItemDescription { get; set; }
            //The line items to be received
            public List<PO_LINEITEM> LineItems { get; set; }
        }

        /// <summary>
        /// A composite model used to display information 
        /// in views regarding searching and browsing of
        /// receiving logs
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

        /// <summary>
        /// Calls GetNonReceivedPOs (below) and returns the filled model
        /// to the view for display
        /// </summary>
        /// <returns>View Model</returns>
        public ActionResult Index()
        {
            try
            {
                
                return GetNonReceivedPOs();
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Fills a list of PURCHASE_ORDER models with the
        /// Purchase Orders that have no yet been completely
        /// received, which is then used the PO Table of Index.cshtml (View)
        /// </summary>
        /// <returns>Index View with a PO List</returns>
        /// ChangeLog:
        ///     
        public ActionResult GetNonReceivedPOs()
        {
            List<PURCHASE_ORDER> objItem = new List<PURCHASE_ORDER>();

            //Will be used to filter out any POs already fully received
            var cte = (from P in db.PURCHASE_ORDER
                       join PL in db.PO_LINEITEM on P.POID equals PL.POID
                       join RL in db.RECEIVING_LOG on PL.POLineItemID equals RL.POLineItemID
                       where PL.QtyOrdered == RL.ReceivedQty
                       select P).Distinct();
            
            //Will be used to find distinct POs with line items
            var temp = (from P in db.PURCHASE_ORDER
                        join PL in db.PO_LINEITEM on P.POID equals PL.POID
                        select P).Distinct();

            //Purpose: Get POs with line items still needing to be received (top 50 oldest POs - Most likely in need of receiving)
            objItem = db.PURCHASE_ORDER.Where(x => !cte.Any(m => m.POID == x.POID) && temp.Any(n => n.POID == x.POID)).OrderBy(p => p.POOrderDate).Take(50).ToList();

            ViewBag.NonReceivedPOs = objItem;

            return View("Index");
        }

        //
        // GET: /ReceivingLog/Details/5

        /// <summary>
        /// Currently unused
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// ChangeLog:
        ///     
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
        // GET: /ReceivingLog/Edit/5

        /// <summary>
        /// Basic edit function to replace changed receiving log in the database
        /// utilizing the ViewBag container and only passing the ID
        /// </summary>
        /// <param name="id">ID of the receiving log to be changed</param>
        /// <returns>Index View</returns>
        /// ChangeLog:
        ///     
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

        /// <summary>
        /// POST method for the Edit function for when a whole receiving 
        /// log is passed back to the controller
        /// </summary>
        /// <param name="log">The updated receiving log</param>
        /// <returns>Index View</returns>
        /// ChangeLog:
        ///     
        [HttpPost]
        public ActionResult EditRL(ReceivingLogCreationViewModel log)
        {
            try
            {
                RECEIVING_LOG updtrlog = log.RL[0];

                db.Entry(updtrlog).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index"); 
            }
            catch(Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        //
        // GET: /ReceivingLog/Delete/5

        /// <summary>
        /// DELETE method for receiving logs.
        /// Currently unused, they should instead only be deactivated
        /// in the database
        /// </summary>
        /// <param name="id">ID of receiving log</param>
        /// <returns>Index View</returns>
        /// ChangeLog:
        ///     
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
                // TODO: Add delete(inactivate) logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //return View();
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// Gets the line items and their descritions for the PO provided
        /// </summary>
        /// <param name="po">Purchase Order selected</param>
        /// <returns>ReceivingLogCreationViewModel</returns>
        /// ChangeLog:
        ///     
        [HttpPost]
        public ActionResult findPO(string po)
        {
            try
            {
                //need to find the PO from the db
                //then populate with the line items
                //then be able to add values for each line item

                ViewBag.CurrentPO = po;

                ReceivingLogCreationViewModel objItem = new ReceivingLogCreationViewModel();

                //Finds the line items for the provided PO
                long test = Convert.ToInt64(po);
                objItem.LineItems = db.PO_LINEITEM.Where(x => x.POID == test).ToList();

                //Finds the descriptions for the line items
                objItem.ItemDescription = new string[objItem.LineItems.Count()];

                for (int i = 0; i < objItem.LineItems.Count(); i++)
                {
                    long temp = objItem.LineItems.ElementAt(i).RecRPC;
                    var temp2 = from it in db.ITEMs where it.RecRPC == temp select it.Description;
                    objItem.ItemDescription[i] = temp2.First();
                }

                return View("Index", objItem);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// TODO: find bugs
        /// </summary>
        /// <param name="objItem"></param>
        /// <param name="POID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateReceived(ReceivingLogCreationViewModel objItem, string POID)
        {
            try
            {
                long test = Convert.ToInt64(POID);
                objItem.LineItems = db.PO_LINEITEM.Where(x => x.POID == test).ToList();

                List<int> tracker = new List<int>();

                foreach (RECEIVING_LOG RLog in objItem.RL)
                {
                    RECEIVING_LOG NewRL = new RECEIVING_LOG();

                    NewRL.POLineItemID = RLog.POLineItemID;
                    NewRL.QtyTypeID = Convert.ToByte(RLog.QtyTypeID.ToString());

                    //CHANGE: these ifs aren't actually working correctly and may not be necessary anyways
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
                    return GetNonReceivedPOs();
                }
                else
                    return View("Index", objItem);
            }
            catch (Exception ex)
            {
                WarehouseUtilities.LogError(ex);
                return RedirectToAction("Error", "Home");
            }
        }

        /// <summary>
        /// TODO: find bugs
        /// </summary>
        /// <param name="receiveDate"></param>
        /// <param name="receivingLogID"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult BrowseReceivingLogs(DateTime? receiveDate, String receivingLogID, int page = 1)
        {
            try
            {
                // Declare model
                BrowseReceivingLogViewModel model;

                // Create master list
                var logs = from v in db.RECEIVING_LOG
                              select v;

                // IF the user doesn't provide a search query...
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

                    };

                    model.qtytype = new string[model.RLs.Count()];

                    for (int i = 0; i < model.RLs.Count(); i++)
                    {
                        byte temp = model.RLs.ElementAt(i).QtyTypeID.Value;
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
                        model.RPCs[i] = model.RLs.ElementAt(i).PO_LINEITEM.RecRPC;
                    }

                }
                //// ELSE (the user did provide a vendor name search query)
                else
                {
                    if (!String.IsNullOrEmpty(receivingLogID.ToString()))
                    {
                        int temp = Convert.ToInt32(receivingLogID);

                        model = new BrowseReceivingLogViewModel
                        {

                            RLs = logs
                                      .Where(ve => ve.ReceivingID == temp)
                                      .ToList(),
                            PagingInfo = new PagingInfo
                            {
                                CurrentPage = page,
                                ItemsPerPage = BrowsePageSize,
                                TotalItems = 1
                            },
                            search = receivingLogID
                            
                        };

                        model.qtytype = new string[model.RLs.Count()];

                        for (int i = 0; i < model.RLs.Count(); i++)
                        {
                            model.qtytype[i] = db.QTY_TYPE.Where(ve => ve.QtyTypeID == model.RLs.ElementAt(i).QtyTypeID).Select(v => v.QtyTypeDescription).ToString();
                        }

                        model.CreatorIDs = new short[model.RLs.Count()];

                        for (int i = 0; i < model.RLs.Count(); i++)
                        {
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
                                      .ToList(),
                            PagingInfo = new PagingInfo
                            {
                                CurrentPage = page,
                                ItemsPerPage = BrowsePageSize,
                                TotalItems = logs.Where(ve => ve.ReceiveDate == receiveDate).Count()
                            },
                            search = receiveDate.ToString()
                            
                        };

                        model.qtytype = new string[model.RLs.Count()];

                        for (int i = 0; i < model.RLs.Count(); i++)
                        {
                            model.qtytype[i] = db.QTY_TYPE.Where(ve => ve.QtyTypeID == model.RLs.ElementAt(i).QtyTypeID).Select(v => v.QtyTypeDescription).ToString();
                        }

                        model.CreatorIDs = new short[model.RLs.Count()];

                        for (int i = 0; i < model.RLs.Count(); i++)
                        {
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

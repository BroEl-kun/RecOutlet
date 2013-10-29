using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using RecOutletWarehouse.Models.PurchaseOrder;

namespace RecOutletWarehouse.Models
{

    /// -----------------------------------------------------------------------------------------------------------------------------
    /// README FIRST!!!!!
    /// <summary>
    /// The DataFetcherSetter class contains all utility methods for working with the database, including INSERT, UPDATE, and DELETE
    /// operations, stored procedures, etc. 
    /// </summary>
    /// To maximize code reusability, do not put database-related methods anywhere else in the project.
    /// PLEASE REMEMBER TO UPDATE THE CHANGELOG CONTAINED IN THE ///summary ... TAGS WHEN YOU MAKE CHANGES TO A METHOD. 
    /// THERE IS A SEPARATE CHANGELOG FOR EACH ONE!
    /// -----------------------------------------------------------------------------------------------------------------------------
    public class DataFetcherSetter
    {
        /// <summary>
        /// This method inserts a purchase order with the supplied attributes into the database.
        /// It should be accessed with a controller method.
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="POID">The Purchase Order ID</param>
        /// <param name="vendorID">The Vendor ID</param>
        /// <param name="POCreateBy">The PO Creation Date</param>
        /// <param name="POOrderDate">The PO Order Date</param>
        /// <param name="POEstShipDate">The PO's Estimated Ship Date</param>
        /// <param name="POFreightCost">The PO's Estimated Freight Cost</param>
        /// <param name="POTerms">The PO's Terms</param>
        /// <param name="POComments">Additional Comments</param>
        /// Changelog:
        /// Version 1.0: 10-25-13 (T.M.)
        /// - Initial Creation
        public void NewPurchaseOrder(int POID, int vendorID, int POCreateBy, DateTime POOrderDate,
                                     DateTime POEstShipDate, decimal POFreightCost, string POTerms,
                                     string POComments) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;
                    command.CommandText = "EXEC dbo.CreatePurchaseOrder "
                                              + "@POID, @vendorID, @POCreateBy, @POOrderDate,"
                                              + "@POEstShipdate, @POFreightCost, @POTerms, @POComments";
                    command.Parameters.AddWithValue("@POID", POID);
                    command.Parameters.AddWithValue("@vendorID", vendorID);
                    command.Parameters.AddWithValue("@POCreateBy", POCreateBy);
                    command.Parameters.AddWithValue("@POOrderDate", POOrderDate);
                    command.Parameters.AddWithValue("@POEstShipDate", POEstShipDate);
                    command.Parameters.AddWithValue("@POFreightCost", POFreightCost);
                    command.Parameters.AddWithValue("@POTerms", POTerms);
                    command.Parameters.AddWithValue("@POComments", POComments);

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                }//.SqlComand
            }//.SqlConnection
        }//.NewPurchaseOrder

        /// <summary>
        /// Creates a PO line item with the specified attributes for the specified PO
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="POID">The PO the line item is to be associated with</param>
        /// <param name="recRPC">The RPC of the item being ordered</param>
        /// <param name="wsCost">The wholesale cost of the item</param>
        /// <param name="qtyOrdered">The quantity to be ordered</param>
        /// <param name="qtyTypeID">The quantity type (NEEDED???)</param>
        /// Changelog:
        ///     Version 1.0: 10-25-13
        ///         - Initial Creation
        public void NewPOLineItemForPO(int POID, long recRPC, decimal wsCost, short qtyOrdered, short qtyTypeID) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;
                    command.CommandText = "EXEC dbo.CreatePOLineItem "
                                              + "@POID, @RecRPC, @WholeSaleCost,"
                                              + "@QtyOrdered, @QtyTypeID";
                    command.Parameters.AddWithValue("@POID", POID);
                    command.Parameters.AddWithValue("@RecRPC", recRPC);
                    command.Parameters.AddWithValue("@WholeSaleCost", wsCost);
                    command.Parameters.AddWithValue("@QtyOrdered", qtyOrdered);
                    command.Parameters.AddWithValue("@QtyTypeID", qtyTypeID);

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                }//.SqlComand
            }//.SqlConnection
        }

        /// <summary>
        /// Retrieves PO information from the database given a PO ID
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="POID">The ID for which information is retrieved</param>
        /// <returns>A PurchaseOrder object with attributes retrieved from the database</returns>
        /// Changelog
        ///     Version 1.0: 10-28-2013 (T.M.)
        ///         - Initial Creation
        public PurchaseOrder.PurchaseOrder RetrievePObyPOID(long POID) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    PurchaseOrder.PurchaseOrder PO = new PurchaseOrder.PurchaseOrder();
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT * FROM PURCHASE_ORDER "
                                        + "WHERE POID = @POID";
                    command.Parameters.AddWithValue("@POID", POID);

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    
                    PO.PurchaseOrderId = POID.ToString();
                    PO.VendorId = Convert.ToInt32(reader["VendorID"].ToString());
                    PO.CreatedBy = Convert.ToInt32(reader["POCreatedBy"].ToString());
                    PO.OrderDate = Convert.ToDateTime(reader["POOrderDate"].ToString());
                    PO.EstShipDate = Convert.ToDateTime(reader["POEstimatedShipDate"].ToString());
                    PO.FreightCost = Convert.ToDecimal(reader["POFreightCost"].ToString());
                    PO.Terms = reader["POTerms"].ToString();
                    PO.Comments = reader["POComments"].ToString();

                    reader.Dispose();
                    command.Parameters.Clear();

                    return PO;
                }

            }
        }

        /// <summary>
        /// Constructs a list of line items associated with a specified PO
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="PO">The PO to which the list of line items are associated</param>
        /// <returns>A list of PurchaseOrderLineItem objects</returns>
        /// Changelog:
        ///     Version 1.0: 10-28-2013 (T.M.)
        ///         - Initial Creation and bugfixes
        public List<PurchaseOrderLineItem> ListLineItemsForPO(int PO) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;

                    command.CommandText = "SELECT * FROM PO_LINEITEM "
                                        + "WHERE POID = @POID";
                    command.Parameters.AddWithValue("@POID", PO);

                    SqlDataReader reader = command.ExecuteReader();

                    List<PurchaseOrderLineItem> LineItemList = new List<PurchaseOrderLineItem>();

                    while (reader.Read()) {
                        LineItemList.Add(new PurchaseOrderLineItem{
                            POID = (reader["POID"].ToString()),
                            RecRPC = Convert.ToInt64(reader["RecRPC"]),
                            WholesaleCost = Convert.ToDecimal(reader["WholesaleCost"]),
                            QtyOrdered = Convert.ToInt16(reader["QtyOrdered"]),
                            QtyTypeId = Convert.ToInt16(reader["QtyTypeID"])
                        });
                    }

                    reader.Dispose();
                    command.Parameters.Clear();

                    return LineItemList;

                }
            }
        }

        public void NewReceivingLog(int ReceivingID, int POLineItemID, int BackorderID, byte QtyTypeID,
                                    DateTime ReceiveDate, string ReceivingNotes, ushort ReceivedQty) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;
                    command.CommandText = "EXEC dbo.CreateReceivingLog "    //Please note this Stored Procedure is not yet made
                                              + "@ReceivingID, @POLineItemID, @BackorderID, @QtyTypeID,"
                                              + "@ReceiveDate, @ReceivingNotes, @ReceivedQty";
                    command.Parameters.AddWithValue("@ReceivingID", ReceivingID);
                    command.Parameters.AddWithValue("@POLineItemID", POLineItemID);
                    command.Parameters.AddWithValue("@BackorderID", BackorderID);
                    command.Parameters.AddWithValue("@QtyTypeID", QtyTypeID);
                    command.Parameters.AddWithValue("@ReceiveDate", ReceiveDate);
                    command.Parameters.AddWithValue("@ReceivingNotes", ReceivingNotes);
                    command.Parameters.AddWithValue("@ReceivedQty", ReceivedQty);

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                }//.SqlComand
            }//.SqlConnection
        }//.NewReceivingLog

    }
}
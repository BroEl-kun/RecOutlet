using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using RecOutletWarehouse.Models.PurchaseOrder;
using RecOutletWarehouse.Models.ItemManagement;
using RecOutletWarehouse.Models.VendorManagement;

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
        /********************************************************
         * DFS methods regarding purchase orders and purchase
         * order line items follow
         ********************************************************/
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
        ///     Version 1.0: 10-25-13 (T.M.)
        ///         - Initial Creation
        ///     Version 1.1: 10-31-13 (T.M.)
        ///         - Modified to return a boolean value indicating success or failure
        ///         - Added Validation
        ///     Version 1.2: 11-18-13 (T.M.)
        ///         - No longer returns a boolean; just inserts into the database
        ///         - Now handles and converts nulls
        public void CreateNewPurchaseOrder(int POID, int vendorID, int POCreateBy, DateTime POOrderDate,
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
                    command.Parameters.AddWithValue("@POCreateBy", 1); //TODO: Work in a validated user
                    command.Parameters.AddWithValue("@POOrderDate", POOrderDate);
                    command.Parameters.AddWithValue("@POEstShipDate", POEstShipDate);
                    command.Parameters.AddWithValue("@POFreightCost", POFreightCost);
                    command.Parameters.AddWithValue("@POTerms", CheckForDbNull(POTerms));
                    command.Parameters.AddWithValue("@POComments", CheckForDbNull(POComments));
                    //TODO: Associate the EmployeeID

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
        ///     Version 1.1: 10-31-2013 (T.M.)
        ///         - Modified to validate the presence of rows before assigning values to an object
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
                    if (reader.HasRows) {
                        PO.PurchaseOrderId = POID.ToString();
                        PO.Vendor = GetVendorNameForVendorId(Convert.ToInt16(reader["VendorId"]));
                        PO.CreatedBy = Convert.ToInt32(reader["POCreatedBy"].ToString());
                        PO.OrderDate = Convert.ToDateTime(reader["POOrderDate"].ToString());
                        PO.EstShipDate = Convert.ToDateTime(reader["POEstimatedShipDate"].ToString());
                        PO.FreightCost = Convert.ToDecimal(reader["POFreightCost"].ToString());
                        PO.Terms = reader["POTerms"].ToString();
                        PO.Comments = reader["POComments"].ToString();
                    }
                    reader.Dispose();
                    command.Parameters.Clear();
                    
                    return PO;
                }

            }
        }

        /// <summary>
        /// Gets the last puchase order number (POID) for a given date
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="date">The date for which the PO was created</param>
        /// <returns>An int representing the last purchase order</returns>
        /// Changelog:
        ///     Version 1.0 - 10-?-13 (T.M.)
        ///         - Initial creation
        public int getLastPONumForDate(DateTime date) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT MAX(POID) "
                                        + "FROM PURCHASE_ORDER "
                                        + "WHERE POOrderDate = @date";
                    command.Parameters.AddWithValue("@date", date);

                    var test = command.ExecuteScalar();
                    if (test.ToString() == "")
                        return 0;

                    int PO = Convert.ToInt32(test);

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
        //public List<PurchaseOrderLineItem> ListLineItemsForPO(int PO) {
        //    using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
        //        thisConnection.Open();

        //        using (SqlCommand command = new SqlCommand()) {
        //            command.Connection = thisConnection;

        //            command.CommandText = "SELECT * FROM PO_LINEITEM "
        //                                + "WHERE POID = @POID";
        //            command.Parameters.AddWithValue("@POID", PO);

        //            SqlDataReader reader = command.ExecuteReader();

        //            List<PurchaseOrderLineItem> LineItemList = new List<PurchaseOrderLineItem>();

        //            while (reader.Read()) {
        //                LineItemList.Add(new PurchaseOrderLineItem{
        //                    //Added
        //                    POLineItem = Convert.ToInt32(reader["POLineItemID"]),
        //                    //
        //                    POID = (reader["POID"].ToString()),
        //                    RecRPC = Convert.ToInt64(reader["RecRPC"]),
        //                    WholesaleCost = Convert.ToDecimal(reader["WholesaleCost"]),
        //                    QtyOrdered = Convert.ToInt16(reader["QtyOrdered"]),
        //                    QtyTypeId = Convert.ToInt16(reader["QtyTypeID"])
        //                });
        //            }

        //            reader.Dispose();
        //            command.Parameters.Clear();

        //            return LineItemList;

        //        }
        //    }
        //}

        public List<PurchaseOrderLineItem> ListLineItemsForPO(int PO)
        {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString))
            {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = thisConnection;

                    command.CommandText = "SELECT * FROM PO_LINEITEM "
                                        + "WHERE POID = @POID AND POLineItemID NOT IN (SELECT P.POLineItemID FROM PO_LINEITEM P INNER JOIN RECEIVING_LOG R ON P.POLineItemID = R.POLineItemID)";
                    //Not in: And has no backlog or QtyReceived = QtyOrdered
                    command.Parameters.AddWithValue("@POID", PO);

                    SqlDataReader reader = command.ExecuteReader();

                    List<PurchaseOrderLineItem> LineItemList = new List<PurchaseOrderLineItem>();

                    while (reader.Read())
                    {
                        LineItemList.Add(new PurchaseOrderLineItem
                        {
                            //Added
                            POLineItem = Convert.ToInt32(reader["POLineItemID"]),
                            //
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

        public List<PurchaseOrder.PurchaseOrder> GetNonReceivedPOs()
        {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString))
            {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = thisConnection;

                    command.CommandText = ";WITH RL_POS_CTE AS (SELECT PL.POID FROM RECEIVING_LOG RL INNER JOIN PO_LINEITEM PL ON RL.POLineItemID = PL.POLineItemID "
                                            + "LEFT JOIN BACKORDER BO ON RL.ReceivingID = BO.ReceivingID WHERE BO.BackorderID IS NULL GROUP BY PL.POID)"
                                            + "SELECT TOP 50 PO.POID, PO.VendorID, PO.POCreatedBy, PO.POOrderDate, PO.POEstimatedShipDate, PO.POCreatedDate, "
                                            + "PO.POFreightCost, PO.POTerms, PO.POComments, PO.ShippingID FROM PURCHASE_ORDER PO WHERE PO.POID NOT IN "
                                            + "(SELECT POID FROM RL_POS_CTE) ORDER BY PO.POEstimatedShipDate";
                    //Not in: And has no backlog or QtyReceived = QtyOrdered

                    SqlDataReader reader = command.ExecuteReader();

                    List<PurchaseOrder.PurchaseOrder> POItemList = new List<PurchaseOrder.PurchaseOrder>();

                    while (reader.Read())
                    {
                        POItemList.Add(new PurchaseOrder.PurchaseOrder
                        {
                            //Added
                            PurchaseOrderId = (reader["POID"].ToString()),
                            Vendor = (reader["VendorID"].ToString()),
                            CreatedBy = Convert.ToInt32(reader["POCreatedBy"]),
                            OrderDate = Convert.ToDateTime(reader["POOrderDate"]),
                            EstShipDate = Convert.ToDateTime(reader["POEstimatedShipDate"]),
                            FreightCost = Convert.ToDecimal(reader["POFreightCost"]),
                            Terms = (reader["POTerms"].ToString()),
                            Comments = (reader["POComments"].ToString())

                        });
                    }

                    reader.Dispose();
                    command.Parameters.Clear();

                    return POItemList;

                }
            }
        }

        /********************************************************
         * Puchase order and PO line item DFS methods end
         ********************************************************/

        /// <summary>
        /// Gets the vendor ID for a specified vendor name
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="vendorName">The vendorName for which we need a vendorID</param>
        /// <returns>A short representing the VendorID</returns>
        /// Changelog:
        ///     Version 1.0 - 11-5-13 (T.M.)
        ///         - Initial creation
        ///     Version 1.01 - 11-18-13 (T.M.)
        ///         - Checks for and modifies nulls
        public short GetVendorIdForVendorName(string vendorName) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;

                    command.CommandText = "SELECT VendorId "
                                        + "FROM VENDOR "
                                        + "WHERE VendorName = @vendor";
                    command.Parameters.AddWithValue("@vendor", CheckForDbNull(vendorName));

                    List<string> results = new List<string>();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        results.Add(reader["VendorId"].ToString());
                    }

                    reader.Dispose();

                    if (results.Count() > 1) {
                        return -1; //error code for too many results
                    }
                    else if (results.Count() < 1) {
                        return 0; //error code for no results
                    }
                    else {
                        return Convert.ToInt16(results[0]);
                    }

                }
            }
        }

        /// <summary>
        /// Returns the vendor name for a specified vendor ID
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="VendorId">The vendor ID for which we need the vendor name</param>
        /// <returns>A string representing the vendor name</returns>
        /// Changelog
        ///     Version 1.0 11-5-13 (T.M.)
        ///         - Initial creation
        public string GetVendorNameForVendorId(short VendorId) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT VendorName "
                                        + "FROM VENDOR "
                                        + "WHERE VendorId = @VendorId";
                    command.Parameters.AddWithValue("@VendorId", VendorId);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    string vendorName = reader["VendorName"].ToString();

                    reader.Dispose();
                    command.Parameters.Clear();

                    return vendorName;
                }
            }
        }

        public void NewReceivingLog(//int ReceivingID, 
            int POLineItemID, int BackorderID, short QtyTypeID, //byte QtyTypeID,
                                    DateTime ReceiveDate, string ReceivingNotes, short ReceivedQty) {
            //ushort ReceivedQty) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;
                    command.CommandText = "EXEC dbo.CreateReceivingLog "    //Please note this Stored Procedure is not yet made
                                              //+ "@ReceivingID, 
                                              + "@POLineItemID, @BackorderID, @QtyTypeID,"
                                              + "@ReceiveDate, @ReceivingNotes, @ReceivedQty";
                    //command.Parameters.AddWithValue("@ReceivingID", ReceivingID);
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

        public void NewReceivingLog(//int ReceivingID, 
            int POLineItemID, short QtyTypeID, //byte QtyTypeID,
                                    DateTime ReceiveDate, string ReceivingNotes, short ReceivedQty)
        {
            //ushort ReceivedQty) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString))
            {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = thisConnection;
                    command.CommandText = "EXEC dbo.CreateReceivingLog "    //Please note this Stored Procedure is not yet made
                        //+ "@ReceivingID, 
                                              + "@POLineItemID," // @BackorderID, 
                                              + "@QtyTypeID,"
                                              + "@ReceiveDate, @ReceivingNotes, @ReceivedQty";
                    //command.Parameters.AddWithValue("@ReceivingID", ReceivingID);
                    command.Parameters.AddWithValue("@POLineItemID", POLineItemID);
                    //command.Parameters.AddWithValue("@BackorderID", null);
                    command.Parameters.AddWithValue("@QtyTypeID", QtyTypeID);
                    command.Parameters.AddWithValue("@ReceiveDate", ReceiveDate);
                    command.Parameters.AddWithValue("@ReceivingNotes", ReceivingNotes);
                    command.Parameters.AddWithValue("@ReceivedQty", ReceivedQty);

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                }//.SqlComand
            }//.SqlConnection
        }//.NewReceivingLog
        
        /// <summary>
        /// Adds a new vendor to the database
        /// </summary>
        /// <author>Mat S.</author>
        /// <param name="vendorName">The name associated with the added vendor</param>
        /// <param name="contactName">The vendor's contact's name</param>
        /// <param name="contactPhone">The contact's primary phone number</param>
        /// <param name="contactFax">The contact's fax number</param>
        /// <param name="altPhone">The vendor's alternate phone number</param>
        /// <param name="address">The vendor's address</param>
        /// <param name="website">The vendor's website</param>
        /// Changelog
        ///     Version 1.0 - 11-2-13 (M.S.)
        ///         - Initial creation
        ///     Version 1.1 - 11-18-13
        ///         - DbNull checking added
        ///         - Removed VendorID requirement
        public void AddNewVendor(string vendorName, string contactName, string contactPhone,
                                    string contactFax, string altPhone, string address, string website)
        {

            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString))
            {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = thisConnection;
                    command.CommandText = "EXEC dbo.CreateVendor @vendorName, @contactName, @contactPhone, "
                                        + "@contactFax, @altPhone, @address, @website";

                    command.Parameters.AddWithValue("@vendorName", vendorName);
                    command.Parameters.AddWithValue("@contactName", CheckForDbNull(contactName));
                    command.Parameters.AddWithValue("@contactPhone", contactPhone);
                    command.Parameters.AddWithValue("@contactFax", CheckForDbNull(contactFax));
                    command.Parameters.AddWithValue("@altPhone", CheckForDbNull(altPhone));
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@website", CheckForDbNull(website));

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                }
            }

        }

        /// <summary>
        /// Adds a product line with the specified parameters to the database.
        /// </summary>
        /// <param name="pl">The ProductLine object to be added to the database.</param>
        /// <returns>A code indicating the success or failure of the database INSERT.</returns>
        public int AddNewProductLine(ProductLine pl) {
            //validate passed attributes
            int testNum;
            bool isNum = int.TryParse(pl.Vendor, out testNum);
            if (!isNum) {
                return 1;
            }
            isNum = int.TryParse(pl.SalesRep, out testNum);
            if (!isNum) {
                return 1;
            }

            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;
                    command.CommandText = "INSERT INTO PRODUCT_LINE (ProductLineName, VendorID, RepID) "
                                        + "VALUES (@plName, @vendorID, @repID)";
                    command.Parameters.AddWithValue("@plName", pl.ProductLineName);
                    command.Parameters.AddWithValue("@vendorID", pl.Vendor);
                    command.Parameters.AddWithValue("@repID", pl.SalesRep);

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                    return 0; //success; TODO: make return codes match up across methods
                }
            }
        }

        /// <summary>
        /// Converts the Vendor name and Sales Rep name to their associated IDs
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="pl">The product line fields are to be converted for.</param>
        /// <returns>A ProductLine object with converted attributes.</returns>
        /// Changelog:
        ///     Version 1.0 - 11-20-13 (T.M.)
        ///         - Initial creation
        public ProductLine convertPLNameFieldsToIDs(ProductLine pl) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT DISTINCT v.VendorID "
                                        + "FROM VENDOR v, PRODUCT_LINE p "
                                        + "WHERE v.VendorName = @vendorName";
                    //TODO: evaluate above for unnecessary join operation
                    command.Parameters.AddWithValue("@vendorName", pl.Vendor);

                    SqlDataReader reader = command.ExecuteReader();

                    ProductLine convertedPL = pl;

                    if (reader.Read()) { //check for any entries
                        convertedPL.Vendor = reader["VendorID"].ToString();
                    }
                    else {
                        convertedPL.Vendor = "0";
                    }

                    if (reader.Read()) //now, check if there's more than one entry
                        convertedPL.Vendor = "-1";
                    reader.Dispose();
                    command.Parameters.Clear();

                    //convert repID

                    command.CommandText = "SELECT DISTINCT RepID "
                                        + "FROM SALES_REP "
                                        + "WHERE SalesRepName = @repName";
                    //TODO: evaluate above for unnecessary join operation
                    command.Parameters.AddWithValue("@repName", pl.SalesRep);

                    reader = command.ExecuteReader();

                    if (reader.Read()) { //check for any entries
                        convertedPL.SalesRep = reader["RepID"].ToString();
                    }
                    else {
                        convertedPL.SalesRep = "0";
                    }

                    if (reader.Read()) //now, check if there's more than one entry
                        convertedPL.SalesRep = "-1";
                    reader.Dispose();
                    command.Parameters.Clear();

                    return convertedPL;
                }
            }
        }

        /// <summary>
        /// Inserts a new Sales Rep into the database.
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="rep">The SalesRep object to be inserted.</param>
        /// <returns>An integer code indicating success or failure of the INSERT statement</returns>
        /// Changelog:
        ///     Version 1.0 - 11-20-13 (T.M.)
        ///         - Initial creation
        public int AddNewSalesRep(SalesRep rep) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;
                    command.CommandText = "INSERT INTO SALES_REP (SalesRepName, SalesRepPhone, SalesRepEmail) "
                                        + "VALUES (@repName, @repPhone, @repEmail)";
                    command.Parameters.AddWithValue("@repName", rep.SalesRepName);
                    command.Parameters.AddWithValue("@repPhone", rep.SalesRepPhone);
                    command.Parameters.AddWithValue("@repEmail", CheckForDbNull(rep.SalesRepEmail));

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                    return 0; //success
                }
            }
        }

        /**********************************************
         * DFS Methods regarding Ajax autocomplete
         * fields follow
         **********************************************/

        /// <summary>
        /// Populates a list of vendors containing a certain query string
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="vendorName">The query string to be checked</param>
        /// <returns>A list of all vendors containing the query string</returns>
        /// Changelog
        ///     Version 1.0 - 11-13-2013 (T.M.)
        ///         - Initial creation
        public List<Vendor> SearchVendorByName(string vendorName) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    List<Vendor> vendorList = new List<Vendor>();
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT * "
                                        + "FROM VENDOR "
                                        + "WHERE VendorName LIKE @vendorName";
                    command.Parameters.AddWithValue("@vendorName", "%" + vendorName + "%");
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        vendorList.Add(new Vendor{
                            VendorId = Convert.ToInt32(reader["VendorId"]),
                            VendorName = reader["VendorName"].ToString(),
                            ContactName = reader["ContactName"].ToString(),
                            ContactPhone = reader["ContactPhone"].ToString(),
                            AltPhone = reader["AltPhone"].ToString(),
                            Address = reader["Address"].ToString(),
                            Website = reader["Website"].ToString()
                            
                        });
                    }

                    reader.Dispose();
                    command.Parameters.Clear();

                    return vendorList;
                }


            }
        }

        /// <summary>
        /// Populates a list of product lines containing a certain query string
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="plName">The query string to be checked</param>
        /// <returns>A list of all product lines containing the query string</returns>
        /// Changelog
        ///     Version 1.0 - 11-13-2013 (T.M.)
        ///         - Initial creation
        public List<ProductLine> SearchProductLinesByName(string plName) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    List<ProductLine> plList = new List<ProductLine>();
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT * "
                                        + "FROM PRODUCT_LINE "
                                        + "WHERE ProductLineName LIKE @plName";
                    command.Parameters.AddWithValue("@plName", "%" + plName + "%");
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        plList.Add(new ProductLine {
                            ProductLineID = Convert.ToInt32(reader["ProductLineID"]),
                            ProductLineName = reader["ProductLineName"].ToString(),
                            Vendor = reader["VendorID"].ToString(),
                            SalesRep = reader["RepID"].ToString()
                        });
                    }

                    reader.Dispose();
                    command.Parameters.Clear();

                    return plList;
                }
            }
        }

        /// <summary>
        /// Populates a list of departments containing a certain query string
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="deptName">The query string to be checked</param>
        /// <returns>A list of all departments containing the query string</returns>
        /// Changelog
        ///     Version 1.0 - 11-13-2013 (T.M.)
        ///         - Initial creation
        public List<Department> SearchDepartmentsByName(string deptName) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    List<Department> deptList = new List<Department>();
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT * "
                                        + "FROM ITEM_DEPARTMENT "
                                        + "WHERE DepartmentName LIKE @deptName";
                    command.Parameters.AddWithValue("@deptName", "%" + deptName + "%");
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        deptList.Add(new Department {
                            DepartmentID = Convert.ToByte(reader["DepartmentID"]),
                            DepartmentName = reader["DepartmentName"].ToString(),
                        });
                    }

                    reader.Dispose();
                    command.Parameters.Clear();

                    return deptList;
                }
            }
        }

        /// <summary>
        /// Populates a list of categories containing a certain query string
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="catName">The query string to be checked</param>
        /// <returns>A list of all categories containing a certain query string</returns>
        /// Changelog
        ///     Version 1.0 - 11-13-2013 (T.M.)
        ///         - Initial creation
        public List<Category> SearchCategoriesByName(string catName) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    List<Category> catList = new List<Category>();
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT * "
                                        + "FROM ITEM_CATEGORY "
                                        + "WHERE CategoryName LIKE @catName";
                    command.Parameters.AddWithValue("@catName", "%" + catName + "%");
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        catList.Add(new Category {
                            CategoryID = Convert.ToByte(reader["CategoryID"]),
                            CategoryName = reader["CategoryName"].ToString(),
                        });
                    }

                    reader.Dispose();
                    command.Parameters.Clear();

                    return catList;
                }
            }
        }

        /// <summary>
        /// Populates a list of subcategories containing a certain query string
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="subcatName">The query string to be checked</param>
        /// <returns>A list of all subcategories containing the query string</returns>
        /// Changelog
        ///     Version 1.0 - 11-13-2013 (T.M.)
        ///         - Initial creation
        public List<SubCategory> SearchSubcategoriesByName(string subcatName) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    List<SubCategory> subcatList = new List<SubCategory>();
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT * "
                                        + "FROM ITEM_SUBCATEGORY "
                                        + "WHERE SubcategoryName LIKE @subcatName";
                    command.Parameters.AddWithValue("@subcatName", "%" + subcatName + "%");
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        subcatList.Add(new SubCategory {
                            SubcategoryID = Convert.ToByte(reader["SubcategoryID"]),
                            SubcategoryName = reader["SubcategoryName"].ToString(),
                        });
                    }

                    reader.Dispose();
                    command.Parameters.Clear();

                    return subcatList;
                }
            }
        }

        /// <summary>
        /// Creates a list of SalesRep objects to assist in Sales Rep autocomplete fields.
        /// The list contains all elements with a "name" containing a certain query string.
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="repName">The query string the search is based on.</param>
        /// <returns>A list of SalesRep objects whose name contains the query string.</returns>
        /// Changelog:
        ///     Version 1.0 - 11-20-13 (T.M.)
        ///         - Initial creation
        public List<SalesRep> SearchRepsByName(string repName) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    List<SalesRep> repList = new List<SalesRep>();
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT * "
                                        + "FROM SALES_REP "
                                        + "WHERE SalesRepName LIKE @repName";
                    command.Parameters.AddWithValue("@repName", "%" + repName + "%");
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        repList.Add(new SalesRep {
                            SalesRepID = Convert.ToInt16(reader["RepID"]),
                            SalesRepName = reader["SalesRepName"].ToString(),
                            SalesRepPhone = reader["SalesRepPhone"].ToString(),
                            SalesRepEmail = reader["SalesRepEmail"].ToString()
                        });
                    }

                    reader.Dispose();
                    command.Parameters.Clear();

                    return repList;
                }
            }
        }

        /***********************************************
         * Ajax autocomplete DFS methods end
         ***********************************************/

        /***********************************************
         * DFS methods regarding the ITEM table follow
         ***********************************************/

        /// <summary>
        /// Adds a new item with the attributes of the specified instance of the item class to the database.
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="item">The instance of the Item model class attributes are retrieved from</param>
        /// Changelog
        ///     Version 1.0 - 11-13-2013 (T.M.)
        ///         - Initial creation
        ///     Version 1.01 - 11-18-2013 (T.M.)
        ///         - Now gets Product Line appropriately
        public void AddNewItem(Item item) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;
                    command.CommandText = "EXEC dbo.CreateItem "
                                        + "@RecRPC, @ItemUPC, @DepartmentID, "
                                        + "@CategoryID, @ItemID, @VendorItemID, @SubcategoryID, "
                                        + "@ProductLineID, @Description, @SeasonCode, @MSRP, "
                                        + "@SellPrice, @RestrictedAge, @TaxRateID, @ItemCreatedBy, "
                                        + "@ItemCreatedDate, @ItemName";
                    //NOTE: legacyID is not included in the INSERT

                    command.Parameters.AddWithValue("@RecRPC", item.RecRPC);
                    command.Parameters.AddWithValue("@ItemUPC", item.UPC);
                    command.Parameters.AddWithValue("@DepartmentID", item.Department); 
                    command.Parameters.AddWithValue("@CategoryID", item.Category); 
                    command.Parameters.AddWithValue("@ItemID", item.ItemId);
                    command.Parameters.AddWithValue("@VendorItemID", item.VendorItemID);
                    command.Parameters.AddWithValue("@SubcategoryID", item.Subcategory); 
                    command.Parameters.AddWithValue("@ProductLineID", item.ProductLine);
                    command.Parameters.AddWithValue("@Description", item.ItemDescription);
                    command.Parameters.AddWithValue("@SeasonCode", item.SeasonCode);
                    command.Parameters.AddWithValue("@MSRP", item.MSRP);
                    command.Parameters.AddWithValue("@SellPrice", item.SellPrice);
                    command.Parameters.AddWithValue("@RestrictedAge", item.restrictedAge);
                    command.Parameters.AddWithValue("@TaxRateID", 1); //CHANGE
                    command.Parameters.AddWithValue("@ItemCreatedBy", item.CreatedBy);
                    command.Parameters.AddWithValue("@ItemCreatedDate", item.CreatedDate);
                    command.Parameters.AddWithValue("@ItemName", item.ItemName);

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                }
            }
        }

        /// <summary>
        /// Converts the Vendor, Product Line, Department, Category, and Subcategory fields into ID fields appropriate to their
        /// respective database fields
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="item">The instance of the Item model class to be converted</param>
        /// <returns>An instance of the Item class with converted Vendor, Product Line, Department, Category, and Subcategory fields</returns>
        /// Changelog
        ///     Version 1.0 - 11-13-2013 (T.M.)
        ///         - Initial Creation
        ///     Version 1.1 - 11-18-2013 (T.M.)
        ///         - Converts Vendor and Product Line
        ///         - Checks for and converts nulls
        public Item ConvertNamesToIDs(Item item) {
            Item convertedItem = item;
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;

                    //Convert Vendor
                    command.CommandText = "SELECT DISTINCT v.VendorID AS VendorID "
                                        + "FROM VENDOR v, ITEM i "
                                        + "WHERE v.VendorName = @VendorName";
                    command.Parameters.AddWithValue("@VendorName", CheckForDbNull(item.Vendor));

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) { //check for any entries
                        convertedItem.Vendor = reader["VendorID"].ToString();
                    }
                    else {
                        convertedItem.Vendor = "0";
                    }

                    if (reader.Read()) //now, check if there's more than one entry
                        convertedItem.Vendor = "-1";
                    reader.Dispose();
                    command.Parameters.Clear();

                    //Convert Product Line
                    command.CommandText = "SELECT DISTINCT pl.ProductLineID AS PLID "
                                        + "FROM PRODUCT_LINE pl, ITEM i "
                                        + "WHERE pl.ProductLineName = @plName "
                                        + "AND pl.VendorID = @vendorID";
                    command.Parameters.AddWithValue("@plName", CheckForDbNull(item.ProductLine));
                    command.Parameters.AddWithValue("@vendorID", CheckForDbNull(item.Vendor)); //since this is after the vendor conversion,
                                                                                               //we don't need to convert it again
                    reader = command.ExecuteReader();
                    if (reader.Read()) { //check for any entries
                        convertedItem.ProductLine = reader["PLID"].ToString();
                    }
                    else {
                        convertedItem.ProductLine = "0";
                    }

                    if (reader.Read()) //now, check if there's more than one entry
                        convertedItem.ProductLine = "-1";
                    reader.Dispose();
                    command.Parameters.Clear();

                    //Convert Department
                    command.CommandText = "SELECT DISTINCT d.DepartmentID AS DeptID "
                                        + "FROM ITEM_DEPARTMENT d, ITEM i "
                                        + "WHERE d.DepartmentName = @DepartmentName";
                    command.Parameters.AddWithValue("@DepartmentName", CheckForDbNull(item.Department));

                    reader = command.ExecuteReader();
                    if (reader.Read()) { //check for any entries
                        convertedItem.Department = reader["DeptID"].ToString();
                    }
                    else {
                        convertedItem.Department = "0";
                    }

                    if (reader.Read()) //now, check if there's more than one entry
                        convertedItem.Department = "-1";
                    reader.Dispose();
                    command.Parameters.Clear();

                    //Convert Category
                    command.CommandText = "SELECT DISTINCT c.CategoryID AS CatID "
                                        + "FROM ITEM_CATEGORY c, ITEM i "
                                        + "WHERE c.CategoryName = @CatName";
                    command.Parameters.AddWithValue("@CatName", CheckForDbNull(item.Category));

                    reader = command.ExecuteReader();

                    if (reader.Read()) { //check for any entries
                        convertedItem.Category = reader["CatID"].ToString();
                    }
                    else {
                        convertedItem.Category = "0";
                    }

                    if (reader.Read()) //check if there's more than one entry
                        convertedItem.Category = "-1";
                    reader.Dispose();
                    command.Parameters.Clear();

                    //Convert Subcategory
                    command.CommandText = "SELECT DISTINCT c.SubcategoryID AS SubcatID "
                                        + "FROM ITEM_SUBCATEGORY c, ITEM i "
                                        + "WHERE c.SubcategoryName = @CatName";
                    command.Parameters.AddWithValue("@CatName", CheckForDbNull(item.Subcategory));

                    reader = command.ExecuteReader();

                    if (reader.Read()) { //check for any entries
                        convertedItem.Subcategory = reader["SubcatID"].ToString();
                    }
                    else {
                        convertedItem.Subcategory = "0";
                    }

                    if (reader.Read()) //check if there's more than one entry
                        convertedItem.Subcategory = "-1";

                    reader.Dispose();
                    command.Parameters.Clear();


                    return convertedItem;
                }
            }
        }

        /// <summary>
        /// Gets the last (max) item number given to an item with the specified department, category, and subcategory.
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="dept">The department number of the item we're seeking</param>
        /// <param name="cat">The category number of the item we're seeking</param>
        /// <param name="subcat">The subcategory number of the item we're seeking</param>
        /// <returns>An integer representing the item number of the "last" (max) item with the specified attributes</returns>
        /// Changelog:
        ///     Version 1.0 - 11-13-13 (T.M.)
        ///         - Initial creation
        public int GetNextItemForDeptCatSubcat(byte dept, byte cat, short subcat) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT MAX(ItemID) "
                                        + "FROM ITEM "
                                        + "WHERE DepartmentID = @DepartmentID "
                                        + "AND CategoryID = @CategoryID "
                                        + "AND SubcategoryID = @SubcategoryID";
                    command.Parameters.AddWithValue("@DepartmentID", dept);
                    command.Parameters.AddWithValue("@CategoryID", cat);
                    command.Parameters.AddWithValue("@SubcategoryID", subcat);

                    var maxItemId = command.ExecuteScalar();
                    command.Parameters.Clear();

                    if (maxItemId.ToString() == "")
                        return 1; //first item in dept/cat/subcat combo; represents 000001
                    else
                        return (Convert.ToInt32(maxItemId) + 1); //return next item number
                }
            }

        }

        /// <summary>
        /// Creates an Item object from the row in the database identified by the RPC parameter
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="RPC">The RPC of the item to be created</param>
        /// <returns>An Item object with complete parameters</returns>
        /// Changelog:
        ///     Version 1.0 - 11-18-13 (T.M.)
        ///         - Initial creation
        public Item GetItemForRPC(long RPC) {
            //TODO: allow this to accept UPCs too
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT * FROM ITEM WHERE RecRPC = @RecRPC";
                        //NOTE: legacyID is not included in the INSERT

                    command.Parameters.AddWithValue("@RecRPC", RPC);

                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    Item searchResult = new Item {
                        RecRPC = Convert.ToInt64(reader["RecRPC"]),
                        UPC = Convert.ToInt64(reader["ItemUPC"]),
                        ItemName = reader["Name"].ToString(),
                        ItemDescription = reader["Description"].ToString(),
                        VendorItemID = Convert.ToInt32(reader["VendorItemID"]),
                        ProductLine = "Test", //FIX
                        Category = reader["CategoryID"].ToString(),
                        Department = reader["DepartmentID"].ToString(),
                        Subcategory = reader["SubcategoryID"].ToString(),
                        MSRP = Convert.ToDecimal(reader["MSRP"]),
                        SellPrice = Convert.ToDecimal(reader["SellPrice"]),
                        TaxRate = Convert.ToDecimal(reader["TaxRateID"]), //FIX
                        restrictedAge = Convert.ToByte(reader["RestrictedAge"]),
                        //legacyID needs to be added
                        CreatedBy = Convert.ToInt16(reader["ItemCreatedBy"]),
                        CreatedDate = Convert.ToDateTime(reader["ItemCreatedDate"])
                    };

                    if (reader.Read()) { //if there's more than one result
                        return null;
                    }
                    else
                        return searchResult;
                }
            }
        }

        /**********************************************
         * ITEM DFS methods end
         **********************************************/

        /**********************************************
         * DataFetcherSetter utility methods follow
         * (Keep this section at the end of the document)
         * ********************************************/

        /// <summary>
        /// Checks an object to see if its value is null, and, if it is, converts
        /// the null to a DbNull (a database-friendly null format)
        /// </summary>
        /// <author>Tyler M.</author>
        /// <param name="value">The object we're checking for "nullness"</param>
        /// <returns>If "value" is null, returns DbNull.
        /// If "value" is not null, it returns "value"</returns>
        /// Changelog
        ///     Version 1.0 (T.M.)
        ///         - Initial creation
        public static object CheckForDbNull(object value) {
            if (value == null) {
                return DBNull.Value; //convert nulls to DBNulls
            }

            return value;
        }

        /**********************************************
         * DataFetcherSetter utility methods end
         * ********************************************/
    }
}
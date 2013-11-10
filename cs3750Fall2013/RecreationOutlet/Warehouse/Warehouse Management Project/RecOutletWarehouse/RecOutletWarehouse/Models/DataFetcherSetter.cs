using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using RecOutletWarehouse.Models.PurchaseOrder;
using RecOutletWarehouse.Models.ItemManagement;

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
        /// <returns>A Boolean value that indicates whether the operation succeeded</returns>
        /// Changelog:
        /// Version 1.0: 10-25-13 (T.M.)
        /// - Initial Creation
        /// Version 1.1: 10-31-13 (T.M.)
        /// - Modified to return a boolean value indicating success or failure
        /// - Added Validation
        public Boolean NewPurchaseOrder(int POID, int vendorID, int POCreateBy, DateTime POOrderDate,
                                     DateTime POEstShipDate, decimal POFreightCost, string POTerms,
                                     string POComments) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;

                    PurchaseOrder.PurchaseOrder PO = RetrievePObyPOID(POID);
                    if (PO.PurchaseOrderId != null)
                        return false;


                    command.CommandText = "EXEC dbo.CreatePurchaseOrder "
                                              + "@POID, @vendorID, @POCreateBy, @POOrderDate,"
                                              + "@POEstShipdate, @POFreightCost, @POTerms, @POComments";
                    command.Parameters.AddWithValue("@POID", POID);
                    command.Parameters.AddWithValue("@vendorID", vendorID);
                    command.Parameters.AddWithValue("@POCreateBy", 1); //TODO: Work in a validated user
                    command.Parameters.AddWithValue("@POOrderDate", POOrderDate);
                    command.Parameters.AddWithValue("@POEstShipDate", POEstShipDate);
                    command.Parameters.AddWithValue("@POFreightCost", POFreightCost);
                    command.Parameters.AddWithValue("@POTerms", POTerms);
                    command.Parameters.AddWithValue("@POComments", POComments);
                    //TODO: Associate the EmployeeID

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                    return true;

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

        public short GetVendorIdForVendorName(string vendorName) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    command.Connection = thisConnection;

                    command.CommandText = "SELECT VendorId "
                                        + "FROM VENDOR "
                                        + "WHERE VendorName = @vendor";
                    command.Parameters.AddWithValue("@vendor", vendorName);

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

        public void AddNewVendor(int vendorId, string vendorName, string contactName, string contactPhone,
                                    string contactFax, string altPhone, string address, string website)
        {

            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString))
            {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = thisConnection;
                    command.CommandText = "INSERT into VENDOR (@vendorId, @vendorName, @contactName, @contactPhone," +
                        " @contactFax, @altPhone, @address, @website)";

                    //TODO: not totally sure how vendorId get generated...
                    command.Parameters.AddWithValue("@vendorId", vendorId);
                    command.Parameters.AddWithValue("@vendorName", vendorName);
                    command.Parameters.AddWithValue("@contactName", contactName);
                    command.Parameters.AddWithValue("@contactPhone", contactName);
                    command.Parameters.AddWithValue("@contactFax", contactFax);
                    command.Parameters.AddWithValue("@altPhone", altPhone);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@website", website);

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                }
            }

        }

        public List<AddVendor.AddVendor> SearchVendorByName(string vendorName) {
            using (SqlConnection thisConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TitanConnection"].ConnectionString)) {
                thisConnection.Open();

                using (SqlCommand command = new SqlCommand()) {
                    List<AddVendor.AddVendor> vendorList = new List<AddVendor.AddVendor>();
                    command.Connection = thisConnection;
                    command.CommandText = "SELECT * "
                                        + "FROM VENDOR "
                                        + "WHERE VendorName LIKE @vendorName";
                    command.Parameters.AddWithValue("@vendorName", "%" + vendorName + "%");
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        vendorList.Add(new AddVendor.AddVendor{
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
                            VendorID = Convert.ToInt16(reader["VendorID"]),
                            RepID = Convert.ToInt16(reader["RepID"])
                        });
                    }

                    reader.Dispose();
                    command.Parameters.Clear();

                    return plList;
                }
            }
        }

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

        /***********************************************
         * DFS Methods regarding the ITEM table follow
         ***********************************************/

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
                    command.Parameters.AddWithValue("@DepartmentID", 8); //CHANGE
                    command.Parameters.AddWithValue("@CategoryID", 5); //CHANGE
                    command.Parameters.AddWithValue("@ItemID", item.ItemId);
                    command.Parameters.AddWithValue("@VendorItemID", item.VendorItemID);
                    command.Parameters.AddWithValue("@SubcategoryID", 6); //CHANGE
                    command.Parameters.AddWithValue("@ProductLineID", 2); //CHANGE
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

        /**********************************************
         * ITEM DFS methods end
         **********************************************/
    }
}
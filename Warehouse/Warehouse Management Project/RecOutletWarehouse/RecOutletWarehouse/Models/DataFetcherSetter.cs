﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace RecOutletWarehouse.Models
{
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
    
    }
}
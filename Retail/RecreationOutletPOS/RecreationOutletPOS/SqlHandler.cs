﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Aliases for the Enum's inner classes
using SqlResultSet = RecreationOutletPOS.Enum.SqlResultSet;

namespace RecreationOutletPOS
{
    public class SqlHandler
    {
        private static string connStr = HelperMethods.connStr();

        #region SELECT Statement Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/7/2013
        /// 
        /// Gets all the transaction reports that occurred within the given dates
        /// </summary>
        /// <param name="begDate">The beginning date period to retrieve transactions from</param>
        /// <param name="endDate">The end date period to retrieve transactions from</param>
        /// <returns>A dataset containing all relevant transactins between the given dates</returns>
        public static DataSet getTransactionReport(string begDate, string endDate)
        {
            string sql = "SELECT TransactionID, TransTotal, TransTax, PaymentType, " +
                                "TransactionDate, EmployeeID, ManagerID, StoreID, TerminalID " +
                         "FROM STORE_TRANSACTION WHERE TransactionDate BETWEEN @begDate AND @endDate;";

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd;
            SqlDataAdapter da;

            DataSet ds = new DataSet();

            ds.Tables.Add(SqlResultSet.TRANS_RESULTSET.ToString());

            try
            {
                cmd = new SqlCommand(sql, conn);

                conn.Open();

                // Adding the timestamp intervals to get the most accurate results
                begDate += " 12:00:00 AM";
                endDate += " 11:59:59 PM";

                cmd.Parameters.AddWithValue("@begDate", begDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);

                da = new SqlDataAdapter(cmd);
                da.Fill(ds.Tables[0]);

                //int c = ds.Tables[0].Rows.Count;
            }

            catch (Exception ex)
            {

            }

            finally
            {
                if(conn != null)
                    conn.Close();
            }

            return ds;
        }

        #endregion
    }
}

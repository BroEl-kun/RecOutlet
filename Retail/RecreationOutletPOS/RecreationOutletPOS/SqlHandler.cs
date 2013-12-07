using System;
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
        /// <param name="beginDate">The beginning date period to retrieve transactions from</param>
        /// <param name="endDate">The end date period to retrieve transactions from</param>
        /// <returns>A dataset containing all relevant transactins between the given dates</returns>
        public static DataSet getTransactionReport(string beginDate, string endDate)
        {
            string sql = "SELECT TransactionID, StoreID, EmployeeID, TransactionDate, TransTotal " +
                         "TransTax, ManagerID, PaymentType " +
                         "FROM STORE_TRANSACTION WHERE TransactionDate BETWEEN '10/14/2013' AND '10/15/2013';";

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd;
            SqlDataAdapter da;

            DataSet ds = new DataSet();

            ds.Tables.Add(SqlResultSet.TRANS_RESULTSET.ToString());

            try
            {
                cmd = new SqlCommand(sql, conn);

                conn.Open();

                //beginDate += " 00:00:00 AM";
                //endDate += " 23:59:00 AM";

                //cmd.Parameters.AddWithValue("@beginDate", beginDate);
                //cmd.Parameters.AddWithValue("@endDate", endDate);

                int x = cmd.ExecuteNonQuery();

                da = new SqlDataAdapter(cmd);
                da.Fill(ds.Tables[0]);
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

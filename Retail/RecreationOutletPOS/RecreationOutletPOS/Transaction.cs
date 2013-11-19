using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Aliases for the Enum's inner classes
using TransKey = RecreationOutletPOS.Enum.TransKey;

namespace RecreationOutletPOS
{
    /// <summary>
    /// Programmer: Michael Vuong
    /// Last Updated: 11/11/2013
    /// 
    /// Represents a single transaction when checking out
    /// </summary>
    public class Transaction
    {
        private string connStr = "Data Source=titan.cs.weber.edu,10433;Initial Catalog=RecreationOutlet_Test1;" +
                                 "Integrated Security=False;User ID=recreation;Password=outlet;Connect Timeout=15;" +
                                 "Encrypt=False;TrustServerCertificate=False";

        public int rowsInserted;

        public Dictionary<TransKey, string> transactionDetails;

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/14/2013
        /// 
        /// Constructor
        /// </summary>
        public Transaction(Dictionary<TransKey, string> transactionDetails)
        {
            this.transactionDetails = transactionDetails;

            rowsInserted = addTransactionToDb(this.transactionDetails);
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/14/2013
        /// 
        /// Inserts a new transaction into the STORE_TRANSACTION data table
        /// </summary>
        /// <returns>The result of performing the INSERT into the database</returns>
        public int addTransactionToDb(Dictionary<TransKey, string> transactionDetails)
        {
            string sql = "INSERT INTO STORE_TRANSACTION([StoreID], [EmployeeID], [TransactionDate], [TerminalID], [TransTotal], [TransTax], [ManagerID], [PaymentType], [PreviousTransactionID])" +
                         "VALUES(@StoreID, @EmployeeID, @TransDate, @TerminalID, @TransTotal, @TransTax, @ManagerID, @PaymentType, @PreviousTransactionID);";
            int rowsInserted = 0;

            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                //cmd.Parameters.AddWithValue("@TransactionID", transactionDetails["TransactionID"]);
                cmd.Parameters.AddWithValue("@StoreID", transactionDetails[TransKey.STORE_ID]);
                cmd.Parameters.AddWithValue("@EmployeeID", transactionDetails[TransKey.EMPLOYEE_ID]);
                cmd.Parameters.AddWithValue("@TransDate", transactionDetails[TransKey.TRANS_DATE]);
                cmd.Parameters.AddWithValue("@TerminalID", transactionDetails[TransKey.TERMINAL_ID]);
                cmd.Parameters.AddWithValue("@TransTotal", transactionDetails[TransKey.TRANS_TOTAL]);
                cmd.Parameters.AddWithValue("@TransTax", transactionDetails[TransKey.TRANS_TAX]);
                cmd.Parameters.AddWithValue("@ManagerID", transactionDetails[TransKey.MANAGER_ID]);
                cmd.Parameters.AddWithValue("@PaymentType", transactionDetails[TransKey.PAYMENT_TYPE]);
                cmd.Parameters.AddWithValue("@PreviousTransactionID", transactionDetails[TransKey.PREVIOUS_TRANS_ID]);

                conn.Open();

                rowsInserted = cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {

            }

            finally
            {
                conn.Close();
            }

            return rowsInserted;
        }
    }
}


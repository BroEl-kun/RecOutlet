using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecreationOutletPOS
{
    /// <summary>
    /// Programmer: Michael Vuong
    /// Last Updated: 10/14/2013
    /// 
    /// Represents a single transaction when checking out
    /// </summary>
    public class Transaction
    {
        private string connStr = "Data Source=titan.cs.weber.edu,10433;Initial Catalog=RecreationOutlet_Test1;" +
                                 "Integrated Security=False;User ID=recreation;Password=outlet;Connect Timeout=15;" +
                                 "Encrypt=False;TrustServerCertificate=False";

        private int transactionID;
        private int storeID;
        private int employeeID;
        private DateTime transDate;
        private string terminalID;
        private Decimal transTotal;
        private Decimal transTax;
        private int managerID;
        private string paymentType;
        private int previousTransactionID;

        Dictionary<string, string> transactionDetails;

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/14/2013
        /// 
        /// Constructor
        /// </summary>
        public Transaction(Dictionary<string, string> transactionDetails)
        {
            this.transactionDetails = transactionDetails;

            addTransactionToDb(this.transactionDetails);
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/14/2013
        /// 
        /// DONT USE FOR NOW - May be needed later however
        /// </summary>
        /// <param name="transactionDetails"></param>
        public void initializeTransactionDetails(Dictionary<string, string> transactionDetails)
        {
            try
            {
                Int32.TryParse(transactionDetails["TransactionID"], out transactionID);
                Int32.TryParse(transactionDetails["StoreID"], out storeID);
                Int32.TryParse(transactionDetails["EmployeeID"], out employeeID);

                transDate = DateTime.Now;
                terminalID = transactionDetails["TerminalID"].ToString();

                Decimal.TryParse(transactionDetails["TransTotal"], out transTotal);
            }

            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 10/14/2013
        /// 
        /// Inserts a new transaction into the STORE_TRANSACTION data table
        /// </summary>
        /// <returns>The result of performing the INSERT into the database</returns>
        public int addTransactionToDb(Dictionary<string, string> transactionDetails)
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
                cmd.Parameters.AddWithValue("@StoreID", transactionDetails["StoreID"]);
                cmd.Parameters.AddWithValue("@EmployeeID", transactionDetails["EmployeeID"]);
                cmd.Parameters.AddWithValue("@TransDate", transactionDetails["TransDate"]);
                cmd.Parameters.AddWithValue("@TerminalID", transactionDetails["TerminalID"]);
                cmd.Parameters.AddWithValue("@TransTotal", transactionDetails["TransTotal"]);
                cmd.Parameters.AddWithValue("@TransTax", transactionDetails["TransTax"]);
                cmd.Parameters.AddWithValue("@ManagerID", transactionDetails["ManagerID"]);
                cmd.Parameters.AddWithValue("@PaymentType", transactionDetails["PaymentType"]);
                cmd.Parameters.AddWithValue("@PreviousTransactionID", transactionDetails["PreviousTransactionID"]);

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


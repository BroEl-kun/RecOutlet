using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

// TEMP
using System.Windows.Forms;


namespace RecreationOutletPOS
{
    /// <summary>
    /// Programmer: Jaed Norberg
    /// Last Updated: 11/03/2013
    /// 
    /// This class controls database interactions in the item search form.    
    /// </summary>
    class ItemSearch
    {
        private string connStr = HelperMethods.connStr();

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/12/2013 
        /// 
        /// Pulls the data from the database using the provided search term.
        /// </summary>
        public DataSet showData(string searchTerm, int department)
        {
            string sql = "SELECT RecRPC, Name, SellPrice FROM ITEM " +
                "WHERE Name LIKE @str";

            if (department != 0)
                sql += " AND DepartmentID = @dep";

            SqlConnection conn = new SqlConnection(connStr);
            DataSet ds = new DataSet();
            ds.Tables.Add("Results");

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                // % is a wild card for SQL where having one before and after the searchTerm means search for this substring
                // in the field we're searching 
                cmd.Parameters.AddWithValue("@str", "%" + searchTerm + "%");
                cmd.Parameters.AddWithValue("@dep", department);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds.Tables[0]);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/24/2013 
        /// 
        /// Pulls the data from the database using the provided search term.
        /// </summary>
        public DataSet retrieveItem(int type, string ID)
        {
            // attempts to first query the sale pricing table
            // to see if the item exists
            DataSet salesDS = new DataSet();
            salesDS = selectFromSales(ID);

            string sql = "";

            if (type == 0)
            {
                if (salesDS.Tables["Sales"].Rows.Count != 0)
                    sql = "SELECT ITEM.RecRPC, ITEM.Name, ITEM.SellPrice, SALE_PRICING.SalePrice " + 
                        "FROM ITEM " + 
                        "INNER JOIN SALE_PRICING " + 
                        "ON ITEM.RecRPC = SALE_PRICING.RecRPC " +
                        "WHERE ITEM.RecRPC = @str;";
                else
                    sql = "SELECT RecRPC, Name, SellPrice FROM ITEM " +
                        "WHERE RecRPC = @str;";
            }
            if (type == 1 || type == 2)
                sql = "SELECT ItemUPC, Name, SellPrice FROM ITEM " +
                    "WHERE ItemUPC = @str;";

            SqlConnection conn = new SqlConnection(connStr);
            DataSet ds = new DataSet();
            ds.Tables.Add("Results");

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                cmd.Parameters.AddWithValue("@str", ID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds.Tables[0]);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }


        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 1/24/2014
        /// 
        /// Queries the sales table for a sale matching the supplied RPC.
        /// </summary>
        public DataSet selectFromSales(string RPC)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add("Sales");

            string sql = "SELECT SalePrice from SALE_PRICING " +
                        "WHERE RecRPC = @id;";

            SqlConnection conn = new SqlConnection(connStr);

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", RPC);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds.Tables[0]);
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
    }
}
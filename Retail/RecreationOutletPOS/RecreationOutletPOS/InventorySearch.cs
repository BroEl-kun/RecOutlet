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
    /// Last Updated: 10/28/2013
    /// 
    /// Contain methods necessary for searching through the store and warehouse's inventory
    /// </summary>
    class InventorySearch
    {
        private string connStr = HelperMethods.connStr();

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/16/2013 
        /// 
        /// Pulls the data from the database using a given "searchColumn" (which correlates to a column in the database)
        /// and searches that column for "searchCriteria" (the substring of interest we're looking for in that column)
        /// </summary>
        public DataSet searchInventoryFor(string searchColumn, string searchCriteria)
        {
            string sql = "SELECT * FROM ITEM WHERE " + searchColumn + 
                         " LIKE @searchCriteria;";

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd;
            SqlDataAdapter da; 

            DataSet ds = new DataSet();

            ds.Tables.Add("Results");

            try
            {
                // Do not grab anything if the search criteria is null or white space
                if (!string.IsNullOrWhiteSpace(searchCriteria))
                {
                    cmd = new SqlCommand(sql, conn);

                    conn.Open();

                    cmd.Parameters.AddWithValue("@searchCriteria", "%" + searchCriteria + "%");

                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds.Tables[0]);
                }
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

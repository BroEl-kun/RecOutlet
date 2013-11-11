using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace RecreationOutletPOS
{
    /// <summary>
    /// Programmer: Jaed Norberg
    /// Last Updated: 11/03/2013
    /// 
    /// This class controls database interactions in the manual item addition form.    
    /// </summary>
    class ManualItemAddition
    {
        private string connStr = HelperMethods.connStr();

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/12/2013 
        /// 
        /// Pulls the data from the database using the provided search term.
        /// </summary>
        public DataSet showData(string searchTerm)
        {
            string sql = "SELECT ItemID, Description, SellPrice FROM ITEM " +
                "WHERE Description LIKE @str;";

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

            // ID
            // item name
            // price
            // quantity
            // discount
            // total
        }

        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/24/2013 
        /// 
        /// Pulls the data from the database using the provided search term.
        /// </summary>
        public DataSet retrieveItem(string ID)
        {
            string sql = "SELECT ItemID, Description, SellPrice FROM ITEM " +
                "WHERE ItemID = @str;";

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
    }

    

}

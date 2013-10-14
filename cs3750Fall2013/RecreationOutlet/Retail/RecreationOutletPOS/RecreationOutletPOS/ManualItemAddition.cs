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
    class ManualItemAddition
    {
        private string connStr = "Data Source=(local);Initial Catalog=master;Integrated Security=True";




        /// <summary>
        /// Programmer: Jaed Norberg
        /// Last Updated: 10/12/2013 
        /// 
        /// Adds an item to the database. Used for debug only.
        /// </summary>
        public void addItem(int ID, string name, string price)
        {
            string sql = "INSERT INTO ITEM ([ItemID], [ProductLineID], [Description], [CategoryID], [DepartmentID], [CreatedBy], [CreatedDate], [SellPrice], [TaxRateID]) " +
                //"VALUES (@id, @desc, @price);";
                "VALUES (1, 1, 'test', 1, 1, 1, " +
                System.DateTime.Now.Date +
                ", 1, 0) " +
                "WHERE [Description] LIKE @str;";

            SqlConnection conn = new SqlConnection(connStr);
            DataSet ds = new DataSet();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                //cmd.Parameters.AddWithValue("@id", ID);
                //cmd.Parameters.AddWithValue("@desc", name);
                //cmd.Parameters.AddWithValue("@price", price);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
            finally
            {
                conn.Close();
            }
        }


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

                cmd.Parameters.AddWithValue("@str", "%" + searchTerm + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds.Tables[0]);
            }
            catch (Exception e)
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

        
    }

    

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecreationOutletPOS
{
    /// <summary>
    /// Programmer: Jaed Norberg
    /// Last Updated: 11/03/2013
    /// 
    /// This class holds several helper methods.    
    /// </summary>
    public static class HelperMethods
    {
        // CONNSTR
        // Retrieves the database connection string.
        public static string connStr()
        {
            string str = "Data Source=titan.cs.weber.edu,10433;Initial Catalog=RecreationOutlet_Test1;" +
                                 "Integrated Security=False;User ID=recreation;Password=outlet;Connect Timeout=15;" +
                                 "Encrypt=False;TrustServerCertificate=False";

            return str;
        }
    }
}

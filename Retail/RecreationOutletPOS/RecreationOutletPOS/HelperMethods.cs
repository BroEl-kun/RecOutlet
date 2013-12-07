using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/7/2013
        /// 
        /// Validates a given date to ensure it is in the format of MM/DD/YYYY
        /// </summary>
        /// <param name="date">The date to validate</param>
        public static bool isValidDate(string date)
        {
            Match dateMatch;

            bool isValidMonth = false;
            bool isValidDay = false;
            bool isValidYear = false;
            bool validDate = false;

            string[] splitDate;

            int month = 0;
            int day = 0;
            int year = 9;

            try
            {
                // Allows for months and days to be 1-2 digits, while year must be 4 digits
                dateMatch = Regex.Match(date, @"\d{1,2}/\d{1,2}/\d{4}");

                // Ensures that the date is at least in the correct format before
                // evaluating the month, day, and year
                if (dateMatch.Success)
                {
                    splitDate = date.Split('/');

                    int.TryParse(splitDate[0], out month);
                    int.TryParse(splitDate[1], out day);
                    int.TryParse(splitDate[2], out year);

                    // Validate each part of the date

                    if (month > 0 && month <= 12)
                        isValidMonth = true;

                    if (day > 0 && day <= 31)
                        isValidDay = true;

                    if (year > 0)
                        isValidYear = true;

                    // If all parts of the date are valid, the given date is valid
                    if (isValidMonth && isValidDay && isValidYear)
                        validDate = true;
                }
            }

            catch (Exception ex)
            {
                
            }

            return validDate;
        }
    }
}

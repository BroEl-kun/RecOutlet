using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ReportType = RecreationOutletPOS.Enum.ReportType;

namespace RecreationOutletPOS
{
    public partial class ShowReportForm : Form
    {
        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/7/2013
        /// 
        /// Constructor
        /// </summary>
        /// <param name="callingButtonText">Used to determine which report to generate</param>
        public ShowReportForm(string callingButtonText)
        {
            InitializeComponent();

            determineReportType(callingButtonText);
        }

        #region Reporting Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/7/2013
        /// 
        /// Determines which report type to show based on what report button the
        /// user selected
        /// </summary>
        /// <param name="buttonText">
        /// The text of the calling button used to determine 
        /// which report to show
        /// </param>
        private void determineReportType(string callingButtonText)
        {
            try
            {
                if (callingButtonText == ReportType.TRANSACTIONS.ToString())
                    showTransactionReports();

                else if (callingButtonText == ReportType.COMMISSIONS.ToString())
                    showCommissionReports();

                else
                    MessageBox.Show("Report type could not be determined", "Unknown Report Call",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/4/2013
        /// 
        /// Shows a list of all transactions within the date range specified in the
        /// From and To Date textboxes
        /// </summary>
        private void showTransactionReports()
        {
            try
            {
                
            }

            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/4/2013
        /// 
        /// Shows a list of all commissions within the date range specified in the
        /// From and To Date textboxes
        ///< /summary>
        private void showCommissionReports()
        {
            try
            {
               
            }

            catch (Exception ex)
            {

            }
        }

        #endregion 
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Aliases for the Enum's inner classes
using StoreTransColumn = RecreationOutletPOS.Enum.StoreTransColumn;
using ReportType = RecreationOutletPOS.Enum.ReportType;
using SqlResultSet = RecreationOutletPOS.Enum.SqlResultSet;
using ListViewRowID = RecreationOutletPOS.Enum.ListViewRowID;

namespace RecreationOutletPOS
{
    public partial class ShowReportForm : Form
    {
        public string fromDateFilter;
        public string toDateFilter;

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/7/2013
        /// 
        /// Constructor
        /// </summary>
        /// <param name="callingButtonText">Used to determine which report to generate</param>
        /// <param name="begDate">The earliest date to show reports from</param>
        /// <param name="endDate">The latest date to show reports from</param>
        public ShowReportForm(string callingButtonText, string begDate, string endDate)
        {
            InitializeComponent();

            fromDateFilter = begDate;
            toDateFilter = endDate;

            determineReportType(callingButtonText);
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/7/2013
        /// 
        /// Determines which report type to show based on what report button the
        /// user selected
        /// </summary>
        /// <param name="buttonText">Used to determine which report to show</param>
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

        #region Reporting Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/4/2013
        /// 
        /// Shows a list of all transactions within the date range specified in the
        /// From and To Date textboxes
        /// </summary>
        private void showTransactionReports()
        {
            DataSet ds;
            
            try
            {
                ds = SqlHandler.getTransactionReport(fromDateFilter, toDateFilter);
                addListViewData(ds);
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

        #region ListView Populating Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/7/2013
        /// 
        /// Populates the Show Report Form's list view with a given DataSet object
        /// </summary>
        /// <param name="ds"></param>
        private void addListViewData(DataSet ds)
        {
            try
            {
                lvReportResults.Items.Clear();

                if (ds.Tables[SqlResultSet.TRANS_RESULTSET.ToString()].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[SqlResultSet.TRANS_RESULTSET.ToString()].Rows)
                    {
                        ListViewItem li = new ListViewItem(row[ListViewRowID.TRANS_ID.ToString()].ToString());

                        li.SubItems.Add(row[StoreTransColumn.TRANS_TOTAL.ToString()].ToString());
                        li.SubItems.Add(row[StoreTransColumn.TRANS_TAX.ToString()].ToString());
                        li.SubItems.Add(row[StoreTransColumn.PAYMENT_TYPE.ToString()].ToString());
                        li.SubItems.Add(row[StoreTransColumn.TRANS_DATE.ToString()].ToString());
                        li.SubItems.Add(row[StoreTransColumn.EMPLOYEE_ID.ToString()].ToString());
                        li.SubItems.Add(row[StoreTransColumn.MANAGER_ID.ToString()].ToString());
                        li.SubItems.Add(row[StoreTransColumn.STORE_ID.ToString()].ToString());
                        li.SubItems.Add(row[StoreTransColumn.TERMINAL_ID.ToString()].ToString());

                        lvReportResults.Items.Add(li);
                    }
                }
            }

            catch (Exception ex)
            {

            }
        }

        #endregion

        #region ListView Column Populating Methods

        private void populateListViewColumns()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void addTransReportColumns()
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

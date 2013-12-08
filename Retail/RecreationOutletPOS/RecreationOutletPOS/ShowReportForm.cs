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
        public string reportType;
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

            reportType = callingButtonText;
            fromDateFilter = begDate;
            toDateFilter = endDate;

            // Initializes the drop down boxes
            setInventoryFromValues();
            setSearchByValues();

            // Sets the default value for the drop down boxes
            cmbInventoryFrom.SelectedIndex = 0;
            cmbSearchBy.SelectedIndex = 2;

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
                lsvReportResults.Items.Clear();

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

                        lsvReportResults.Items.Add(li);
                    }
                }
            }

            catch (Exception ex)
            {

            }
        }

        #region Dropdown Populating Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/21/2013
        /// 
        /// Populates the Search By dropdown box 
        /// </summary>
        private void setSearchByValues()
        {
            List<StoreTransColumn> searchByValues = StoreTransColumn.getReportColumns();

            try
            {
                foreach (StoreTransColumn columnEnum in searchByValues)
                {
                    cmbSearchBy.Items.Add(columnEnum.ToString());
                }
            }

            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 11/21/2013
        /// 
        /// NOTE- hardcoded store names for now, this should be changed later when its
        /// possible to retrieve store names and their inventory
        /// 
        /// Populates the Inventory From dropdown box
        /// </summary>
        private void setInventoryFromValues()
        {
            List<string> inventoryLocations = new List<string>();

            try
            {
                inventoryLocations.Add("<This Store>");
                inventoryLocations.Add("Store 1");
                inventoryLocations.Add("Store 2");
                inventoryLocations.Add("Warehouse");

                foreach (string location in inventoryLocations)
                {
                    cmbInventoryFrom.Items.Add(location);
                }
            }

            catch (Exception ex)
            {

            }
        }

        #endregion

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
                setTransReportColumns();
                
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

        #region ListView Column Setting Methods

        /// <summary>
        /// Programmer: Michael Vuong
        /// Last Updated: 12/7/2013
        /// 
        /// Adds the STORE_TRANSACTION related table columns to the list view
        /// </summary>
        private void setTransReportColumns()
        {
            List<StoreTransColumn> reportColumns = new List<StoreTransColumn>();
            HorizontalAlignment align = HorizontalAlignment.Left;

            try
            {
                reportColumns = StoreTransColumn.getReportColumns();

                foreach (StoreTransColumn column in reportColumns)
                {
                    lsvReportResults.Columns.Add(column.ToString(), 130, align);
                }

            }

            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}

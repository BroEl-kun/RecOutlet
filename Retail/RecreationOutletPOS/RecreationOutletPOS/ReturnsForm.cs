using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecreationOutletPOS
{
    public partial class ReturnsForm : Form
    {
        public ReturnsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Programmer: Aaron Sorensen
        /// Last Updated: 10/23/2013
        /// 
        /// Switch to SalesForm (Work in progress)
        /// </summary>
        private void btnSales_Click(object sender, EventArgs e)
        {
            SalesForm myNewForm = new SalesForm();
            this.Hide();
            myNewForm.Show();
        }

        private void btnReturns_Click(object sender, EventArgs e)
        {

        }
    }
}

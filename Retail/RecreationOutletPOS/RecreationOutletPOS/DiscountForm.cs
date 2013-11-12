/*using System;
using System.Collections;
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
    public partial class DiscountForm : Form
    {
        /// <summary>
        /// Programmer: Nate Maurer
        /// Last Updated: 11/11/2013
        ///
        /// Constructor for the SalesForm calling this
        /// </summary>
        /// 
        SalesForm salesForm;
        TransactionItem d = new TransactionItem();

        public DiscountForm(SalesForm inForm)
        {
            this.salesForm = inForm;

            InitializeComponent();
        }

        private void tbDiscountPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string inPrice = tbDiscountPrice.Text;
                double price = Convert.ToDouble(inPrice);

                d.setDiscount(price);
            }
            catch(Exception ex)
            {
            }

        }
    }
}*/

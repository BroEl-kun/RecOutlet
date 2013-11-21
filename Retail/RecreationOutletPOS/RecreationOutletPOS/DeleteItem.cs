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
    public partial class DeleteItem : Form
    {
        private SalesForm parent;
        private int item;

        public DeleteItem(SalesForm parent, int item)
        {
            InitializeComponent();

            this.parent = parent;
            this.item = item;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int amount = 0;

            if (tbQuantity.Text == "")
            {
                MessageBox.Show("Quantity field can't be left blank.", "Item Void",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tbQuantity.Text = "1";
            }

            try
            {
                int.TryParse(tbQuantity.Text, out amount);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid value in quantity field.", "Item Void",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tbQuantity.Text = "1";
            }

            parent.voidItem(item, amount);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}

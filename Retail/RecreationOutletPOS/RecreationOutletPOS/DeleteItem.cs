﻿using System;
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
        private int item;

        //Constructor for combined form -Aaron
        Combined combined;
        public DeleteItem(Combined parent, int item)
        {
            InitializeComponent();

            this.combined = parent;
            this.item = item;
        }
        //-------------------------------------



        private void validateDeletion()
        {
            int amount = 0;
            bool failFlag = false;

            if (tbQuantity.Text == "")
            {
                MessageBox.Show("Quantity field can't be left blank.", "Item Void",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tbQuantity.Text = "1";
                failFlag = true;
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

            if (!failFlag)
            {
                if (combined != null)
                {
                    combined.voidItem(item, amount);
                }
                this.Close();
            }
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            validateDeletion();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

            if (e.KeyChar == 13)
            {
                validateDeletion();
            }
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

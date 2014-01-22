using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using SqlResultSet = RecreationOutletPOS.Enum.SqlResultSet;
using EmployeeTableColumn = RecreationOutletPOS.Enum.EmployeeTableColumn;

namespace RecreationOutletPOS
{
    public partial class Login : Form
    {
        Combined source;

        public Login()
        {
            InitializeComponent();
        }

        public Login(Combined c)
        {
            source = c;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblMessage.Hide();
            this.Location = new Point(source.Location.X + source.Width/2 - this.Width/2, source.Location.Y + source.Height/2 - this.Height/2);
            txtUser.Select();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
                //User Login
                string user = txtUser.Text.ToLower();
                string pass = txtPass.Text;

                DataSet ds = new DataSet();

                EmployeeLogin dt = new EmployeeLogin();

                try
                {
                    ds = dt.searchInventoryFor("Username", user);

                    if (ds.Tables[SqlResultSet.ITEM_RESULTSET.ToString()].Rows.Count != 0)
                    {
                        foreach (DataRow row in ds.Tables[SqlResultSet.ITEM_RESULTSET.ToString()].Rows)
                        {
                            if (row[EmployeeTableColumn.PIN.ToString()].ToString() == pass && row[EmployeeTableColumn.USERNAME.ToString()].ToString().ToLower() == user)
                            {
                                source.login(row[EmployeeTableColumn.NAME.ToString()].ToString(), row[EmployeeTableColumn.POSITION.ToString()].ToString().ToLower());
                                this.Close();
                            }
                            lblMessage.Show();
                        }
                    }
                    else
                    {
                        lblMessage.Show();
                    }
                }
                catch (Exception ex)
                {
                }
        }
    }
}

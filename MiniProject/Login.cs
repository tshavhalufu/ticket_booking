using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ID;
            ID = comboBoxLoginID.Text;
            ID = ID.ToUpper();

            bool blnValidatePassword = true;
            blnValidatePassword = ValidatePassword(blnValidatePassword);
            if(blnValidatePassword == true)
            {
                if(ID == "ADMIN")
                {
                    // declares a new instance of the Admin form (which, by default, is not visible)
                    Admin f1 = new Admin();
                    // makes the current form “invisible”
                    this.Visible = false;
                    // shows the new instance of the Admin form
                    f1.ShowDialog();
                }
                else if (ID == "FAN")
                {
                    // declares a new instance of the Admin form (which, by default, is not visible)
                    Reservation f1 = new Reservation();
                    // makes the current form “invisible”
                    this.Visible = false;
                    // shows the new instance of the Admin form
                    f1.ShowDialog();

                }
            }



        }
        
        private bool ValidatePassword(bool blnValidatePassword)
        {
            if(txtPassword.Text != "INFO2000" )
            {
                blnValidatePassword = false;
            }

            return blnValidatePassword;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxLoginID.Text = "";
            txtPassword.Text = "";
            comboBoxLoginID.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

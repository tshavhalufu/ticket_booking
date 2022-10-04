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
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
        }

        const double PArkingAmt = 100;
        const double HospitalityAmt = 1000;

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblDate.Text = ".......";
            lblMatchBooked.Text = "....";
            lblNumberOfPeople.Text = ".....";
            lblTotalCost.Text = "0.00";
            nudPeople.Value = 0;
            dateTimePicker1.Value = DateTime.Today;
            cboMatch.SelectedValue = " ";
            radBestinStands.Checked = false;
            radGeneral.Checked = false;
            radSuite.Checked = false;
            cbHospitality.Checked = false;
            cbParking.Checked = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // declares a new instance of the Admin form (which, by default, is not visible)
            Login f1 = new Login();
            // makes the current form “invisible”
            this.Visible = false;
            // shows the new instance of the Admin form
            f1.ShowDialog();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            int intMatchCount;
            for (intMatchCount = 0; intMatchCount < ArrayClass.Match.Length; ++intMatchCount)
            {
                cboMatch.Items.Add(ArrayClass.Match[intMatchCount]);
            }
        }

        private void makeAReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double dblprice = 0;
            double dblcost;

            bool blnValidateFormInput = true;
            blnValidateFormInput =  ValidateInput(blnValidateFormInput);

            if (blnValidateFormInput == true)
            {
                for (int i = 0; i < ArrayClass.Match.Length; i++)
                {
                    if (cboMatch.SelectedIndex == i)
                    {
                        dblprice = ArrayClass.LowestPrice[i];
                    }
                }

                dblcost = calculatePrice(dblprice);
                DisplayOutput(dblcost);
                
            }
        }

        public bool ValidateInput(bool blnValidateFormInput)
        {

            if(cboMatch.Text == "")
            {
                blnValidateFormInput = false;
                MessageBox.Show("Invalid Match Input");
            }
            if(Convert.ToInt32(this.nudPeople.Value) < 1 )
            {
                blnValidateFormInput = false;
                MessageBox.Show("Invalid Number of people");
            }
            if(radBestinStands.Checked == false && radGeneral.Checked ==false && radSuite.Checked == false)
            {
                blnValidateFormInput = false;
                MessageBox.Show("Please select the seating plan");
            }
            if((dateTimePicker1.Value - DateTime.Today).Days < 14)
            {
                MessageBox.Show("Please book for 14 day ahead");
                blnValidateFormInput = false;
            }

            if (cbParking.Checked == true && cbHospitality.Checked == true)
            {
                blnValidateFormInput = false;
                MessageBox.Show("Please select either parking or full hospitality");
            }

            return blnValidateFormInput;
        }

        public double calculatePrice(double dblprice)
        {
            double Finalprice = 0;
            if(radSuite.Checked == true)
            {
                Finalprice = 2500;
            }
            if(radGeneral.Checked == true)
            {
                Finalprice = dblprice + (0.01 * dblprice);
            }
            if(radBestinStands.Checked == true)
            {
                Finalprice = dblprice + (0.5 * dblprice);
            }

            Finalprice = Finalprice * Convert.ToInt32(nudPeople.Value);

            if(cbParking.Checked == true)
            {
                Finalprice = Finalprice + PArkingAmt;
            }
            if(cbHospitality.Checked == true)
            {
                Finalprice = Finalprice + (HospitalityAmt * Convert.ToInt32(nudPeople.Value));
            }

            return Finalprice;
        }
        public void DisplayOutput(double dblcost)
        {
            lblTotalCost.Text = dblcost.ToString("C2");
            lblNumberOfPeople.Text = Convert.ToString(nudPeople.Value);
            lblMatchBooked.Text = cboMatch.SelectedItem.ToString();
            lblDate.Text = dateTimePicker1.Value.ToLongDateString();

        }
    }
}

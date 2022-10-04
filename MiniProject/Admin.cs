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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        public static string InputBox(string prompt, string title, string defaultValue)
        {
            InputBoxDialog ib = new InputBoxDialog();
            ib.FormPrompt = prompt;
            ib.FormCaption = title;
            ib.DefaultValue = defaultValue;
            ib.ShowDialog();
            string s = ib.InputResponse;
            ib.Close();
            return s;
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            // declares a new instance of the Admin form (which, by default, is not visible)
            Login f1 = new Login();
            // makes the current form “invisible”
            this.Visible = false;
            // shows the new instance of the Admin form
            f1.ShowDialog();
        }

        private void btnAddMatch_Click(object sender, EventArgs e)
        {
            string[] NewMatch = new string[3];
            double[] NewLowestPrice = new double[3];

            for(int i = 0;i < 3; i++)
            {
                NewMatch[i] = Convert.ToString(InputBox("Enter the Match", "Match Input", ""));
                NewLowestPrice[i] = Convert.ToDouble(InputBox("Enter the ticket price", "Price Input", ""));
            }
            ArrayClass.Match = NewMatch;
            ArrayClass.LowestPrice = NewLowestPrice;
        }
    }

}

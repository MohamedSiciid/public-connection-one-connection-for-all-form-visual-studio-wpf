using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class AdminDashboardForm : Form
    {
        private readonly string Role;
        public AdminDashboardForm(string cmprole)
        {
            InitializeComponent();
            Role = cmprole;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPage lg = new LoginPage();
            lg.Show();
            this.Close();   
           

        }
        private void AdjustLayout()
        {
            // Assuming btnstaff is the button you want to hide
            // and controlBelowButton is the control directly below the button
            Control controlBelowButton = this.btnpayment; // Replace with your actual control

            // Calculate the new top position for the control below the button
            int newTopPosition = controlBelowButton.Top - btnpayment.Height - btnpayment.Margin.Bottom - controlBelowButton.Margin.Top;

            // Set the new top position to move the control up
            controlBelowButton.Top = newTopPosition;

            // Refresh the form to update the layout
            this.Refresh();
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            if (Role == "user")
            {
                btnstaff.Hide(); // Hide the button and remove the space
                AdjustLayout();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();

            }
        }
    }
}

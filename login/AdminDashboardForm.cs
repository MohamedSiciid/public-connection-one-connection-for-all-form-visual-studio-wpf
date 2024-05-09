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

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            if (Role == "user")
            {
                btnstaff.Visible = false; // Hide the button
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

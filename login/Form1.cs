using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace login
{
    public partial class Login : Form
    {
        private SqlConnection conn;
        public Login()
        {
            InitializeComponent();
            conn = DatabaseHelper.GetConnection();
        }

        public void loagin()
        {
            if (cmprole.Text.ToString()=="" && txtPassword.Text==""&&txtUsername.Text=="")
            {
                MessageBox.Show("empty space is not allowed");
            }
            else if (cmprole.SelectedItem.ToString() == "admin")
            {

                conn.Open();
                string select = "select * from Login where UserName='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'and UserRole='" + cmprole.Text + "'";
                SqlCommand cmd = new SqlCommand(select, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                if (dt.Rows.Count == 1)
                {
                    AdminDashboardForm fd = new AdminDashboardForm();
                    fd.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Username, Password or Role please  check", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtUsername.Focus();
                }
            }
            else if (cmprole.SelectedItem.ToString() == "user")
            {
                conn.Open();
                string select = "select * from Login where UserName='" + txtUsername.Text + "' and Password='" + txtPassword.Text + "'and UserRole='" + cmprole.Text + "'";
                SqlCommand cmd = new SqlCommand(select, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                if (dt.Rows.Count == 1)
                {
                    UserHomePageForm fd = new UserHomePageForm();
                    fd.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Username, Password or Role please  check", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtUsername.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please fill the blank or check your Role", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the initial state: hide password characters
            txtPassword.PasswordChar = '*';
            txtUsername.PlaceholderText = "Enter your Username";
            txtPassword.PlaceholderText = "Enter your Password";

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
           


        }

        private void picClose_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            try
            {
                // Show the "Show" button
                btnshow.Show();
                // Hide password characters
                txtPassword.PasswordChar = '*';
                txtPassword.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                // Hide the "Show" button
                btnshow.Hide();
                // Reveal actual characters
                txtPassword.PasswordChar = '\0';
                txtPassword.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            loagin();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

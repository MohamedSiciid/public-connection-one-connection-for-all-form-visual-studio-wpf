using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace login
{
    public partial class LoginPage : Form
    {
        private SqlConnection conn;
        public LoginPage()
        {
            InitializeComponent();
            conn = DatabaseHelper.GetConnection();
        }
        public void loadData1()
        {

            if (conn.State == ConnectionState.Open)
                conn.Close();
            string sqlquery = " SELECT * FROM Login";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlquery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM Login WHERE UserName = @UserName";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCommand.Parameters.AddWithValue("@UserName", txtuser.Text);
                        int rowsAffected = deleteCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data was deleted successfully.");
                            loadData1();
                        }
                        else
                        {
                            MessageBox.Show("No records found for the specified user.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                string insertQuery = "INSERT INTO Login (UserName, Password, UserRole) VALUES (@UserName, @Password, @UserRole)";
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, conn))
                {
                    insertCommand.Parameters.AddWithValue("@UserName", txtusername.Text);
                    insertCommand.Parameters.AddWithValue("@Password", txtpassword.Text);
                    insertCommand.Parameters.AddWithValue("@UserRole", cmprole.SelectedItem.ToString());
                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("data saved successfull");

                }
            }
            else
            {
                MessageBox.Show("connection is not open");
            }
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            loadData1();
            txtpassword.PasswordChar = '*';
            txtusername.PlaceholderText = "Enter your Username";
            txtpassword.PlaceholderText = "Enter your Password";

            txtuser.PlaceholderText = "Enter your Username";
            txtpass.PlaceholderText = "Enter your Password";
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnhide_Click(object sender, EventArgs e)
        {
            try
            {
                // Show the "Show" button
                btnshow.Show();
                // Hide password characters
                txtpassword.PasswordChar = '*';
                txtpassword.Focus();
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
                txtpassword.PasswordChar = '\0';
                txtpassword.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}

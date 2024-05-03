using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class LoginPageControl : UserControl
    {
        string cs = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        public LoginPageControl()
        {
            InitializeComponent();
            conn = new SqlConnection(cs);
        }

        private void btnSave_Click(object sender, EventArgs e)
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

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
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
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
namespace login
{
    public partial class LoginPageControl : UserControl
    {
        private SqlConnection conn;
        public LoginPageControl()
        {
            InitializeComponent();
            conn = DatabaseHelper.GetConnection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
           


        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

        }
    }
}

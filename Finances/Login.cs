using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Finances
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=VINCENTRAN93\SQLEXPRESS;Initial Catalog=FinancesDb;Integrated Security=True");
        public static string User;
        private void LoginBtn_Click(object sender, EventArgs e)
        {   
            if(UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter both the username and password");
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTbl where UName='" + UnameTb.Text + "' and Upass='" + PasswordTb.Text + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    User = UnameTb.Text;
                    Dashboard Obj = new Dashboard();
                    Obj.Show(); 
                    this.Hide();
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("Wrong UserName or Password!");
                    UnameTb.Text = "";
                    PasswordTb.Text = "";

                }
                Con.Close();
            }
            
        }
    }
}

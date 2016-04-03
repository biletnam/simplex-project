using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CTS
{
    public partial class Login : Form
    {
        //private object CTSDBDataSet;

        public Login()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SHASHI\\SQLEXPRESS;Initial Catalog=CTSDB;Integrated Security=True");
            con.Open();
            string usertype = comboBox1.Text.ToString();
            //MessageBox.Show(usertype);
            string username = textBox1.Text;
            string password = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select usertype,username,password from Users where usertype = '" +usertype+ "' and username='" + username + "' and password ='" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (usertype == "user")
                {
                    //MessageBox.Show("Login valid. Welcome. Press any key to continue.");
                    Home Homescreen = new Home();
                    Homescreen.Show();
                    this.Hide();
                }
                else
                {
                    AdminScreen showAdminscreen = new AdminScreen();
                    showAdminscreen.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Invalid login. Please check username and/or password.");
            }
            con.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cTSDBDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.cTSDBDataSet.Users);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AboutBox1 AboutSimp = new AboutBox1();
            AboutSimp.Show();
            
            
        }
    }
}

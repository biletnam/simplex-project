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
    public partial class AdminScreen : Form
    {
        string varWeekday;
        int varShownum;
        int varClass;
        

        public AdminScreen()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*varWeekday = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            varShownum = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            varClass = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            MessageBox.Show("Hello");*/

        }

        private void AdminScreen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cTSDBDataSet1.Ratecard' table. You can move, or remove it, as needed.
            this.ratecardTableAdapter1.Fill(this.cTSDBDataSet1.Ratecard);
            // TODO: This line of code loads data into the 'cTSDBDataSet2.Ratecard' table. You can move, or remove it, as needed.
            //this.ratecardTableAdapter.Fill(this.cTSDBDataSet2.Ratecard);
            // TODO: This line of code loads data into the 'cTSDBDataSet.Ratemaster' table. You can move, or remove it, as needed.
            //this.ratemasterTableAdapter.Fill(this.cTSDBDataSet.Ratemaster);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // update the rate
            SqlConnection con = new SqlConnection("Data Source=SHASHI\\SQLEXPRESS;Initial Catalog=CTSDB;Integrated Security=True");
            con.Open();
            string SQLstmt = "UPDATE Ratecard SET Rate=";
            SQLstmt += textBox1.Text;
            SQLstmt += " WHERE Day = '";
            SQLstmt += varWeekday;
            SQLstmt += "' AND ShowNum = ";
            SQLstmt += varShownum;
            SQLstmt += " AND SeatClass = ";
            SQLstmt += varClass;
            SqlCommand cmd = new SqlCommand(SQLstmt, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("New rate has been updated.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Code to insert new user in User table
            string Usertype = "user";
            string Username = textBox2.Text;
            string Password = textBox3.Text;
            SqlConnection con2 = new SqlConnection("Data Source=SHASHI\\SQLEXPRESS;Initial Catalog=CTSDB;Integrated Security=True");
            con2.Open();
            string query = "insert into Users (Usertype,Username,Password) values ('" + Usertype + "','" + Username + "','" + Password + "')";
            SqlCommand cmd = new SqlCommand(query, con2);
            cmd.ExecuteNonQuery();
            MessageBox.Show("New user has been added.");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            varWeekday = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            varShownum = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            varClass = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //MessageBox.Show("Hello");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}

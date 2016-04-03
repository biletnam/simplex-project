using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTS
{
    public partial class Home : Form
    {
        //private object button1;

        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Booking Form2 = new Booking(button1.Text,label4.Text);
            Form2.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Booking Form2 = new Booking(button2.Text,label5.Text);
            Form2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Booking Form2 = new Booking(button3.Text,label6.Text);
            Form2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Booking Form2 = new Booking(button4.Text,label7.Text);
            Form2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}


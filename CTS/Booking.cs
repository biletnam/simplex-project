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
    public partial class Booking : Form
    {
        public Booking(string movieName,string screenNo)
        {
            InitializeComponent();
            label3.Text = movieName;
            label6.Text = screenNo;
            dateTimePicker1.MinDate = DateTime.Now;
        }

        private void Booking_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Screen2Seat Form3 = new Screen2Seat(movieName,screenNo);
            //Form3.Show();
            //this.Hide();
        }

        //private void label2_Click(object sender, EventArgs e)
       // {
       //
        //}
    }
}

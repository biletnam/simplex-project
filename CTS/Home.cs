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
            Screen2Seat Form2 = new Screen2Seat(button1.Text,button1.Tag.ToString());
            Form2.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            MinimumSize = this.Size;
            MaximumSize = this.Size;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Screen2Seat Form2 = new Screen2Seat(button2.Text,button2.Tag.ToString());
            Form2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Screen2Seat Form2 = new Screen2Seat(button3.Text,button3.Tag.ToString());
            Form2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Screen2Seat Form2 = new Screen2Seat(button4.Text,button4.Tag.ToString());
            Form2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}


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
    public partial class Screen1SeatSel : Form
    {
        int[] seatnum;
        public Screen1SeatSel()
        {
            InitializeComponent();
            seatnum = new int[200];
            //button1.BackColor = Color.LightGreen;
            for (int i=0;i<200;i++)
            {
                seatnum[i] = 0;
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (seatnum[0]==0)
            {
                //button1.BackColor = Color.Blue;
                seatnum[0] = 1;
                MessageBox.Show("Button 1 =" + seatnum[0]);
            }
        }

        private void Screen1SeatSel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cTSDBDataSet1.Screenmaster' table. You can move, or remove it, as needed.
            this.screenmasterTableAdapter.Fill(this.cTSDBDataSet1.Screenmaster);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                    
        }
    }
}

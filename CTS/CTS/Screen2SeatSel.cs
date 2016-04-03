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
    public partial class Screen2Seat : Form, ISeats
    {
        List<Control> listControls = new List<Control>();
        List<string> seatsBooked = new List<string>();
        List<Button> listButtons = new List<Button>();
        private bool button1Clicked = true;
        Button[] btn = new Button[220];
        public Screen2Seat()
        {
            InitializeComponent();
            List<Button> lstbtn = new List<Button>();
            DataGrid oDataGrid = new DataGrid();

            /*for (int x = 1; x <= 220; x++)
            {
                lstbtn.Add(button1Clicked + x);
            }*/
            GetAllControl(this, listControls);
            foreach (Control control in listControls)
            {
                if (control.GetType() == typeof(Button))
                {
                    //all btn
                    ((Button)control).Click += Screen2Seat_Click;
                    listButtons.Add(((Button)control));
                }
            }
        }


        private void Screen2Seat_Click(object sender, EventArgs e)
        {
            AddCurrentSeat(((Button)sender).Name);
            MessageBox.Show(((Button)sender).Name);
        }


        private void GetAllControl(Control c, List<Control> list)
        {
            foreach (Control control in c.Controls)
            {
                list.Add(control);


                if (control.GetType() == typeof(Panel))
                    GetAllControl(control, list);
            }
        }


        public void AddCurrentSeat(string seatNumber)
        {
            seatsBooked.Add(seatNumber);
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (var item in seatsBooked)
            {
                MessageBox.Show(item);
            }

        }
    }
}
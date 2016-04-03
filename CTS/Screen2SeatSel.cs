using System;
using System.Collections;
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
    public partial class Screen2Seat : Form, ISeats
    {
        List<Control> listControls = new List<Control>();
        List<string> seatsBooked = new List<string>();
        List<Button> listButtons = new List<Button>();
        private bool button1Clicked = true;
        Button[] btn = new Button[220];
        int scrNo;
        double totalAmount = 0.0;
        const int seatsInHall = (16 * 5) + (16 * 3) + (8 * 2);
        bool billed = false;
        string selseatssend = "";
        string movienamesend = "";
        string scrnosend = "";


        public Screen2Seat(string movieName, string screenNo)
        {
            InitializeComponent();
            label3.Text = movieName;
            movienamesend = movieName;
            label6.Text = screenNo;
            scrnosend = screenNo;
            scrNo = int.Parse(screenNo);
            dateTimePicker1.MinDate = DateTime.Now;

            rightShowTime();
            GetAllControl(this, listControls);
            foreach (Control control in listControls)
            {
                if (control.GetType() == typeof(Button))
                {
                    //all btn
                    if (((Button)control).Tag != "exclude")
                    {
                        ((Button)control).Click += Screen2Seat_Click;
                        listButtons.Add(((Button)control));
                    }
                }
            }


        }


        private void Screen2Seat_Click(object sender, EventArgs e)
        {
            //string tempb = "Booked:" ;

            AddCurrentSeat(((Button)sender).Text);
            // disable the selected seat to avoid double booking
            ((Button)sender).Enabled = false;

            //update the status display
            //label12.Text = (seatsBooked.Count).ToString();

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

        private void button104_Click(object sender, EventArgs e)
        {

        }

        private void Screen2Seat_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            MinimumSize = this.Size;
            MaximumSize = this.Size;

        }

        // handler for GENERATE BILL button
        private void button5_Click(object sender, EventArgs e)
        {
            // display the selected seats, amount etc.
            string tempb = "";
            double amount = 0.0;
            double rate = 150.0;
            int seatcount = 0;


            // to be deleted
            foreach (var item in seatsBooked)
            {
                tempb += item;
                tempb += ", ";
            }
            selseatssend = tempb;

            //Getting date from datepicker1
            DateTime showDate = dateTimePicker1.Value;

            //Getting showNum from comboBox1
            int showNum = comboBox1.SelectedIndex + 1;

            seatcount = seatsBooked.Count;
            for (int i = 0; i < seatcount; i++)
            {
                string seatNo = seatsBooked.ElementAt(i);
                //Getting rate from db
                rate = getRate(showDate, showNum, seatNo);
                amount += rate;
            }

            totalAmount = amount;
            label12.Text = tempb;
            label20.Text = amount.ToString();
            billed = true;
        }

        public double getRate(DateTime sDate, int sNum, string seatNo)
        {
            //Get day of week
            int sDay = (int)sDate.DayOfWeek;
            string wkDayEnd;
            int sClass;
            int rowNum = 0; // row number 
            string columnName = "Rate";
            double varRate = 0.0;
            const int SUNDAY = 0;
            const int FRIDAY = 5;
            const int SATURDAY = 6;

            // Friday, Saturday and Sunday are considered weekend
            if (sDay == SUNDAY || sDay == FRIDAY || sDay == SATURDAY)
            {
                wkDayEnd = "Weekend";
            }
            else
            {
                wkDayEnd = "Weekday";
            }

            // determine the seat class from the seat number
            // Gold   = 1
            // Silver = 2
            // Rows I and J are Gold class; rest are Silver
            // Seat numbers are alphanumeric. Ex: A12, I7 etc.
            // The first letter gives the row number. Hence use of seatNo[0]
            if (seatNo[0] == 'I' || seatNo[0] == 'J')
            {
                sClass = 1;     // gold
            }
            else
            {
                sClass = 2;     // silver
            }


            //Retrieving rate from db
            SqlConnection con = new SqlConnection("Data Source=SHASHI\\SQLEXPRESS;Initial Catalog=CTSDB;Integrated Security=True");
            con.Open();
            //string query2 = "SELECT Rate FROM Ratecard WHERE Day = '"+wkDayEnd+"' AND ShowNum = '"+sNum +"' AND SeatClass = '"+sClass+'"';
            string query = "SELECT Rate FROM Ratecard WHERE Day = ";
            query += "'";
            query += wkDayEnd;
            query += "'";
            query += " AND ShowNum = ";
            query += sNum;
            query += " AND SeatClass = ";
            query += sClass;

            //MessageBox.Show(query);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //SQL successful
                rowNum = 0; // row number 
                columnName = "Rate"; // database table column name
                //MessageBox.Show(dt.Rows[rowNum][columnName].ToString());
                varRate = (double)dt.Rows[rowNum][columnName];
            }

            return (varRate);
        }

        // handler for Book Tickets button
        // inserts data into the SeatsBooked and Booking tables
        private void button7_Click(object sender, EventArgs e)
        {
            int seatcount = 0;
            string seatNo;
            int bid = 1;
            string showDate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            int showno = (comboBox1.SelectedIndex) + 1;

            if (billed == false)
            {
                MessageBox.Show("Please generate bill first");
                return;
            }
            //Testing stuff with msgboxes
            //MessageBox.Show("Scr :" + scrNo);
            //string showDate = dateTimePicker1.Value.ToShortDateString();
            //MessageBox.Show("Date :" + showDate);
            //MessageBox.Show("Show no : " + showno.ToString());
            //MessageBox.Show("Seats booked :" + seatsBooked.ElementAt(0));
            //MessageBox.Show("Amount: " + totalAmount);
            SqlConnection con = new SqlConnection("Data Source=SHASHI\\SQLEXPRESS;Initial Catalog=CTSDB;Integrated Security=True");
            con.Open();
            string query = "select max(Bid) from Seatsbooked";
            SqlCommand cmd = new SqlCommand(query, con);
            //cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
           
            if ((dt.Rows.Count > 0))
             {
                //SQL successful
                int rowNum = 0; // row number 
                string columnName = "Bid"; // database table column name
                //MessageBox.Show(dt.Rows[rowNum][columnName].ToString());
                bid = Int32.Parse((dt.Rows[0][0]).ToString());
                bid++;
            }
            else
            {
                bid = 1;
            }


            //insert records into table seatsBooked
            seatcount = seatsBooked.Count;
            for (int i = 0; i < seatcount; i++)
            {
                seatNo = seatsBooked.ElementAt(i);
                SqlConnection con2 = new SqlConnection("Data Source=SHASHI\\SQLEXPRESS;Initial Catalog=CTSDB;Integrated Security=True");
                con2.Open();
                string query2 = "insert into Seatsbooked (Bid,Screen,ShowDate,ShowNum,SeatNum) values (" + bid + "," + scrNo + ",'" + showDate + "'," + showno + ",'" + seatNo + "')";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.ExecuteNonQuery();



            }

            //insert records into table Booking
            SqlConnection con3 = new SqlConnection("Data Source=SHASHI\\SQLEXPRESS;Initial Catalog=CTSDB;Integrated Security=True");
            con3.Open();
            string query3 = "insert into Booking (Bid,Screen,ShowDate,ShowNum,Price) values (" + bid + "," + scrNo + ",'" + showDate + "'," + showno + "," + totalAmount + ")";
            SqlCommand cmd3 = new SqlCommand(query3, con3);
            cmd3.ExecuteNonQuery();

            MessageBox.Show("Tickets booked successfully!");
            PrintPDFTicket showPDF = new PrintPDFTicket(selseatssend,movienamesend,scrnosend);
            showPDF.Show();
           
        }
            
   
  
        private void button134_Click(object sender, EventArgs e)
        {
            // refresh the seating based on the date and screen chosen
            string showDt = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            int showNo = (comboBox1.SelectedIndex) + 1;
            int rowcount = 0;
            int rowNum = 0;
            int btncount = 0;
            int i;
            string btntext;
            string columnName = "SeatNum";

            SqlConnection con4 = new SqlConnection("Data Source=SHASHI\\SQLEXPRESS;Initial Catalog=CTSDB;Integrated Security=True");
            con4.Open();
            //string query4 = "SELECT SeatNum FROM Seatsbooked WHERE ShowDate= '" + showDt + "' AND ShowNum="+showNo+";
            string query4 = "SELECT SeatNum FROM Seatsbooked WHERE Screen = ";
            query4 += scrNo;
            query4 += " AND ShowDate = ";
            query4 += "'";
            query4 += showDt;
            query4 += "'";
            query4 += " AND ShowNum = ";
            query4 += showNo;

            //MessageBox.Show(query);
            SqlCommand cmd4 = new SqlCommand(query4, con4);
            //cmd4.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rowcount = dt.Rows.Count;
            rowNum = 0; // row number 
            columnName = "SeatNum"; // database table column name

            while (rowcount > 0)
            {
                //SQL successful
                btntext = dt.Rows[rowNum][columnName].ToString();
                btncount = listButtons.Count;
                for (i = 0; i < btncount; i++)
                {

                    if (listButtons.ElementAt(i).Text == btntext)
                    {
                        listButtons.ElementAt(i).Enabled=false;
                    }

                }
                rowNum++;
                rowcount--;
            }
        }

        private void button135_Click(object sender, EventArgs e)
        {
            // to be deleted. only for practice
            /*
            List<string> fruits = new List<string> { "apple", "passionfruit", "banana", "mango",
                    "orange", "blueberry", "grape", "strawberry" };

            IEnumerable<string> query = fruits.Where(junk => junk.Length < 6);

            foreach (string junk in query)
            {
                MessageBox.Show(junk);
            }
            */

            //IEnumerable<Button> query2 = listButtons.Where(btext => btext.Text == "J4");
            int btncount = listButtons.Count;
            for (int i=0; i<btncount;i++)
            {

                if(listButtons.ElementAt(i).Text == "A1")
                {
                    MessageBox.Show(listButtons.ElementAt(i).Name);
                }
                
            }
            
             /*
            foreach (Button btext in query2)
            {
                MessageBox.Show(btext);
            } */
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Home Homescreen = new Home();
            Homescreen.Show();
            this.Hide();
            
        }

        //Function to show correct showtimes
        public void rightShowTime()
        {
            int i=0;
            DateTime tmpshowDt = dateTimePicker1.Value.Date;
            DateTime dateNow = DateTime.Now.Date;
            DateTime timeNow = DateTime.Now;
            int count = 0;
            count = comboBox1.Items.Count;
            for (int j=0;j<count;j++)
            {
                comboBox1.Items.RemoveAt(0);
            }
            DateTime op1 = Convert.ToDateTime("10:00:00 AM");
            DateTime op2 = Convert.ToDateTime("01:00:00 PM");
            DateTime op3 = Convert.ToDateTime("05:00:00 PM");
            DateTime op4 = Convert.ToDateTime("10:00:00 PM");

            comboBox1.Items.Add("Morning (10:00 am)");
            comboBox1.Items.Add("Matinee (01:00 pm)");
            comboBox1.Items.Add("Evening (05:00 pm)");
            comboBox1.Items.Add("Night (10:00 pm)");

            comboBox1.SelectedIndex = 0;

            //Time check is required only for today
            if (tmpshowDt == dateNow)
            {
                i = DateTime.Compare(timeNow, op1);
                if (i > 0)
                {
                    comboBox1.Items.RemoveAt(0);
                    comboBox1.SelectedIndex = 0;
                }

                i = DateTime.Compare(timeNow, op2);
                if (i > 0)
                {
                    comboBox1.Items.RemoveAt(0);
                    comboBox1.SelectedIndex = 0;
                }

                i = DateTime.Compare(timeNow, op3);
                if (i > 0)
                {
                    comboBox1.Items.RemoveAt(0);
                    comboBox1.SelectedIndex = 0;
                }

                i = DateTime.Compare(timeNow, op4);
                if (i > 0)
                {
                    comboBox1.Items.RemoveAt(0);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            rightShowTime();
        }

        private void dateTimePicker1_LostFocus(object sender,EventArgs e)
        {
            
        }

        private void button135_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
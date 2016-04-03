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
    public partial class TestingPurposeOnly : Form
    {
        public TestingPurposeOnly()
        {
            InitializeComponent();
        }

        private void TestingPurposeOnly_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.RemoveAt(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.RemoveAt(1);
        }
    }
}

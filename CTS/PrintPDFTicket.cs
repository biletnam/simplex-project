using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CTS
{
    public partial class PrintPDFTicket : Form
    {
        int x = 40;
        int y = 30;
        PdfPage pdfp;
        XGraphics graph;

        public PrintPDFTicket(string selseatssend,string movienamesend,string scrnosend)
        {
            InitializeComponent();
            PdfDocument pdf = new PdfSharp.Pdf.PdfDocument();
            label1.Text = "Tickets printed.";
            pdfp = pdf.AddPage();
            graph = XGraphics.FromPdfPage(pdfp);
            XFont font_title = new XFont("Franklin Gothic Heavy", 20, XFontStyle.Bold);
            XFont font_normal = new XFont("Segoe UI", 11, XFontStyle.Regular);
            writePdfText("SimPlex Cinemas", font_title, "Blue");
            y += 20;
            writePdfText("MOVIE TICKET | ADMIT ONE PER SEAT", font_normal, "Black");
            y += 10;
            writePdfText("Screen number: " +scrnosend, font_normal, "Black");
            y += 10;
            writePdfText("Movie name: " + movienamesend, font_normal, "Black");
            y += 10;
            writePdfText("Seat Number:" +selseatssend, font_normal, "Black");
            y += 20;
            writePdfText("Preserve ticket till end of show. All Rights Reserved.", font_normal, "Black");

            pdf.Save("FirstPDF.pdf");

            //label2.Text = "PDF creation completed";
        }

        private void writePdfText(string text, XFont fonttype, string pdfTextColour)
        {
            XSolidBrush textColour = new XSolidBrush();

            switch (pdfTextColour)
            {

                case "Black":
                    textColour = XBrushes.Black;
                    break;
                case "Blue":
                    textColour = XBrushes.Blue;
                    break;

                default: break;

            }


            graph.DrawString(text, fonttype, textColour,
                new XRect(x, y, pdfp.Width.Point, pdfp.Height.Point), XStringFormats.
                TopLeft);


        }

        private void PrintPDFTicket_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"FirstPDF.pdf");
            
        }
    }
}

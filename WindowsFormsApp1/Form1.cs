using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using System.Drawing.Printing;
using System.Net.Mail;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            updatebarcode("", "99.99");
        }
               
        private void updatebarcode(string BarcodeText, string weight)
        {
            try
            {
                var barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128,
                    Options = new EncodingOptions
                    {
                        Height = 200,
                        Width = 500,
                        Margin = 1,
                    }
                };
                //Weight in pounds 3202 with 2 decmial places
                //string content = "VIKBDA" +BarcodeText + "3102" + weight;
                string date = System.DateTime.Today.ToString("yyMMdd");
                
                Decimal weightformated = Math.Round(Convert.ToDecimal(weight),2);
                String weightformated2 = weightformated.ToString("0000.00");
                String weightformated3 = weightformated2.Replace(".","");
                //string test = string.Format("{0:0.00}", weightformated.ToString());
                //string test2 = string.Format("%05d", test);
                //20 = product varient , 11 = producation date, 3102, weigt

                string textepadde = BarcodeText.PadLeft(textBox1.MaxLength);

                string content = "11" + date +"3202" + weightformated3 + "90" + textepadde;

                //string content = weightformated.ToString();
                //string content = ($"{(char)0x00F1}91AK905{(char)0x00F1}3102");

                var barcodeImage = barcodeWriter.Write(content);

                pictureBox1.Image = barcodeImage;

                Graphics gr = Graphics.FromImage(barcodeImage);

                Font myFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                String textToDraw = "    Viking Code: " + BarcodeText + "   Weight: " + weight;

                //Size sizeOfText = TextRenderer.MeasureText(textToDraw, myFont);

                Rectangle rect = new Rectangle(0,0,Width,20);

                gr.FillRectangle(Brushes.White, rect);

                gr.DrawString(textToDraw, myFont,drawBrush,0,0);


                pictureBox1.Invalidate();

                //label1.Text = "Viking Code: " + content + "   Weight: " + weight;
            }
            catch
            {

            }
        }

        private void printimage()
        {
            if (textBox1.Text.Length >= 3)
            {
                PrintDocument pd = new PrintDocument();

                //pd.PrinterSettings.PrinterName = "CutePDF Writer";
                string printer = @"\\viking-print16\Front";
                pd.PrinterSettings.PrinterName = printer;

                pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                pd.DefaultPageSettings.Landscape = true;
                pd.DefaultPageSettings.Margins = new Margins(1, 1, 1, 1);

                pd.Print();

                /*
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "viking-bm.mail.protection.outlook.com";
                mail.To.Add(new MailAddress("admin@viking.bm"));
                mail.From = new MailAddress("lablelogger@viking.bm");
                mail.Subject = "New Lablel";
                string emailbody = "Label Printed For: " + textBox1.Text + " Weight: " + label3.Text + " At Time: " +System.DateTime.Now.ToString();
                mail.Body = emailbody;
                client.Send(mail);
                */

                textBox1.Text = "";
                textBox1.Focus();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 0, 0);
        }

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                updatebarcode(textBox1.Text, label3.Text);
                printimage();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updatebarcode(textBox1.Text, label3.Text);
            printimage();           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updatebarcode(textBox1.Text, label3.Text);
        }
    }
}

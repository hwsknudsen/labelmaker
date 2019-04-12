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
using System.IO.Ports;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            labelScaleWeight.Text = Getweight().ToString();
            updatebarcode("", labelScaleWeight.Text);
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

                string textepadde = BarcodeText.PadLeft(textBoxMain.MaxLength);



                Boolean manual = true;
                if (textBoxWeight.Text.Length != 0)
                {
                    manual = false;
                }

                string manual2 = "";
                if (manual == true)
                {
                    manual2 = "Y";
                }
                else
                {
                    manual2 = "N";
                }




                string content = "11" + date +"3202" + weightformated3 + "90" + textepadde;
                String textToDraw = "  Viking Code: " + BarcodeText + " Weight: " + weight + " SCALE:" + manual2;
                string contentoverlay = "    (11)" + date + "(3202)" + weightformated3 + "(90)" + textepadde + "\n" + "    www.viking.bm Tel: +1.441.238.2211";

                if (weightformated == 0)
                {
                    content = "11" + date + "90" + textepadde;
                    textToDraw = "  Viking Code: " + BarcodeText;
                    contentoverlay = "    (11)" + date + "(90)" + textepadde + "\n" + "    www.viking.bm Tel: +1.441.238.2211";

                }

                var barcodeImage = barcodeWriter.Write(content);
                pictureBox1.Image = barcodeImage;

                Graphics gr = Graphics.FromImage(barcodeImage);

                Font myFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                                
                Rectangle rect = new Rectangle(0,0,Width,22);

                gr.FillRectangle(Brushes.White, rect);

                gr.DrawString(textToDraw, myFont,drawBrush,0,0);

                int boxstart = 150;

                Rectangle rect2 = new Rectangle(0, boxstart, Width, Height-boxstart);

                gr.FillRectangle(Brushes.White, rect2);

                gr.DrawString(contentoverlay, myFont, drawBrush, 0, boxstart+1);
                                                 
                pictureBox1.Invalidate();
                                                         

            }
            catch
            {

            }
        }

        private void printimage()
        {
            if (textBoxMain.Text.Length >= 3)//sanity check for minmum code length
            {
                PrintDocument pd = new PrintDocument();

                //pd.PrinterSettings.PrinterName = "CutePDF Writer";
                //string printer = @"\\viking-print16\Front";
                string printer = "Rollo Printer";

                pd.PrinterSettings.PrinterName = printer;

                pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                pd.DefaultPageSettings.Landscape = true;
                pd.DefaultPageSettings.Margins = new Margins(1, 1, 1, 1);

                
                while (numericUpDownPrintQuantity.Value > 1) {
                    pd.Print();
                    numericUpDownPrintQuantity.Value = numericUpDownPrintQuantity.Value - 1;
                }
               
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

                //set current code entery to old code in case reentry is desired

                textBoxOld.Text = textBoxMain.Text;
                textBoxMain.Text = "";
                textBoxMain.Focus();
                textBoxWeight.Clear();

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
                updateandPrint();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateandPrint();          
        }

        private void updateandPrint()
        {
            if (textBoxWeight.TextLength != 0) { //Make the barcode Custom Weight
                updatebarcode(textBoxMain.Text, textBoxWeight.Text);
                printimage(); //Print the bar code
            }
            else
            { //make the barcode scale weight
                labelScaleWeight.Text = Getweight().ToString();
                updatebarcode(textBoxMain.Text, labelScaleWeight.Text);
                printimage(); //Print the bar code
            }
        }


      

        private void textBox1_TextChanged(object sender, EventArgs e) //update
        {
            labelScaleWeight.Text = Getweight().ToString();
            updatebarcode(textBoxMain.Text, labelScaleWeight.Text);
        }

        private object Getweight()
        {

            double weight = 00.00;

            try//try and get weight from scale return 0 if no weight
            {
                SerialPort port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
                port.Open();
                string raw = port.ReadLine();

                double newweight = 00.00;
                try
                {
                    string substring = raw.Substring(4, 5);
                    newweight = Convert.ToDouble(substring);
                }
                catch
                {

                }

                //Console.WriteLine(weight);

                //weight = Convert.ToDouble(raw.Substring(0, 8));

                port.Close();

                if (newweight > 0 & newweight < 100) //sainity check for weight from scale
                {
                    weight = newweight;
                }
            }
            catch {
            }
            return weight;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)  //update barcode
        {
            if (textBoxWeight.TextLength != 0)
            {
                updatebarcode(textBoxMain.Text, textBoxWeight.Text);
            }
            else
            {
                updatebarcode(textBoxMain.Text, labelScaleWeight.Text);
            }
        }

        private void button2_Click_1(object sender, EventArgs e) //print old
        {
            textBoxMain.Text = textBoxOld.Text;
            textBoxMain.Focus();
            updateandPrint();
        }
    }
}

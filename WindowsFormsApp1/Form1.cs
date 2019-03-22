﻿using System;
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
            label3.Text = Getweight().ToString();
            updatebarcode("", label3.Text);
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
               
                if (weightformated == 0)
                {
                    content = "11" + date + "90" + textepadde;
                }
                //string content = weightformated.ToString();
                //string content = ($"{(char)0x00F1}91AK905{(char)0x00F1}3102");

                var barcodeImage = barcodeWriter.Write(content);
                pictureBox1.Image = barcodeImage;

                Graphics gr = Graphics.FromImage(barcodeImage);

                Font myFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                Boolean manual = true;
                if (textBox2.Text.Length != 0)
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


                
                String textToDraw = "  Viking Code: " + BarcodeText + " Weight: " + weight + " SCALE:"+ manual2;
                if (weightformated == 0)
                {
                    textToDraw = "  Viking Code: " + BarcodeText;
                }



                //Size sizeOfText = TextRenderer.MeasureText(textToDraw, myFont);

                Rectangle rect = new Rectangle(0,0,Width,22);

                gr.FillRectangle(Brushes.White, rect);

                gr.DrawString(textToDraw, myFont,drawBrush,0,0);


                int boxstart = 150;

                string contentoverlay = "    (11)" + date + "(3202)" + weightformated3 + "(90)" + textepadde +"\n" + "    www.viking.bm Tel: +1.441.238.2211";
                if (weightformated == 0)
                {
                    contentoverlay = "    (11)" + date + "(90)" + textepadde + "\n" + "    www.viking.bm Tel: +1.441.238.2211";
                }

                Rectangle rect2 = new Rectangle(0, boxstart, Width, Height-boxstart);

                gr.FillRectangle(Brushes.White, rect2);

                gr.DrawString(contentoverlay, myFont, drawBrush, 0, boxstart+1);
                               
                //string contentoverlay2 = "    www.viking.bm Tel:+1.441.238.2211 \n hi";
                //Rectangle rect3 = new Rectangle(0, 175, Width, 30);

                //gr.FillRectangle(Brushes.White, rect3);

                //gr.DrawString(contentoverlay2, myFont, drawBrush, 0, boxstart+25);

                                          
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
                //string printer = @"\\viking-print16\Front";
                string printer = "Rollo Printer";

                pd.PrinterSettings.PrinterName = printer;

                pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                pd.DefaultPageSettings.Landscape = true;
                pd.DefaultPageSettings.Margins = new Margins(1, 1, 1, 1);

                
                while (numericUpDown1.Value > 1) {
                    pd.Print();
                    numericUpDown1.Value = numericUpDown1.Value - 1;
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

                textBox3.Text = textBox1.Text;
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
                updateandPrint();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateandPrint();          
        }

        private void updateandPrint()
        {
            if (textBox2.TextLength!=0) { //Make the barcode Custom Weight
                updatebarcode(textBox1.Text, textBox2.Text);
                textBox2.Clear();
            }
            else{ //make the barcode scale weight
                label3.Text = Getweight().ToString();
                updatebarcode(textBox1.Text, label3.Text);
            }
            printimage(); //Print the bar code
        }


      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = Getweight().ToString();
            updatebarcode(textBox1.Text, label3.Text);
        }

        private object Getweight()
        {

            double weight = 00.00;

            try//try adn get weight from scale return 0 if no weight
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

                if (newweight > 0 & newweight < 100)
                {
                    weight = newweight;
                }
            }
            catch {
            }
            return weight;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength != 0)
            {
                updatebarcode(textBox1.Text, textBox2.Text);
            }
            else
            {
                updatebarcode(textBox1.Text, label3.Text);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox3.Text;
            textBox1.Focus();
            updateandPrint();
        }
    }
}

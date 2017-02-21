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
using System.Drawing.Imaging;

namespace EmploymentContractMaker
{
    public partial class Form1 : Form
    {
        Bitmap whiteImg;
        Bitmap studentImg;
        Bitmap teacherImg;
        String startdate = "";
        String enddate = "";
        String feenumber = "";
        Bitmap dateImg;
        Bitmap numberImg;

        public Bitmap StringTo32bppArgbBitmap(String str, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h, PixelFormat.Format32bppArgb);
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                    bmp.SetPixel(i, j, Color.White);
            Graphics g = Graphics.FromImage(bmp);
            Font drawFont = new Font("Arial", 14);
            RectangleF drawRect = new RectangleF(0, 0, 210, 20);
            StringFormat drawFormat = new StringFormat();
            g.DrawString(str, drawFont, Brushes.Black, drawRect, drawFormat);
            g.Flush();
            return bmp;
        }

        public Bitmap StreampTo32bppArgbBitmap(Stream myStream)
        {
            Bitmap orig;
            Bitmap newimg;
            using (myStream)
            {
                orig = new Bitmap(myStream);
                newimg = new Bitmap(orig.Width, orig.Height, PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(newimg))
                {
                    gr.DrawImage(orig, new Rectangle(0, 0, orig.Width, orig.Height));
                }
            }
            return newimg;
        }

        public Bitmap TryToCreateResultBitmap()
        {
            Bitmap newimg = null;
            if (whiteImg != null)
            {
                newimg = new Bitmap(whiteImg.Width, whiteImg.Height, PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(newimg))
                {
                    gr.DrawImage(whiteImg, new Rectangle(0, 0, whiteImg.Width, whiteImg.Height));
                }
            }
            else
            {
                return null;
            }
            if (studentImg != null && teacherImg != null && !startdate.Equals("") && !enddate.Equals("") && !feenumber.Equals(""))
            {

                for (int i = 0; i < studentImg.Width; i++)
                {
                    for (int j = 0; j < studentImg.Height; j++)
                    {
                        newimg.SetPixel(535 + i, 978 + j, studentImg.GetPixel(i, j));
                    }
                }
                for (int i = 0; i < teacherImg.Width; i++)
                {
                    for (int j = 0; j < teacherImg.Height; j++)
                    {
                        newimg.SetPixel(630 + i, 1403 + j, teacherImg.GetPixel(i, j));
                    }
                }
                String date = startdate + " ~ " + enddate;
                dateImg = StringTo32bppArgbBitmap(date, 205, 20);
                for (int i = 0; i < dateImg.Width; i++)
                {
                    for (int j = 0; j < dateImg.Height; j++)
                    {
                        newimg.SetPixel(994 + i, 223 + j, dateImg.GetPixel(i, j));
                    }
                }
                numberImg = StringTo32bppArgbBitmap(feenumber, 140, 20);
                for (int i = 0; i < numberImg.Width; i++)
                {
                    for (int j = 0; j < numberImg.Height; j++)
                    {
                        newimg.SetPixel(713 + i, 225 + j, numberImg.GetPixel(i, j));
                    }
                }
                return newimg;
            }
            else
            {
                return null;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Jpg files (*.jpg)|*.jpg";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            String FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileName = openFileDialog1.FileName;
                    textBox1.Text = FileName;
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        whiteImg = StreampTo32bppArgbBitmap(myStream);
                        myStream.Close();
                        int w = whiteImg.Width;
                        int h = whiteImg.Height;
                        textBox1.Text = FileName + " (" + w + "x" + h + ")";
                        ImageForm browser = new ImageForm();
                        browser.config(w, h, whiteImg);
                        browser.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("無法開啟" + FileName + ":\n" + ex.Message);
                    textBox1.Text = "";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var picker = new DateTimePicker();
            picker.Width = 160;
            picker.Height = 20;
            Form f = new Form();
            f.Width = 240;
            f.Height = 240;
            Button btn = new Button();
            btn.Text = "OK";
            btn.SetBounds(160, 0, 60, 20);
            f.Controls.Add(btn);
            f.Controls.Add(picker);
            btn.Click += (object s, EventArgs ee) => { f.DialogResult = DialogResult.OK; f.Close(); };
            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                String str = picker.Value.Year + "/" + picker.Value.Month + "/" + picker.Value.Day;
                textBox4.Text = str;
                startdate = str;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Jpg files (*.jpg)|*.jpg";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            String FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileName = openFileDialog1.FileName;
                    textBox1.Text = FileName;
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        studentImg = StreampTo32bppArgbBitmap(myStream);
                        myStream.Close();
                        int w = studentImg.Width;
                        int h = studentImg.Height;
                        textBox2.Text = FileName + " (" + w + "x" + h + ")";
                        ImageForm browser = new ImageForm();
                        browser.config(w, h, studentImg);
                        browser.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("無法開啟" + FileName + ":\n" + ex.Message);
                    textBox1.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Jpg files (*.jpg)|*.jpg";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            String FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileName = openFileDialog1.FileName;
                    textBox1.Text = FileName;
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        teacherImg = StreampTo32bppArgbBitmap(myStream);
                        myStream.Close();
                        int w = teacherImg.Width;
                        int h = teacherImg.Height;
                        textBox3.Text = FileName + " (" + w + "x" + h + ")";
                        ImageForm browser = new ImageForm();
                        browser.config(w, h, teacherImg);
                        browser.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("無法開啟" + FileName + ":\n" + ex.Message);
                    textBox1.Text = "";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var picker = new DateTimePicker();
            picker.Width = 160;
            picker.Height = 20;
            Form f = new Form();
            f.Width = 240;
            f.Height = 240;
            Button btn = new Button();
            btn.Text = "OK";
            btn.SetBounds(160, 0, 60, 20);
            f.Controls.Add(btn);
            f.Controls.Add(picker);
            btn.Click += (object s, EventArgs ee) => { f.DialogResult = DialogResult.OK; f.Close(); };
            var result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                String str = picker.Value.Year + "/" + picker.Value.Month + "/" + picker.Value.Day;
                textBox5.Text = str;
                enddate = str;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox6.Enabled = true;
            textBox6.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap result = TryToCreateResultBitmap();
            if (result == null)
            {
                MessageBox.Show("尚有欄位尚未輸入");
            }
            else
            {
                int w = result.Width;
                int h = result.Height;
                ImageForm browser = new ImageForm();
                browser.config(w, h, result);
                browser.Show();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            feenumber = textBox6.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Jpg files (*.jpg)|*.jpg";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    Bitmap result = TryToCreateResultBitmap();
                    if (result != null)
                    {
                        result.Save(myStream, ImageFormat.Jpeg);
                    }
                    else
                    {
                        MessageBox.Show("尚有欄位尚未輸入");
                    }
                    myStream.Close();
                }
            }
        }
    }
}

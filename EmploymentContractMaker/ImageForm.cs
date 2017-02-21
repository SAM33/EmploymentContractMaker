using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmploymentContractMaker
{



    public partial class ImageForm : Form
    {

        public ImageForm()
        {
            InitializeComponent();
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {

        }

        public void config(int w, int h, Bitmap image)
        {
            this.Width = w + 10;
            this.Height = h + 40;
            pictureBox1.Width = w;
            pictureBox1.Height = h;
            pictureBox1.Image = image;
            this.AutoScroll = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("x=" + e.X + " y=" + e.Y);
        }
    }
}



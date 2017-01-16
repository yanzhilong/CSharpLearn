using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class ImageListForm : Form
    {
        public ImageListForm()
        {
            InitializeComponent();
        }

        private void ImageListForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(imageList1.Images.Count > 0)
            {
                pictureBox1.Image = imageList1.Images[0];
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (imageList1.Images.Count > 1)
            {
                pictureBox1.Image = imageList1.Images[1];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Path = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            Path += @"\01.jpg";
            string Path2 = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            Path2 += @"\02.jpg";
            Image Mimg = Image.FromFile(Path, true);
            imageList1.Images.Add(Mimg);
            Image Mimg2 = Image.FromFile(Path2, true);
            imageList1.Images.Add(Mimg2);
            imageList1.ImageSize = new Size(200, 165);
            pictureBox1.Width = 200;
            pictureBox1.Height = 165;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //imageList1.Images.RemoveAt(0);
            pictureBox1.Image = null; 
            imageList1.Images.Clear();
        }
    }
}

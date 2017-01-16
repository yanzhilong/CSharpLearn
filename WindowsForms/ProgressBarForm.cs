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
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 5000;
            progressBar1.Step = 1;
            for(int i = 0; i < 5000; i++)
            {
                progressBar1.PerformStep();
                textBox1.Text = "进度值:" + progressBar1.Value.ToString();
            }
        }
    }
}

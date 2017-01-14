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
    public partial class StatusStripForm : Form
    {
        public StatusStripForm()
        {
            InitializeComponent();
        }

        private void StatusStripForm_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.toolStripProgressBar1.Minimum = 0;
            this.toolStripProgressBar1.Maximum = 5000;
            this.toolStripProgressBar1.Step = 2;
            for (int i = 0; i <= 4999; i++)
            {
                this.toolStripProgressBar1.PerformStep();
            }
        }
    }
}

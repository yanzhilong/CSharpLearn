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
    public partial class RadioButtonForm : Form
    {
        public RadioButtonForm()
        {
            InitializeComponent();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                label1.Text = "选中";
            }else
            {
                label1.Text = "未选中";
            }
        }

        private void RadioButtonForm_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label2.Text = "选中";
            }
            else
            {
                label2.Text = "未选中";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = "选项更改";
        }
    }
}

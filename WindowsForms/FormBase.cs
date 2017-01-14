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
    public partial class FormBase : Form
    {
        FormBaseSecond secondForm;
        public FormBase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            secondForm = new FormBaseSecond();
            secondForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            secondForm.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("点击了");
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否查看窗体！", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Console.WriteLine("点击是");
                //MessageBox.Show("谢谢");
            }
            else
            {
                Console.WriteLine("点击否");
            }
        }

        private void FormBase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("窗口点击了");
        }

        private void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否关闭窗体！", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                e.Cancel = false;
                //MessageBox.Show("谢谢");
            }
            else
            {
                e.Cancel = true;
                Console.WriteLine("点击否");
            }
        }
    }
}

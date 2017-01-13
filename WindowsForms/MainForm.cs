using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForm;

namespace WindowsFormsApplication1
{

    public partial class MainForm : Form

    {

        SecondForm secondForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            secondForm = new SecondForm();
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

        private void MainForm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("窗口点击了");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否查看窗体！","",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Console.WriteLine("点击是");
                //MessageBox.Show("谢谢");
            }else
            {
                Console.WriteLine("点击否");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
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

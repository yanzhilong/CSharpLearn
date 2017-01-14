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
    public partial class ButtonForm : Form
    {
        public ButtonForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("点击按钮了");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("触发接受按钮了");
        }

        private void ButtonForm_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button2;
            this.CancelButton = button3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("触发取消按钮了");
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.Text = "鼠标进入";
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Text = "鼠标不在";
        }
    }
}

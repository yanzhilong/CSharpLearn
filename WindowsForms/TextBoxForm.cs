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
    public partial class TextBoxForm : Form
    {
        public TextBoxForm()
        {
            InitializeComponent();
        }

        private void TextBoxForm_Load(object sender, EventArgs e)
        {
            textBox7.Multiline = true;
            textBox7.Height = 100;
            textBox7.Text = "这里是内容这里是内容!";
            textBox7.SelectionStart = 5;
            textBox7.SelectionLength = 5;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            label9.Text = textBox8.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只能数字
            //if ((e.KeyChar != 8 && !char.IsDigit(e.KeyChar)) && e.KeyChar != 13)
            //{
            //    MessageBox.Show("商品数量只能输入数字", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    e.Handled = true;//表示已经处理过了KeyPress事件
            //}
        }
    }
}

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
    public partial class RichTextBoxForm : Form
    {
        public RichTextBoxForm()
        {
            InitializeComponent();
        }

        private void RichTextBoxForm_Load(object sender, EventArgs e)
        {
            //设置字体
            richTextBox1.Multiline = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.SelectionFont = new Font("楷体", 12, FontStyle.Bold);
            richTextBox1.SelectionColor = System.Drawing.Color.Blue;

            //设置链接
            richTextBox2.Multiline = true;
            richTextBox2.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox2.Text = "欢迎登录http://www.cccxy.com编程体验网";

            //设置项目符号
            richTextBox3.Multiline = true;
            richTextBox3.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox3.SelectionBullet = true;

            //设置段落格式
            richTextBox4.Multiline = true;
            richTextBox4.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox4.SelectionIndent = 8;
            richTextBox4.SelectionRightIndent = 12;
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

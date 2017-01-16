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
    public partial class ErrorProviderForm : Form
    {
        public ErrorProviderForm()
        {
            InitializeComponent();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            DateTime dt = DateTime.Now;
            
            string strB = String.Format("{0:D}", dt);
            label2.Text = "验证中" + dt.ToLongTimeString();
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "不能为空");
            }
            else
            {
                try
                {
                    int x = Int32.Parse(textBox1.Text);
                    errorProvider1.SetError(textBox1, "");
                }
                catch
                {
                    errorProvider1.SetError(textBox1, "请输入一个数");
                }
            }
        }

        private void ErrorProviderForm_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

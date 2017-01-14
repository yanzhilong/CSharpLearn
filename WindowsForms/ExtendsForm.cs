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
    /// <summary>
    /// 通过继承选择器创建的
    /// </summary>
    public partial class ExtendsForm : Form
    {
        public ExtendsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExtendsFormChild1 extendsForm1 = new ExtendsFormChild1();
            extendsForm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExtendsFormChild2 extendsForm2 = new ExtendsFormChild2();
            extendsForm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExtendsFormChild3 extendsForm3 = new ExtendsFormChild3();
            extendsForm3.Show();

        }
    }
}

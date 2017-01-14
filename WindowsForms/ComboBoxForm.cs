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
    public partial class ComboBoxForm : Form
    {
        public ComboBoxForm()
        {
            InitializeComponent();
        }

        private void ComboBoxForm_Load(object sender, EventArgs e)
        {
            //只能选择
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("用一生下载你");
            comboBox1.Items.Add("芸烨湘枫");
            comboBox1.Items.Add("一生所爱");

            //可选择，可编辑
            comboBox2.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox2.Items.Add("用一生下载你");
            comboBox2.Items.Add("芸烨湘枫");
            comboBox2.Items.Add("一生所爱");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.SelectAll();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            label3.Text = comboBox2.Text;
        }
    }
}

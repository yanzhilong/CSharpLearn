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
    public partial class DateTimePickerForm : Form
    {
        public DateTimePickerForm()
        {
            InitializeComponent();
        }

        private void DateTimePickerForm_Load(object sender, EventArgs e)
        {
            //设置显示自定义的时间格式
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";
            label1.Text = dateTimePicker1.Text;

            textBox1.Text = dateTimePicker2.Text;
            textBox2.Text = dateTimePicker2.Value.Year.ToString();
            textBox3.Text = dateTimePicker2.Value.Month.ToString();
            textBox4.Text = dateTimePicker2.Value.Day.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

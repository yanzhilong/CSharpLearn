using System;
using System.Collections;
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
    public partial class ListViewForm : Form
    {
        public ListViewForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("项目不能为空");
            }
            else
            {
                listView1.Items.Add(textBox1.Text.Trim());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选择要移除的项");
            }else
            {
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);//删除选中的0项
                listView1.SelectedItems.Clear();//清除选中项数据
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.CheckBoxes = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView1.CheckBoxes = false;
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            if(listView1.Items.Count == 0)
            {
                MessageBox.Show("没有项");
            }else
            {
                listView1.Items[0].Selected = true;
            }
        }

        private void ListViewForm_Load(object sender, EventArgs e)
        {
            //设置默认选中
            listView1.Items.Add("aaa");
            listView1.Items.Add("aaa");
            listView1.Items.Add("aaa");
            listView1.Items.Add("aaa");
            listView1.Items[0].Selected = true;

        }
    }
}

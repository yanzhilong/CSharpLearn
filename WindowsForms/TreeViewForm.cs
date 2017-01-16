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
    public partial class TreeViewForm : Form
    {
        public TreeViewForm()
        {
            InitializeComponent();
        }

        private void TreeViewForm_Load(object sender, EventArgs e)
        {
            TreeNode tn1 = treeView1.Nodes.Add("名称");
            TreeNode tn2 = treeView1.Nodes.Add("性别");
            TreeNode tn3 = treeView1.Nodes.Add("年龄");
            TreeNode Ntn1 = new TreeNode("用一生下载你");
            TreeNode Ntn2 = new TreeNode("芸烨湘枫");
            TreeNode Ntn3 = new TreeNode("一生所爱");
            tn1.Nodes.Add(Ntn1);
            tn1.Nodes.Add(Ntn2);
            tn1.Nodes.Add(Ntn3);
            TreeNode Stn1 = new TreeNode("男");
            TreeNode Stn2 = new TreeNode("女");
            TreeNode Stn3 = new TreeNode("男");
            tn2.Nodes.Add(Stn1);
            tn2.Nodes.Add(Stn2);
            tn2.Nodes.Add(Stn3);
            TreeNode Atn1 = new TreeNode("28");
            TreeNode Atn2 = new TreeNode("27");
            TreeNode Atn3 = new TreeNode("26");
            tn3.Nodes.Add(Atn1);
            tn3.Nodes.Add(Atn2);
            tn3.Nodes.Add(Atn3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Text == "gfdonx")
            {
                MessageBox.Show("请选择要删除的子节点");
            }
            else
            {
                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            label1.Text = "当前选中的节点：" + e.Node.Text;
        }
    }
}

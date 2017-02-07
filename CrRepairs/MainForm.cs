﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrRepairs
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TreeNode tn1 = treeView1.Nodes.Add("报修模块");
            TreeNode Ntn1 = new TreeNode("位置管理");
            TreeNode Ntn2 = new TreeNode("设备点管理");
            TreeNode Ntn3 = new TreeNode("报修位置管理");
            TreeNode Ntn4 = new TreeNode("故障描述管理");
            TreeNode Ntn5 = new TreeNode("故障分类管理");
            TreeNode Ntn6 = new TreeNode("报修申请");
            TreeNode Ntn7 = new TreeNode("报修列表管理");

            tn1.Nodes.Add(Ntn1);
            tn1.Nodes.Add(Ntn2);
            tn1.Nodes.Add(Ntn3);
            tn1.Nodes.Add(Ntn4);
            tn1.Nodes.Add(Ntn5);
            tn1.Nodes.Add(Ntn6);
            tn1.Nodes.Add(Ntn7);

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Text == "位置管理")
            {
                var c = new LocationList();
                this.panel1.Controls.Add(c);
            }else
            {
                this.panel1.Controls.Clear();
            }


        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class TreeViewListViewForm : Form
    {
        public TreeViewListViewForm()
        {
            InitializeComponent();
        }

        private void TreeViewListViewForm_Load(object sender, EventArgs e)
        {
            TreeNode CountNode = new TreeNode("我的电脑");//初始化TreeView控件添加总结点
            TreeViewFile.Nodes.Add(CountNode);
            ListViewShow(CountNode);	//初始化ListView控件
            TreeViewShow(CountNode);
        }

        private void ListViewShow(TreeNode NodeDir)//初始化ListView控件，把TrreView控件中的数据添加进来
        {
            ListViewFile.Clear();

            try
            {
                //显示分区
                if (NodeDir.Parent == null)// 如果当前TreeView的父结点为空，就把我的电脑下的分区名称添加进来
                {
                    foreach (string DrvName in Directory.GetLogicalDrives())//获得硬盘分区名
                    {
                        ListViewItem ItemList = new ListViewItem(DrvName);
                        ListViewFile.Items.Add(ItemList);//添加进来
                    }
                }
                else//如果当前TreeView的父结点不为空，把点击的结点，做为一个目录文件的总结点
                {
                    foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))//编历当前分区或文件夹所有目录
                    {
                        ListViewItem ItemList = new ListViewItem(DirName);
                        ListViewFile.Items.Add(ItemList);
                    }
                    foreach (string FileName in Directory.GetFiles((string)NodeDir.Tag))//编历当前分区或文件夹所有目录的文件
                    {
                        ListViewItem ItemList = new ListViewItem(FileName);
                        ListViewFile.Items.Add(ItemList);
                    }//
                }
            }
            catch { }
        }//
        private void ListViewShow(string DirFileName)//获取当有文件夹内的文件和目录
        {
            ListViewFile.Clear();
            try
            {
                foreach (string DirName in Directory.GetDirectories(DirFileName))
                {
                    ListViewItem ItemList = new ListViewItem(DirName);
                    ListViewFile.Items.Add(ItemList);
                }
                foreach (string FileName in Directory.GetFiles(DirFileName))
                {
                    ListViewItem ItemList = new ListViewItem(FileName);
                    ListViewFile.Items.Add(ItemList);
                }
            }
            catch { }
        }

        private void TreeViewShow(TreeNode NodeDir)//初始化TreeView控件
        {
            try
            {
                if (NodeDir.Nodes.Count == 0)
                {
                    if (NodeDir.Parent == null)//如果结点为空显示硬盘分区
                    {
                        foreach (string DrvName in Directory.GetLogicalDrives())
                        {
                            TreeNode aNode = new TreeNode(DrvName);
                            aNode.Tag = DrvName;
                            NodeDir.Nodes.Add(aNode);
                        }
                    }// end 
                    else// 不为空，显示分区下文件夹
                    {
                        foreach (string DirName in Directory.GetDirectories((string)NodeDir.Tag))
                        {
                            TreeNode aNode = new TreeNode(DirName);
                            aNode.Tag = DirName;
                            NodeDir.Nodes.Add(aNode);
                        }
                    }
                }
            }
            catch { }
        }

        private void ListViewFile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TreeViewFile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ListViewShow(e.Node);
            TreeViewShow(e.Node);
        }

        private void ListViewFile_DoubleClick(object sender, EventArgs e)
        {
            foreach (int ListIndex in ListViewFile.SelectedIndices)
            {
                ListViewShow(ListViewFile.Items[ListIndex].Text);
            }
        }
    }
}

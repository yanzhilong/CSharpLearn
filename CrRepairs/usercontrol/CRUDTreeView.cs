using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using static CrRepairs.crudmoudle.LocationCRUD;
using CrRepairs.crudmoudle;

namespace CrRepairs.usercontrol
{
    public partial class CRUDTreeView : UserControl
    {
        private TreeViewEvent treeviewEnent;

        private TreeViewNode mTreeviewNode;//节点
        public TreeViewEvent TreeviewEnent
        {
            get
            {
                return treeviewEnent;
            }

            set
            {
                treeviewEnent = value;
            }
        }

        public CRUDTreeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化目录树
        /// </summary>
        /// <param name="hashtable"></param>
        public void initTreeView(Hashtable treeViewIdTable,Hashtable treeViewNodeTable)
        {
            treeView1.Nodes.Clear();//先清空
            addTreeNode(treeView1.Nodes, treeViewIdTable, treeViewNodeTable);
        }

        /// <summary>
        /// 获得当前的树
        /// </summary>
        /// <returns></returns>
        public TreeView getTreeView()
        {
            return treeView1;
        }


        /// <summary>
        /// 将指定地址树添加到TreeNodeCollection中
        /// </summary>
        /// <param name="treeNodeCollection"></param>
        /// <param name="locationTB"></param>
        private void addTreeNode(TreeNodeCollection treeNodeCollection, Hashtable treeViewIdTable, Hashtable treeViewNodeTable)
        {
            //遍历
            foreach (DictionaryEntry dict in treeViewIdTable)
            {
                string treeViewNodeKey = (string)dict.Key;
                TreeViewNode treeviewnode = (TreeViewNode)treeViewNodeTable[treeViewNodeKey];
                TreeNode treenode = treeNodeCollection.Add(treeviewnode.Name);
                treenode.Tag = treeviewnode;
                Hashtable tmpHashtable = (Hashtable)dict.Value;
                //递归将子树添加到TreeNodeCollection的子集合中
                addTreeNode(treenode.Nodes, tmpHashtable, treeViewNodeTable);
            }
        }


        public TreeViewNode getSelectTreeViewNode()
        {
            TreeNode treeNode = treeView1.SelectedNode;
            if(treeNode == null)
            {
                return null;
            }else
            {
                return (TreeViewNode)treeNode.Tag;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //List<string> treelist = new List<string>();
            //TreeNode treeNode = e.Node;
            ////do
            ////{
            ////    treelist.Add(treeNode.Name);
            ////} while ((treeNode = treeNode.Parent) != null);
            ////string[] array = treelist.ToArray();
            //////倒序，父级在前面
            ////Array.Reverse(array);
            ////return array;

            //if(TreeviewEnent != null)
            //{
            //    TreeviewEnent.TreeViewSelect((TreeViewNode)treeNode.Tag);
            //}
        }

        
    }
    /// <summary>
    /// 树窗口的事件
    /// </summary>
    public interface TreeViewEvent
    {
        void TreeViewSelect(TreeViewNode treeviewNode);
    }
}

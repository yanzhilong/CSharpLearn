using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrRepairs.util
{
    class TreeViewUtil
    {
        private static Hashtable NodesStatus = new Hashtable();//保存是否展开的节点状态
        private static String SelectNodeFullPath = String.Empty; //保存选中的节点
        #region 状态保持方法
        public static void GetTreeNodesStatus(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.IsExpanded)
                    NodesStatus[node.FullPath] = true;
                else
                    NodesStatus.Remove(node.FullPath);
                if (node.IsSelected)
                    SelectNodeFullPath = node.FullPath;
                GetTreeNodesStatus(node.Nodes);
            }
        }

        public static TreeNode SetTreeNodesStatus(TreeNodeCollection nodes)
        {
            TreeNode selectTreeNode = null;
            foreach (TreeNode node in nodes)
            {
                if (NodesStatus[node.FullPath] != null)
                    node.Expand();
                if (node.FullPath == SelectNodeFullPath)
                    selectTreeNode = node;
                SetTreeNodesStatus(node.Nodes);
            }
            return selectTreeNode;
        }
        #endregion
    }
}

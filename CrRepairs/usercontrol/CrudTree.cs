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
using CrRepairs.viewinterface;
using CrRepairs.crudmoudle;
using static CrRepairs.usercontrol.CRUDDataGridView;

namespace CrRepairs.usercontrol
{
    public partial class CrudTree : UserControl,ViewEventI
    {

        private const int ADD = 0;
        private const int UPDATE = 1;

        private int operater = 0;

        private TreeView treeview;

        private CrudTreeViewBase crudBase;
        private CRUDTreeView crudTreeView;
        public CrudTree(CrudTreeViewBase crudBase)
        {
            InitializeComponent();
            this.crudBase = crudBase;
            crudTreeView = new CRUDTreeView();
            loadData();
        }

        public void exit()
        {
            crudBase.refreshData();
            loadData();
        }

        public void loadData()
        {
            //保存树状态
            SaveTreeNodesStatus();
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(crudTreeView);
            crudTreeView.initTreeView(crudBase.getTreeViewData(), crudBase.getTreeViewNode());
            //保存树状态
            RecoverTreeNodesStatus();
            this.panel2.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            operater = ADD;
            this.panel1.Controls.Clear();
            var c = new CrudView(this);
            this.panel1.Controls.Add(c);
            c.addItems(this.crudBase.getAdds());
            this.panel2.Hide();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_Click(object sender, EventArgs e)
        {
            operater = UPDATE;
            TreeViewNode tvn = crudTreeView.getSelectTreeViewNode();
            if (tvn == null)
            {
                MessageBox.Show("当前没有选中");
                return;
            }
            this.panel1.Controls.Clear();
            var c = new CrudView(this);
            this.panel1.Controls.Add(c);
            List<CrudItem> updateCrudItems = this.crudBase.getUpdates();

            //这里需要判断哪些是可以修改的，这里先全部修改成当前Node的值
            for (int i = 0; i < updateCrudItems.Count; i++)
            {
                updateCrudItems[i].Value = tvn.Name;
            }

            c.addItems(updateCrudItems);
            this.panel2.Hide();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_Click(object sender, EventArgs e)
        {
            TreeViewNode tvn = crudTreeView.getSelectTreeViewNode();
            if (tvn == null)
            {
                MessageBox.Show("当前没有选中");
                return;
            }
            
            if (MessageBox.Show("是否删除当前项！", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                crudBase.Delete(tvn);
                this.exit();
            }
        }

        /// <summary>
        /// 子页面确认提交的事件
        /// </summary>
        /// <param name="cruditems"></param>
        public void submit(List<CrudItem> cruditems)
        {
            if (operater == ADD)
            {
                crudBase.Add(cruditems, crudTreeView.getSelectTreeViewNode());
            }
            else
            {
                crudBase.Update(cruditems, crudTreeView.getSelectTreeViewNode());
            }
            this.exit();
        }

        private Hashtable NodesStatus = new Hashtable();//保存是否展开的节点状态
        private String SelectNodeFullPath = String.Empty; //保存选中的节点
        #region 状态保持方法
        public void SaveTreeNodesStatus()
        {
            NodesStatus.Clear();
            TreeNodeCollection nodes = crudTreeView.getTreeView().Nodes;
            SaveTreeNodesStatus(nodes);
        }

        /// <summary>
        /// 保存树状态
        /// </summary>
        /// <param name="nodes"></param>
        private void SaveTreeNodesStatus(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.IsExpanded)
                    NodesStatus[node.FullPath] = true;
                else
                    NodesStatus.Remove(node.FullPath);
                if (node.IsSelected)
                    SelectNodeFullPath = node.FullPath;
                SaveTreeNodesStatus(node.Nodes);
            }
        }

        /// <summary>
        /// 状态恢复方法
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public void RecoverTreeNodesStatus()
        {
            TreeNodeCollection nodes = crudTreeView.getTreeView().Nodes;
            RecoverTreeNodesStatus(nodes);
        }

        /// <summary>
        /// 状态恢复方法
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private void RecoverTreeNodesStatus(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (NodesStatus[node.FullPath] != null)
                    node.Expand();
                if (node.FullPath == SelectNodeFullPath)
                    node.Checked = true;
                RecoverTreeNodesStatus(node.Nodes);
            }
        }
        #endregion
    }

}

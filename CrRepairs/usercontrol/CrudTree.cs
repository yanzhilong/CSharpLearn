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

        private CrudTreeViewBase crudBase;
        private CRUDTreeView crudTreeView;
        public CrudTree(CrudTreeViewBase crudBase)
        {
            InitializeComponent();
            this.crudBase = crudBase;
            loadData();
        }

        public void exit()
        {
            loadData();
        }

        private void loadData()
        {
            this.panel1.Controls.Clear();
            
            crudTreeView = new CRUDTreeView();
            this.panel1.Controls.Add(crudTreeView);
            crudTreeView.initTreeView(crudBase.getTreeViewData(), crudBase.getTreeViewNode());
                        
            this.panel2.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var c = new CrudView(this);
            this.panel1.Controls.Add(c);
            c.addItems(this.crudBase.getAdds());
            this.panel2.Hide();
        }


        private void update_Click(object sender, EventArgs e)
        {
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
            c.addItems(this.crudBase.getUpdates());
            this.panel2.Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //Hashtable hashtable = cruddatagridview.getCurrentRowData();
            //if (hashtable.Keys.Count == 0)
            //{
            //    MessageBox.Show("当前没有选中");
            //}

            //if (MessageBox.Show("是否删除当前项！", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //{
            //    crudBase.CrudEvent.delete(hashtable);
            //    this.exit();
            //}
            //else
            //{

            //}

            
        }

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
    }
    
}

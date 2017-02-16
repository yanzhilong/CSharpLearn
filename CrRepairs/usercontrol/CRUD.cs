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
    public partial class CRUD : UserControl,ViewEventI, RowSelect
    {
        private CRUDBase crudBase;
        private CRUDDataGridView cruddatagridview;
        private CRUDTreeView crudTreeView;
        public CRUD(CRUDBase crudBase)
        {
            InitializeComponent();
            this.crudBase = crudBase;
            loadData(crudBase);
        }

        public void exit()
        {
            loadData(crudBase);
        }

        private void loadData(CRUDBase crudBase)
        {
            this.panel1.Controls.Clear();
            if (crudBase.DisplayType == CRUDBase.GRIDVIEW)
            {
                cruddatagridview = new CRUDDataGridView();
                this.panel1.Controls.Add(cruddatagridview);
                cruddatagridview.loadData(crudBase.CrudEvent.loadGridViewData(), crudBase.Titles);
                cruddatagridview.Rowsele = this;
            }
            else
            {
                crudTreeView = new CRUDTreeView();
                this.panel1.Controls.Add(crudTreeView);
                crudTreeView.initTreeView(crudBase.HashtableTree, crudBase.TreeViewNodeTable);
            }
            this.panel2.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var c = new CrudView(crudBase.CrudEvent,this, CrudView.ADD);
            this.panel1.Controls.Add(c);
            c.addItems(this.crudBase.Adds);
            this.panel2.Hide();
        }

        public void rowSelect(Hashtable select)
        {
            if(select.Keys.Count > 0)
            {
                update.Enabled = true;
                delete.Enabled = true;
            }else
            {
                update.Enabled = false;
                delete.Enabled = false;
            }
            
        }

        private void update_Click(object sender, EventArgs e)
        {

            Hashtable hashtable = cruddatagridview.getCurrentRowData();
            if(hashtable.Keys.Count == 0)
            {
                MessageBox.Show("当前没有选中");
            }

            this.panel1.Controls.Clear();
            var c = new CrudView(crudBase.CrudEvent, this,CrudView.UPDATE);
            this.panel1.Controls.Add(c);
            List<CrudItem> updateCrudItems = this.crudBase.Updates;
            for(int i = 0; i < updateCrudItems.Count; i++)
            {
                updateCrudItems[i].Value = (string)hashtable[(string)(updateCrudItems[i].Valuekey)];
            }
            c.addItems(this.crudBase.Updates);
            this.panel2.Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Hashtable hashtable = cruddatagridview.getCurrentRowData();
            if (hashtable.Keys.Count == 0)
            {
                MessageBox.Show("当前没有选中");
            }

            if (MessageBox.Show("是否删除当前项！", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                crudBase.CrudEvent.delete(hashtable);
                this.exit();
            }
            else
            {

            }

            
        }
    }
    
}

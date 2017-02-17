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
    public partial class CrudTable : UserControl,ViewEventI
    {
        private const int ADD = 0;
        private const int UPDATE = 1;

        private int operater = 0;

        private CrudGridViewBase crudBase;
        private CRUDDataGridView cruddatagridview;
        public CrudTable(CrudGridViewBase crudBase)
        {
            this.crudBase = crudBase;
            InitializeComponent();
            loadData();
        }

        public void exit()
        {
            loadData();
        }

        private void loadData()
        {
            this.panel1.Controls.Clear();
            cruddatagridview = new CRUDDataGridView();
            this.panel1.Controls.Add(cruddatagridview);
            cruddatagridview.loadData(crudBase.getGridViewData());
           
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


        private void update_Click(object sender, EventArgs e)
        {
            operater = UPDATE;
                Hashtable hashtable = cruddatagridview.getCurrentRowData();
                if (hashtable.Keys.Count == 0)
                {
                    MessageBox.Show("当前没有选中");
                }

                this.panel1.Controls.Clear();
                var c = new CrudView(this);
                this.panel1.Controls.Add(c);
                List<CrudItem> updateCrudItems = this.crudBase.getUpdates();
                for (int i = 0; i < updateCrudItems.Count; i++)
                {
                    updateCrudItems[i].Value = (string)hashtable[(string)(updateCrudItems[i].Valuekey)];
                }
                c.addItems(updateCrudItems);
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
                crudBase.Delete(hashtable);
                this.exit();
            }
            else
            {

            }

            
        }

        public void submit(List<CrudItem> cruditems)
        {
           if(operater == ADD)
            {
                crudBase.Add(cruditems);
            }
            else
            {
                crudBase.Update(cruditems);
            }
            this.exit();
        }
    }
    
}

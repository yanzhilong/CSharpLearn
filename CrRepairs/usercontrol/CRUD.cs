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

namespace CrRepairs.usercontrol
{
    public partial class CRUD : UserControl,ViewExitI
    {
        private CRUDProperties properties;
        private CRUDDataGridView cruddatagridview;
        private string sql;
        public CRUD()
        {
            InitializeComponent();
        }

        public void exit()
        {
            loadData(sql,properties);
        }

        public void loadData(string sql, CRUDProperties properties)
        {
            this.sql = sql;
            this.properties = properties;
            this.panel1.Controls.Clear();
            cruddatagridview = new CRUDDataGridView();
            this.panel1.Controls.Add(cruddatagridview);
            cruddatagridview.loadData(sql,this.properties.Titles);
            this.panel2.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            var c = new CRUDItems();
            this.panel1.Controls.Add(c);

            c.addItems(this.properties.Adds,this);
            
            this.panel2.Hide();
        }
    }

    public class CRUDProperties
    {
        private Hashtable titles;//数据的列名和显示
        private Hashtable updates;//要更新数据的时候允许更改的字段列表
        private Hashtable adds;//要添加数据的时候允许增加的数据列表
        private CRUDEvent crudEvent;//按钮事件

        public Hashtable Titles
        {
            get
            {
                return titles;
            }

            set
            {
                titles = value;
            }
        }

        public Hashtable Updates
        {
            get
            {
                return updates;
            }

            set
            {
                updates = value;
            }
        }

        public Hashtable Adds
        {
            get
            {
                return adds;
            }

            set
            {
                adds = value;
            }
        }

        public CRUDEvent CrudEvent
        {
            get
            {
                return crudEvent;
            }

            set
            {
                crudEvent = value;
            }
        }
    }

    public interface CRUDEvent
    {
        void add(string[][] values);//添加数据
        void update(string[][] source, string[][] updates);//修改数据
        void delete(string[][] sourde);//删除
    }
    
}

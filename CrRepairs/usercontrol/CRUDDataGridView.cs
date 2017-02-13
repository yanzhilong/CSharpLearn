using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyz.ibean.model;
using MySql.Data.MySqlClient;
using System.Collections;

namespace CrRepairs.usercontrol
{
    public partial class CRUDDataGridView : UserControl
    {
        private Hashtable titles;
        private MySqlModule mySqlModule;

        public CRUDDataGridView()
        {
            InitializeComponent();
            mySqlModule = new MySqlModule();
        }

        private DataTable getDataTable(string sql)
        {

            return mySqlModule.queryDataTable(sql);
        }



        public void loadData(string sql,Hashtable titles)
        {
            this.titles = titles;
            DataTable datatable = getDataTable(sql);

            foreach (DictionaryEntry dict in titles)
            {
                if(dict.Value != null)
                {
                    datatable.Columns[(string)dict.Key].ColumnName = (string)dict.Value;
                }
                
            }
           

            dataGridView1.DataSource = datatable;
            dataGridView1.ReadOnly = true;
        }

    }

}
